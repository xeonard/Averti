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
            this.btnSTCancel = new System.Windows.Forms.Button();
            this.btnSTCompleteOrder = new System.Windows.Forms.Button();
            this.lblSTNewWalletCredit = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnSTAddToOrder = new System.Windows.Forms.Button();
            this.NUDSTArticleAmount = new System.Windows.Forms.NumericUpDown();
            this.cbxSTArticles = new System.Windows.Forms.ComboBox();
            this.lblCostumerWallet = new System.Windows.Forms.Label();
            this.btnSTSeeDetails = new System.Windows.Forms.Button();
            this.tbxSTCustomerID = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tabCheckIn = new System.Windows.Forms.TabPage();
            this.lbAssigned = new System.Windows.Forms.Label();
            this.btnCheckTicket = new System.Windows.Forms.Button();
            this.btnCheckInSubmit = new System.Windows.Forms.Button();
            this.tbxCheckInID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGoToDetails = new System.Windows.Forms.Button();
            this.tabDBView = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cbxDTSelectArticle = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cbxDTSelectCampSpot = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cbxDTSelectEvent = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbxDTPErsonID = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
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
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(784, 561);
            this.TabControl.TabIndex = 0;
            // 
            // tabSales
            // 
            this.tabSales.Controls.Add(this.btnSTCancel);
            this.tabSales.Controls.Add(this.btnSTCompleteOrder);
            this.tabSales.Controls.Add(this.lblSTNewWalletCredit);
            this.tabSales.Controls.Add(this.richTextBox1);
            this.tabSales.Controls.Add(this.btnSTAddToOrder);
            this.tabSales.Controls.Add(this.NUDSTArticleAmount);
            this.tabSales.Controls.Add(this.cbxSTArticles);
            this.tabSales.Controls.Add(this.lblCostumerWallet);
            this.tabSales.Controls.Add(this.btnSTSeeDetails);
            this.tabSales.Controls.Add(this.tbxSTCustomerID);
            this.tabSales.Controls.Add(this.label9);
            this.tabSales.Location = new System.Drawing.Point(4, 22);
            this.tabSales.Name = "tabSales";
            this.tabSales.Padding = new System.Windows.Forms.Padding(3);
            this.tabSales.Size = new System.Drawing.Size(776, 535);
            this.tabSales.TabIndex = 0;
            this.tabSales.Text = "Sales";
            this.tabSales.ToolTipText = "All transactions are to be made here.";
            this.tabSales.UseVisualStyleBackColor = true;
            // 
            // btnSTCancel
            // 
            this.btnSTCancel.Location = new System.Drawing.Point(205, 454);
            this.btnSTCancel.Name = "btnSTCancel";
            this.btnSTCancel.Size = new System.Drawing.Size(99, 23);
            this.btnSTCancel.TabIndex = 11;
            this.btnSTCancel.Text = "Cancel Order";
            this.btnSTCancel.UseVisualStyleBackColor = true;
            // 
            // btnSTCompleteOrder
            // 
            this.btnSTCompleteOrder.Location = new System.Drawing.Point(11, 454);
            this.btnSTCompleteOrder.Name = "btnSTCompleteOrder";
            this.btnSTCompleteOrder.Size = new System.Drawing.Size(99, 23);
            this.btnSTCompleteOrder.TabIndex = 10;
            this.btnSTCompleteOrder.Text = "Complete Order";
            this.btnSTCompleteOrder.UseVisualStyleBackColor = true;
            // 
            // lblSTNewWalletCredit
            // 
            this.lblSTNewWalletCredit.AutoSize = true;
            this.lblSTNewWalletCredit.Location = new System.Drawing.Point(8, 390);
            this.lblSTNewWalletCredit.Name = "lblSTNewWalletCredit";
            this.lblSTNewWalletCredit.Size = new System.Drawing.Size(144, 13);
            this.lblSTNewWalletCredit.TabIndex = 9;
            this.lblSTNewWalletCredit.Text = "Wallet Credit after purchase: ";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(11, 169);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(293, 199);
            this.richTextBox1.TabIndex = 8;
            this.richTextBox1.Text = "";
            // 
            // btnSTAddToOrder
            // 
            this.btnSTAddToOrder.Location = new System.Drawing.Point(229, 108);
            this.btnSTAddToOrder.Name = "btnSTAddToOrder";
            this.btnSTAddToOrder.Size = new System.Drawing.Size(75, 23);
            this.btnSTAddToOrder.TabIndex = 7;
            this.btnSTAddToOrder.Text = "Add to order";
            this.btnSTAddToOrder.UseVisualStyleBackColor = true;
            // 
            // NUDSTArticleAmount
            // 
            this.NUDSTArticleAmount.Location = new System.Drawing.Point(159, 111);
            this.NUDSTArticleAmount.Name = "NUDSTArticleAmount";
            this.NUDSTArticleAmount.Size = new System.Drawing.Size(38, 20);
            this.NUDSTArticleAmount.TabIndex = 6;
            // 
            // cbxSTArticles
            // 
            this.cbxSTArticles.FormattingEnabled = true;
            this.cbxSTArticles.Location = new System.Drawing.Point(11, 110);
            this.cbxSTArticles.Name = "cbxSTArticles";
            this.cbxSTArticles.Size = new System.Drawing.Size(121, 21);
            this.cbxSTArticles.TabIndex = 5;
            this.cbxSTArticles.Text = "Select An Article";
            // 
            // lblCostumerWallet
            // 
            this.lblCostumerWallet.AutoSize = true;
            this.lblCostumerWallet.Location = new System.Drawing.Point(8, 70);
            this.lblCostumerWallet.Name = "lblCostumerWallet";
            this.lblCostumerWallet.Size = new System.Drawing.Size(73, 13);
            this.lblCostumerWallet.TabIndex = 4;
            this.lblCostumerWallet.Text = "Wallet Credit: ";
            // 
            // btnSTSeeDetails
            // 
            this.btnSTSeeDetails.Location = new System.Drawing.Point(216, 22);
            this.btnSTSeeDetails.Name = "btnSTSeeDetails";
            this.btnSTSeeDetails.Size = new System.Drawing.Size(75, 23);
            this.btnSTSeeDetails.TabIndex = 3;
            this.btnSTSeeDetails.Text = "See Details";
            this.btnSTSeeDetails.UseVisualStyleBackColor = true;
            // 
            // tbxSTCustomerID
            // 
            this.tbxSTCustomerID.Location = new System.Drawing.Point(97, 27);
            this.tbxSTCustomerID.Name = "tbxSTCustomerID";
            this.tbxSTCustomerID.Size = new System.Drawing.Size(100, 20);
            this.tbxSTCustomerID.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(34, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "FRID :";
            // 
            // tabCheckIn
            // 
            this.tabCheckIn.Controls.Add(this.lbAssigned);
            this.tabCheckIn.Controls.Add(this.btnCheckTicket);
            this.tabCheckIn.Controls.Add(this.btnCheckInSubmit);
            this.tabCheckIn.Controls.Add(this.tbxCheckInID);
            this.tabCheckIn.Controls.Add(this.label1);
            this.tabCheckIn.Controls.Add(this.btnGoToDetails);
            this.tabCheckIn.Location = new System.Drawing.Point(4, 22);
            this.tabCheckIn.Name = "tabCheckIn";
            this.tabCheckIn.Padding = new System.Windows.Forms.Padding(3);
            this.tabCheckIn.Size = new System.Drawing.Size(776, 535);
            this.tabCheckIn.TabIndex = 1;
            this.tabCheckIn.Text = "Check In/Out";
            this.tabCheckIn.UseVisualStyleBackColor = true;
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
            this.btnCheckInSubmit.Name = "btnCheckInSubmit";
            this.btnCheckInSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnCheckInSubmit.TabIndex = 11;
            this.btnCheckInSubmit.Text = "Submit";
            this.btnCheckInSubmit.UseVisualStyleBackColor = true;
            this.btnCheckInSubmit.Click += new System.EventHandler(this.btnCheckInSubmit_Click);
            // 
            // tbxCheckInID
            // 
            this.tbxCheckInID.Location = new System.Drawing.Point(299, 157);
            this.tbxCheckInID.Name = "tbxCheckInID";
            this.tbxCheckInID.Size = new System.Drawing.Size(100, 20);
            this.tbxCheckInID.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(216, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Ticket Number";
            // 
            // btnGoToDetails
            // 
            this.btnGoToDetails.Location = new System.Drawing.Point(509, 157);
            this.btnGoToDetails.Name = "btnGoToDetails";
            this.btnGoToDetails.Size = new System.Drawing.Size(75, 23);
            this.btnGoToDetails.TabIndex = 6;
            this.btnGoToDetails.Text = "Go to details";
            this.btnGoToDetails.UseVisualStyleBackColor = true;
            // 
            // tabDBView
            // 
            this.tabDBView.Controls.Add(this.dataGridView1);
            this.tabDBView.Controls.Add(this.cbxDTSelectArticle);
            this.tabDBView.Controls.Add(this.label14);
            this.tabDBView.Controls.Add(this.cbxDTSelectCampSpot);
            this.tabDBView.Controls.Add(this.label13);
            this.tabDBView.Controls.Add(this.cbxDTSelectEvent);
            this.tabDBView.Controls.Add(this.label12);
            this.tabDBView.Controls.Add(this.tbxDTPErsonID);
            this.tabDBView.Controls.Add(this.label11);
            this.tabDBView.Controls.Add(this.cbxDTInfoType);
            this.tabDBView.Controls.Add(this.label10);
            this.tabDBView.Location = new System.Drawing.Point(4, 22);
            this.tabDBView.Name = "tabDBView";
            this.tabDBView.Size = new System.Drawing.Size(776, 535);
            this.tabDBView.TabIndex = 2;
            this.tabDBView.Text = "Database view";
            this.tabDBView.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(11, 197);
            this.dataGridView1.Name = "dataGridView1";
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
            this.cbxDTSelectArticle.Name = "cbxDTSelectArticle";
            this.cbxDTSelectArticle.Size = new System.Drawing.Size(121, 21);
            this.cbxDTSelectArticle.TabIndex = 9;
            this.cbxDTSelectArticle.Text = "Articles";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 134);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 13);
            this.label14.TabIndex = 8;
            this.label14.Text = "Select Article";
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
            this.cbxDTSelectCampSpot.Name = "cbxDTSelectCampSpot";
            this.cbxDTSelectCampSpot.Size = new System.Drawing.Size(121, 21);
            this.cbxDTSelectCampSpot.TabIndex = 7;
            this.cbxDTSelectCampSpot.Text = "Camp Nrs";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 107);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(106, 13);
            this.label13.TabIndex = 6;
            this.label13.Text = "Select Camping Spot";
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
            this.cbxDTSelectEvent.Name = "cbxDTSelectEvent";
            this.cbxDTSelectEvent.Size = new System.Drawing.Size(121, 21);
            this.cbxDTSelectEvent.TabIndex = 5;
            this.cbxDTSelectEvent.Text = "Events";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 80);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 13);
            this.label12.TabIndex = 4;
            this.label12.Text = "Select Event";
            // 
            // tbxDTPErsonID
            // 
            this.tbxDTPErsonID.Location = new System.Drawing.Point(133, 51);
            this.tbxDTPErsonID.Name = "tbxDTPErsonID";
            this.tbxDTPErsonID.Size = new System.Drawing.Size(121, 20);
            this.tbxDTPErsonID.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 54);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Person ID";
            // 
            // cbxDTInfoType
            // 
            this.cbxDTInfoType.AutoCompleteCustomSource.AddRange(new string[] {
            "Person",
            "Event",
            "Camping",
            "Sales"});
            this.cbxDTInfoType.FormattingEnabled = true;
            this.cbxDTInfoType.Location = new System.Drawing.Point(133, 24);
            this.cbxDTInfoType.Name = "cbxDTInfoType";
            this.cbxDTInfoType.Size = new System.Drawing.Size(121, 21);
            this.cbxDTInfoType.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 13);
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
            this.tabEvent.Location = new System.Drawing.Point(4, 22);
            this.tabEvent.Name = "tabEvent";
            this.tabEvent.Size = new System.Drawing.Size(776, 535);
            this.tabEvent.TabIndex = 3;
            this.tabEvent.Text = "Event";
            this.tabEvent.ToolTipText = "Create, change or delete an event";
            this.tabEvent.UseVisualStyleBackColor = true;
            this.tabEvent.Click += new System.EventHandler(this.tabEvent_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(256, 450);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(101, 23);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnETSave
            // 
            this.btnETSave.Location = new System.Drawing.Point(24, 450);
            this.btnETSave.Name = "btnETSave";
            this.btnETSave.Size = new System.Drawing.Size(101, 23);
            this.btnETSave.TabIndex = 18;
            this.btnETSave.Text = "Save";
            this.btnETSave.UseVisualStyleBackColor = true;
            // 
            // richTbxETDescription
            // 
            this.richTbxETDescription.Location = new System.Drawing.Point(109, 303);
            this.richTbxETDescription.Name = "richTbxETDescription";
            this.richTbxETDescription.Size = new System.Drawing.Size(248, 99);
            this.richTbxETDescription.TabIndex = 17;
            this.richTbxETDescription.Text = "";
            // 
            // dtpETEventDate
            // 
            this.dtpETEventDate.Location = new System.Drawing.Point(109, 205);
            this.dtpETEventDate.Name = "dtpETEventDate";
            this.dtpETEventDate.Size = new System.Drawing.Size(200, 20);
            this.dtpETEventDate.TabIndex = 16;
            // 
            // tbxETLocation
            // 
            this.tbxETLocation.Location = new System.Drawing.Point(109, 250);
            this.tbxETLocation.Name = "tbxETLocation";
            this.tbxETLocation.Size = new System.Drawing.Size(100, 20);
            this.tbxETLocation.TabIndex = 15;
            // 
            // tbxETMaxCamp
            // 
            this.tbxETMaxCamp.Location = new System.Drawing.Point(109, 163);
            this.tbxETMaxCamp.Name = "tbxETMaxCamp";
            this.tbxETMaxCamp.Size = new System.Drawing.Size(100, 20);
            this.tbxETMaxCamp.TabIndex = 13;
            // 
            // tbxETMaxTickets
            // 
            this.tbxETMaxTickets.Location = new System.Drawing.Point(109, 119);
            this.tbxETMaxTickets.Name = "tbxETMaxTickets";
            this.tbxETMaxTickets.Size = new System.Drawing.Size(100, 20);
            this.tbxETMaxTickets.TabIndex = 12;
            // 
            // tbxETEventName
            // 
            this.tbxETEventName.Location = new System.Drawing.Point(109, 72);
            this.tbxETEventName.Name = "tbxETEventName";
            this.tbxETEventName.Size = new System.Drawing.Size(100, 20);
            this.tbxETEventName.TabIndex = 11;
            // 
            // btnETDeleteEvent
            // 
            this.btnETDeleteEvent.Location = new System.Drawing.Point(470, 30);
            this.btnETDeleteEvent.Name = "btnETDeleteEvent";
            this.btnETDeleteEvent.Size = new System.Drawing.Size(101, 23);
            this.btnETDeleteEvent.TabIndex = 10;
            this.btnETDeleteEvent.Text = "Delete Event";
            this.btnETDeleteEvent.UseVisualStyleBackColor = true;
            // 
            // btnETNewEvent
            // 
            this.btnETNewEvent.Location = new System.Drawing.Point(363, 30);
            this.btnETNewEvent.Name = "btnETNewEvent";
            this.btnETNewEvent.Size = new System.Drawing.Size(101, 23);
            this.btnETNewEvent.TabIndex = 9;
            this.btnETNewEvent.Text = "New Event";
            this.btnETNewEvent.UseVisualStyleBackColor = true;
            this.btnETNewEvent.Click += new System.EventHandler(this.btnETNewEvent_Click);
            // 
            // btnETSelectEvent
            // 
            this.btnETSelectEvent.Location = new System.Drawing.Point(256, 30);
            this.btnETSelectEvent.Name = "btnETSelectEvent";
            this.btnETSelectEvent.Size = new System.Drawing.Size(101, 23);
            this.btnETSelectEvent.TabIndex = 8;
            this.btnETSelectEvent.Text = "Select Event";
            this.btnETSelectEvent.UseVisualStyleBackColor = true;
            this.btnETSelectEvent.Click += new System.EventHandler(this.btnETSelectEvent_Click);
            // 
            // cmbxEventSelectEvent
            // 
            this.cmbxEventSelectEvent.FormattingEnabled = true;
            this.cmbxEventSelectEvent.Location = new System.Drawing.Point(109, 32);
            this.cmbxEventSelectEvent.Name = "cmbxEventSelectEvent";
            this.cmbxEventSelectEvent.Size = new System.Drawing.Size(121, 21);
            this.cmbxEventSelectEvent.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 306);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Description";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 253);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Location";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 211);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Event Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Max camping";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Max tickets";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Event Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Select Event";
            // 
            // FestivalAppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.TabControl);
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
        private System.Windows.Forms.TextBox tbxSTCustomerID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblSTNewWalletCredit;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnSTAddToOrder;
        private System.Windows.Forms.NumericUpDown NUDSTArticleAmount;
        private System.Windows.Forms.ComboBox cbxSTArticles;
        private System.Windows.Forms.Label lblCostumerWallet;
        private System.Windows.Forms.Button btnSTSeeDetails;
        private System.Windows.Forms.Button btnSTCancel;
        private System.Windows.Forms.Button btnSTCompleteOrder;
        private System.Windows.Forms.ComboBox cbxDTSelectArticle;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbxDTSelectCampSpot;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbxDTSelectEvent;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbxDTPErsonID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbxDTInfoType;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnCheckTicket;
        private System.Windows.Forms.Label lbAssigned;


    }
}