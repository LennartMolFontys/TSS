using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace SocketServer
{
    class Program
    {
        static void Main(string[] args)
        {

            TcpListener servSock = null;
            TcpClient clientSock = null;
            const int port = 8888;
            byte[] bytes = new byte[1024];
            string incomingMessage = "";
            try
            {
                servSock = new TcpListener(IPAddress.Parse("145.93.62.116"), port);
                servSock.Start();
                clientSock = new TcpClient();
                Console.WriteLine("Waiting for the client to connect");
                clientSock = servSock.AcceptTcpClient();
                Console.WriteLine("Connected !");
                NetworkStream stream = clientSock.GetStream();

                while(!incomingMessage.Contains("quit"))
                {
                    incomingMessage = "";
                    string input = Console.ReadLine();
                    byte[] sendMessage = Encoding.ASCII.GetBytes(input);
                    stream.Write(sendMessage, 0, sendMessage.Length);


                        int num = stream.Read(bytes, 0, bytes.Length);
                        incomingMessage = Encoding.ASCII.GetString(bytes, 0, num);
                        Console.WriteLine(incomingMessage);


                        byte[] data = Encoding.ASCII.GetBytes(incomingMessage.ToUpper());
                        stream.Write(data, 0, data.Length);
                    
                }
                
                clientSock.Close();
                servSock.Stop();
            }
            catch(Exception e)
            {
                Console.WriteLine("SocketException: {0}", e.ToString());
            }

        }
    }
}
