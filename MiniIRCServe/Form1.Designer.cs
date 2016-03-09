namespace MiniIRCServe
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
            this.txt_log = new System.Windows.Forms.RichTextBox();
            this.list_users = new System.Windows.Forms.ListBox();
            this.bt_start = new System.Windows.Forms.Button();
            this.bt_stop = new System.Windows.Forms.Button();
            this.bt_port = new System.Windows.Forms.NumericUpDown();
            this.Worker_Uzytkownicy = new System.ComponentModel.BackgroundWorker();
            this.Rozsylanie = new System.ComponentModel.BackgroundWorker();
            this.Odbieranie = new System.ComponentModel.BackgroundWorker();
            this.Czyszczenie = new System.ComponentModel.BackgroundWorker();
            this.button1 = new System.Windows.Forms.Button();
            this.txt_send = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bt_port)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_log
            // 
            this.txt_log.Location = new System.Drawing.Point(4, 4);
            this.txt_log.Name = "txt_log";
            this.txt_log.ReadOnly = true;
            this.txt_log.Size = new System.Drawing.Size(357, 400);
            this.txt_log.TabIndex = 0;
            this.txt_log.Text = "Server 0.1";
            // 
            // list_users
            // 
            this.list_users.FormattingEnabled = true;
            this.list_users.Location = new System.Drawing.Point(441, 12);
            this.list_users.Name = "list_users";
            this.list_users.Size = new System.Drawing.Size(181, 186);
            this.list_users.TabIndex = 1;
            // 
            // bt_start
            // 
            this.bt_start.Location = new System.Drawing.Point(417, 239);
            this.bt_start.Name = "bt_start";
            this.bt_start.Size = new System.Drawing.Size(181, 38);
            this.bt_start.TabIndex = 2;
            this.bt_start.Text = "Start";
            this.bt_start.UseVisualStyleBackColor = true;
            this.bt_start.Click += new System.EventHandler(this.bt_start_Click);
            // 
            // bt_stop
            // 
            this.bt_stop.Location = new System.Drawing.Point(417, 283);
            this.bt_stop.Name = "bt_stop";
            this.bt_stop.Size = new System.Drawing.Size(181, 32);
            this.bt_stop.TabIndex = 3;
            this.bt_stop.Text = "Stop";
            this.bt_stop.UseVisualStyleBackColor = true;
            this.bt_stop.Click += new System.EventHandler(this.bt_stop_Click);
            // 
            // bt_port
            // 
            this.bt_port.Location = new System.Drawing.Point(515, 347);
            this.bt_port.Maximum = new decimal(new int[] {
            6543,
            0,
            0,
            0});
            this.bt_port.Name = "bt_port";
            this.bt_port.Size = new System.Drawing.Size(82, 20);
            this.bt_port.TabIndex = 4;
            // 
            // Worker_Uzytkownicy
            // 
            this.Worker_Uzytkownicy.WorkerSupportsCancellation = true;
            this.Worker_Uzytkownicy.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Worker_Uzytkownicy_DoWork);
            this.Worker_Uzytkownicy.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Worker_Uzytkownicy_RunWorkerCompleted);
            // 
            // Rozsylanie
            // 
            this.Rozsylanie.WorkerSupportsCancellation = true;
            this.Rozsylanie.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Rozsylanie_DoWork);
            this.Rozsylanie.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Rozsylanie_RunWorkerCompleted);
            // 
            // Odbieranie
            // 
            this.Odbieranie.WorkerSupportsCancellation = true;
            this.Odbieranie.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Odbieranie_RunWorkerCompleted);
            // 
            // Czyszczenie
            // 
            this.Czyszczenie.WorkerSupportsCancellation = true;
            this.Czyszczenie.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Czyszczenie_DoWork);
            this.Czyszczenie.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Czyszczenie_RunWorkerCompleted);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(367, 156);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 42);
            this.button1.TabIndex = 5;
            this.button1.Text = "Wyslij do";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_send
            // 
            this.txt_send.Location = new System.Drawing.Point(367, 204);
            this.txt_send.Name = "txt_send";
            this.txt_send.Size = new System.Drawing.Size(255, 20);
            this.txt_send.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 419);
            this.Controls.Add(this.txt_send);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bt_port);
            this.Controls.Add(this.bt_stop);
            this.Controls.Add(this.bt_start);
            this.Controls.Add(this.list_users);
            this.Controls.Add(this.txt_log);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Server";
            ((System.ComponentModel.ISupportInitialize)(this.bt_port)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txt_log;
        private System.Windows.Forms.ListBox list_users;
        private System.Windows.Forms.Button bt_start;
        private System.Windows.Forms.Button bt_stop;
        private System.Windows.Forms.NumericUpDown bt_port;
        private System.ComponentModel.BackgroundWorker Worker_Uzytkownicy;
        private System.ComponentModel.BackgroundWorker Rozsylanie;
        private System.ComponentModel.BackgroundWorker Odbieranie;
        private System.ComponentModel.BackgroundWorker Czyszczenie;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txt_send;
    }
}

