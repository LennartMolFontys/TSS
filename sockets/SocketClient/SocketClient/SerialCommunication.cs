using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Ports;

namespace SocketClient
{
    /// Class to send / receive messages using the serial port.
    public class SerialMessenger
    {
        /// Serial port used for the connection.
        private SerialPort serialPort;

        /// The Baudrate of the communication (bytes per second)
        public int BaudRate { get { return serialPort.BaudRate; } }

        /// The serial port name
        public string PortName { get { return serialPort.PortName; } }

        ///Message markers
        private char messageBeginMarker;
        private char messageEndMarker;

        /// Creates a Serial Messenger
        public SerialMessenger(string portName, int baudRate, char messageBeginMarker, char messageEndMarker)
        {
            if (portName == null)
            {
                throw new ArgumentNullException("portName");

            }

            if (baudRate < 9600)
            {
                throw new ArgumentOutOfRangeException("baudRate");
            }

            serialPort = new SerialPort();
            serialPort.BaudRate = baudRate;
            serialPort.PortName = portName;
            this.messageBeginMarker = messageBeginMarker;
            this.messageEndMarker = messageEndMarker;
        }

        /// Connect to the serial port
        public void Connect()
        {
            if (!serialPort.IsOpen)
            {
                serialPort.Open();
                if (serialPort.IsOpen)
                {
                    serialPort.DiscardInBuffer();
                    serialPort.DiscardOutBuffer();
                }
            }
        }

        /// Disconnect from the serial port
        public void Disconnect()
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }

        /// <returns>True is connected, else false</returns>
        public bool IsConnected()
        {
            return serialPort.IsOpen;
        }

        /// Sends the given message to the serial port.
        /// <returns>true if the message was send, false otherwise.</returns>
       public bool SendMessage(string message)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Write(messageBeginMarker + message + messageEndMarker);
                return true;
            }
            return false;
        }


        /// <returns>An array with messages, of null if no (complete) messages were received (yet)</returns>
        public string ReadMessages()
        {
            return serialPort.ReadLine();
        }

        public void Send(string SendString)
        {
            serialPort.WriteLine(SendString);
        }
    }
}
