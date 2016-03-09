using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace MIrcClient
{
    public partial class Form1 : Form
    {
        TcpClient polaczenie;
        NetworkStream ns;
        BinaryReader klient_czytaj;
        BinaryWriter klient_pisz;
        EventHandler EventSetText;
        public Form1()
        {
            InitializeComponent();
            EventSetText += SetTxt;
        }

        private void bt_connect_Click(object sender, EventArgs e)
        {
            try
            {
                polaczenie = new TcpClient(tx_IP.Text, (int)tx_port.Value);
                ns = polaczenie.GetStream();
                klient_czytaj = new BinaryReader(ns);
                klient_pisz = new BinaryWriter(ns);
                klient_pisz.Write("##K:AUTH##" + tx_nick.Text);
                SetTxt("Polaczono", null);
                worker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            string buffor = klient_czytaj.ReadString();
            if (buffor.Contains("##MSG##")&&buffor.Contains("##MSG##"+tx_nick.Text)==false)
            {
                buffor ="\n"+"["+DateTime.Now.ToString()+"]\n"+ buffor.Substring(7);
                SetTxt(buffor, null);

            }
        }
        void SetTxt(object obj, EventArgs e)
        {
            if (tx_log.InvokeRequired == true)
            {
                tx_log.Invoke(EventSetText, new Object[] { obj, e });
            }
            else
            {
                tx_log.Text += (string)obj;
                tx_log.SelectionStart = tx_log.Text.Length;
                tx_log.ScrollToCaret();
            }
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            worker.RunWorkerAsync();
        }

        private void bt_send_Click(object sender, EventArgs e)
        {
            klient_pisz.Write("##MSG##" + tx_send.Text);
            SetTxt("\n["+DateTime.Now.ToString()+"]"+"\nJa:" + tx_send.Text,null);
            tx_send.Text = "";
        }

        private void tx_nick_Click(object sender, EventArgs e)
        {
            tx_nick.Text = "";
        }

        private void tx_send_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                bt_send_Click(sender, null);
            }
        }

        private void bt_disconnect_Click(object sender, EventArgs e)
        {
            klient_pisz.Write("##EXIT##");
            SetTxt("Rozlaczone",null);
            klient_pisz.Close();
            klient_czytaj.Close();
            ns.Close();
            polaczenie.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (polaczenie.Connected)
            {
                bt_disconnect_Click(sender, e);
            }
        }
    }
}
