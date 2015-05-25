namespace AvertiFestivalApplication
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
            this.btnSTSeeDetails = new System.Windows.Forms.Button();
            this.tbxRFID = new System.Windows.Forms.TextBox();
            this.lbFRID = new System.Windows.Forms.Label();
            this.tabCheckIn = new System.Windows.Forms.TabPage();
            this.lbUnassigned = new System.Windows.Forms.Label();
            this.lbAssigned = new System.Windows.Forms.Label();
            this.btnCheckTicket = new System.Windows.Forms.Button();
            this.btnCheckInSubmit = new System.Windows.Forms.Button();
            this.tbxCheckInID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGoToDetails = new System.Windows.Forms.Button();
            this.tabDBView = new System.Windows.Forms.TabPage();
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnETSave = new System.Windows.Forms.Button();
            this.richTbxETDescription = new System.Windows.Forms.RichTextBox();
            this.dtpETEventDate = new System.Windows.Forms.DateTimePicker();
            this.tbxETLocation = new System.Windows.Forms.TextBox();
            this.tbxETMaxCamp = new System.Windows.Forms.TextBox();
            this.tbxETMaxTickets = new System.Windows.Forms.TextBox();
            this.tbxETEventName = new System.Windows.Forms.TextBox();
            this.btnETDeleteEvent = new System.Windows.Forms.Button();
            this.btnETNewEvent = new System.Windows.Forms.Button();
            this.btnETSelectEvent = new System.Windows.Forms.Button();
            this.cmbxEventSelectEvent = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.TabControl.SuspendLayout();
            this.tabSales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDSTArticleAmount)).BeginInit();
            this.tabCheckIn.SuspendLayout();
            this.tabDBView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabEvent.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.tabSales);
            this.TabControl.Controls.Add(this.tabCheckIn);
            this.TabControl.Controls.Add(this.tabDBView);
            this.TabControl.Controls.Add(this.tabEvent);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.Location = new System.Drawing.Point(0, 0);
            this.TabControl.Margin = new System.Windows.Forms.Padding(4);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(1045, 777);
            this.TabControl.TabIndex = 0;
            // 
            // tabSales
            // 
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
            this.tabSales.Controls.Add(this.btnSTSeeDetails);
            this.tabSales.Controls.Add(this.tbxRFID);
            this.tabSales.Controls.Add(this.lbFRID);
            this.tabSales.Location = new System.Drawing.Point(4, 25);
            this.tabSales.Margin = new System.Windows.Forms.Padding(4);
            this.tabSales.Name = "tabSales";
            this.tabSales.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabSales.Size = new System.Drawing.Size(1037, 748);
            this.tabSales.TabIndex = 0;
            this.tabSales.Text = "Sales";
            this.tabSales.ToolTipText = "All transactions are to be made here.";
            this.tabSales.UseVisualStyleBackColor = true;
            this.tabSales.Click += new System.EventHandler(this.tabSales_Click);
            // 
            // cbxSortArticle
            // 
            this.cbxSortArticle.FormattingEnabled = true;
            this.cbxSortArticle.Location = new System.Drawing.Point(14, 145);
            this.cbxSortArticle.Name = "cbxSortArticle";
            this.cbxSortArticle.Size = new System.Drawing.Size(121, 24);
            this.cbxSortArticle.TabIndex = 14;
            // 
            // lbWallet
            // 
            this.lbWallet.AutoSize = true;
            this.lbWallet.Location = new System.Drawing.Point(129, 86);
            this.lbWallet.Name = "lbWallet";
            this.lbWallet.Size = new System.Drawing.Size(54, 17);
            this.lbWallet.TabIndex = 13;
            this.lbWallet.Text = "label11";
            // 
            // lbOrder
            // 
            this.lbOrder.ItemHeight = 16;
            this.lbOrder.Location = new System.Drawing.Point(15, 212);
            this.lbOrder.Margin = new System.Windows.Forms.Padding(4);
            this.lbOrder.Name = "lbOrder";
            this.lbOrder.Size = new System.Drawing.Size(308, 260);
            this.lbOrder.TabIndex = 12;
            // 
            // btnSTCancel
            // 
            this.btnSTCancel.Location = new System.Drawing.Point(273, 559);
            this.btnSTCancel.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnSTCancel.Name = "btnSTCancel";
            this.btnSTCancel.Size = new System.Drawing.Size(132, 28);
            this.btnSTCancel.TabIndex = 11;
            this.btnSTCancel.Text = "Cancel Order";
            this.btnSTCancel.UseVisualStyleBackColor = true;
            this.btnSTCancel.Click += new System.EventHandler(this.btnSTCancel_Click);
            // 
            // btnSTCompleteOrder
            // 
            this.btnSTCompleteOrder.Location = new System.Drawing.Point(15, 559);
            this.btnSTCompleteOrder.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnSTCompleteOrder.Name = "btnSTCompleteOrder";
            this.btnSTCompleteOrder.Size = new System.Drawing.Size(132, 28);
            this.btnSTCompleteOrder.TabIndex = 10;
            this.btnSTCompleteOrder.Text = "Complete Order";
            this.btnSTCompleteOrder.UseVisualStyleBackColor = true;
            this.btnSTCompleteOrder.Click += new System.EventHandler(this.btnSTCompleteOrder_Click);
            // 
            // lblSTNewWalletCredit
            // 
            this.lblSTNewWalletCredit.AutoSize = true;
            this.lblSTNewWalletCredit.Location = new System.Drawing.Point(12, 504);
            this.lblSTNewWalletCredit.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblSTNewWalletCredit.Name = "lblSTNewWalletCredit";
            this.lblSTNewWalletCredit.Size = new System.Drawing.Size(192, 17);
            this.lblSTNewWalletCredit.TabIndex = 9;
            this.lblSTNewWalletCredit.Text = "Wallet Credit after purchase: ";
            // 
            // btnSTAddToOrder
            // 
            this.btnSTAddToOrder.Location = new System.Drawing.Point(305, 133);
            this.btnSTAddToOrder.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnSTAddToOrder.Name = "btnSTAddToOrder";
            this.btnSTAddToOrder.Size = new System.Drawing.Size(100, 28);
            this.btnSTAddToOrder.TabIndex = 7;
            this.btnSTAddToOrder.Text = "Add to order";
            this.btnSTAddToOrder.UseVisualStyleBackColor = true;
            this.btnSTAddToOrder.Click += new System.EventHandler(this.btnSTAddToOrder_Click);
            // 
            // NUDSTArticleAmount
            // 
            this.NUDSTArticleAmount.Location = new System.Drawing.Point(210, 180);
            this.NUDSTArticleAmount.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.NUDSTArticleAmount.Name = "NUDSTArticleAmount";
            this.NUDSTArticleAmount.Size = new System.Drawing.Size(51, 22);
            this.NUDSTArticleAmount.TabIndex = 6;
            // 
            // cbxNameArticles
            // 
            this.cbxNameArticles.FormattingEnabled = true;
            this.cbxNameArticles.Location = new System.Drawing.Point(14, 178);
            this.cbxNameArticles.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbxNameArticles.Name = "cbxNameArticles";
            this.cbxNameArticles.Size = new System.Drawing.Size(160, 24);
            this.cbxNameArticles.TabIndex = 5;
            this.cbxNameArticles.Text = "Select An Article";
            // 
            // lblCostumerWallet
            // 
            this.lblCostumerWallet.AutoSize = true;
            this.lblCostumerWallet.Location = new System.Drawing.Point(11, 86);
            this.lblCostumerWallet.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCostumerWallet.Name = "lblCostumerWallet";
            this.lblCostumerWallet.Size = new System.Drawing.Size(96, 17);
            this.lblCostumerWallet.TabIndex = 4;
            this.lblCostumerWallet.Text = "Wallet Credit: ";
            // 
            // btnSTSeeDetails
            // 
            this.btnSTSeeDetails.Location = new System.Drawing.Point(288, 27);
            this.btnSTSeeDetails.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnSTSeeDetails.Name = "btnSTSeeDetails";
            this.btnSTSeeDetails.Size = new System.Drawing.Size(100, 28);
            this.btnSTSeeDetails.TabIndex = 3;
            this.btnSTSeeDetails.Text = "See Details";
            this.btnSTSeeDetails.UseVisualStyleBackColor = true;
            this.btnSTSeeDetails.Click += new System.EventHandler(this.btnSTSeeDetails_Click);
            // 
            // tbxRFID
            // 
            this.tbxRFID.Location = new System.Drawing.Point(129, 33);
            this.tbxRFID.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbxRFID.Name = "tbxRFID";
            this.tbxRFID.Size = new System.Drawing.Size(132, 22);
            this.tbxRFID.TabIndex = 1;
            // 
            // lbFRID
            // 
            this.lbFRID.AutoSize = true;
            this.lbFRID.Location = new System.Drawing.Point(45, 33);
            this.lbFRID.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbFRID.Name = "lbFRID";
            this.lbFRID.Size = new System.Drawing.Size(47, 17);
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
            this.tabCheckIn.Controls.Add(this.btnGoToDetails);
            this.tabCheckIn.Location = new System.Drawing.Point(4, 25);
            this.tabCheckIn.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabCheckIn.Name = "tabCheckIn";
            this.tabCheckIn.Padding = new System.Windows.Forms.Padding(4);
            this.tabCheckIn.Size = new System.Drawing.Size(1037, 748);
            this.tabCheckIn.TabIndex = 1;
            this.tabCheckIn.Text = "Check In/Out";
            this.tabCheckIn.UseVisualStyleBackColor = true;
            // 
            // lbUnassigned
            // 
            this.lbUnassigned.AutoSize = true;
            this.lbUnassigned.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUnassigned.Location = new System.Drawing.Point(269, 256);
            this.lbUnassigned.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbUnassigned.Name = "lbUnassigned";
            this.lbUnassigned.Size = new System.Drawing.Size(360, 46);
            this.lbUnassigned.TabIndex = 13;
            this.lbUnassigned.Text = "RFID: Unassigned";
            this.lbUnassigned.Visible = false;
            // 
            // lbAssigned
            // 
            this.lbAssigned.AutoSize = true;
            this.lbAssigned.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAssigned.Location = new System.Drawing.Point(269, 74);
            this.lbAssigned.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbAssigned.Name = "lbAssigned";
            this.lbAssigned.Size = new System.Drawing.Size(525, 52);
            this.lbAssigned.TabIndex = 13;
            this.lbAssigned.Text = "RFID: Assigned to ********";
            this.lbAssigned.Visible = false;
            // 
            // btnCheckTicket
            // 
            this.btnCheckTicket.Location = new System.Drawing.Point(540, 193);
            this.btnCheckTicket.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnCheckTicket.Name = "btnCheckTicket";
            this.btnCheckTicket.Size = new System.Drawing.Size(131, 28);
            this.btnCheckTicket.TabIndex = 12;
            this.btnCheckTicket.Text = "Check Ticket";
            this.btnCheckTicket.UseVisualStyleBackColor = true;
            this.btnCheckTicket.Click += new System.EventHandler(this.btnCheckTicket_Click);
            // 
            // btnCheckInSubmit
            // 
            this.btnCheckInSubmit.Location = new System.Drawing.Point(432, 353);
            this.btnCheckInSubmit.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnCheckInSubmit.Name = "btnCheckInSubmit";
            this.btnCheckInSubmit.Size = new System.Drawing.Size(100, 28);
            this.btnCheckInSubmit.TabIndex = 11;
            this.btnCheckInSubmit.Text = "Check out";
            this.btnCheckInSubmit.UseVisualStyleBackColor = true;
            this.btnCheckInSubmit.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // tbxCheckInID
            // 
            this.tbxCheckInID.Location = new System.Drawing.Point(399, 193);
            this.tbxCheckInID.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbxCheckInID.Name = "tbxCheckInID";
            this.tbxCheckInID.Size = new System.Drawing.Size(132, 22);
            this.tbxCheckInID.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(288, 193);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Ticket Number";
            // 
            // btnGoToDetails
            // 
            this.btnGoToDetails.Location = new System.Drawing.Point(679, 193);
            this.btnGoToDetails.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnGoToDetails.Name = "btnGoToDetails";
            this.btnGoToDetails.Size = new System.Drawing.Size(100, 28);
            this.btnGoToDetails.TabIndex = 14;
            this.btnGoToDetails.Text = "Go to details";
            this.btnGoToDetails.UseVisualStyleBackColor = true;
            this.btnGoToDetails.Click += new System.EventHandler(this.btnGoToDetails_Click);
            // 
            // tabDBView
            // 
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
            this.tabDBView.Location = new System.Drawing.Point(4, 25);
            this.tabDBView.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabDBView.Name = "tabDBView";
            this.tabDBView.Size = new System.Drawing.Size(1037, 748);
            this.tabDBView.TabIndex = 2;
            this.tabDBView.Text = "Database view";
            this.tabDBView.UseVisualStyleBackColor = true;
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(361, 28);
            this.btnShow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(89, 23);
            this.btnShow.TabIndex = 11;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 242);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(837, 331);
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
            this.cbxDTSelectArticle.Location = new System.Drawing.Point(177, 161);
            this.cbxDTSelectArticle.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbxDTSelectArticle.Name = "cbxDTSelectArticle";
            this.cbxDTSelectArticle.Size = new System.Drawing.Size(160, 24);
            this.cbxDTSelectArticle.TabIndex = 9;
            this.cbxDTSelectArticle.Text = "Articles";
            this.cbxDTSelectArticle.Visible = false;
            // 
            // lblSelectArticle
            // 
            this.lblSelectArticle.AutoSize = true;
            this.lblSelectArticle.Location = new System.Drawing.Point(11, 165);
            this.lblSelectArticle.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblSelectArticle.Name = "lblSelectArticle";
            this.lblSelectArticle.Size = new System.Drawing.Size(90, 17);
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
            this.cbxDTSelectCampSpot.Location = new System.Drawing.Point(177, 128);
            this.cbxDTSelectCampSpot.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbxDTSelectCampSpot.Name = "cbxDTSelectCampSpot";
            this.cbxDTSelectCampSpot.Size = new System.Drawing.Size(160, 24);
            this.cbxDTSelectCampSpot.TabIndex = 7;
            this.cbxDTSelectCampSpot.Text = "Camp Nrs";
            this.cbxDTSelectCampSpot.Visible = false;
            // 
            // lblSelectCSpot
            // 
            this.lblSelectCSpot.AutoSize = true;
            this.lblSelectCSpot.Location = new System.Drawing.Point(11, 132);
            this.lblSelectCSpot.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblSelectCSpot.Name = "lblSelectCSpot";
            this.lblSelectCSpot.Size = new System.Drawing.Size(139, 17);
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
            this.cbxDTSelectEvent.Location = new System.Drawing.Point(177, 95);
            this.cbxDTSelectEvent.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbxDTSelectEvent.Name = "cbxDTSelectEvent";
            this.cbxDTSelectEvent.Size = new System.Drawing.Size(160, 24);
            this.cbxDTSelectEvent.TabIndex = 5;
            this.cbxDTSelectEvent.Text = "Events";
            this.cbxDTSelectEvent.Visible = false;
            // 
            // lblSelectEvent
            // 
            this.lblSelectEvent.AutoSize = true;
            this.lblSelectEvent.Location = new System.Drawing.Point(11, 98);
            this.lblSelectEvent.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblSelectEvent.Name = "lblSelectEvent";
            this.lblSelectEvent.Size = new System.Drawing.Size(87, 17);
            this.lblSelectEvent.TabIndex = 4;
            this.lblSelectEvent.Text = "Select Event";
            this.lblSelectEvent.Visible = false;
            // 
            // tbxDTPErsonID
            // 
            this.tbxDTPErsonID.Location = new System.Drawing.Point(177, 63);
            this.tbxDTPErsonID.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbxDTPErsonID.Name = "tbxDTPErsonID";
            this.tbxDTPErsonID.Size = new System.Drawing.Size(160, 22);
            this.tbxDTPErsonID.TabIndex = 3;
            this.tbxDTPErsonID.Visible = false;
            // 
            // lblPersonID
            // 
            this.lblPersonID.AutoSize = true;
            this.lblPersonID.Location = new System.Drawing.Point(11, 66);
            this.lblPersonID.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPersonID.Name = "lblPersonID";
            this.lblPersonID.Size = new System.Drawing.Size(70, 17);
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
            this.cbxDTInfoType.Location = new System.Drawing.Point(177, 30);
            this.cbxDTInfoType.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbxDTInfoType.Name = "cbxDTInfoType";
            this.cbxDTInfoType.Size = new System.Drawing.Size(160, 24);
            this.cbxDTInfoType.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 39);
            this.label10.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(126, 17);
            this.label10.TabIndex = 0;
            this.label10.Text = "Select Type of info";
            // 
            // tabEvent
            // 
            this.tabEvent.Controls.Add(this.btnCancel);
            this.tabEvent.Controls.Add(this.btnETSave);
            this.tabEvent.Controls.Add(this.richTbxETDescription);
            this.tabEvent.Controls.Add(this.dtpETEventDate);
            this.tabEvent.Controls.Add(this.tbxETLocation);
            this.tabEvent.Controls.Add(this.tbxETMaxCamp);
            this.tabEvent.Controls.Add(this.tbxETMaxTickets);
            this.tabEvent.Controls.Add(this.tbxETEventName);
            this.tabEvent.Controls.Add(this.btnETDeleteEvent);
            this.tabEvent.Controls.Add(this.btnETNewEvent);
            this.tabEvent.Controls.Add(this.btnETSelectEvent);
            this.tabEvent.Controls.Add(this.cmbxEventSelectEvent);
            this.tabEvent.Controls.Add(this.label8);
            this.tabEvent.Controls.Add(this.label7);
            this.tabEvent.Controls.Add(this.label6);
            this.tabEvent.Controls.Add(this.label5);
            this.tabEvent.Controls.Add(this.label4);
            this.tabEvent.Controls.Add(this.label3);
            this.tabEvent.Controls.Add(this.label2);
            this.tabEvent.Location = new System.Drawing.Point(4, 25);
            this.tabEvent.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabEvent.Name = "tabEvent";
            this.tabEvent.Size = new System.Drawing.Size(1037, 748);
            this.tabEvent.TabIndex = 3;
            this.tabEvent.Text = "Event";
            this.tabEvent.ToolTipText = "Create, change or delete an event";
            this.tabEvent.UseVisualStyleBackColor = true;
            this.tabEvent.Click += new System.EventHandler(this.tabEvent_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(341, 554);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(135, 28);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnETSave
            // 
            this.btnETSave.Location = new System.Drawing.Point(32, 554);
            this.btnETSave.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnETSave.Name = "btnETSave";
            this.btnETSave.Size = new System.Drawing.Size(135, 28);
            this.btnETSave.TabIndex = 18;
            this.btnETSave.Text = "Save";
            this.btnETSave.UseVisualStyleBackColor = true;
            // 
            // richTbxETDescription
            // 
            this.richTbxETDescription.Location = new System.Drawing.Point(145, 373);
            this.richTbxETDescription.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.richTbxETDescription.Name = "richTbxETDescription";
            this.richTbxETDescription.Size = new System.Drawing.Size(329, 121);
            this.richTbxETDescription.TabIndex = 17;
            this.richTbxETDescription.Text = "";
            // 
            // dtpETEventDate
            // 
            this.dtpETEventDate.Location = new System.Drawing.Point(145, 252);
            this.dtpETEventDate.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.dtpETEventDate.Name = "dtpETEventDate";
            this.dtpETEventDate.Size = new System.Drawing.Size(265, 22);
            this.dtpETEventDate.TabIndex = 16;
            // 
            // tbxETLocation
            // 
            this.tbxETLocation.Location = new System.Drawing.Point(145, 308);
            this.tbxETLocation.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbxETLocation.Name = "tbxETLocation";
            this.tbxETLocation.Size = new System.Drawing.Size(132, 22);
            this.tbxETLocation.TabIndex = 15;
            // 
            // tbxETMaxCamp
            // 
            this.tbxETMaxCamp.Location = new System.Drawing.Point(145, 201);
            this.tbxETMaxCamp.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbxETMaxCamp.Name = "tbxETMaxCamp";
            this.tbxETMaxCamp.Size = new System.Drawing.Size(132, 22);
            this.tbxETMaxCamp.TabIndex = 13;
            // 
            // tbxETMaxTickets
            // 
            this.tbxETMaxTickets.Location = new System.Drawing.Point(145, 146);
            this.tbxETMaxTickets.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbxETMaxTickets.Name = "tbxETMaxTickets";
            this.tbxETMaxTickets.Size = new System.Drawing.Size(132, 22);
            this.tbxETMaxTickets.TabIndex = 12;
            // 
            // tbxETEventName
            // 
            this.tbxETEventName.Location = new System.Drawing.Point(145, 89);
            this.tbxETEventName.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tbxETEventName.Name = "tbxETEventName";
            this.tbxETEventName.Size = new System.Drawing.Size(132, 22);
            this.tbxETEventName.TabIndex = 11;
            // 
            // btnETDeleteEvent
            // 
            this.btnETDeleteEvent.Location = new System.Drawing.Point(627, 37);
            this.btnETDeleteEvent.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnETDeleteEvent.Name = "btnETDeleteEvent";
            this.btnETDeleteEvent.Size = new System.Drawing.Size(135, 28);
            this.btnETDeleteEvent.TabIndex = 10;
            this.btnETDeleteEvent.Text = "Delete Event";
            this.btnETDeleteEvent.UseVisualStyleBackColor = true;
            // 
            // btnETNewEvent
            // 
            this.btnETNewEvent.Location = new System.Drawing.Point(484, 37);
            this.btnETNewEvent.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnETNewEvent.Name = "btnETNewEvent";
            this.btnETNewEvent.Size = new System.Drawing.Size(135, 28);
            this.btnETNewEvent.TabIndex = 9;
            this.btnETNewEvent.Text = "New Event";
            this.btnETNewEvent.UseVisualStyleBackColor = true;
            this.btnETNewEvent.Click += new System.EventHandler(this.btnETNewEvent_Click);
            // 
            // btnETSelectEvent
            // 
            this.btnETSelectEvent.Location = new System.Drawing.Point(341, 37);
            this.btnETSelectEvent.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnETSelectEvent.Name = "btnETSelectEvent";
            this.btnETSelectEvent.Size = new System.Drawing.Size(135, 28);
            this.btnETSelectEvent.TabIndex = 8;
            this.btnETSelectEvent.Text = "Select Event";
            this.btnETSelectEvent.UseVisualStyleBackColor = true;
            this.btnETSelectEvent.Click += new System.EventHandler(this.btnETSelectEvent_Click);
            // 
            // cmbxEventSelectEvent
            // 
            this.cmbxEventSelectEvent.FormattingEnabled = true;
            this.cmbxEventSelectEvent.Location = new System.Drawing.Point(145, 39);
            this.cmbxEventSelectEvent.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cmbxEventSelectEvent.Name = "cmbxEventSelectEvent";
            this.cmbxEventSelectEvent.Size = new System.Drawing.Size(160, 24);
            this.cmbxEventSelectEvent.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 377);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 17);
            this.label8.TabIndex = 6;
            this.label8.Text = "Description";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 311);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 17);
            this.label7.TabIndex = 5;
            this.label7.Text = "Location";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 260);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 17);
            this.label6.TabIndex = 4;
            this.label6.Text = "Event Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 204);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "Max camping";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 146);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Max tickets";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 92);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Event Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 43);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Select Event";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 17);
            this.label9.TabIndex = 1;
            this.label9.Text = "label9";
            // 
            // FestivalAppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 777);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.TabControl);
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "FestivalAppForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Averti Festival ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FestivalAppForm_FormClosing);
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
            this.tabEvent.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Button btnGoToDetails;
        private System.Windows.Forms.ComboBox cmbxEventSelectEvent;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxETLocation;
        private System.Windows.Forms.TextBox tbxETMaxCamp;
        private System.Windows.Forms.TextBox tbxETMaxTickets;
        private System.Windows.Forms.TextBox tbxETEventName;
        private System.Windows.Forms.Button btnETDeleteEvent;
        private System.Windows.Forms.Button btnETNewEvent;
        private System.Windows.Forms.Button btnETSelectEvent;
        private System.Windows.Forms.DateTimePicker dtpETEventDate;
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
        private System.Windows.Forms.Button btnSTSeeDetails;
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
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbxSortArticle;
        private System.Windows.Forms.Label lbWallet;


    }
}