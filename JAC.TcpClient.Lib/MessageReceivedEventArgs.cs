using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JAC.Contracts;
using JAC.Shared;

namespace JAC.TcpClient.Lib
{
    public class MessageReceivedEventArgs
    {
        public IMessage Message { get; }

        public MessageReceivedEventArgs(string message)
        {
            Message = (ChatMessage)new JSONSerializer().Deserialize(message);
        }
    }
}
