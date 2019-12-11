using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using EasySave.Helpers.Files;
using EasySave.Model.Output;

namespace EasySave.Model.Output
{
    class ProgressSocket
    {
        /// <summary>
        /// Buffer used to send name of the task and its progress
        /// </summary>
        private byte[] _sendBuffer { get; set; }

        /// <summary>
        /// Port used for the socket
        /// </summary>
        private int _port { get; set; }

        /// <summary>
        /// IP Address used for the socket
        /// </summary>
        private string _address { get; set; } 

        /// <summary>
        /// Socket of the app (server)
        /// </summary>
        private Socket _socket { get; set; }

        /// <summary>
        /// List of the sockets of the clients
        /// </summary>
        private Socket _client { get; set; }

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="address">IP Address</param>
        /// <param name="port">Port</param>
        public ProgressSocket()
        {
            _sendBuffer = new byte[1024];
            string host = Dns.GetHostName();
            _address = Dns.GetHostEntry(host).AddressList[1].ToString();
            _port = 50000;
            try
            {
                _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                _socket.Bind(new IPEndPoint(IPAddress.Parse(_address), _port));
            }
            catch(Exception e)
            {
                throw new Exception("Error initializing socket");
            }
        }

        /// <summary>
        /// Start a thread that allows to listen to clients
        /// </summary>
        public void StartListening()
        {
            Thread myThread = new Thread(ListenClient);
            myThread.Start();
        }

        /// <summary>
        /// Accept the clients
        /// </summary>
        /// <param name="objet"></param>
        public void ListenClient()
        {
            while (true)
            {
                Socket clientSocket = _socket.Accept();
                int receive = clientSocket.Receive(_sendBuffer);
                _client = clientSocket;
            }
        }

        /// <summary>
        /// Convert the progress of the task to a buffer containing the name of the task of its progress
        /// </summary>
        /// <param name="nameTask"></param>
        /// <param name="totalFiles"></param>
        /// <param name="doneFiles"></param>
        /// <returns></returns>
        public byte[] ConvertProgressToBuffer(string nameTask, int totalFiles, int doneFiles, string fileInProgress)
        {
            // Create all the byte arrays to store the data
            byte[] nameTaskBuffer = Encoding.UTF8.GetBytes(nameTask);
            byte[] fileInProgressBuffer = Encoding.UTF8.GetBytes(fileInProgress);
            float ratioProgress = (float)totalFiles / (float)doneFiles;
            byte[] ratioProgressBuffer = BitConverter.GetBytes(ratioProgress);

            // Copy the previously arrays to a common array to store everything
            nameTaskBuffer.CopyTo(_sendBuffer, 0);
            fileInProgressBuffer.CopyTo(_sendBuffer, 60);
            ratioProgressBuffer.CopyTo(_sendBuffer, 572);
            return _sendBuffer;
        }

        /// <summary>
        /// Send to clients the progress of all the works
        /// </summary>
        public void SendProgress(byte[] progressBuffer)
        {
            _client.Send(progressBuffer);
        }
    }
}
