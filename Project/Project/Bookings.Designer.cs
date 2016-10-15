namespace Project
{
    partial class Bookings
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnAddGoodsBooking = new System.Windows.Forms.Button();
            this.btnDeleteGoodsBooking = new System.Windows.Forms.Button();
            this.btnUpdateGoodsBooking = new System.Windows.Forms.Button();
            this.rtbGoodsDesciption = new System.Windows.Forms.RichTextBox();
            this.tbxGoodsType = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxGoodsID = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnAddDeliveryBooking = new System.Windows.Forms.Button();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabBookingParticipants = new System.Windows.Forms.TabPage();
            this.cbxBookingDriverID = new System.Windows.Forms.ComboBox();
            this.cbxBookingClientID = new System.Windows.Forms.ComboBox();
            this.cbxBookingStaffID = new System.Windows.Forms.ComboBox();
            this.cbxBookingTruckID = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tabBookingDetails = new System.Windows.Forms.TabPage();
            this.cbxBookingGoodsID = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.rtbBookingNotes = new System.Windows.Forms.RichTextBox();
            this.tbxDeliveryDistance = new System.Windows.Forms.TextBox();
            this.tbxBookingDateMade = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.tabDeliveryDeparture = new System.Windows.Forms.TabPage();
            this.tbxDepartureCity = new System.Windows.Forms.TextBox();
            this.tbxDepartureAdrArea = new System.Windows.Forms.TextBox();
            this.tbxDepartureAdrNumber = new System.Windows.Forms.TextBox();
            this.tbxDepartureStreetName = new System.Windows.Forms.TextBox();
            this.tbxDepartureDate = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.tabDeliveryArrival = new System.Windows.Forms.TabPage();
            this.tbxArrivalCity = new System.Windows.Forms.TextBox();
            this.tbxArrivalAdrArea = new System.Windows.Forms.TextBox();
            this.tbxArrivalAdrNumber = new System.Windows.Forms.TextBox();
            this.tbxArrivalStreetName = new System.Windows.Forms.TextBox();
            this.tbxArrivalDate = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.btnDeleteDeliveryBooking = new System.Windows.Forms.Button();
            this.btnUpdateDeliveryBooking = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxDeliveryID = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabBookingParticipants.SuspendLayout();
            this.tabBookingDetails.SuspendLayout();
            this.tabDeliveryDeparture.SuspendLayout();
            this.tabDeliveryArrival.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(500, 385);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnAddGoodsBooking);
            this.tabPage1.Controls.Add(this.btnDeleteGoodsBooking);
            this.tabPage1.Controls.Add(this.btnUpdateGoodsBooking);
            this.tabPage1.Controls.Add(this.rtbGoodsDesciption);
            this.tabPage1.Controls.Add(this.tbxGoodsType);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.cbxGoodsID);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(492, 359);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Booking for Goods";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnAddGoodsBooking
            // 
            this.btnAddGoodsBooking.Location = new System.Drawing.Point(301, 330);
            this.btnAddGoodsBooking.Name = "btnAddGoodsBooking";
            this.btnAddGoodsBooking.Size = new System.Drawing.Size(185, 23);
            this.btnAddGoodsBooking.TabIndex = 11;
            this.btnAddGoodsBooking.Text = "Add Goods Booking";
            this.btnAddGoodsBooking.UseVisualStyleBackColor = true;
            this.btnAddGoodsBooking.Click += new System.EventHandler(this.btnAddGoodsBooking_Click);
            // 
            // btnDeleteGoodsBooking
            // 
            this.btnDeleteGoodsBooking.Location = new System.Drawing.Point(301, 41);
            this.btnDeleteGoodsBooking.Name = "btnDeleteGoodsBooking";
            this.btnDeleteGoodsBooking.Size = new System.Drawing.Size(185, 23);
            this.btnDeleteGoodsBooking.TabIndex = 10;
            this.btnDeleteGoodsBooking.Text = "Delete Goods Booking";
            this.btnDeleteGoodsBooking.UseVisualStyleBackColor = true;
            this.btnDeleteGoodsBooking.Click += new System.EventHandler(this.btnDeleteGoodsBooking_Click);
            // 
            // btnUpdateGoodsBooking
            // 
            this.btnUpdateGoodsBooking.Location = new System.Drawing.Point(301, 12);
            this.btnUpdateGoodsBooking.Name = "btnUpdateGoodsBooking";
            this.btnUpdateGoodsBooking.Size = new System.Drawing.Size(185, 23);
            this.btnUpdateGoodsBooking.TabIndex = 9;
            this.btnUpdateGoodsBooking.Text = "Update Goods Booking";
            this.btnUpdateGoodsBooking.UseVisualStyleBackColor = true;
            this.btnUpdateGoodsBooking.Click += new System.EventHandler(this.btnUpdateGoodsBooking_Click);
            // 
            // rtbGoodsDesciption
            // 
            this.rtbGoodsDesciption.Location = new System.Drawing.Point(109, 99);
            this.rtbGoodsDesciption.Name = "rtbGoodsDesciption";
            this.rtbGoodsDesciption.Size = new System.Drawing.Size(336, 139);
            this.rtbGoodsDesciption.TabIndex = 8;
            this.rtbGoodsDesciption.Text = "";
            // 
            // tbxGoodsType
            // 
            this.tbxGoodsType.Location = new System.Drawing.Point(106, 73);
            this.tbxGoodsType.Name = "tbxGoodsType";
            this.tbxGoodsType.Size = new System.Drawing.Size(165, 20);
            this.tbxGoodsType.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Select goods ID:";
            // 
            // cbxGoodsID
            // 
            this.cbxGoodsID.FormattingEnabled = true;
            this.cbxGoodsID.Items.AddRange(new object[] {
            "New..."});
            this.cbxGoodsID.Location = new System.Drawing.Point(106, 42);
            this.cbxGoodsID.Name = "cbxGoodsID";
            this.cbxGoodsID.Size = new System.Drawing.Size(165, 21);
            this.cbxGoodsID.TabIndex = 5;
            this.cbxGoodsID.SelectedIndexChanged += new System.EventHandler(this.cbxGoodsID_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(290, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Select an existing goods ID to update or delete the booking:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Goods Description:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Goods Type:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnAddDeliveryBooking);
            this.tabPage2.Controls.Add(this.tabControl2);
            this.tabPage2.Controls.Add(this.btnDeleteDeliveryBooking);
            this.tabPage2.Controls.Add(this.btnUpdateDeliveryBooking);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.cbxDeliveryID);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(492, 359);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Booking for Delivery";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnAddDeliveryBooking
            // 
            this.btnAddDeliveryBooking.Location = new System.Drawing.Point(297, 325);
            this.btnAddDeliveryBooking.Name = "btnAddDeliveryBooking";
            this.btnAddDeliveryBooking.Size = new System.Drawing.Size(185, 23);
            this.btnAddDeliveryBooking.TabIndex = 17;
            this.btnAddDeliveryBooking.Text = "Add Delivery Booking";
            this.btnAddDeliveryBooking.UseVisualStyleBackColor = true;
            this.btnAddDeliveryBooking.Click += new System.EventHandler(this.btnAddDeliveryBooking_Click);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabBookingParticipants);
            this.tabControl2.Controls.Add(this.tabBookingDetails);
            this.tabControl2.Controls.Add(this.tabDeliveryDeparture);
            this.tabControl2.Controls.Add(this.tabDeliveryArrival);
            this.tabControl2.Location = new System.Drawing.Point(9, 73);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(477, 246);
            this.tabControl2.TabIndex = 16;
            // 
            // tabBookingParticipants
            // 
            this.tabBookingParticipants.Controls.Add(this.cbxBookingDriverID);
            this.tabBookingParticipants.Controls.Add(this.cbxBookingClientID);
            this.tabBookingParticipants.Controls.Add(this.cbxBookingStaffID);
            this.tabBookingParticipants.Controls.Add(this.cbxBookingTruckID);
            this.tabBookingParticipants.Controls.Add(this.label8);
            this.tabBookingParticipants.Controls.Add(this.label9);
            this.tabBookingParticipants.Controls.Add(this.label11);
            this.tabBookingParticipants.Controls.Add(this.label12);
            this.tabBookingParticipants.Location = new System.Drawing.Point(4, 22);
            this.tabBookingParticipants.Name = "tabBookingParticipants";
            this.tabBookingParticipants.Padding = new System.Windows.Forms.Padding(3);
            this.tabBookingParticipants.Size = new System.Drawing.Size(469, 220);
            this.tabBookingParticipants.TabIndex = 0;
            this.tabBookingParticipants.Text = "Booking Participants:";
            this.tabBookingParticipants.UseVisualStyleBackColor = true;
            // 
            // cbxBookingDriverID
            // 
            this.cbxBookingDriverID.FormattingEnabled = true;
            this.cbxBookingDriverID.Location = new System.Drawing.Point(93, 97);
            this.cbxBookingDriverID.Name = "cbxBookingDriverID";
            this.cbxBookingDriverID.Size = new System.Drawing.Size(197, 21);
            this.cbxBookingDriverID.TabIndex = 38;
            // 
            // cbxBookingClientID
            // 
            this.cbxBookingClientID.FormattingEnabled = true;
            this.cbxBookingClientID.Location = new System.Drawing.Point(93, 70);
            this.cbxBookingClientID.Name = "cbxBookingClientID";
            this.cbxBookingClientID.Size = new System.Drawing.Size(197, 21);
            this.cbxBookingClientID.TabIndex = 37;
            // 
            // cbxBookingStaffID
            // 
            this.cbxBookingStaffID.FormattingEnabled = true;
            this.cbxBookingStaffID.Location = new System.Drawing.Point(93, 43);
            this.cbxBookingStaffID.Name = "cbxBookingStaffID";
            this.cbxBookingStaffID.Size = new System.Drawing.Size(197, 21);
            this.cbxBookingStaffID.TabIndex = 36;
            // 
            // cbxBookingTruckID
            // 
            this.cbxBookingTruckID.FormattingEnabled = true;
            this.cbxBookingTruckID.Location = new System.Drawing.Point(93, 16);
            this.cbxBookingTruckID.Name = "cbxBookingTruckID";
            this.cbxBookingTruckID.Size = new System.Drawing.Size(197, 21);
            this.cbxBookingTruckID.TabIndex = 35;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 34;
            this.label8.Text = "Driver ID:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 33;
            this.label9.Text = "Client ID:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 42);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 13);
            this.label11.TabIndex = 31;
            this.label11.Text = "Staff ID:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 13);
            this.label12.TabIndex = 30;
            this.label12.Text = "Truck ID:";
            // 
            // tabBookingDetails
            // 
            this.tabBookingDetails.Controls.Add(this.cbxBookingGoodsID);
            this.tabBookingDetails.Controls.Add(this.label10);
            this.tabBookingDetails.Controls.Add(this.rtbBookingNotes);
            this.tabBookingDetails.Controls.Add(this.tbxDeliveryDistance);
            this.tabBookingDetails.Controls.Add(this.tbxBookingDateMade);
            this.tabBookingDetails.Controls.Add(this.label15);
            this.tabBookingDetails.Controls.Add(this.label16);
            this.tabBookingDetails.Controls.Add(this.label17);
            this.tabBookingDetails.Location = new System.Drawing.Point(4, 22);
            this.tabBookingDetails.Name = "tabBookingDetails";
            this.tabBookingDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tabBookingDetails.Size = new System.Drawing.Size(469, 220);
            this.tabBookingDetails.TabIndex = 1;
            this.tabBookingDetails.Text = "Booking Details:";
            this.tabBookingDetails.UseVisualStyleBackColor = true;
            // 
            // cbxBookingGoodsID
            // 
            this.cbxBookingGoodsID.FormattingEnabled = true;
            this.cbxBookingGoodsID.Location = new System.Drawing.Point(129, 44);
            this.cbxBookingGoodsID.Name = "cbxBookingGoodsID";
            this.cbxBookingGoodsID.Size = new System.Drawing.Size(189, 21);
            this.cbxBookingGoodsID.TabIndex = 41;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 44);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 40;
            this.label10.Text = "Goods ID:";
            // 
            // rtbBookingNotes
            // 
            this.rtbBookingNotes.Location = new System.Drawing.Point(129, 104);
            this.rtbBookingNotes.Name = "rtbBookingNotes";
            this.rtbBookingNotes.Size = new System.Drawing.Size(301, 101);
            this.rtbBookingNotes.TabIndex = 39;
            this.rtbBookingNotes.Text = "";
            // 
            // tbxDeliveryDistance
            // 
            this.tbxDeliveryDistance.Location = new System.Drawing.Point(129, 74);
            this.tbxDeliveryDistance.Name = "tbxDeliveryDistance";
            this.tbxDeliveryDistance.Size = new System.Drawing.Size(189, 20);
            this.tbxDeliveryDistance.TabIndex = 38;
            // 
            // tbxBookingDateMade
            // 
            this.tbxBookingDateMade.Location = new System.Drawing.Point(129, 15);
            this.tbxBookingDateMade.Name = "tbxBookingDateMade";
            this.tbxBookingDateMade.Size = new System.Drawing.Size(189, 20);
            this.tbxBookingDateMade.TabIndex = 36;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(7, 74);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(93, 13);
            this.label15.TabIndex = 32;
            this.label15.Text = "Delivery Distance:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(7, 104);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(80, 13);
            this.label16.TabIndex = 31;
            this.label16.Text = "Booking Notes:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 15);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(105, 13);
            this.label17.TabIndex = 30;
            this.label17.Text = "Booking Date Made:";
            // 
            // tabDeliveryDeparture
            // 
            this.tabDeliveryDeparture.Controls.Add(this.tbxDepartureCity);
            this.tabDeliveryDeparture.Controls.Add(this.tbxDepartureAdrArea);
            this.tabDeliveryDeparture.Controls.Add(this.tbxDepartureAdrNumber);
            this.tabDeliveryDeparture.Controls.Add(this.tbxDepartureStreetName);
            this.tabDeliveryDeparture.Controls.Add(this.tbxDepartureDate);
            this.tabDeliveryDeparture.Controls.Add(this.label13);
            this.tabDeliveryDeparture.Controls.Add(this.label14);
            this.tabDeliveryDeparture.Controls.Add(this.label18);
            this.tabDeliveryDeparture.Controls.Add(this.label19);
            this.tabDeliveryDeparture.Controls.Add(this.label20);
            this.tabDeliveryDeparture.Location = new System.Drawing.Point(4, 22);
            this.tabDeliveryDeparture.Name = "tabDeliveryDeparture";
            this.tabDeliveryDeparture.Padding = new System.Windows.Forms.Padding(3);
            this.tabDeliveryDeparture.Size = new System.Drawing.Size(469, 220);
            this.tabDeliveryDeparture.TabIndex = 2;
            this.tabDeliveryDeparture.Text = "Delivery Departure:";
            this.tabDeliveryDeparture.UseVisualStyleBackColor = true;
            // 
            // tbxDepartureCity
            // 
            this.tbxDepartureCity.Location = new System.Drawing.Point(140, 118);
            this.tbxDepartureCity.Name = "tbxDepartureCity";
            this.tbxDepartureCity.Size = new System.Drawing.Size(189, 20);
            this.tbxDepartureCity.TabIndex = 28;
            // 
            // tbxDepartureAdrArea
            // 
            this.tbxDepartureAdrArea.Location = new System.Drawing.Point(140, 92);
            this.tbxDepartureAdrArea.Name = "tbxDepartureAdrArea";
            this.tbxDepartureAdrArea.Size = new System.Drawing.Size(189, 20);
            this.tbxDepartureAdrArea.TabIndex = 27;
            // 
            // tbxDepartureAdrNumber
            // 
            this.tbxDepartureAdrNumber.Location = new System.Drawing.Point(140, 66);
            this.tbxDepartureAdrNumber.Name = "tbxDepartureAdrNumber";
            this.tbxDepartureAdrNumber.Size = new System.Drawing.Size(189, 20);
            this.tbxDepartureAdrNumber.TabIndex = 26;
            // 
            // tbxDepartureStreetName
            // 
            this.tbxDepartureStreetName.Location = new System.Drawing.Point(140, 40);
            this.tbxDepartureStreetName.Name = "tbxDepartureStreetName";
            this.tbxDepartureStreetName.Size = new System.Drawing.Size(189, 20);
            this.tbxDepartureStreetName.TabIndex = 25;
            // 
            // tbxDepartureDate
            // 
            this.tbxDepartureDate.Location = new System.Drawing.Point(140, 14);
            this.tbxDepartureDate.Name = "tbxDepartureDate";
            this.tbxDepartureDate.Size = new System.Drawing.Size(189, 20);
            this.tbxDepartureDate.TabIndex = 24;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 118);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(108, 13);
            this.label13.TabIndex = 22;
            this.label13.Text = "Departure City Name:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 92);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(117, 13);
            this.label14.TabIndex = 21;
            this.label14.Text = "Departure Adress Area:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 66);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(132, 13);
            this.label18.TabIndex = 20;
            this.label18.Text = "Departure Adress Number:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(7, 40);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(119, 13);
            this.label19.TabIndex = 19;
            this.label19.Text = "Departure Street Name:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 14);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(83, 13);
            this.label20.TabIndex = 18;
            this.label20.Text = "Departure Date:";
            // 
            // tabDeliveryArrival
            // 
            this.tabDeliveryArrival.Controls.Add(this.tbxArrivalCity);
            this.tabDeliveryArrival.Controls.Add(this.tbxArrivalAdrArea);
            this.tabDeliveryArrival.Controls.Add(this.tbxArrivalAdrNumber);
            this.tabDeliveryArrival.Controls.Add(this.tbxArrivalStreetName);
            this.tabDeliveryArrival.Controls.Add(this.tbxArrivalDate);
            this.tabDeliveryArrival.Controls.Add(this.label7);
            this.tabDeliveryArrival.Controls.Add(this.label21);
            this.tabDeliveryArrival.Controls.Add(this.label22);
            this.tabDeliveryArrival.Controls.Add(this.label23);
            this.tabDeliveryArrival.Controls.Add(this.label24);
            this.tabDeliveryArrival.Location = new System.Drawing.Point(4, 22);
            this.tabDeliveryArrival.Name = "tabDeliveryArrival";
            this.tabDeliveryArrival.Padding = new System.Windows.Forms.Padding(3);
            this.tabDeliveryArrival.Size = new System.Drawing.Size(469, 220);
            this.tabDeliveryArrival.TabIndex = 3;
            this.tabDeliveryArrival.Text = "Delivery Arrival:";
            this.tabDeliveryArrival.UseVisualStyleBackColor = true;
            // 
            // tbxArrivalCity
            // 
            this.tbxArrivalCity.Location = new System.Drawing.Point(140, 116);
            this.tbxArrivalCity.Name = "tbxArrivalCity";
            this.tbxArrivalCity.Size = new System.Drawing.Size(189, 20);
            this.tbxArrivalCity.TabIndex = 38;
            // 
            // tbxArrivalAdrArea
            // 
            this.tbxArrivalAdrArea.Location = new System.Drawing.Point(140, 90);
            this.tbxArrivalAdrArea.Name = "tbxArrivalAdrArea";
            this.tbxArrivalAdrArea.Size = new System.Drawing.Size(189, 20);
            this.tbxArrivalAdrArea.TabIndex = 37;
            // 
            // tbxArrivalAdrNumber
            // 
            this.tbxArrivalAdrNumber.Location = new System.Drawing.Point(140, 64);
            this.tbxArrivalAdrNumber.Name = "tbxArrivalAdrNumber";
            this.tbxArrivalAdrNumber.Size = new System.Drawing.Size(189, 20);
            this.tbxArrivalAdrNumber.TabIndex = 36;
            // 
            // tbxArrivalStreetName
            // 
            this.tbxArrivalStreetName.Location = new System.Drawing.Point(140, 38);
            this.tbxArrivalStreetName.Name = "tbxArrivalStreetName";
            this.tbxArrivalStreetName.Size = new System.Drawing.Size(189, 20);
            this.tbxArrivalStreetName.TabIndex = 35;
            // 
            // tbxArrivalDate
            // 
            this.tbxArrivalDate.Location = new System.Drawing.Point(140, 12);
            this.tbxArrivalDate.Name = "tbxArrivalDate";
            this.tbxArrivalDate.Size = new System.Drawing.Size(189, 20);
            this.tbxArrivalDate.TabIndex = 34;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 33;
            this.label7.Text = "Arrival City Name:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(7, 90);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(99, 13);
            this.label21.TabIndex = 32;
            this.label21.Text = "Arrival Adress Area:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(6, 64);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(114, 13);
            this.label22.TabIndex = 31;
            this.label22.Text = "Arrival Adress Number:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(7, 38);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(101, 13);
            this.label23.TabIndex = 30;
            this.label23.Text = "Arrival Street Name:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(6, 12);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(65, 13);
            this.label24.TabIndex = 29;
            this.label24.Text = "Arrival Date:";
            // 
            // btnDeleteDeliveryBooking
            // 
            this.btnDeleteDeliveryBooking.Location = new System.Drawing.Point(301, 45);
            this.btnDeleteDeliveryBooking.Name = "btnDeleteDeliveryBooking";
            this.btnDeleteDeliveryBooking.Size = new System.Drawing.Size(185, 23);
            this.btnDeleteDeliveryBooking.TabIndex = 15;
            this.btnDeleteDeliveryBooking.Text = "Delete Delivery Booking";
            this.btnDeleteDeliveryBooking.UseVisualStyleBackColor = true;
            this.btnDeleteDeliveryBooking.Click += new System.EventHandler(this.btnDeleteDeliveryBooking_Click);
            // 
            // btnUpdateDeliveryBooking
            // 
            this.btnUpdateDeliveryBooking.Location = new System.Drawing.Point(301, 16);
            this.btnUpdateDeliveryBooking.Name = "btnUpdateDeliveryBooking";
            this.btnUpdateDeliveryBooking.Size = new System.Drawing.Size(185, 23);
            this.btnUpdateDeliveryBooking.TabIndex = 14;
            this.btnUpdateDeliveryBooking.Text = "Update Delivery Booking";
            this.btnUpdateDeliveryBooking.UseVisualStyleBackColor = true;
            this.btnUpdateDeliveryBooking.Click += new System.EventHandler(this.btnUpdateDeliveryBooking_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Select delivery ID:";
            // 
            // cbxDeliveryID
            // 
            this.cbxDeliveryID.FormattingEnabled = true;
            this.cbxDeliveryID.Items.AddRange(new object[] {
            "New..."});
            this.cbxDeliveryID.Location = new System.Drawing.Point(106, 46);
            this.cbxDeliveryID.Name = "cbxDeliveryID";
            this.cbxDeliveryID.Size = new System.Drawing.Size(165, 21);
            this.cbxDeliveryID.TabIndex = 12;
            this.cbxDeliveryID.SelectedIndexChanged += new System.EventHandler(this.cbxDeliveryID_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(297, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Select an existing delivery ID to update or delete the booking:";
            // 
            // Bookings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 409);
            this.Controls.Add(this.tabControl1);
            this.Name = "Bookings";
            this.Text = " Manage Bookings";
            this.Load += new System.EventHandler(this.Bookings_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabBookingParticipants.ResumeLayout(false);
            this.tabBookingParticipants.PerformLayout();
            this.tabBookingDetails.ResumeLayout(false);
            this.tabBookingDetails.PerformLayout();
            this.tabDeliveryDeparture.ResumeLayout(false);
            this.tabDeliveryDeparture.PerformLayout();
            this.tabDeliveryArrival.ResumeLayout(false);
            this.tabDeliveryArrival.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxGoodsID;
        private System.Windows.Forms.TextBox tbxGoodsType;
        private System.Windows.Forms.RichTextBox rtbGoodsDesciption;
        private System.Windows.Forms.Button btnDeleteGoodsBooking;
        private System.Windows.Forms.Button btnUpdateGoodsBooking;
        private System.Windows.Forms.Button btnAddGoodsBooking;
        private System.Windows.Forms.Button btnDeleteDeliveryBooking;
        private System.Windows.Forms.Button btnUpdateDeliveryBooking;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxDeliveryID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabBookingParticipants;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TabPage tabBookingDetails;
        private System.Windows.Forms.TextBox tbxDeliveryDistance;
        private System.Windows.Forms.TextBox tbxBookingDateMade;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.RichTextBox rtbBookingNotes;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabPage tabDeliveryDeparture;
        private System.Windows.Forms.Button btnAddDeliveryBooking;
        private System.Windows.Forms.TabPage tabDeliveryArrival;
        private System.Windows.Forms.ComboBox cbxBookingDriverID;
        private System.Windows.Forms.ComboBox cbxBookingClientID;
        private System.Windows.Forms.ComboBox cbxBookingStaffID;
        private System.Windows.Forms.ComboBox cbxBookingTruckID;
        private System.Windows.Forms.ComboBox cbxBookingGoodsID;
        private System.Windows.Forms.TextBox tbxDepartureCity;
        private System.Windows.Forms.TextBox tbxDepartureAdrArea;
        private System.Windows.Forms.TextBox tbxDepartureAdrNumber;
        private System.Windows.Forms.TextBox tbxDepartureStreetName;
        private System.Windows.Forms.TextBox tbxDepartureDate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox tbxArrivalCity;
        private System.Windows.Forms.TextBox tbxArrivalAdrArea;
        private System.Windows.Forms.TextBox tbxArrivalAdrNumber;
        private System.Windows.Forms.TextBox tbxArrivalStreetName;
        private System.Windows.Forms.TextBox tbxArrivalDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
    }
}