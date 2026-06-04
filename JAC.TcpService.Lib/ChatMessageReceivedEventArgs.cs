using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JAC.Contracts;
using JAC.Shared;

namespace JAC.TcpService.Lib
{
    public class ChatMessageReceivedEventArgs
    {
        public IMessage Message { get; }

        public ChatMessageReceivedEventArgs(ChatMessage message)
        {
            Message = message;
        }
    }
}
