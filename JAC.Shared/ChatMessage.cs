using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JAC.Contracts;

namespace JAC.Shared
{
    public class ChatMessage : IMessage
    {
        public string Recipient { get; set; }

        public string Sender { get; set; }

        public string Content { get; set; }

        public DateTime Timestamp { get; set; }

        public bool IsPrivate { get; set; }

        public ChatMessage(string command, string sender)
        {
            Sender = sender;

            if (command.Split(' ')[0] == "/whisper")
            {
                Recipient = command.Split(' ')[1];

                for (int i = 2; i < command.Split(' ').Length; i++)
                {
                    Content += command.Split(' ')[i] + " ";
                }
                Content = Content.Trim();
                Timestamp = DateTime.Now;
                IsPrivate = true;
            }
            else if (command.Split(' ')[0] == "/broadcast")
            {
                Recipient = "";

                for (int i = 1; i < command.Split(' ').Length; i++)
                {
                    Content += command.Split(' ')[i] + " ";
                }
                Content = Content.Trim();
                Timestamp = DateTime.Now;
                IsPrivate = false;
            }
        }

        public ChatMessage() { }
    }
}
