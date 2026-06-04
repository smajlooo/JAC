using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using JAC.Contracts;
using JAC.Shared;

namespace JAC.TcpService.Lib
{
    public class SessionHandler
    {
        Socket _clientSocket;
        SocketWriter _sw;
        SocketReader _sr;
        IServiceLogger _logger;
        IUser _user;

        public event EventHandler SessionClosed;

        public SessionHandler(Socket clientSocket, IServiceLogger logger)
        {
            _clientSocket = clientSocket;
            _sw = new SocketWriter(_clientSocket);
            _sr = new SocketReader(_clientSocket);
            _logger = logger;
        }

        public IUser User
        {
            get
            {
                return _user;
            }
        }

        public void HandleCommunication()
        {
            MessageStorage storage = MessageStorage.Instance;
            string req = "";
            string res = "";
            IMessage message;


            _logger.LogServiceInformation($"[{DateTime.Now}] Waiting for incoming client requests...");

            UserLogin();

            do
            {
                req = _sr.ReceiveText();

                try
                {
                    message = new JSONSerializer().Deserialize(req);
                    storage.Add((ChatMessage)message);
                }
                catch (Exception)
                {
                    res = req;
                    _logger.LogRequestInformation($"[{DateTime.Now}] Request received from client {_clientSocket.RemoteEndPoint}: {req}");
                    _sw.SendText(res);
                    _logger.LogRequestInformation($"[{DateTime.Now}] Response sent to client {_clientSocket.RemoteEndPoint}: {res}");
                }


            } while (req != "exit");

            _user.Logout();
        }

        private void UserLogin()
        {
            string req = "";
            string res = "";
            ChatServiceDirectory directory = ChatServiceDirectory.Instance;
            _user = new ChatUser("");

            do
            {
                req = _sr.ReceiveText().Trim();
                _logger.LogRequestInformation($"[{DateTime.Now}] Login request received from client {_clientSocket.RemoteEndPoint}: {req}");

                if (req.Split(' ').Length == 2 && req.Split(' ')[0] == "/login")
                {
                    string nickname = req.Split(' ')[1];

                    _user = new ChatUser(nickname);

                    if (directory.FindUser(_user.Nickname) != null)
                    {
                        res = "failed|Login failed... User with this nickname already exists...";
                        _sw.SendText(res);
                        _logger.LogRequestInformation($"[{DateTime.Now}] Login response sent to client {_clientSocket.RemoteEndPoint}: {res}");
                    }
                    else
                    {
                        _user.Login();
                        res = $"loggedin|Login successful... You are logged in as {_user.Nickname}...";
                        _sw.SendText(res);
                        _logger.LogRequestInformation($"[{DateTime.Now}] Login response sent to client {_clientSocket.RemoteEndPoint}: {res}");
                        directory.AddUser(_user);
                    }

                }
                else if(req.Split(' ').Length != 2 || req.Split(' ')[0] != "/login")
                {
                    res = "failed|Login failed... Invalid syntax...";
                    _sw.SendText(res);
                    _logger.LogRequestInformation($"[{DateTime.Now}] Login response sent to client {_clientSocket.RemoteEndPoint}: {res}");
                }

            } while (_user.IsLoggedIn == false);
        }

        public void SendText(string message)
        {
            _sw.SendText(message);
        }

        public void Close()
        {
            OnSessionClosed();
            try
            {
                _clientSocket.Shutdown(SocketShutdown.Both);
                _clientSocket.Close();
            }
            catch (SocketException)
            {

            }
        }

        protected virtual void OnSessionClosed()
        {
            SessionClosed?.Invoke(this, EventArgs.Empty);
        }
    }
}
