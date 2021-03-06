﻿namespace AvertiFestivalApplication
{
    partial class FestivalAppForm
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
            this.TabControl = new System.Windows.Forms.TabControl();
            this.tabSales = new System.Windows.Forms.TabPage();
            this.btnDelete = new System.Windows.Forms.Button();
            this.SelectAnArticle = new System.Windows.Forms.Label();
            this.cbxSortArticle = new System.Windows.Forms.ComboBox();
            this.lbWallet = new System.Windows.Forms.Label();
            this.lbOrder = new System.Windows.Forms.ListBox();
            this.btnSTCancel = new System.Windows.Forms.Button();
            this.btnSTCompleteOrder = new System.Windows.Forms.Button();
            this.lblSTNewWalletCredit = new System.Windows.Forms.Label();
            this.btnSTAddToOrder = new System.Windows.Forms.Button();
            this.NUDSTArticleAmount = new System.Windows.Forms.NumericUpDown();
            this.cbxNameArticles = new System.Windows.Forms.ComboBox();
            this.lblCostumerWallet = new System.Windows.Forms.Label();
            this.tbxRFID = new System.Windows.Forms.TextBox();
            this.lbFRID = new System.Windows.Forms.Label();
            this.tabCheckIn = new System.Windows.Forms.TabPage();
            this.lbUnassigned = new System.Windows.Forms.Label();
            this.lbAssigned = new System.Windows.Forms.Label();
            this.btnCheckTicket = new System.Windows.Forms.Button();
            this.btnCheckInSubmit = new System.Windows.Forms.Button();
            this.tbxCheckInID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabDBView = new System.Windows.Forms.TabPage();
            this.btnShowSQL = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cbxDTSelectArticle = new System.Windows.Forms.ComboBox();
            this.lblSelectArticle = new System.Windows.Forms.Label();
            this.cbxDTSelectCampSpot = new System.Windows.Forms.ComboBox();
            this.lblSelectCSpot = new System.Windows.Forms.Label();
            this.cbxDTSelectEvent = new System.Windows.Forms.ComboBox();
            this.lblSelectEvent = new System.Windows.Forms.Label();
            this.tbxDTPErsonID = new System.Windows.Forms.TextBox();
            this.lblPersonID = new System.Windows.Forms.Label();
            this.cbxDTInfoType = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tabEvent = new System.Windows.Forms.TabPage();
            this.listBoxEventSelect = new System.Windows.Forms.ListBox();
            this.tabNewEvent = new System.Windows.Forms.Panel();
            this.tbxETEventMinage = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tbxETEventName = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnETSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.richTbxETDescription = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxETdate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxETLocation = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxETMaxCamp = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbxETMaxTickets = new System.Windows.Forms.TextBox();
            this.btnETNewEvent = new System.Windows.Forms.Button();
            this.btnETViewEvents = new System.Windows.Forms.Button();
            this.tabOv = new System.Windows.Forms.TabPage();
            this.lbxOvInfo = new System.Windows.Forms.ListBox();
            this.btnOvRefresh = new System.Windows.Forms.Button();
            this.tabAccounts = new System.Windows.Forms.TabPage();
            this.AccountInfoPanel = new System.Windows.Forms.Panel();
            this.lblAccPID = new System.Windows.Forms.Label();
            this.btnAccCancel = new System.Windows.Forms.Button();
            this.btnAccSave = new System.Windows.Forms.Button();
            this.tbxAccPass = new System.Windows.Forms.TextBox();
            this.lblAccPass = new System.Windows.Forms.Label();
            this.tbxAccEmail = new System.Windows.Forms.TextBox();
            this.lblAccEmail = new System.Windows.Forms.Label();
            this.tbxAccName = new System.Windows.Forms.TextBox();
            this.lblAccName = new System.Windows.Forms.Label();
            this.cbxAccDesc = new System.Windows.Forms.ComboBox();
            this.lblAccDesc = new System.Windows.Forms.Label();
            this.lbAccIdNrInfo = new System.Windows.Forms.Label();
            this.btnNewAccount = new System.Windows.Forms.Button();
            this.lbxAccounts = new System.Windows.Forms.ListBox();
            this.TabControl.SuspendLayout();
            this.tabSales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDSTArticleAmount)).BeginInit();
            this.tabCheckIn.SuspendLayout();
            this.tabDBView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabEvent.SuspendLayout();
            this.tabNewEvent.SuspendLayout();
            this.tabOv.SuspendLayout();
            this.tabAccounts.SuspendLayout();
            this.AccountInfoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.tabSales);
            this.TabControl.Controls.Add(this.tabCheckIn);
            this.TabControl.Controls.Add(this.tabDBView);
            this.TabControl.Controls.Add(this.tabEvent);
            this.TabControl.Controls.Add(this.tabOv);
            this.TabControl.Controls.Add(this.tabAccounts);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.Location = new System.Drawing.Point(0, 0);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(784, 602);
            this.TabControl.TabIndex = 0;
            // 
            // tabSales
            // 
            this.tabSales.Controls.Add(this.btnDelete);
            this.tabSales.Controls.Add(this.SelectAnArticle);
            this.tabSales.Controls.Add(this.cbxSortArticle);
            this.tabSales.Controls.Add(this.lbWallet);
            this.tabSales.Controls.Add(this.lbOrder);
            this.tabSales.Controls.Add(this.btnSTCancel);
            this.tabSales.Controls.Add(this.btnSTCompleteOrder);
            this.tabSales.Controls.Add(this.lblSTNewWalletCredit);
            this.tabSales.Controls.Add(this.btnSTAddToOrder);
            this.tabSales.Controls.Add(this.NUDSTArticleAmount);
            this.tabSales.Controls.Add(this.cbxNameArticles);
            this.tabSales.Controls.Add(this.lblCostumerWallet);
            this.tabSales.Controls.Add(this.tbxRFID);
            this.tabSales.Controls.Add(this.lbFRID);
            this.tabSales.Location = new System.Drawing.Point(4, 22);
            this.tabSales.Name = "tabSales";
            this.tabSales.Padding = new System.Windows.Forms.Padding(2);
            this.tabSales.Size = new System.Drawing.Size(776, 576);
            this.tabSales.TabIndex = 0;
            this.tabSales.Text = "Sales";
            this.tabSales.ToolTipText = "All transactions are to be made here.";
            this.tabSales.UseVisualStyleBackColor = true;
            this.tabSales.Click += new System.EventHandler(this.tabSales_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(417, 135);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 23);
            this.btnDelete.TabIndex = 17;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // SelectAnArticle
            // 
            this.SelectAnArticle.AutoSize = true;
            this.SelectAnArticle.Location = new System.Drawing.Point(9, 106);
            this.SelectAnArticle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SelectAnArticle.Name = "SelectAnArticle";
            this.SelectAnArticle.Size = new System.Drawing.Size(86, 13);
            this.SelectAnArticle.TabIndex = 16;
            this.SelectAnArticle.Text = "Select an article:";
            // 
            // cbxSortArticle
            // 
            this.cbxSortArticle.FormattingEnabled = true;
            this.cbxSortArticle.Location = new System.Drawing.Point(11, 135);
            this.cbxSortArticle.Margin = new System.Windows.Forms.Padding(2);
            this.cbxSortArticle.Name = "cbxSortArticle";
            this.cbxSortArticle.Size = new System.Drawing.Size(92, 21);
            this.cbxSortArticle.TabIndex = 14;
            this.cbxSortArticle.Tag = "";
            this.cbxSortArticle.Text = "Sort of article";
            this.cbxSortArticle.SelectedIndexChanged += new System.EventHandler(this.cbxSortArticle_SelectedIndexChanged);
            // 
            // lbWallet
            // 
            this.lbWallet.AutoSize = true;
            this.lbWallet.Location = new System.Drawing.Point(112, 63);
            this.lbWallet.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbWallet.Name = "lbWallet";
            this.lbWallet.Size = new System.Drawing.Size(0, 13);
            this.lbWallet.TabIndex = 13;
            // 
            // lbOrder
            // 
            this.lbOrder.Location = new System.Drawing.Point(11, 172);
            this.lbOrder.Name = "lbOrder";
            this.lbOrder.Size = new System.Drawing.Size(418, 212);
            this.lbOrder.TabIndex = 12;
            // 
            // btnSTCancel
            // 
            this.btnSTCancel.Location = new System.Drawing.Point(205, 454);
            this.btnSTCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSTCancel.Name = "btnSTCancel";
            this.btnSTCancel.Size = new System.Drawing.Size(99, 23);
            this.btnSTCancel.TabIndex = 11;
            this.btnSTCancel.Text = "Cancel Order";
            this.btnSTCancel.UseVisualStyleBackColor = true;
            this.btnSTCancel.Click += new System.EventHandler(this.btnSTCancel_Click);
            // 
            // btnSTCompleteOrder
            // 
            this.btnSTCompleteOrder.Location = new System.Drawing.Point(11, 454);
            this.btnSTCompleteOrder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSTCompleteOrder.Name = "btnSTCompleteOrder";
            this.btnSTCompleteOrder.Size = new System.Drawing.Size(99, 23);
            this.btnSTCompleteOrder.TabIndex = 10;
            this.btnSTCompleteOrder.Text = "Complete Order";
            this.btnSTCompleteOrder.UseVisualStyleBackColor = true;
            this.btnSTCompleteOrder.Click += new System.EventHandler(this.btnSTCompleteOrder_Click);
            // 
            // lblSTNewWalletCredit
            // 
            this.lblSTNewWalletCredit.AutoSize = true;
            this.lblSTNewWalletCredit.Location = new System.Drawing.Point(9, 410);
            this.lblSTNewWalletCredit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSTNewWalletCredit.Name = "lblSTNewWalletCredit";
            this.lblSTNewWalletCredit.Size = new System.Drawing.Size(144, 13);
            this.lblSTNewWalletCredit.TabIndex = 9;
            this.lblSTNewWalletCredit.Text = "Wallet Credit after purchase: ";
            // 
            // btnSTAddToOrder
            // 
            this.btnSTAddToOrder.Location = new System.Drawing.Point(324, 135);
            this.btnSTAddToOrder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSTAddToOrder.Name = "btnSTAddToOrder";
            this.btnSTAddToOrder.Size = new System.Drawing.Size(75, 23);
            this.btnSTAddToOrder.TabIndex = 7;
            this.btnSTAddToOrder.Text = "Add to order";
            this.btnSTAddToOrder.UseVisualStyleBackColor = true;
            this.btnSTAddToOrder.Click += new System.EventHandler(this.btnSTAddToOrder_Click);
            // 
            // NUDSTArticleAmount
            // 
            this.NUDSTArticleAmount.Location = new System.Drawing.Point(266, 135);
            this.NUDSTArticleAmount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.NUDSTArticleAmount.Name = "NUDSTArticleAmount";
            this.NUDSTArticleAmount.Size = new System.Drawing.Size(38, 20);
            this.NUDSTArticleAmount.TabIndex = 6;
            this.NUDSTArticleAmount.ValueChanged += new System.EventHandler(this.NUDSTArticleAmount_ValueChanged);
            // 
            // cbxNameArticles
            // 
            this.cbxNameArticles.FormattingEnabled = true;
            this.cbxNameArticles.Location = new System.Drawing.Point(122, 135);
            this.cbxNameArticles.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxNameArticles.Name = "cbxNameArticles";
            this.cbxNameArticles.Size = new System.Drawing.Size(121, 21);
            this.cbxNameArticles.TabIndex = 5;
            this.cbxNameArticles.Text = "Name of article";
            this.cbxNameArticles.SelectedIndexChanged += new System.EventHandler(this.cbxNameArticles_SelectedIndexChanged);
            // 
            // lblCostumerWallet
            // 
            this.lblCostumerWallet.AutoSize = true;
            this.lblCostumerWallet.Location = new System.Drawing.Point(9, 63);
            this.lblCostumerWallet.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCostumerWallet.Name = "lblCostumerWallet";
            this.lblCostumerWallet.Size = new System.Drawing.Size(73, 13);
            this.lblCostumerWallet.TabIndex = 4;
            this.lblCostumerWallet.Text = "Wallet Credit: ";
            // 
            // tbxRFID
            // 
            this.tbxRFID.Location = new System.Drawing.Point(74, 24);
            this.tbxRFID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbxRFID.Name = "tbxRFID";
            this.tbxRFID.ReadOnly = true;
            this.tbxRFID.Size = new System.Drawing.Size(170, 20);
            this.tbxRFID.TabIndex = 1;
            // 
            // lbFRID
            // 
            this.lbFRID.AutoSize = true;
            this.lbFRID.Location = new System.Drawing.Point(16, 24);
            this.lbFRID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbFRID.Name = "lbFRID";
            this.lbFRID.Size = new System.Drawing.Size(38, 13);
            this.lbFRID.TabIndex = 0;
            this.lbFRID.Text = "RFID :";
            // 
            // tabCheckIn
            // 
            this.tabCheckIn.Controls.Add(this.lbUnassigned);
            this.tabCheckIn.Controls.Add(this.lbAssigned);
            this.tabCheckIn.Controls.Add(this.btnCheckTicket);
            this.tabCheckIn.Controls.Add(this.btnCheckInSubmit);
            this.tabCheckIn.Controls.Add(this.tbxCheckInID);
            this.tabCheckIn.Controls.Add(this.label1);
            this.tabCheckIn.Location = new System.Drawing.Point(4, 22);
            this.tabCheckIn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabCheckIn.Name = "tabCheckIn";
            this.tabCheckIn.Padding = new System.Windows.Forms.Padding(3);
            this.tabCheckIn.Size = new System.Drawing.Size(776, 576);
            this.tabCheckIn.TabIndex = 1;
            this.tabCheckIn.Text = "Check In/Out";
            this.tabCheckIn.UseVisualStyleBackColor = true;
            // 
            // lbUnassigned
            // 
            this.lbUnassigned.AutoSize = true;
            this.lbUnassigned.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUnassigned.Location = new System.Drawing.Point(202, 208);
            this.lbUnassigned.Name = "lbUnassigned";
            this.lbUnassigned.Size = new System.Drawing.Size(293, 37);
            this.lbUnassigned.TabIndex = 13;
            this.lbUnassigned.Text = "RFID: Unassigned";
            this.lbUnassigned.Visible = false;
            // 
            // lbAssigned
            // 
            this.lbAssigned.AutoSize = true;
            this.lbAssigned.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAssigned.Location = new System.Drawing.Point(202, 60);
            this.lbAssigned.Name = "lbAssigned";
            this.lbAssigned.Size = new System.Drawing.Size(418, 39);
            this.lbAssigned.TabIndex = 13;
            this.lbAssigned.Text = "RFID: Assigned to ********";
            this.lbAssigned.Visible = false;
            // 
            // btnCheckTicket
            // 
            this.btnCheckTicket.Location = new System.Drawing.Point(405, 157);
            this.btnCheckTicket.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCheckTicket.Name = "btnCheckTicket";
            this.btnCheckTicket.Size = new System.Drawing.Size(98, 23);
            this.btnCheckTicket.TabIndex = 12;
            this.btnCheckTicket.Text = "Check Ticket";
            this.btnCheckTicket.UseVisualStyleBackColor = true;
            this.btnCheckTicket.Click += new System.EventHandler(this.btnCheckTicket_Click);
            // 
            // btnCheckInSubmit
            // 
            this.btnCheckInSubmit.Location = new System.Drawing.Point(324, 287);
            this.btnCheckInSubmit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCheckInSubmit.Name = "btnCheckInSubmit";
            this.btnCheckInSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnCheckInSubmit.TabIndex = 11;
            this.btnCheckInSubmit.Text = "Check out";
            this.btnCheckInSubmit.UseVisualStyleBackColor = true;
            this.btnCheckInSubmit.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // tbxCheckInID
            // 
            this.tbxCheckInID.Location = new System.Drawing.Point(299, 157);
            this.tbxCheckInID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbxCheckInID.Name = "tbxCheckInID";
            this.tbxCheckInID.Size = new System.Drawing.Size(100, 20);
            this.tbxCheckInID.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(216, 157);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Ticket Number";
            // 
            // tabDBView
            // 
            this.tabDBView.Controls.Add(this.btnShowSQL);
            this.tabDBView.Controls.Add(this.btnShow);
            this.tabDBView.Controls.Add(this.dataGridView1);
            this.tabDBView.Controls.Add(this.cbxDTSelectArticle);
            this.tabDBView.Controls.Add(this.lblSelectArticle);
            this.tabDBView.Controls.Add(this.cbxDTSelectCampSpot);
            this.tabDBView.Controls.Add(this.lblSelectCSpot);
            this.tabDBView.Controls.Add(this.cbxDTSelectEvent);
            this.tabDBView.Controls.Add(this.lblSelectEvent);
            this.tabDBView.Controls.Add(this.tbxDTPErsonID);
            this.tabDBView.Controls.Add(this.lblPersonID);
            this.tabDBView.Controls.Add(this.cbxDTInfoType);
            this.tabDBView.Controls.Add(this.label10);
            this.tabDBView.Location = new System.Drawing.Point(4, 22);
            this.tabDBView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabDBView.Name = "tabDBView";
            this.tabDBView.Size = new System.Drawing.Size(776, 576);
            this.tabDBView.TabIndex = 2;
            this.tabDBView.Text = "Database view";
            this.tabDBView.UseVisualStyleBackColor = true;
            // 
            // btnShowSQL
            // 
            this.btnShowSQL.Location = new System.Drawing.Point(271, 50);
            this.btnShowSQL.Margin = new System.Windows.Forms.Padding(2);
            this.btnShowSQL.Name = "btnShowSQL";
            this.btnShowSQL.Size = new System.Drawing.Size(67, 19);
            this.btnShowSQL.TabIndex = 12;
            this.btnShowSQL.Text = "Show";
            this.btnShowSQL.UseVisualStyleBackColor = true;
            this.btnShowSQL.Click += new System.EventHandler(this.btnShowSQL_Click);
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(271, 23);
            this.btnShow.Margin = new System.Windows.Forms.Padding(2);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(67, 19);
            this.btnShow.TabIndex = 11;
            this.btnShow.Text = "Select";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(11, 197);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(628, 269);
            this.dataGridView1.TabIndex = 10;
            // 
            // cbxDTSelectArticle
            // 
            this.cbxDTSelectArticle.AutoCompleteCustomSource.AddRange(new string[] {
            "Person",
            "Event",
            "Camping",
            "Sales"});
            this.cbxDTSelectArticle.FormattingEnabled = true;
            this.cbxDTSelectArticle.Location = new System.Drawing.Point(133, 131);
            this.cbxDTSelectArticle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxDTSelectArticle.Name = "cbxDTSelectArticle";
            this.cbxDTSelectArticle.Size = new System.Drawing.Size(121, 21);
            this.cbxDTSelectArticle.TabIndex = 9;
            this.cbxDTSelectArticle.Text = "Articles";
            this.cbxDTSelectArticle.Visible = false;
            // 
            // lblSelectArticle
            // 
            this.lblSelectArticle.AutoSize = true;
            this.lblSelectArticle.Location = new System.Drawing.Point(8, 134);
            this.lblSelectArticle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSelectArticle.Name = "lblSelectArticle";
            this.lblSelectArticle.Size = new System.Drawing.Size(69, 13);
            this.lblSelectArticle.TabIndex = 8;
            this.lblSelectArticle.Text = "Select Article";
            this.lblSelectArticle.Visible = false;
            // 
            // cbxDTSelectCampSpot
            // 
            this.cbxDTSelectCampSpot.AutoCompleteCustomSource.AddRange(new string[] {
            "Person",
            "Event",
            "Camping",
            "Sales"});
            this.cbxDTSelectCampSpot.FormattingEnabled = true;
            this.cbxDTSelectCampSpot.Location = new System.Drawing.Point(133, 104);
            this.cbxDTSelectCampSpot.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxDTSelectCampSpot.Name = "cbxDTSelectCampSpot";
            this.cbxDTSelectCampSpot.Size = new System.Drawing.Size(121, 21);
            this.cbxDTSelectCampSpot.TabIndex = 7;
            this.cbxDTSelectCampSpot.Text = "Camp Nrs";
            this.cbxDTSelectCampSpot.Visible = false;
            // 
            // lblSelectCSpot
            // 
            this.lblSelectCSpot.AutoSize = true;
            this.lblSelectCSpot.Location = new System.Drawing.Point(8, 107);
            this.lblSelectCSpot.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSelectCSpot.Name = "lblSelectCSpot";
            this.lblSelectCSpot.Size = new System.Drawing.Size(106, 13);
            this.lblSelectCSpot.TabIndex = 6;
            this.lblSelectCSpot.Text = "Select Camping Spot";
            this.lblSelectCSpot.Visible = false;
            // 
            // cbxDTSelectEvent
            // 
            this.cbxDTSelectEvent.AutoCompleteCustomSource.AddRange(new string[] {
            "Person",
            "Event",
            "Camping",
            "Sales"});
            this.cbxDTSelectEvent.FormattingEnabled = true;
            this.cbxDTSelectEvent.Location = new System.Drawing.Point(133, 77);
            this.cbxDTSelectEvent.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxDTSelectEvent.Name = "cbxDTSelectEvent";
            this.cbxDTSelectEvent.Size = new System.Drawing.Size(121, 21);
            this.cbxDTSelectEvent.TabIndex = 5;
            this.cbxDTSelectEvent.Text = "Events";
            this.cbxDTSelectEvent.Visible = false;
            // 
            // lblSelectEvent
            // 
            this.lblSelectEvent.AutoSize = true;
            this.lblSelectEvent.Location = new System.Drawing.Point(8, 80);
            this.lblSelectEvent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSelectEvent.Name = "lblSelectEvent";
            this.lblSelectEvent.Size = new System.Drawing.Size(68, 13);
            this.lblSelectEvent.TabIndex = 4;
            this.lblSelectEvent.Text = "Select Event";
            this.lblSelectEvent.Visible = false;
            // 
            // tbxDTPErsonID
            // 
            this.tbxDTPErsonID.Location = new System.Drawing.Point(133, 51);
            this.tbxDTPErsonID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbxDTPErsonID.Name = "tbxDTPErsonID";
            this.tbxDTPErsonID.Size = new System.Drawing.Size(121, 20);
            this.tbxDTPErsonID.TabIndex = 3;
            this.tbxDTPErsonID.Visible = false;
            // 
            // lblPersonID
            // 
            this.lblPersonID.AutoSize = true;
            this.lblPersonID.Location = new System.Drawing.Point(8, 54);
            this.lblPersonID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPersonID.Name = "lblPersonID";
            this.lblPersonID.Size = new System.Drawing.Size(54, 13);
            this.lblPersonID.TabIndex = 2;
            this.lblPersonID.Text = "Person ID";
            this.lblPersonID.Visible = false;
            // 
            // cbxDTInfoType
            // 
            this.cbxDTInfoType.AutoCompleteCustomSource.AddRange(new string[] {
            "Person",
            "Event",
            "Camping",
            "Sales"});
            this.cbxDTInfoType.FormattingEnabled = true;
            this.cbxDTInfoType.Items.AddRange(new object[] {
            "Event",
            "Person ",
            "Camping",
            "Sales"});
            this.cbxDTInfoType.Location = new System.Drawing.Point(133, 24);
            this.cbxDTInfoType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxDTInfoType.Name = "cbxDTInfoType";
            this.cbxDTInfoType.Size = new System.Drawing.Size(121, 21);
            this.cbxDTInfoType.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 32);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Select Type of info";
            // 
            // tabEvent
            // 
            this.tabEvent.Controls.Add(this.listBoxEventSelect);
            this.tabEvent.Controls.Add(this.tabNewEvent);
            this.tabEvent.Controls.Add(this.btnETNewEvent);
            this.tabEvent.Controls.Add(this.btnETViewEvents);
            this.tabEvent.Location = new System.Drawing.Point(4, 22);
            this.tabEvent.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabEvent.Name = "tabEvent";
            this.tabEvent.Size = new System.Drawing.Size(776, 576);
            this.tabEvent.TabIndex = 3;
            this.tabEvent.Text = "Event";
            this.tabEvent.ToolTipText = "Create, change or delete an event";
            this.tabEvent.UseVisualStyleBackColor = true;
            // 
            // listBoxEventSelect
            // 
            this.listBoxEventSelect.FormattingEnabled = true;
            this.listBoxEventSelect.Location = new System.Drawing.Point(37, 155);
            this.listBoxEventSelect.Name = "listBoxEventSelect";
            this.listBoxEventSelect.Size = new System.Drawing.Size(201, 329);
            this.listBoxEventSelect.TabIndex = 21;
            this.listBoxEventSelect.SelectedIndexChanged += new System.EventHandler(this.listBoxEventSelect_SelectedIndexChanged);
            // 
            // tabNewEvent
            // 
            this.tabNewEvent.Controls.Add(this.tbxETEventMinage);
            this.tabNewEvent.Controls.Add(this.label15);
            this.tabNewEvent.Controls.Add(this.tbxETEventName);
            this.tabNewEvent.Controls.Add(this.btnCancel);
            this.tabNewEvent.Controls.Add(this.label3);
            this.tabNewEvent.Controls.Add(this.btnETSave);
            this.tabNewEvent.Controls.Add(this.label4);
            this.tabNewEvent.Controls.Add(this.richTbxETDescription);
            this.tabNewEvent.Controls.Add(this.label5);
            this.tabNewEvent.Controls.Add(this.tbxETdate);
            this.tabNewEvent.Controls.Add(this.label6);
            this.tabNewEvent.Controls.Add(this.tbxETLocation);
            this.tabNewEvent.Controls.Add(this.label7);
            this.tabNewEvent.Controls.Add(this.tbxETMaxCamp);
            this.tabNewEvent.Controls.Add(this.label8);
            this.tabNewEvent.Controls.Add(this.tbxETMaxTickets);
            this.tabNewEvent.Location = new System.Drawing.Point(256, 64);
            this.tabNewEvent.Name = "tabNewEvent";
            this.tabNewEvent.Size = new System.Drawing.Size(498, 465);
            this.tabNewEvent.TabIndex = 20;
            this.tabNewEvent.Visible = false;
            // 
            // tbxETEventMinage
            // 
            this.tbxETEventMinage.Location = new System.Drawing.Point(49, 233);
            this.tbxETEventMinage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbxETEventMinage.Name = "tbxETEventMinage";
            this.tbxETEventMinage.Size = new System.Drawing.Size(51, 20);
            this.tbxETEventMinage.TabIndex = 25;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(144, 236);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(280, 13);
            this.label15.TabIndex = 24;
            this.label15.Text = "Specify the minimum age of participants allowed to attend.";
            // 
            // tbxETEventName
            // 
            this.tbxETEventName.Location = new System.Drawing.Point(149, 15);
            this.tbxETEventName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbxETEventName.Name = "tbxETEventName";
            this.tbxETEventName.Size = new System.Drawing.Size(246, 20);
            this.tbxETEventName.TabIndex = 11;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(296, 393);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(101, 23);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Clear";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 18);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Event Name";
            // 
            // btnETSave
            // 
            this.btnETSave.Location = new System.Drawing.Point(64, 393);
            this.btnETSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnETSave.Name = "btnETSave";
            this.btnETSave.Size = new System.Drawing.Size(101, 23);
            this.btnETSave.TabIndex = 18;
            this.btnETSave.Text = "Save";
            this.btnETSave.UseVisualStyleBackColor = true;
            this.btnETSave.Click += new System.EventHandler(this.btnETSave_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 62);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Max tickets";
            // 
            // richTbxETDescription
            // 
            this.richTbxETDescription.Location = new System.Drawing.Point(149, 274);
            this.richTbxETDescription.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.richTbxETDescription.Name = "richTbxETDescription";
            this.richTbxETDescription.Size = new System.Drawing.Size(248, 99);
            this.richTbxETDescription.TabIndex = 17;
            this.richTbxETDescription.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 109);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Max camping";
            // 
            // tbxETdate
            // 
            this.tbxETdate.Location = new System.Drawing.Point(149, 148);
            this.tbxETdate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbxETdate.Name = "tbxETdate";
            this.tbxETdate.Size = new System.Drawing.Size(248, 20);
            this.tbxETdate.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(48, 154);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Event Date";
            // 
            // tbxETLocation
            // 
            this.tbxETLocation.Location = new System.Drawing.Point(149, 193);
            this.tbxETLocation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbxETLocation.Name = "tbxETLocation";
            this.tbxETLocation.Size = new System.Drawing.Size(248, 20);
            this.tbxETLocation.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(48, 196);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Location";
            // 
            // tbxETMaxCamp
            // 
            this.tbxETMaxCamp.Location = new System.Drawing.Point(149, 106);
            this.tbxETMaxCamp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbxETMaxCamp.Name = "tbxETMaxCamp";
            this.tbxETMaxCamp.Size = new System.Drawing.Size(248, 20);
            this.tbxETMaxCamp.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(48, 277);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Description";
            // 
            // tbxETMaxTickets
            // 
            this.tbxETMaxTickets.Location = new System.Drawing.Point(149, 62);
            this.tbxETMaxTickets.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbxETMaxTickets.Name = "tbxETMaxTickets";
            this.tbxETMaxTickets.Size = new System.Drawing.Size(248, 20);
            this.tbxETMaxTickets.TabIndex = 12;
            // 
            // btnETNewEvent
            // 
            this.btnETNewEvent.Location = new System.Drawing.Point(37, 76);
            this.btnETNewEvent.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnETNewEvent.Name = "btnETNewEvent";
            this.btnETNewEvent.Size = new System.Drawing.Size(201, 23);
            this.btnETNewEvent.TabIndex = 9;
            this.btnETNewEvent.Text = "New Event";
            this.btnETNewEvent.UseVisualStyleBackColor = true;
            this.btnETNewEvent.Click += new System.EventHandler(this.btnETNewEvent_Click);
            // 
            // btnETViewEvents
            // 
            this.btnETViewEvents.Location = new System.Drawing.Point(37, 109);
            this.btnETViewEvents.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnETViewEvents.Name = "btnETViewEvents";
            this.btnETViewEvents.Size = new System.Drawing.Size(201, 23);
            this.btnETViewEvents.TabIndex = 8;
            this.btnETViewEvents.Text = "View All Events";
            this.btnETViewEvents.UseVisualStyleBackColor = true;
            this.btnETViewEvents.Click += new System.EventHandler(this.btnETSelectEvent_Click);
            // 
            // tabOv
            // 
            this.tabOv.Controls.Add(this.lbxOvInfo);
            this.tabOv.Controls.Add(this.btnOvRefresh);
            this.tabOv.Location = new System.Drawing.Point(4, 22);
            this.tabOv.Name = "tabOv";
            this.tabOv.Padding = new System.Windows.Forms.Padding(3);
            this.tabOv.Size = new System.Drawing.Size(776, 576);
            this.tabOv.TabIndex = 4;
            this.tabOv.Text = "Overview";
            this.tabOv.UseVisualStyleBackColor = true;
            // 
            // lbxOvInfo
            // 
            this.lbxOvInfo.FormattingEnabled = true;
            this.lbxOvInfo.Location = new System.Drawing.Point(8, 6);
            this.lbxOvInfo.Name = "lbxOvInfo";
            this.lbxOvInfo.Size = new System.Drawing.Size(262, 290);
            this.lbxOvInfo.TabIndex = 1;
            // 
            // btnOvRefresh
            // 
            this.btnOvRefresh.Location = new System.Drawing.Point(8, 302);
            this.btnOvRefresh.Name = "btnOvRefresh";
            this.btnOvRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnOvRefresh.TabIndex = 0;
            this.btnOvRefresh.Text = "Refresh";
            this.btnOvRefresh.UseVisualStyleBackColor = true;
            this.btnOvRefresh.Click += new System.EventHandler(this.btnOvRefresh_Click);
            // 
            // tabAccounts
            // 
            this.tabAccounts.Controls.Add(this.AccountInfoPanel);
            this.tabAccounts.Controls.Add(this.btnNewAccount);
            this.tabAccounts.Controls.Add(this.lbxAccounts);
            this.tabAccounts.Location = new System.Drawing.Point(4, 22);
            this.tabAccounts.Name = "tabAccounts";
            this.tabAccounts.Size = new System.Drawing.Size(776, 576);
            this.tabAccounts.TabIndex = 5;
            this.tabAccounts.Text = "Accounts";
            this.tabAccounts.UseVisualStyleBackColor = true;
            // 
            // AccountInfoPanel
            // 
            this.AccountInfoPanel.Controls.Add(this.lblAccPID);
            this.AccountInfoPanel.Controls.Add(this.btnAccCancel);
            this.AccountInfoPanel.Controls.Add(this.btnAccSave);
            this.AccountInfoPanel.Controls.Add(this.tbxAccPass);
            this.AccountInfoPanel.Controls.Add(this.lblAccPass);
            this.AccountInfoPanel.Controls.Add(this.tbxAccEmail);
            this.AccountInfoPanel.Controls.Add(this.lblAccEmail);
            this.AccountInfoPanel.Controls.Add(this.tbxAccName);
            this.AccountInfoPanel.Controls.Add(this.lblAccName);
            this.AccountInfoPanel.Controls.Add(this.cbxAccDesc);
            this.AccountInfoPanel.Controls.Add(this.lblAccDesc);
            this.AccountInfoPanel.Controls.Add(this.lbAccIdNrInfo);
            this.AccountInfoPanel.Location = new System.Drawing.Point(338, 62);
            this.AccountInfoPanel.Name = "AccountInfoPanel";
            this.AccountInfoPanel.Size = new System.Drawing.Size(381, 368);
            this.AccountInfoPanel.TabIndex = 2;
            // 
            // lblAccPID
            // 
            this.lblAccPID.AutoSize = true;
            this.lblAccPID.Location = new System.Drawing.Point(195, 10);
            this.lblAccPID.Name = "lblAccPID";
            this.lblAccPID.Size = new System.Drawing.Size(0, 13);
            this.lblAccPID.TabIndex = 13;
            // 
            // btnAccCancel
            // 
            this.btnAccCancel.Location = new System.Drawing.Point(244, 316);
            this.btnAccCancel.Name = "btnAccCancel";
            this.btnAccCancel.Size = new System.Drawing.Size(75, 23);
            this.btnAccCancel.TabIndex = 12;
            this.btnAccCancel.Text = "Cancel";
            this.btnAccCancel.UseVisualStyleBackColor = true;
            this.btnAccCancel.Click += new System.EventHandler(this.btnAccCancel_Click);
            // 
            // btnAccSave
            // 
            this.btnAccSave.Location = new System.Drawing.Point(20, 316);
            this.btnAccSave.Name = "btnAccSave";
            this.btnAccSave.Size = new System.Drawing.Size(75, 23);
            this.btnAccSave.TabIndex = 11;
            this.btnAccSave.Text = "Save";
            this.btnAccSave.UseVisualStyleBackColor = true;
            this.btnAccSave.Click += new System.EventHandler(this.btnAccSave_Click);
            // 
            // tbxAccPass
            // 
            this.tbxAccPass.Location = new System.Drawing.Point(198, 189);
            this.tbxAccPass.Name = "tbxAccPass";
            this.tbxAccPass.Size = new System.Drawing.Size(121, 20);
            this.tbxAccPass.TabIndex = 10;
            this.tbxAccPass.UseSystemPasswordChar = true;
            // 
            // lblAccPass
            // 
            this.lblAccPass.AutoSize = true;
            this.lblAccPass.Location = new System.Drawing.Point(17, 192);
            this.lblAccPass.Name = "lblAccPass";
            this.lblAccPass.Size = new System.Drawing.Size(53, 13);
            this.lblAccPass.TabIndex = 9;
            this.lblAccPass.Text = "Password";
            // 
            // tbxAccEmail
            // 
            this.tbxAccEmail.Location = new System.Drawing.Point(198, 139);
            this.tbxAccEmail.Name = "tbxAccEmail";
            this.tbxAccEmail.Size = new System.Drawing.Size(121, 20);
            this.tbxAccEmail.TabIndex = 8;
            // 
            // lblAccEmail
            // 
            this.lblAccEmail.AutoSize = true;
            this.lblAccEmail.Location = new System.Drawing.Point(17, 142);
            this.lblAccEmail.Name = "lblAccEmail";
            this.lblAccEmail.Size = new System.Drawing.Size(35, 13);
            this.lblAccEmail.TabIndex = 7;
            this.lblAccEmail.Text = "E-mail";
            // 
            // tbxAccName
            // 
            this.tbxAccName.Location = new System.Drawing.Point(198, 96);
            this.tbxAccName.Name = "tbxAccName";
            this.tbxAccName.Size = new System.Drawing.Size(121, 20);
            this.tbxAccName.TabIndex = 3;
            // 
            // lblAccName
            // 
            this.lblAccName.AutoSize = true;
            this.lblAccName.Location = new System.Drawing.Point(17, 99);
            this.lblAccName.Name = "lblAccName";
            this.lblAccName.Size = new System.Drawing.Size(35, 13);
            this.lblAccName.TabIndex = 6;
            this.lblAccName.Text = "Name";
            // 
            // cbxAccDesc
            // 
            this.cbxAccDesc.FormattingEnabled = true;
            this.cbxAccDesc.Items.AddRange(new object[] {
            "Sales Person",
            "Ticket Checker",
            "Admin"});
            this.cbxAccDesc.Location = new System.Drawing.Point(198, 49);
            this.cbxAccDesc.Name = "cbxAccDesc";
            this.cbxAccDesc.Size = new System.Drawing.Size(121, 21);
            this.cbxAccDesc.TabIndex = 5;
            // 
            // lblAccDesc
            // 
            this.lblAccDesc.AutoSize = true;
            this.lblAccDesc.Location = new System.Drawing.Point(17, 52);
            this.lblAccDesc.Name = "lblAccDesc";
            this.lblAccDesc.Size = new System.Drawing.Size(62, 13);
            this.lblAccDesc.TabIndex = 4;
            this.lblAccDesc.Text = "Department";
            // 
            // lbAccIdNrInfo
            // 
            this.lbAccIdNrInfo.AutoSize = true;
            this.lbAccIdNrInfo.Location = new System.Drawing.Point(17, 10);
            this.lbAccIdNrInfo.Name = "lbAccIdNrInfo";
            this.lbAccIdNrInfo.Size = new System.Drawing.Size(106, 13);
            this.lbAccIdNrInfo.TabIndex = 3;
            this.lbAccIdNrInfo.Text = "Personal ID number: ";
            // 
            // btnNewAccount
            // 
            this.btnNewAccount.Location = new System.Drawing.Point(25, 62);
            this.btnNewAccount.Name = "btnNewAccount";
            this.btnNewAccount.Size = new System.Drawing.Size(154, 23);
            this.btnNewAccount.TabIndex = 1;
            this.btnNewAccount.Text = "Add a new account";
            this.btnNewAccount.UseVisualStyleBackColor = true;
            this.btnNewAccount.Click += new System.EventHandler(this.btnNewAccount_Click);
            // 
            // lbxAccounts
            // 
            this.lbxAccounts.FormattingEnabled = true;
            this.lbxAccounts.Location = new System.Drawing.Point(25, 114);
            this.lbxAccounts.Name = "lbxAccounts";
            this.lbxAccounts.Size = new System.Drawing.Size(154, 316);
            this.lbxAccounts.TabIndex = 0;
            this.lbxAccounts.SelectedIndexChanged += new System.EventHandler(this.lbxAccounts_SelectedIndexChanged);
            this.lbxAccounts.SelectedValueChanged += new System.EventHandler(this.lbxAccounts_SelectedIndexChanged);
            // 
            // FestivalAppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 602);
            this.Controls.Add(this.TabControl);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FestivalAppForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Averti Festival ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FestivalAppForm_FormClosing);
            this.Load += new System.EventHandler(this.FestivalAppForm_Load);
            this.TabControl.ResumeLayout(false);
            this.tabSales.ResumeLayout(false);
            this.tabSales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDSTArticleAmount)).EndInit();
            this.tabCheckIn.ResumeLayout(false);
            this.tabCheckIn.PerformLayout();
            this.tabDBView.ResumeLayout(false);
            this.tabDBView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabEvent.ResumeLayout(false);
            this.tabNewEvent.ResumeLayout(false);
            this.tabNewEvent.PerformLayout();
            this.tabOv.ResumeLayout(false);
            this.tabAccounts.ResumeLayout(false);
            this.AccountInfoPanel.ResumeLayout(false);
            this.AccountInfoPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage tabSales;
        private System.Windows.Forms.TabPage tabCheckIn;
        private System.Windows.Forms.TabPage tabDBView;
        private System.Windows.Forms.TabPage tabEvent;
        private System.Windows.Forms.Button btnCheckInSubmit;
        private System.Windows.Forms.TextBox tbxCheckInID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxETLocation;
        private System.Windows.Forms.TextBox tbxETMaxCamp;
        private System.Windows.Forms.TextBox tbxETMaxTickets;
        private System.Windows.Forms.TextBox tbxETEventName;
        private System.Windows.Forms.Button btnETNewEvent;
        private System.Windows.Forms.Button btnETViewEvents;
        private System.Windows.Forms.DateTimePicker tbxETdate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnETSave;
        private System.Windows.Forms.RichTextBox richTbxETDescription;
        private System.Windows.Forms.TextBox tbxRFID;
        private System.Windows.Forms.Label lbFRID;
        private System.Windows.Forms.Label lblSTNewWalletCredit;
        private System.Windows.Forms.Button btnSTAddToOrder;
        private System.Windows.Forms.NumericUpDown NUDSTArticleAmount;
        private System.Windows.Forms.ComboBox cbxNameArticles;
        private System.Windows.Forms.Label lblCostumerWallet;
        private System.Windows.Forms.Button btnSTCancel;
        private System.Windows.Forms.Button btnSTCompleteOrder;
        private System.Windows.Forms.ComboBox cbxDTSelectArticle;
        private System.Windows.Forms.Label lblSelectArticle;
        private System.Windows.Forms.ComboBox cbxDTSelectCampSpot;
        private System.Windows.Forms.Label lblSelectCSpot;
        private System.Windows.Forms.ComboBox cbxDTSelectEvent;
        private System.Windows.Forms.Label lblSelectEvent;
        private System.Windows.Forms.TextBox tbxDTPErsonID;
        private System.Windows.Forms.Label lblPersonID;
        private System.Windows.Forms.ComboBox cbxDTInfoType;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnCheckTicket;
        private System.Windows.Forms.Label lbUnassigned;
        private System.Windows.Forms.ListBox lbOrder;
        private System.Windows.Forms.Label lbAssigned;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.ComboBox cbxSortArticle;
        private System.Windows.Forms.Label lbWallet;
        private System.Windows.Forms.Button btnShowSQL;
        private System.Windows.Forms.Label SelectAnArticle;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TabPage tabOv;
        private System.Windows.Forms.ListBox lbxOvInfo;
        private System.Windows.Forms.Button btnOvRefresh;
        private System.Windows.Forms.ListBox listBoxEventSelect;
        private System.Windows.Forms.Panel tabNewEvent;
        private System.Windows.Forms.TextBox tbxETEventMinage;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TabPage tabAccounts;
        private System.Windows.Forms.Button btnNewAccount;
        private System.Windows.Forms.ListBox lbxAccounts;
        private System.Windows.Forms.Panel AccountInfoPanel;
        private System.Windows.Forms.Button btnAccCancel;
        private System.Windows.Forms.Button btnAccSave;
        private System.Windows.Forms.TextBox tbxAccPass;
        private System.Windows.Forms.Label lblAccPass;
        private System.Windows.Forms.TextBox tbxAccEmail;
        private System.Windows.Forms.Label lblAccEmail;
        private System.Windows.Forms.TextBox tbxAccName;
        private System.Windows.Forms.Label lblAccName;
        private System.Windows.Forms.ComboBox cbxAccDesc;
        private System.Windows.Forms.Label lblAccDesc;
        private System.Windows.Forms.Label lbAccIdNrInfo;
        private System.Windows.Forms.Label lblAccPID;


    }
}