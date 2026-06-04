using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using JAC.Contracts;

namespace JAC.TcpService.Lib
{
    public class TcpServer
    {
        Socket _serverSocket;
        IPEndPoint _ep;
        Thread _serverThread;
        IServiceLogger _logger;

        public TcpServer(IPAddress adr, int port, IServiceLogger logger)
        {
            _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _ep = new IPEndPoint(adr, port);
            _logger = logger;
        }

        public TcpServer(IServiceLogger logger)
        {
            _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _ep = new IPEndPoint(IPAddress.Loopback, 1147);
            _logger = logger;
        }

        public void Start()
        {
            _serverSocket.Bind(_ep);
            _serverSocket.Listen(100);

            _serverThread = new Thread(new ThreadStart(() =>
            {
                ClientHandler ch = new ClientHandler(_serverSocket, _logger);
                ch.AcceptClients();
            }));

            _serverThread.Start();
        }

        public void Stop()
        {
            try
            {
                _serverSocket.Shutdown(SocketShutdown.Both);
                _serverSocket.Close();
            }
            catch (SocketException)
            {

            }
        }
    }
}
