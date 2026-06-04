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

namespace JAC.TcpService.Lib
{
    public class ClientHandler
    {
        Socket _serverSocket;
        Socket _clientSocket;
        Thread _clientThread;
        List<SessionHandler> _sessions = new List<SessionHandler>();
        IServiceLogger _logger;

        public ClientHandler(Socket serverSocket, IServiceLogger logger)
        {
            _serverSocket = serverSocket;
            _logger = logger;
        }

        public void AcceptClients()
        {
            _logger.LogServiceInformation($"[{DateTime.Now}] Server started...");
            _logger.LogServiceInformation($"[{DateTime.Now}] Waiting for incoming client connections...");

            MessageStorage storage = MessageStorage.Instance;

            storage.ChatMessageReceived += (sender, e) =>
            {
                ChatMessage message = (ChatMessage)e.Message;
                MessageDispatcher dispatcher = new MessageDispatcher(_sessions);

                if (message.IsPrivate)
                {
                    dispatcher.Whisper(message);
                }
                else if (!message.IsPrivate)
                {
                    dispatcher.Broadcast(message);
                }
            };

            do
            {
                try
                {
                    _clientSocket = _serverSocket.Accept();

                    _clientThread = new Thread(new ThreadStart(() => {
                        SessionHandler session = new SessionHandler(_clientSocket, _logger);
                        _sessions.Add(session);
                        _logger.LogServiceInformation($"[{DateTime.Now}] Client {_clientSocket.RemoteEndPoint} connected... Total clients connected: {_sessions.Count}");
                        session.SessionClosed += (sender, e) =>
                        {
                            _sessions.Remove((SessionHandler)sender);
                            _logger.LogServiceInformation($"[{DateTime.Now}] Client {_clientSocket.RemoteEndPoint} disconnected... Total clients connected: {_sessions.Count}");
                        };
                        session.HandleCommunication();
                        session.Close();
                    }));

                    _clientThread.Start();

                    _logger.LogServiceInformation($"[{DateTime.Now}] Incoming client {_clientSocket.RemoteEndPoint} connection established...");
                }
                catch (SocketException)
                {
                    _logger.LogServiceInformation($"[{DateTime.Now}] Accepting clients failed...");
                    break;
                }

            } while (true);
        }
    }
}
