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
        static TcpClient klient_tcp;
        static TcpListener serwer_tcp;
        static void Main(string[] args)
        {
            

            IPAddress adres;
            adres = IPAddress.Parse("127.0.0.1");
            int port = 1243;

            

            try
            {
                serwer_tcp = new TcpListener(adres, port);
                serwer_tcp.Start();
                serwer_tcp.BeginAcceptTcpClient(new AsyncCallback(MetodaAkceptujaca), serwer_tcp);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.WriteLine("Czekam");
            Console.Read();

        }
        static void MetodaAkceptujaca(IAsyncResult asyncResult)
        {
            TcpListener listener = (TcpListener)asyncResult.AsyncState;
            klient_tcp = listener.EndAcceptTcpClient(asyncResult);
            Console.WriteLine("Udane {0}",klient_tcp.ToString());
            klient_tcp.Close();
            serwer_tcp.Stop();
        }
    }
}