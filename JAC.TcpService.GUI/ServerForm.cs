using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using JAC.Contracts;
using JAC.TcpService.Lib;

namespace JAC.TcpService.GUI
{
    public partial class ServerForm : Form
    {
        TcpServer _server;
        public ServerForm()
        {
            InitializeComponent();
        }

        private void ServerForm_Load(object sender, EventArgs e)
        {
            btnStop.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IPAddress adr = IPAddress.Any;
            int port = 0;

            try
            {
                adr = IPAddress.Parse(tbxIp.Text);
                port = Convert.ToInt32(tbxPort.Text);

                _server = new TcpServer(adr, port, new ListBoxLogger(lbxService, lbxRequest));
                _server.Start();

                btnStartDef.Enabled = false;
                btnStart.Enabled = false;
                btnStop.Enabled = true;
                tbxIp.Enabled = false;
                tbxPort.Enabled = false;
            }
            catch (SocketException)
            {
                MessageBox.Show("Invalid input...");
            }

        }

        private void btnStartDef_Click(object sender, EventArgs e)
        {
            _server = new TcpServer(new ListBoxLogger(lbxService, lbxRequest));
            _server.Start();

            tbxIp.Text = "127.0.0.1";
            tbxPort.Text = "1147";

            btnStartDef.Enabled = false;
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            tbxIp.Enabled = false;
            tbxPort.Enabled = false;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            _server.Stop();

            btnStartDef.Enabled = true;
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            tbxIp.Enabled = true;
            tbxPort.Enabled = true;
        }
    }
}
