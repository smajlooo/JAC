using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JAC.Contracts;
using JAC.Shared;

namespace JAC.TcpService.Lib
{
    public class MessageDispatcher
    {
        List<SessionHandler> _sessions = new List<SessionHandler>();

        public MessageDispatcher(List<SessionHandler> sessions)
        {
            _sessions = sessions;
        }

        public void Broadcast(IMessage message)
        {
            foreach(SessionHandler s in _sessions)
            {
                if(s.User.Nickname != message.Sender)
                {
                    s.SendText(new JSONSerializer().Serialize(message));
                }
            }
        }

        public void Whisper(IMessage message)
        {
            foreach(SessionHandler s in _sessions)
            {
                if(s.User.Nickname == message.Recipient)
                {
                    s.SendText(new JSONSerializer().Serialize(message));
                }
            }
        }
    }
}
