
namespace JAC.TcpService.GUI
{
    partial class ServerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlMain = new System.Windows.Forms.Panel();
            this.tbxIp = new System.Windows.Forms.TextBox();
            this.tbxPort = new System.Windows.Forms.TextBox();
            this.lblIp = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.lbxService = new System.Windows.Forms.ListBox();
            this.lbxRequest = new System.Windows.Forms.ListBox();
            this.btnStartDef = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.btnStop);
            this.pnlMain.Controls.Add(this.btnStartDef);
            this.pnlMain.Controls.Add(this.lbxRequest);
            this.pnlMain.Controls.Add(this.lbxService);
            this.pnlMain.Controls.Add(this.btnStart);
            this.pnlMain.Controls.Add(this.lblPort);
            this.pnlMain.Controls.Add(this.lblIp);
            this.pnlMain.Controls.Add(this.tbxPort);
            this.pnlMain.Controls.Add(this.tbxIp);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1299, 647);
            this.pnlMain.TabIndex = 0;
            // 
            // tbxIp
            // 
            this.tbxIp.Location = new System.Drawing.Point(121, 38);
            this.tbxIp.Name = "tbxIp";
            this.tbxIp.Size = new System.Drawing.Size(397, 22);
            this.tbxIp.TabIndex = 0;
            // 
            // tbxPort
            // 
            this.tbxPort.Location = new System.Drawing.Point(121, 75);
            this.tbxPort.Name = "tbxPort";
            this.tbxPort.Size = new System.Drawing.Size(397, 22);
            this.tbxPort.TabIndex = 1;
            // 
            // lblIp
            // 
            this.lblIp.AutoSize = true;
            this.lblIp.Location = new System.Drawing.Point(34, 41);
            this.lblIp.Name = "lblIp";
            this.lblIp.Size = new System.Drawing.Size(81, 17);
            this.lblIp.TabIndex = 2;
            this.lblIp.Text = "IP-Address:";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(34, 78);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(38, 17);
            this.lblPort.TabIndex = 3;
            this.lblPort.Text = "Port:";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(524, 38);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(147, 59);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbxService
            // 
            this.lbxService.FormattingEnabled = true;
            this.lbxService.ItemHeight = 16;
            this.lbxService.Location = new System.Drawing.Point(12, 119);
            this.lbxService.Name = "lbxService";
            this.lbxService.Size = new System.Drawing.Size(630, 516);
            this.lbxService.TabIndex = 6;
            // 
            // lbxRequest
            // 
            this.lbxRequest.FormattingEnabled = true;
            this.lbxRequest.ItemHeight = 16;
            this.lbxRequest.Location = new System.Drawing.Point(657, 119);
            this.lbxRequest.Name = "lbxRequest";
            this.lbxRequest.Size = new System.Drawing.Size(630, 516);
            this.lbxRequest.TabIndex = 7;
            // 
            // btnStartDef
            // 
            this.btnStartDef.Location = new System.Drawing.Point(677, 38);
            this.btnStartDef.Name = "btnStartDef";
            this.btnStartDef.Size = new System.Drawing.Size(147, 59);
            this.btnStartDef.TabIndex = 8;
            this.btnStartDef.Text = "Start Default";
            this.btnStartDef.UseVisualStyleBackColor = true;
            this.btnStartDef.Click += new System.EventHandler(this.btnStartDef_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(830, 38);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(147, 59);
            this.btnStop.TabIndex = 9;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btn_Click);
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1299, 647);
            this.Controls.Add(this.pnlMain);
            this.Name = "ServerForm";
            this.Text = "JAC-Server";
            this.Load += new System.EventHandler(this.ServerForm_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblIp;
        private System.Windows.Forms.TextBox tbxPort;
        private System.Windows.Forms.TextBox tbxIp;
        private System.Windows.Forms.ListBox lbxRequest;
        private System.Windows.Forms.ListBox lbxService;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStartDef;
    }
}

