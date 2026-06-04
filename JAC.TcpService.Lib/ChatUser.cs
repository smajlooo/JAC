using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JAC.Contracts;

namespace JAC.TcpService.Lib
{
    public class ChatUser : IUser
    {
        public string Nickname { get; private set; }
        public string CurrentChannel { get; set; }
        public bool IsLoggedIn { get; private set; }

        public ChatUser(string nickname)
        {
            Nickname = nickname;
            CurrentChannel = "all";
            IsLoggedIn = false;
        }

        public void Login()
        {
            IsLoggedIn = true;
        }

        public void Logout()
        {
            IsLoggedIn = false;
        }
    }
}
