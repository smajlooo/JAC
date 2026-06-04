using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using JAC.Contracts;
using JAC.Shared;

namespace JAC.TcpClient.Lib
{
    public class MessageReceiver
    {
        public event EventHandler<MessageReceivedEventArgs> MessageReceived;
        Socket _socket;

        public MessageReceiver(Socket socket)
        {
            _socket = socket;
        }

        public void Start()
        {
            Thread listenThread = new Thread(new ThreadStart(() =>
            {
                ReceiveMessages();
            }));
            listenThread.Start();
        }

        private void ReceiveMessages()
        {
            SocketReader sr = new SocketReader(_socket);
            string res = "";

            do
            {

                res = sr.ReceiveText();

                try
                {
                    if ((ChatMessage)new JSONSerializer().Deserialize(res) is ChatMessage)
                    {
                        OnMessageReceived(res);
                    }
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine(res);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                

            } while (res != "exit");
        }

        protected virtual void OnMessageReceived(string message)
        {
            MessageReceived?.Invoke(this, new MessageReceivedEventArgs(message));
        } 
    }
}
