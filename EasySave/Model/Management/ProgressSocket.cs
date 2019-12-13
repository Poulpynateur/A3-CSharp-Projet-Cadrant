using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using EasySave.Helpers.Files;
using EasySave.Model.Management;
using System.Windows;

namespace EasySave.Model.Management
{
    class ProgressSocket
    {
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
        public Socket _socket { get; private set; }

        /// <summary>
        /// List of the sockets of the clients
        /// </summary>
        public Socket _client { get; private set; }

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="address">IP Address</param>
        /// <param name="port">Port</param>
        public ProgressSocket()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    _address = ip.ToString();
                }
            }
            _port = 50000;

            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _socket.Bind(new IPEndPoint(IPAddress.Parse(_address), _port));
            _socket.Listen(100);

            this.ListenClient();
        }

        /// <summary>
        /// Accept the clients
        /// </summary>
        /// <param name="objet"></param>
        public void ListenClient()
        {
            ThreadPool.QueueUserWorkItem((state)=>
            {
                while(true)
                {
                    try
                    {
                        _client = _socket.Accept();
                    } catch
                    {}
                }
            });
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
            int ratioProgress = doneFiles * 100 / totalFiles;
            string str = ratioProgress + ";" + nameTask + ";" + fileInProgress + "\n";

            return Encoding.UTF8.GetBytes(str);
        }

        /// <summary>
        /// Send to clients the progress of all the works
        /// </summary>
        public void SendProgress(byte[] progressBuffer)
        {
            if(_client != null)
                _client.Send(progressBuffer);
        }
    }
}
