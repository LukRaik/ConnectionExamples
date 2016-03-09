using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace TcpSerwer
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener serwer_tcp;
            TcpClient klient_tcp;

            IPAddress adres;
            adres = IPAddress.Parse("127.0.0.1");
            int port = 1243;

            try
            {
                serwer_tcp = new TcpListener(adres, port);
                serwer_tcp.Start();
                klient_tcp = serwer_tcp.AcceptTcpClient();
                Console.WriteLine("Nawiazano polaczenie");
                IPEndPoint IP = (IPEndPoint)klient_tcp.Client.RemoteEndPoint;
                Console.WriteLine("Polaczono na {0}", IP.ToString());
                klient_tcp.Close();
                serwer_tcp.Stop();
                Console.Read();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            
        }
    }
}
