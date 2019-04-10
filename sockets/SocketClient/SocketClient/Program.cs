using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace SocketClient
{
    class Program
    {
        public static SerialMessenger serial;
        static void Main(string[] args)
        {
            const int port = 8888;
            String sendLine = "";
            byte[] bytes = new byte[1024];
            string incomingMessage = "";
            string trainData = "";
          
            try
            {
                TcpClient clientSock = new TcpClient();
                Console.WriteLine("give ipAdress to connect to");
                IPAddress.TryParse(Console.ReadLine(), out IPAddress serverIP);

                Console.WriteLine("Connecting to Server ...");
                clientSock.Connect(serverIP , port);
                Console.WriteLine("Connected!");
                NetworkStream stream = clientSock.GetStream();

                serial = new SerialMessenger("COM4", 9600, '#', '%');
                serial.Connect();

                while (sendLine != "quit")
                {
                    if (stream.DataAvailable == true)
                    {
                        int num = stream.Read(bytes, 0, bytes.Length);
                        incomingMessage = Encoding.ASCII.GetString(bytes, 0, num);
                        Console.WriteLine(incomingMessage);
                    }

                    /*trainData = ReadMessage();   
                    string message = serial.ReadMessages();
                    if(message != null)
                    {
                        trainData = message;
                    }
                    Console.WriteLine(trainData);*/

                    if (incomingMessage.Contains("Initialize"))
                    {
                        serial.Send("GetUnitInfo");
                        trainData = ReadMessage();
                        byte[] data = Encoding.ASCII.GetBytes(trainData);
                        stream.Write(data, 0, data.Length);
                        
                    }
                    else if(incomingMessage.Contains("SeatInfo"))
                    {
                        serial.Send("GetUnitInfo");
                        trainData = ReadMessage();
                        byte[] data = Encoding.ASCII.GetBytes(trainData);
                        stream.Write(data, 0, data.Length);
                    }
                    incomingMessage = "";                   
                }
                serial.Disconnect();
                clientSock.Close();
             }
             catch (Exception e)
             {
                    Console.WriteLine(e.ToString());
             }
            Console.Read();


        }

        public static string ReadMessage()
        {
            string Traindata = "";
            string message = serial.ReadMessages();
            if (message != null || message != string.Empty)
            {
                Traindata = message;
            }

            return Traindata;
        }
    }

}
