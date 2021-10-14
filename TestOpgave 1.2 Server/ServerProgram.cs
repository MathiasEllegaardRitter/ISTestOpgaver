using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TestOpgave_1._2_Server
{
    class ServerProgram
    {
        public static void Main(String[] args)
        {
            var server = new Server();

            server.Start();
            Console.WriteLine("Server running");
            Console.ReadLine();
        }
    }
}
