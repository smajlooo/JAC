using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using JAC.Contracts;
using JAC.Shared;

namespace JAC.TcpClient.Lib
{
    public class Client
    {
        Socket _socket;
        IPEndPoint _ep;
        string _nickname;
       
        public Client(IPAddress adr, int port)
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _ep = new IPEndPoint(adr, port);
        }

        public Client()
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _ep = new IPEndPoint(IPAddress.Loopback, 1147);
        }

        public void Connect()
        {
            try
            {
                _socket.Connect(_ep);
                HandleCommunication();
            }
            catch (SocketException)
            {
                Console.WriteLine("Failed to connect to server...");
            }
        }

        private void HandleCommunication()
        {
            string req = "";
            string res = "";
            SocketWriter sw = new SocketWriter(_socket);
            SocketReader sr = new SocketReader(_socket);
            MessageReceiver receiver = new MessageReceiver(_socket);
            IMessage message;

            Login();

            receiver.MessageReceived += (sender, e) =>
            {
                message = (ChatMessage)e.Message;

                if (message.IsPrivate)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"[{message.Timestamp}][Private][{message.Sender}]: {message.Content}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (!message.IsPrivate)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"[{message.Timestamp}][Broadcast][{message.Sender}]: {message.Content}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            };
            receiver.Start();

            do
            {
                req = Console.ReadLine();

                if(req.Split(' ')[0] == "/whisper" || req.Split(' ')[0] == "/broadcast")
                {
                    message = new ChatMessage(req, _nickname);
                    sw.SendText(new JSONSerializer().Serialize(message));
                }
                else
                {
                    sw.SendText(req);
                }

            } while (req != "exit");
        }

        private void Login()
        {
            string req = "";
            string res = "";
            SocketWriter sw = new SocketWriter(_socket);
            SocketReader sr = new SocketReader(_socket);

            Console.WriteLine("To login type in /login and your nickname as shown in the example.");
            Console.WriteLine("/login johndoe");
            Console.WriteLine();

            do
            {
                req = Console.ReadLine();

                sw.SendText(req);

                res = sr.ReceiveText();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(res.Split('|')[1]);
                Console.ForegroundColor = ConsoleColor.White;

            } while (res.Split('|')[0] != "loggedin");

            _nickname = req.Split(' ')[1];
        }
    }
}
