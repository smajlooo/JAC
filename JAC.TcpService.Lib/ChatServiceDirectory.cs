using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JAC.Contracts;

namespace JAC.TcpService.Lib
{
    public class ChatServiceDirectory
    {
        public List<IUser> Users { get; private set; } = new List<IUser>();
        public List<string> Channels { get; private set; } = new List<string>();
        private static ChatServiceDirectory _instance;

        private ChatServiceDirectory()
        {

        }

        public static ChatServiceDirectory Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new ChatServiceDirectory();
                }
                return _instance;
            }
        }

        public void AddUser(IUser user)
        {
            Users.Add(user);
        }

        public void RemoveUser(IUser user)
        {
            Users.Remove(user);
        }

        public IUser FindUser(string nickname)
        {
            foreach(IUser u in Users)
            {
                if(u.Nickname == nickname)
                {
                    return u;
                }
            }
            return null;
        }

        public void AddChannel(string channel)
        {
            Channels.Add(channel);
        }

        public void RemoveChannel(string channel)
        {
            Channels.Remove(channel);
        }

        public string FindChannel(string channel)
        {
            foreach (string c in Channels)
            {
                if (c == channel)
                {
                    return c;
                }
            }
            return null;
        }
    }
}
