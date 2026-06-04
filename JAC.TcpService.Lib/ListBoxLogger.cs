using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JAC.Contracts;

namespace JAC.TcpService.Lib
{
    public class ListBoxLogger : IServiceLogger
    {
        ListBox _lbxService;
        ListBox _lbxRequest;

        Action<string> _logServiceInformationDelegate;
        Action<string> _logRequestInformationDelegate;

        public ListBoxLogger(ListBox lbxService, ListBox lbxRequest)
        {
            _lbxService = lbxService;
            _lbxRequest = lbxRequest;

            _logServiceInformationDelegate = new Action<string>(LogServiceInformation);
            _logRequestInformationDelegate = new Action<string>(LogRequestInformation);
        }

        public void LogServiceInformation(string text)
        {
            if (_lbxService.InvokeRequired)
            {
                _lbxService.Invoke(_logServiceInformationDelegate, text);
            }
            else
            {
                _lbxService.Items.Add(text);
            }
        }

        public void LogRequestInformation(string text)
        {
            if (_lbxRequest.InvokeRequired)
            {
                _lbxRequest.Invoke(_logRequestInformationDelegate, text);
            }
            else
            {
                _lbxRequest.Items.Add(text);
            }
        }
    }
}
