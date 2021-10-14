using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TestOpgave_1._2_Server
{
    class Server
    {
        // Port
        const int port = 9000;
        // Get computers local ip adress.
        IPAddress serverIp = IPAddress.Loopback;

        public void Start()
        {
            TcpListener tcpListener = new TcpListener(serverIp, port);
            tcpListener.Start();

            // Listen to client, and get stream
            TcpClient client = tcpListener.AcceptTcpClient();
            NetworkStream networkStream = client.GetStream();



            byte[] buffer = new byte[client.ReceiveBufferSize];


            while (true)
            {
                // Reads data
                int bytesRead = networkStream.Read(buffer, 0, client.ReceiveBufferSize);
                // Converts data to string
                string dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                Console.WriteLine(dataReceived);
            }

        }



    }
}
