using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace Platform
{
    public class NetWork
    {
        private string IPadress = "";
        private int Port = 0;
        private TcpListener PlatForm = null;
        private TcpClient Train = null;
        private NetworkStream Stream;
        private byte[] bytes = new byte[1024];
        private string incomingMessage = "";
        public bool Conneted { get;  private set; } 


        public NetWork (string ipAdress, int port)
        {
            IPadress = ipAdress;
            Port = port;
            
        }

        public void Connect()
        {
            try
            {
                // connect to Train
                PlatForm = new TcpListener(IPAddress.Parse(IPadress), Port);
                PlatForm.Start();
                Train = new TcpClient();
                Train = PlatForm.AcceptTcpClient();
                Stream = Train.GetStream();
                Conneted = true;
            }
            catch
            {
                Conneted = false; // exception handling toepassen
            }
        }

        public string Getinfo (string send)
        {
            // ask Train How many seats are Taken
            byte[] SendMessage = Encoding.ASCII.GetBytes(send);
            Stream.Write(SendMessage, 0, SendMessage.Length);

            // Get Answer Train
            int num = Stream.Read(bytes, 0, bytes.Length);
            string info = ASCIIEncoding.ASCII.GetString(bytes, 0, bytes.Length);

            return info;
        }


    }
}
