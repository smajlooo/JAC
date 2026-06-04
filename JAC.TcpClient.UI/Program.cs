using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JAC.TcpClient.Lib;

namespace JAC.TcpClient.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type any key to connect...");
            Console.ReadKey();
            Console.WriteLine();

            Client client = new Client();
            client.Connect();
        }
    }
}
