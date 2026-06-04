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
    public class SocketReader
    {
        Socket _socket;

        public SocketReader(Socket socket)
        {
            _socket = socket;
        }

        public string ReceiveText()
        {
            byte[] b = new byte[1024];
            _socket.Receive(b);
            string s = Encoding.ASCII.GetString(b);
            return s.Substring(0, s.IndexOf("\0"));
        }
    }
}
