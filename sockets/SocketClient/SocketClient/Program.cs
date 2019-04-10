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
        private static int trainID = 6404;
        private static string initializeInfo = "";
        private static string seatInfo = "";
        public static SerialMessenger serial;
        


        static void Main(string[] args)
        {
            const int port = 8888;
            String sendLine = "";
            byte[] bytes = new byte[1024];
            string incomingMessage = "";
            
          
            try
            {
                TcpClient clientSock = new TcpClient();
                Console.WriteLine("give ipAdress to connect to");
                IPAddress.TryParse(Console.ReadLine(), out IPAddress serverIP);

                Console.WriteLine("Connecting to Server ...");
                clientSock.Connect(serverIP , port);
                Console.WriteLine("Connected!");
                NetworkStream stream = clientSock.GetStream();

                serial = new SerialMessenger("COM9", 9600, '#', '%');
                serial.Connect();

                while (sendLine != "quit")
                {
                    ReadMessage();
                    if (stream.DataAvailable == true)
                    {
                        int num = stream.Read(bytes, 0, bytes.Length);
                        incomingMessage = Encoding.ASCII.GetString(bytes, 0, num);
                        Console.WriteLine(incomingMessage);
                    }

                    if (incomingMessage.Contains("Initialize"))
                    {
                        Console.WriteLine(initializeInfo);
                        byte[] data = Encoding.ASCII.GetBytes(initializeInfo);
                        stream.Write(data, 0, data.Length);
                        
                    }
                    else if(incomingMessage.Contains("SeatInfo"))
                    {
                        Console.WriteLine(seatInfo);
                        byte[] data = Encoding.ASCII.GetBytes(seatInfo);
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

        public static void ReadMessage()
        {
            string message = serial.ReadMessages();
            if (message != null || message != string.Empty)
            {
                string[] stringValues = message.Split(new string[] { "[", "] [", "]" }, StringSplitOptions.RemoveEmptyEntries);
                StringBuilder sb = new StringBuilder();
                seatInfo = "";
                for (int i = 1; i < stringValues.Count(); i +=4)
                {
                    sb.AppendFormat("SeatsTaken:{0}", stringValues[i]);
                    seatInfo += sb;
                }
                int unitAmount = stringValues.Count() / 4;
                initializeInfo = "ID:" + trainID.ToString() + "UnitAmount:" + unitAmount.ToString();
                int formatInt = 0;
                for (int i = 1; i <= unitAmount; i++)
                {
                    initializeInfo = initializeInfo + "Length:" + stringValues[i*4-1] + "TotalSeats:" + stringValues[i*3-1] ;
                    formatInt += 2;
                }
                initializeInfo = initializeInfo + "\n"; 
            }

        }
    }

}
