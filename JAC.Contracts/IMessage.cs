using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAC.Contracts
{
    public interface IMessage
    {
        string Recipient { get; set; }
        string Sender { get; set; }
        string Content { get; set; }
        DateTime Timestamp { get; set; }
        bool IsPrivate { get; set; }
    }
}
