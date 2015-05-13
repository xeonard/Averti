namespace AvertiFestivalApplication
{
    partial class LogInForm
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
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.tbxLoginID = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.btnNormalLog = new System.Windows.Forms.Button();
            this.tbPass = new System.Windows.Forms.TextBox();
            this.tbPersID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Enabled = false;
            this.btnLogin.Location = new System.Drawing.Point(48, 128);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(98, 23);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "Login with RFID";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(149, 195);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 23);
            this.btnQuit.TabIndex = 1;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // tbxLoginID
            // 
            this.tbxLoginID.Location = new System.Drawing.Point(48, 69);
            this.tbxLoginID.Name = "tbxLoginID";
            this.tbxLoginID.Size = new System.Drawing.Size(87, 20);
            this.tbxLoginID.TabIndex = 2;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(45, 53);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(59, 13);
            this.lblID.TabIndex = 3;
            this.lblID.Text = "RFID code";
            // 
            // btnNormalLog
            // 
            this.btnNormalLog.Location = new System.Drawing.Point(263, 128);
            this.btnNormalLog.Name = "btnNormalLog";
            this.btnNormalLog.Size = new System.Drawing.Size(75, 23);
            this.btnNormalLog.TabIndex = 4;
            this.btnNormalLog.Text = "Login";
            this.btnNormalLog.UseVisualStyleBackColor = true;
            this.btnNormalLog.Click += new System.EventHandler(this.btnNormalLog_Click);
            // 
            // tbPass
            // 
            this.tbPass.Location = new System.Drawing.Point(251, 69);
            this.tbPass.Name = "tbPass";
            this.tbPass.Size = new System.Drawing.Size(87, 20);
            this.tbPass.TabIndex = 5;
            this.tbPass.Text = "password";
            // 
            // tbPersID
            // 
            this.tbPersID.Location = new System.Drawing.Point(251, 46);
            this.tbPersID.Name = "tbPersID";
            this.tbPersID.Size = new System.Drawing.Size(87, 20);
            this.tbPersID.TabIndex = 6;
            this.tbPersID.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(353, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Personal ID Code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(353, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Password";
            // 
            // LogInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 372);
            this.Controls.Add(this.tbPersID);
            this.Controls.Add(this.tbPass);
            this.Controls.Add(this.btnNormalLog);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxLoginID);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LogInForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Festival - Log In";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LogInForm_FormClosing);
            this.Load += new System.EventHandler(this.LogInForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.TextBox tbxLoginID;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Button btnNormalLog;
        private System.Windows.Forms.TextBox tbPass;
        private System.Windows.Forms.TextBox tbPersID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

