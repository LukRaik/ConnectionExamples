using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace Udp
{
    class Program
    {
        static void Main(string[] args)
        {
            string ip = "127.0.0.1";
            int port = 1243;
            try
            {
                UdpClient klient_udp = new UdpClient(ip, port);
                Byte[] dane = Encoding.ASCII.GetBytes("Wiadomosc1");
                klient_udp.Send(dane, dane.Length);
                Console.WriteLine("Wyslana wiadomosc !");
                klient_udp.Close();
                Console.Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Blad:{0}", ex.ToString());
            }
        }
    }
}
