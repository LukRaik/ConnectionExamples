using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;

namespace KonektTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string host = "127.0.0.1";
            int port = 1243;
            Console.Read();
            try
            {
                TcpClient klient_tcp = new TcpClient(host, port);
                Console.WriteLine("Polaczenie nawiazane");
                byte[] buffor= Encoding.ASCII.GetBytes("##HI23##");
                NetworkStream stream = klient_tcp.GetStream();
                BinaryWriter pisz = new BinaryWriter(stream);
                BinaryReader czytaj = new BinaryReader(stream);
                pisz.Write("##HI23##");
                while (czytaj.ReadString() != "##AUTH##")
                {

                }
                Console.WriteLine("POJSZLO");
                Console.ReadLine();
                klient_tcp.Close();
                
                Console.Read();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.Read();
            }
            
            
            
            
            

        }
    }
}
