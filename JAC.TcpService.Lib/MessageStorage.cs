using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JAC.Contracts;
using JAC.Shared;

namespace JAC.TcpService.Lib
{
    public class MessageStorage
    {
        public event EventHandler<ChatMessageReceivedEventArgs> ChatMessageReceived;
        private static MessageStorage _instance;
        private List<ChatMessage> _messages = new List<ChatMessage>();

        private MessageStorage() { }

        public static MessageStorage Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new MessageStorage();
                }
                return _instance;
            }
        }

        public void Add(ChatMessage message)
        {
            _messages.Add(message);
            OnChatMessageReceived();
        }

        protected virtual void OnChatMessageReceived()
        {
            ChatMessageReceived?.Invoke(this, new ChatMessageReceivedEventArgs(_messages[_messages.Count - 1]));
        }
    }
}
