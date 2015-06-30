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
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnNormalLog = new System.Windows.Forms.Button();
            this.tbPass = new System.Windows.Forms.TextBox();
            this.tbPersID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(98, 230);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 23);
            this.btnQuit.TabIndex = 5;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnNormalLog
            // 
            this.btnNormalLog.Location = new System.Drawing.Point(98, 120);
            this.btnNormalLog.Name = "btnNormalLog";
            this.btnNormalLog.Size = new System.Drawing.Size(75, 23);
            this.btnNormalLog.TabIndex = 3;
            this.btnNormalLog.Text = "Login";
            this.btnNormalLog.UseVisualStyleBackColor = true;
            this.btnNormalLog.Click += new System.EventHandler(this.btnNormalLog_Click);
            // 
            // tbPass
            // 
            this.tbPass.Location = new System.Drawing.Point(157, 76);
            this.tbPass.Name = "tbPass";
            this.tbPass.Size = new System.Drawing.Size(87, 20);
            this.tbPass.TabIndex = 2;
            this.tbPass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPass_KeyDown);
            // 
            // tbPersID
            // 
            this.tbPersID.Location = new System.Drawing.Point(157, 40);
            this.tbPersID.Name = "tbPersID";
            this.tbPersID.Size = new System.Drawing.Size(87, 20);
            this.tbPersID.TabIndex = 1;
            this.tbPersID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPersID_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Personal ID Code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Password";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(43, 175);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(45, 13);
            this.lblInfo.TabIndex = 9;
            this.lblInfo.Text = "RFID is ";
            // 
            // LogInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 265);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.tbPersID);
            this.Controls.Add(this.tbPass);
            this.Controls.Add(this.btnNormalLog);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnQuit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LogInForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Festival - Log In";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnNormalLog;
        private System.Windows.Forms.TextBox tbPass;
        private System.Windows.Forms.TextBox tbPersID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblInfo;
    }
}

