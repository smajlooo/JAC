using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using JAC.Contracts;

namespace JAC.Shared
{
    public class JSONSerializer : ISerializer
    {
        public JSONSerializer()
        {
            
        }

        public string Serialize(IMessage message)
        {
            return JsonSerializer.Serialize(message);
        }

        public IMessage Deserialize(string jsonstring)
        {
            return JsonSerializer.Deserialize<ChatMessage>(jsonstring);
        }

    }
}
