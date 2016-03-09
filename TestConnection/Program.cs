using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace TestConnection
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient klient = new TcpClient("127.0.0.1", 1243);
            NetworkStream ns = klient.GetStream();
            BinaryWriter writer = new BinaryWriter(ns);
            BinaryReader reader = new BinaryReader(ns);
            while (reader.ReadString() != "##S:AUTH##")
            {

            }
            writer.Write("##K:AUTH##Raik");
            Console.WriteLine("Polaczono");
            Console.WriteLine("Co chcesz zrobic 1,2");
            while (klient.Connected == true)
            {
                string buffor = Console.ReadLine();
                switch (Convert.ToInt32(buffor))
                {
                    case 1:
                        writer.Write("##MSG##KURWA MAC CZY TO DZIALA ?");
                        break;
                    case 2:
                        writer.Write("##EXIT##");
                        break;
                }
            }
            Console.ReadLine();
        


        }
    }
}
