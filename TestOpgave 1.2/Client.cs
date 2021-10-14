using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace TestOpgave_1._2
{
    class Client
    {
        // Port
        const int port = 9000;

        //besked
        public class MyMessage
        {

            public string message;
            public int packet;
        }

        //start method
        public void Start()
        {
            // Get ipadress on local pc
            var serverIp = IPAddress.Loopback.ToString();

            // Adds value to message
            var myMessage = new MyMessage
            {
                message = "Hello this is packet ",
                packet = 1
            };

            // instance the tcp client and stream.
            TcpClient client = new TcpClient(serverIp, port);
            NetworkStream networkStream = client.GetStream();

            //Keep writing to the server could implete a function to stop this.
            while (true)
            {
                byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(myMessage.message + myMessage.packet);

                // sender data til stream. 
                networkStream.Write(bytesToSend, 0, bytesToSend.Length);
                Console.WriteLine("message sent");

                myMessage.packet++;
                Thread.Sleep(5000);
            }
        }





    }
}
