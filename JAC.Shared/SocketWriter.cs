using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using JAC.Contracts;

namespace JAC.Shared
{
    public class SocketWriter
    {
        Socket _socket;

        public SocketWriter(Socket socket)
        {
            _socket = socket;
        }

        public void SendText(string text)
        {
            byte[] b = Encoding.ASCII.GetBytes(text);
            _socket.Send(b);
        }
    }
}
