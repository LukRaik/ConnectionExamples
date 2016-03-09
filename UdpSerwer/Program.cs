using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace UdpSerwer
{
    class Program
    {
        static void Main(string[] args)
        {
            int port = 1243;
            IPEndPoint zdalnyIP = new IPEndPoint(IPAddress.Any, 0);
            try
            {
                UdpClient serwer = new UdpClient(port);
                Byte[] odczyt = serwer.Receive(ref zdalnyIP);
                string dane = Encoding.ASCII.GetString(odczyt);
                Console.WriteLine("Wiadomosc {0}", dane);
                serwer.Close();
                Console.Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Blad:{0}", ex.ToString());
            }
        }
    }
}
