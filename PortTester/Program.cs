using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace PortTester
{
    class Program
    {
        //W folderze powinien sie znajdowac plik porty.txt, linijka na port
        static void Main(string[] args)
        {
            string ip = "127.0.0.1";
            List<int> Porty = new List<int>();
            Console.WriteLine("Wczytywanie pliku porty.txt");
            if (File.Exists("porty.txt") == false)
            {
                Console.WriteLine("Plik nie istnieje");
                Console.WriteLine("Przykladowy schemat:");
                Console.WriteLine("131\n12312\n4242");
            }
            else
            {

                StreamReader Czytnik = new StreamReader("porty.txt");
                string buffor = "";
                while (buffor != null)
                {
                    buffor = Czytnik.ReadLine();
                    if (buffor != "" && buffor != null)
                    {
                        Porty.Add(Convert.ToInt32(buffor));
                    }
                }

                foreach (int obj in Porty)
                {
                    try
                    {
                        TcpClient klient = new TcpClient(ip, obj);
                        Console.WriteLine("{0}:Otwarty", obj);
                    }
                    catch
                    {
                        Console.WriteLine("{0}:Zamkniety",obj);
                    }
                }






            }
            Console.WriteLine("Koniec");
            Console.Read();
        }
    }
}
