using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.IO;

namespace Platform
{
    public class Display
    {
        private SerialPort serialPort = new SerialPort();
        public int COM_Port { get; private set; }
        public bool connected { get; private set; }
        public Display (int COM_Port)
        {
            this.COM_Port = COM_Port;
        }

        public void Connect()
        {
            serialPort.BaudRate = 9600;
            serialPort.PortName = "COM" + COM_Port.ToString();
            serialPort.Open();
            if (!serialPort.IsOpen)
            {
                connected = false;
                serialPort.Close();
            }

        }

        public void CloseSerialPort()
        {
            if(serialPort.IsOpen)
            {
                serialPort.Close();
                connected = false;
            }
        }

        public void Send(string info)
        {
            if(!string.IsNullOrEmpty(info))
            {
                serialPort.WriteLine("#" + info + "%");
            }
        }
    }
}
