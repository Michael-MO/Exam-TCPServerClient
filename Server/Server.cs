using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class Server
    {
        private int PORT;

        public Server(int PORT)
        {
            this.PORT = PORT;
        }

        public void Start()
        {
            TcpListener serverListener = new TcpListener(IPAddress.Loopback, PORT);
            serverListener.Start();

            while (true)
            {
                TcpClient socket = serverListener.AcceptTcpClient();

                Task.Run(() =>
                {
                    TcpClient tempSocket = socket;
                    DoClient(tempSocket);
                });
            }
        }

        public void DoClient(TcpClient socket)
        {
            using (StreamReader sr = new StreamReader(socket.GetStream()))
            using (StreamWriter sw = new StreamWriter(socket.GetStream()))
            {
                String str = sr.ReadLine();

                Console.WriteLine($"Input: {str}");

                sw.WriteLine(str);
                sw.Flush();
            }
        }
    }
}
