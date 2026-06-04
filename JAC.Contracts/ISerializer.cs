using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAC.Contracts
{
    public interface ISerializer
    {
        string Serialize(IMessage message);
        IMessage Deserialize(string s);
    }
}
