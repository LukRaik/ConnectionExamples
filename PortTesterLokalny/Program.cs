using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
namespace PortTesterLokalny
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] Porty = { 132, 232, 434, 626, 800 };

            Console.WriteLine("Sprawdzamy!");

            for (int i = 0; i < 8000;i++ )
            {
                try
                {
                    TcpListener listener = new TcpListener(i);
                    listener.Start();
                    listener.Stop();
                    Console.WriteLine("{0}:Otwarty", i);
                }
                catch
                {
                    Console.WriteLine("{0}:Zamkniety", i);
                    Console.ReadLine();
                }
            }

            Console.Read();
        }
    }
}
