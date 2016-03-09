using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace MiniIRCServe
{
    public partial class Form1 : Form
    {
        TcpListener serwer;
        List<TcpUser> lista_uzytkownikow;
        static public List<TcpUser> rozlaczeni=new List<TcpUser>();
        EventHandler TextLog;
        EventHandler AddToList;
        EventHandler RemoveFromList;
        List<string> msg_to_send;
        public Form1()
        {
            InitializeComponent();
            lista_uzytkownikow = new List<TcpUser>();
            msg_to_send = new List<string>();
            TextLog += AddLog;
            AddToList += DodajDoListy;
            RemoveFromList += UsunZListy;
        }

        private void bt_start_Click(object sender, EventArgs e)
        {
            serwer = new TcpListener((int)bt_port.Value);
            serwer.Start();
            Worker_Uzytkownicy.RunWorkerAsync();
            Czyszczenie.RunWorkerAsync();
            Odbieranie.RunWorkerAsync();
            Rozsylanie.RunWorkerAsync();
            AddLog("Start",null);
        }
        void AddLog(object log, EventArgs e)
        {
            string buffor = "\n[" + DateTime.Now.ToString() + "]\n" + (string)log;
            if (txt_log.InvokeRequired == true)
            {
                txt_log.Invoke(TextLog, new object[] { log, e });
            }
            else
            {
                txt_log.Text += buffor;
            }
        }
        private void Worker_Uzytkownicy_DoWork(object sender, DoWorkEventArgs e)
        {
            TcpClient klient = serwer.AcceptTcpClient();
            TcpUser uzytkownik = new TcpUser(klient,ref TextLog,ref msg_to_send);
            if (uzytkownik.Auth() == true)
            {
                DodajDoListy(uzytkownik,null);
                lista_uzytkownikow.Add(uzytkownik);
                AddLog("Polaczono "+uzytkownik.Name+":" + klient.Client.RemoteEndPoint.ToString(), null);
                msg_to_send.Add("Do pokoju przybyl " + uzytkownik.Name);
                uzytkownik.worker.RunWorkerAsync();
            }
        }

        private void bt_stop_Click(object sender, EventArgs e)
        {
            Worker_Uzytkownicy.CancelAsync();
            Odbieranie.CancelAsync();
            Czyszczenie.CancelAsync();
            Worker_Uzytkownicy.CancelAsync();
            serwer.Stop();
        }

        private void Worker_Uzytkownicy_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Worker_Uzytkownicy.RunWorkerAsync();
        }

        void DodajDoListy(object obj, EventArgs e)
        {
            if (list_users.InvokeRequired == true)
            {
                list_users.Invoke(AddToList, new object[] { obj, e });
            }
            else
            {
                list_users.Items.Add((TcpUser)obj);
            }
        }
        void UsunZListy(object obj, EventArgs e)
        {
            if (list_users.InvokeRequired == true)
            {
                list_users.Invoke(RemoveFromList, new object[] { obj, e });
            }
            else
            {
                list_users.Items.Remove((TcpUser)obj);
            }
        }

        private void Czyszczenie_DoWork(object sender, DoWorkEventArgs e)
        {
            if (rozlaczeni.Count > 0)
            {
                foreach (TcpUser obj in rozlaczeni)
                {

                    lista_uzytkownikow.Remove(obj);
                    UsunZListy(obj,null);
                }
                rozlaczeni = new List<TcpUser>();
            }
            System.Threading.Thread.Sleep(100);
        }

        private void Czyszczenie_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Czyszczenie.RunWorkerAsync();
        }

        private void Odbieranie_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Odbieranie.RunWorkerAsync();
        }

        private void Rozsylanie_DoWork(object sender, DoWorkEventArgs e)
        {
            if (msg_to_send.Count > 0)
            {
                foreach(TcpUser obj in lista_uzytkownikow)
                {
                    obj.klient_pisanie.Write("##MSG##"+msg_to_send[0]);
                }
                msg_to_send.RemoveAt(0);
            }
            System.Threading.Thread.Sleep(100);
        }

        private void Rozsylanie_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Rozsylanie.RunWorkerAsync();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (list_users.Items.Count > 0 && list_users.SelectedIndex>=0)
            {
                TcpUser user = (TcpUser)list_users.Items[list_users.SelectedIndex];
                user.Wyslij(txt_send.Text);
            }
        }
    }
}
