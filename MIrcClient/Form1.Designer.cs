namespace MIrcClient
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Wymagana metoda wsparcia projektanta - nie należy modyfikować
        /// zawartość tej metody z edytorem kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.tx_IP = new System.Windows.Forms.TextBox();
            this.tx_port = new System.Windows.Forms.NumericUpDown();
            this.bt_connect = new System.Windows.Forms.Button();
            this.bt_disconnect = new System.Windows.Forms.Button();
            this.tx_log = new System.Windows.Forms.RichTextBox();
            this.tx_send = new System.Windows.Forms.TextBox();
            this.worker = new System.ComponentModel.BackgroundWorker();
            this.tx_nick = new System.Windows.Forms.TextBox();
            this.bt_send = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tx_port)).BeginInit();
            this.SuspendLayout();
            // 
            // tx_IP
            // 
            this.tx_IP.Location = new System.Drawing.Point(12, 13);
            this.tx_IP.Name = "tx_IP";
            this.tx_IP.Size = new System.Drawing.Size(76, 20);
            this.tx_IP.TabIndex = 0;
            this.tx_IP.Text = "213.5.145.141";
            // 
            // tx_port
            // 
            this.tx_port.Location = new System.Drawing.Point(94, 12);
            this.tx_port.Maximum = new decimal(new int[] {
            6543,
            0,
            0,
            0});
            this.tx_port.Name = "tx_port";
            this.tx_port.Size = new System.Drawing.Size(64, 20);
            this.tx_port.TabIndex = 1;
            this.tx_port.Value = new decimal(new int[] {
            1243,
            0,
            0,
            0});
            // 
            // bt_connect
            // 
            this.bt_connect.Location = new System.Drawing.Point(224, 1);
            this.bt_connect.Name = "bt_connect";
            this.bt_connect.Size = new System.Drawing.Size(49, 32);
            this.bt_connect.TabIndex = 2;
            this.bt_connect.Text = "Polacz";
            this.bt_connect.UseVisualStyleBackColor = true;
            this.bt_connect.Click += new System.EventHandler(this.bt_connect_Click);
            // 
            // bt_disconnect
            // 
            this.bt_disconnect.Location = new System.Drawing.Point(164, 1);
            this.bt_disconnect.Name = "bt_disconnect";
            this.bt_disconnect.Size = new System.Drawing.Size(54, 32);
            this.bt_disconnect.TabIndex = 3;
            this.bt_disconnect.Text = "Rozlacz";
            this.bt_disconnect.UseVisualStyleBackColor = true;
            this.bt_disconnect.Click += new System.EventHandler(this.bt_disconnect_Click);
            // 
            // tx_log
            // 
            this.tx_log.Location = new System.Drawing.Point(6, 39);
            this.tx_log.Name = "tx_log";
            this.tx_log.ReadOnly = true;
            this.tx_log.Size = new System.Drawing.Size(371, 384);
            this.tx_log.TabIndex = 4;
            this.tx_log.Text = "";
            // 
            // tx_send
            // 
            this.tx_send.Location = new System.Drawing.Point(6, 432);
            this.tx_send.Name = "tx_send";
            this.tx_send.Size = new System.Drawing.Size(289, 20);
            this.tx_send.TabIndex = 5;
            this.tx_send.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tx_send_KeyPress);
            // 
            // worker
            // 
            this.worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.worker_DoWork);
            this.worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.worker_RunWorkerCompleted);
            // 
            // tx_nick
            // 
            this.tx_nick.Location = new System.Drawing.Point(278, 8);
            this.tx_nick.Name = "tx_nick";
            this.tx_nick.Size = new System.Drawing.Size(98, 20);
            this.tx_nick.TabIndex = 6;
            this.tx_nick.Text = "Wpisz Tu Nick";
            this.tx_nick.Click += new System.EventHandler(this.tx_nick_Click);
            // 
            // bt_send
            // 
            this.bt_send.Location = new System.Drawing.Point(301, 432);
            this.bt_send.Name = "bt_send";
            this.bt_send.Size = new System.Drawing.Size(76, 30);
            this.bt_send.TabIndex = 7;
            this.bt_send.Text = "Wyslij";
            this.bt_send.UseVisualStyleBackColor = true;
            this.bt_send.Click += new System.EventHandler(this.bt_send_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 464);
            this.Controls.Add(this.bt_send);
            this.Controls.Add(this.tx_nick);
            this.Controls.Add(this.tx_send);
            this.Controls.Add(this.tx_log);
            this.Controls.Add(this.bt_disconnect);
            this.Controls.Add(this.bt_connect);
            this.Controls.Add(this.tx_port);
            this.Controls.Add(this.tx_IP);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Czat 0.1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.tx_port)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tx_IP;
        private System.Windows.Forms.NumericUpDown tx_port;
        private System.Windows.Forms.Button bt_connect;
        private System.Windows.Forms.Button bt_disconnect;
        private System.Windows.Forms.RichTextBox tx_log;
        private System.Windows.Forms.TextBox tx_send;
        private System.ComponentModel.BackgroundWorker worker;
        private System.Windows.Forms.TextBox tx_nick;
        private System.Windows.Forms.Button bt_send;
    }
}

