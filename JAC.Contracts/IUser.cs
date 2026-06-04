using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAC.Contracts
{
    public interface IUser
    {
        string Nickname { get; }
        string CurrentChannel { get; set; }
        bool IsLoggedIn { get; }
        void Login();
        void Logout();
    }
}
