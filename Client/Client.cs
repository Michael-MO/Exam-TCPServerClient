using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    public class Client
    {
        private int PORT = 7;

        public Client(int PORT)
        {
            this.PORT = PORT;
        }

        public void Start()
        {
            using (TcpClient socket = new TcpClient(IPAddress.Loopback.ToString(), PORT))
            {
                NetworkStream ns = socket.GetStream();

                using (StreamReader sr = new StreamReader(ns))
                using (StreamWriter sw = new StreamWriter(ns))
                {
                    string customText = Console.ReadLine();
                    sw.WriteLine(customText);
                    sw.Flush();

                    string line = sr.ReadLine();
                    //Console.WriteLine(line);
                }
            }
        }
    }
}
