using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAC.Contracts
{
    public interface IServiceLogger
    {
        void LogServiceInformation(string text);
        void LogRequestInformation(string text);
    }
}
