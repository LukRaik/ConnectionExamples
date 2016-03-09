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
    public class TcpUser
    {
        public string Name;
        TcpClient klient;
        public NetworkStream strumien_sieci;
        public BinaryReader klient_czytanie;
        public BinaryWriter klient_pisanie;
        public BackgroundWorker worker;
        List<string> msg_to_send;
        EventHandler Text_Log;
        bool connected;
        public TcpUser(TcpClient klient,ref EventHandler deleg,ref List<string> Msg_to_send)
        {
            this.klient = klient;
            strumien_sieci = klient.GetStream();
            klient_czytanie = new BinaryReader(strumien_sieci);
            klient_pisanie = new BinaryWriter(strumien_sieci);
            worker = new BackgroundWorker();
            msg_to_send = Msg_to_send;
            Text_Log = deleg;
            worker.DoWork += Odbieranie_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
        }
        private void Odbieranie_DoWork(object sender, DoWorkEventArgs e)
        {
            if (connected == true)
            {
                string buffor = this.klient_czytanie.ReadString();
                if (buffor.Contains("##MSG##") == true)
                {
                    string Wiadomosc = this.Name + ":" + buffor.Substring(7);
                    msg_to_send.Add(Wiadomosc);
                    Text_Log(Wiadomosc, null);
                }
                else if (buffor.Contains("##EXIT##") == true)
                {
                    string Wiadomosc = this.Name + " wyszedl";
                    this.Disc();
                    msg_to_send.Add(Wiadomosc);
                    Text_Log(Wiadomosc, null);
                }
            }
        }
        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            worker.RunWorkerAsync();
        }
        public bool Auth()
        {
            klient_pisanie.Write("##S:AUTH##");
            string buffor = klient_czytanie.ReadString();
            if(buffor.Contains("##K:AUTH##")==true)
            {
                string buffor2 = buffor.Substring(10);
                Name = buffor2;
                connected = true;
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Disc()
        {
            connected = false;
            Form1.rozlaczeni.Add(this);
        }
        public void Wyslij(string tekst)
        {
            klient_pisanie.Write("##MSG##SERVER:" + tekst);
            Text_Log("Server to " + Name + ":" + tekst,null);

        }
        public override string ToString()
        {
            string buffor = Name + " " + klient.Client.RemoteEndPoint.ToString();
            return buffor;
        }
    }
}
