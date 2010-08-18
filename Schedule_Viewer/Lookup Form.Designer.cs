namespace Schedule_Viewer
{
    partial class Lookup_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Lookup_Form));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboTerm = new System.Windows.Forms.ComboBox();
            this.comboSession = new System.Windows.Forms.ComboBox();
            this.comboCampus = new System.Windows.Forms.ComboBox();
            this.comboDistanceLearning = new System.Windows.Forms.ComboBox();
            this.comboCollege = new System.Windows.Forms.ComboBox();
            this.comboDepartment = new System.Windows.Forms.ComboBox();
            this.comboStatus = new System.Windows.Forms.ComboBox();
            this.comboStatus2 = new System.Windows.Forms.ComboBox();
            this.comboLevel = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.labelDistanceLearning = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelStatus2 = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textCRN = new System.Windows.Forms.TextBox();
            this.textHours = new System.Windows.Forms.TextBox();
            this.textNumber = new System.Windows.Forms.TextBox();
            this.textSubject = new System.Windows.Forms.TextBox();
            this.textTitle = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.checkMon1 = new System.Windows.Forms.CheckBox();
            this.checkTues1 = new System.Windows.Forms.CheckBox();
            this.checkWed1 = new System.Windows.Forms.CheckBox();
            this.checkThurs1 = new System.Windows.Forms.CheckBox();
            this.checkFri1 = new System.Windows.Forms.CheckBox();
            this.checkSat1 = new System.Windows.Forms.CheckBox();
            this.checkSun1 = new System.Windows.Forms.CheckBox();
            this.checkSun2 = new System.Windows.Forms.CheckBox();
            this.checkSat2 = new System.Windows.Forms.CheckBox();
            this.checkFri2 = new System.Windows.Forms.CheckBox();
            this.checkThurs2 = new System.Windows.Forms.CheckBox();
            this.checkWed2 = new System.Windows.Forms.CheckBox();
            this.checkTues2 = new System.Windows.Forms.CheckBox();
            this.checkMon2 = new System.Windows.Forms.CheckBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.comboTime = new System.Windows.Forms.ComboBox();
            this.textInstructor = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.comboUGR = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.btnAddList = new System.Windows.Forms.Button();
            this.btnClearForm = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.textLabel = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.listLabels = new System.Windows.Forms.ListBox();
            this.label25 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.buttonClearList = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "TERM -- REQUIRED";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(154, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "TERM";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(321, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "SESSION (A, B && C Summer ONLY)";
            // 
            // comboTerm
            // 
            this.comboTerm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTerm.FormattingEnabled = true;
            this.comboTerm.Items.AddRange(new object[] {
            ""});
            this.comboTerm.Location = new System.Drawing.Point(157, 125);
            this.comboTerm.Name = "comboTerm";
            this.comboTerm.Size = new System.Drawing.Size(121, 21);
            this.comboTerm.TabIndex = 2;
            // 
            // comboSession
            // 
            this.comboSession.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSession.FormattingEnabled = true;
            this.comboSession.Items.AddRange(new object[] {
            ""});
            this.comboSession.Location = new System.Drawing.Point(324, 124);
            this.comboSession.Name = "comboSession";
            this.comboSession.Size = new System.Drawing.Size(166, 21);
            this.comboSession.TabIndex = 3;
            // 
            // comboCampus
            // 
            this.comboCampus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCampus.FormattingEnabled = true;
            this.comboCampus.Items.AddRange(new object[] {
            ""});
            this.comboCampus.Location = new System.Drawing.Point(157, 153);
            this.comboCampus.Name = "comboCampus";
            this.comboCampus.Size = new System.Drawing.Size(217, 21);
            this.comboCampus.TabIndex = 4;
            // 
            // comboDistanceLearning
            // 
            this.comboDistanceLearning.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDistanceLearning.FormattingEnabled = true;
            this.comboDistanceLearning.Items.AddRange(new object[] {
            ""});
            this.comboDistanceLearning.Location = new System.Drawing.Point(157, 181);
            this.comboDistanceLearning.Name = "comboDistanceLearning";
            this.comboDistanceLearning.Size = new System.Drawing.Size(245, 21);
            this.comboDistanceLearning.TabIndex = 6;
            // 
            // comboCollege
            // 
            this.comboCollege.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCollege.FormattingEnabled = true;
            this.comboCollege.Items.AddRange(new object[] {
            ""});
            this.comboCollege.Location = new System.Drawing.Point(157, 209);
            this.comboCollege.Name = "comboCollege";
            this.comboCollege.Size = new System.Drawing.Size(312, 21);
            this.comboCollege.TabIndex = 7;
            // 
            // comboDepartment
            // 
            this.comboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDepartment.FormattingEnabled = true;
            this.comboDepartment.Items.AddRange(new object[] {
            ""});
            this.comboDepartment.Location = new System.Drawing.Point(157, 237);
            this.comboDepartment.Name = "comboDepartment";
            this.comboDepartment.Size = new System.Drawing.Size(333, 21);
            this.comboDepartment.TabIndex = 8;
            // 
            // comboStatus
            // 
            this.comboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboStatus.FormattingEnabled = true;
            this.comboStatus.Items.AddRange(new object[] {
            ""});
            this.comboStatus.Location = new System.Drawing.Point(157, 265);
            this.comboStatus.Name = "comboStatus";
            this.comboStatus.Size = new System.Drawing.Size(70, 21);
            this.comboStatus.TabIndex = 9;
            // 
            // comboStatus2
            // 
            this.comboStatus2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboStatus2.FormattingEnabled = true;
            this.comboStatus2.Items.AddRange(new object[] {
            ""});
            this.comboStatus2.Location = new System.Drawing.Point(157, 293);
            this.comboStatus2.Name = "comboStatus2";
            this.comboStatus2.Size = new System.Drawing.Size(245, 21);
            this.comboStatus2.TabIndex = 10;
            // 
            // comboLevel
            // 
            this.comboLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboLevel.FormattingEnabled = true;
            this.comboLevel.Items.AddRange(new object[] {
            ""});
            this.comboLevel.Location = new System.Drawing.Point(157, 321);
            this.comboLevel.Name = "comboLevel";
            this.comboLevel.Size = new System.Drawing.Size(121, 21);
            this.comboLevel.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(99, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "CAMPUS";
            // 
            // labelDistanceLearning
            // 
            this.labelDistanceLearning.AutoSize = true;
            this.labelDistanceLearning.Location = new System.Drawing.Point(32, 184);
            this.labelDistanceLearning.Name = "labelDistanceLearning";
            this.labelDistanceLearning.Size = new System.Drawing.Size(119, 13);
            this.labelDistanceLearning.TabIndex = 13;
            this.labelDistanceLearning.Text = "DISTANCE LEARNING";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(95, 212);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "COLLEGE";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(69, 240);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "DEPARTMENT";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(111, 324);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "LEVEL";
            // 
            // labelStatus2
            // 
            this.labelStatus2.AutoSize = true;
            this.labelStatus2.Location = new System.Drawing.Point(92, 296);
            this.labelStatus2.Name = "labelStatus2";
            this.labelStatus2.Size = new System.Drawing.Size(59, 13);
            this.labelStatus2.TabIndex = 17;
            this.labelStatus2.Text = "STATUS 2";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(101, 268);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(50, 13);
            this.labelStatus.TabIndex = 16;
            this.labelStatus.Text = "STATUS";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(165, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(236, 24);
            this.label11.TabIndex = 19;
            this.label11.Text = "USF SCHEDULE SEARCH";
            // 
            // textCRN
            // 
            this.textCRN.Location = new System.Drawing.Point(157, 349);
            this.textCRN.MaxLength = 5;
            this.textCRN.Name = "textCRN";
            this.textCRN.Size = new System.Drawing.Size(57, 20);
            this.textCRN.TabIndex = 12;
            // 
            // textHours
            // 
            this.textHours.Location = new System.Drawing.Point(158, 465);
            this.textHours.Name = "textHours";
            this.textHours.Size = new System.Drawing.Size(57, 20);
            this.textHours.TabIndex = 16;
            // 
            // textNumber
            // 
            this.textNumber.Location = new System.Drawing.Point(157, 401);
            this.textNumber.MaxLength = 4;
            this.textNumber.Name = "textNumber";
            this.textNumber.Size = new System.Drawing.Size(57, 20);
            this.textNumber.TabIndex = 14;
            // 
            // textSubject
            // 
            this.textSubject.Location = new System.Drawing.Point(157, 375);
            this.textSubject.MaxLength = 3;
            this.textSubject.Name = "textSubject";
            this.textSubject.Size = new System.Drawing.Size(57, 20);
            this.textSubject.TabIndex = 13;
            // 
            // textTitle
            // 
            this.textTitle.Location = new System.Drawing.Point(157, 427);
            this.textTitle.Name = "textTitle";
            this.textTitle.Size = new System.Drawing.Size(294, 20);
            this.textTitle.TabIndex = 15;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(121, 352);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(30, 13);
            this.label12.TabIndex = 25;
            this.label12.Text = "CRN";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(99, 378);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 13);
            this.label13.TabIndex = 26;
            this.label13.Text = "SUBJECT";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(99, 404);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(54, 13);
            this.label14.TabIndex = 27;
            this.label14.Text = "NUMBER";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(114, 430);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(37, 13);
            this.label15.TabIndex = 28;
            this.label15.Text = "TITLE";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(63, 468);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(89, 13);
            this.label16.TabIndex = 29;
            this.label16.Text = "CREDIT HOURS";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(158, 492);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(85, 13);
            this.label17.TabIndex = 30;
            this.label17.Text = "meets only on";
            // 
            // checkMon1
            // 
            this.checkMon1.AutoSize = true;
            this.checkMon1.Location = new System.Drawing.Point(161, 509);
            this.checkMon1.Name = "checkMon1";
            this.checkMon1.Size = new System.Drawing.Size(64, 17);
            this.checkMon1.TabIndex = 31;
            this.checkMon1.TabStop = false;
            this.checkMon1.Text = "Monday";
            this.checkMon1.UseVisualStyleBackColor = true;
            // 
            // checkTues1
            // 
            this.checkTues1.AutoSize = true;
            this.checkTues1.Location = new System.Drawing.Point(161, 530);
            this.checkTues1.Name = "checkTues1";
            this.checkTues1.Size = new System.Drawing.Size(67, 17);
            this.checkTues1.TabIndex = 32;
            this.checkTues1.Text = "Tuesday";
            this.checkTues1.UseVisualStyleBackColor = true;
            // 
            // checkWed1
            // 
            this.checkWed1.AutoSize = true;
            this.checkWed1.Location = new System.Drawing.Point(161, 551);
            this.checkWed1.Name = "checkWed1";
            this.checkWed1.Size = new System.Drawing.Size(83, 17);
            this.checkWed1.TabIndex = 33;
            this.checkWed1.Text = "Wednesday";
            this.checkWed1.UseVisualStyleBackColor = true;
            // 
            // checkThurs1
            // 
            this.checkThurs1.AutoSize = true;
            this.checkThurs1.Location = new System.Drawing.Point(161, 571);
            this.checkThurs1.Name = "checkThurs1";
            this.checkThurs1.Size = new System.Drawing.Size(70, 17);
            this.checkThurs1.TabIndex = 34;
            this.checkThurs1.Text = "Thursday";
            this.checkThurs1.UseVisualStyleBackColor = true;
            // 
            // checkFri1
            // 
            this.checkFri1.AutoSize = true;
            this.checkFri1.Location = new System.Drawing.Point(161, 590);
            this.checkFri1.Name = "checkFri1";
            this.checkFri1.Size = new System.Drawing.Size(54, 17);
            this.checkFri1.TabIndex = 35;
            this.checkFri1.Text = "Friday";
            this.checkFri1.UseVisualStyleBackColor = true;
            // 
            // checkSat1
            // 
            this.checkSat1.AutoSize = true;
            this.checkSat1.Location = new System.Drawing.Point(161, 611);
            this.checkSat1.Name = "checkSat1";
            this.checkSat1.Size = new System.Drawing.Size(68, 17);
            this.checkSat1.TabIndex = 36;
            this.checkSat1.Text = "Saturday";
            this.checkSat1.UseVisualStyleBackColor = true;
            // 
            // checkSun1
            // 
            this.checkSun1.AutoSize = true;
            this.checkSun1.Location = new System.Drawing.Point(161, 632);
            this.checkSun1.Name = "checkSun1";
            this.checkSun1.Size = new System.Drawing.Size(62, 17);
            this.checkSun1.TabIndex = 37;
            this.checkSun1.Text = "Sunday";
            this.checkSun1.UseVisualStyleBackColor = true;
            // 
            // checkSun2
            // 
            this.checkSun2.AutoSize = true;
            this.checkSun2.Location = new System.Drawing.Point(320, 632);
            this.checkSun2.Name = "checkSun2";
            this.checkSun2.Size = new System.Drawing.Size(62, 17);
            this.checkSun2.TabIndex = 45;
            this.checkSun2.Text = "Sunday";
            this.checkSun2.UseVisualStyleBackColor = true;
            // 
            // checkSat2
            // 
            this.checkSat2.AutoSize = true;
            this.checkSat2.Location = new System.Drawing.Point(320, 611);
            this.checkSat2.Name = "checkSat2";
            this.checkSat2.Size = new System.Drawing.Size(68, 17);
            this.checkSat2.TabIndex = 44;
            this.checkSat2.Text = "Saturday";
            this.checkSat2.UseVisualStyleBackColor = true;
            // 
            // checkFri2
            // 
            this.checkFri2.AutoSize = true;
            this.checkFri2.Location = new System.Drawing.Point(320, 590);
            this.checkFri2.Name = "checkFri2";
            this.checkFri2.Size = new System.Drawing.Size(54, 17);
            this.checkFri2.TabIndex = 43;
            this.checkFri2.Text = "Friday";
            this.checkFri2.UseVisualStyleBackColor = true;
            // 
            // checkThurs2
            // 
            this.checkThurs2.AutoSize = true;
            this.checkThurs2.Location = new System.Drawing.Point(320, 571);
            this.checkThurs2.Name = "checkThurs2";
            this.checkThurs2.Size = new System.Drawing.Size(70, 17);
            this.checkThurs2.TabIndex = 42;
            this.checkThurs2.Text = "Thursday";
            this.checkThurs2.UseVisualStyleBackColor = true;
            // 
            // checkWed2
            // 
            this.checkWed2.AutoSize = true;
            this.checkWed2.Location = new System.Drawing.Point(320, 551);
            this.checkWed2.Name = "checkWed2";
            this.checkWed2.Size = new System.Drawing.Size(83, 17);
            this.checkWed2.TabIndex = 41;
            this.checkWed2.Text = "Wednesday";
            this.checkWed2.UseVisualStyleBackColor = true;
            // 
            // checkTues2
            // 
            this.checkTues2.AutoSize = true;
            this.checkTues2.Location = new System.Drawing.Point(320, 530);
            this.checkTues2.Name = "checkTues2";
            this.checkTues2.Size = new System.Drawing.Size(67, 17);
            this.checkTues2.TabIndex = 40;
            this.checkTues2.Text = "Tuesday";
            this.checkTues2.UseVisualStyleBackColor = true;
            // 
            // checkMon2
            // 
            this.checkMon2.AutoSize = true;
            this.checkMon2.Location = new System.Drawing.Point(320, 509);
            this.checkMon2.Name = "checkMon2";
            this.checkMon2.Size = new System.Drawing.Size(64, 17);
            this.checkMon2.TabIndex = 39;
            this.checkMon2.Text = "Monday";
            this.checkMon2.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(317, 492);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(104, 13);
            this.label18.TabIndex = 38;
            this.label18.Text = "meets at least on";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(256, 555);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(33, 18);
            this.label19.TabIndex = 46;
            this.label19.Text = "OR";
            // 
            // comboTime
            // 
            this.comboTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTime.FormattingEnabled = true;
            this.comboTime.Items.AddRange(new object[] {
            ""});
            this.comboTime.Location = new System.Drawing.Point(161, 656);
            this.comboTime.Name = "comboTime";
            this.comboTime.Size = new System.Drawing.Size(83, 21);
            this.comboTime.TabIndex = 17;
            // 
            // textInstructor
            // 
            this.textInstructor.Location = new System.Drawing.Point(161, 684);
            this.textInstructor.Name = "textInstructor";
            this.textInstructor.Size = new System.Drawing.Size(213, 20);
            this.textInstructor.TabIndex = 18;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(86, 659);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(69, 13);
            this.label20.TabIndex = 49;
            this.label20.Text = "BEGIN TIME";
            // 
            // comboUGR
            // 
            this.comboUGR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboUGR.FormattingEnabled = true;
            this.comboUGR.Items.AddRange(new object[] {
            ""});
            this.comboUGR.Location = new System.Drawing.Point(161, 710);
            this.comboUGR.Name = "comboUGR";
            this.comboUGR.Size = new System.Drawing.Size(221, 21);
            this.comboUGR.TabIndex = 19;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(77, 687);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(78, 13);
            this.label21.TabIndex = 51;
            this.label21.Text = "INSTRUCTOR";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(46, 705);
            this.label22.MaximumSize = new System.Drawing.Size(110, 30);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(109, 26);
            this.label22.TabIndex = 52;
            this.label22.Text = "UNDERGRADUATE REQUIREMENTS";
            // 
            // btnAddList
            // 
            this.btnAddList.Location = new System.Drawing.Point(203, 743);
            this.btnAddList.Name = "btnAddList";
            this.btnAddList.Size = new System.Drawing.Size(76, 23);
            this.btnAddList.TabIndex = 20;
            this.btnAddList.Text = "AddToList";
            this.btnAddList.UseVisualStyleBackColor = true;
            this.btnAddList.Click += new System.EventHandler(this.btnAddList_Click);
            // 
            // btnClearForm
            // 
            this.btnClearForm.Location = new System.Drawing.Point(299, 743);
            this.btnClearForm.Name = "btnClearForm";
            this.btnClearForm.Size = new System.Drawing.Size(75, 23);
            this.btnClearForm.TabIndex = 21;
            this.btnClearForm.Text = "Clear Form";
            this.btnClearForm.UseVisualStyleBackColor = true;
            this.btnClearForm.Click += new System.EventHandler(this.btnClearForm_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(98, 76);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(180, 13);
            this.label23.TabIndex = 55;
            this.label23.Text = "SEARCH LABEL -- REQUIRED";
            // 
            // textLabel
            // 
            this.textLabel.Location = new System.Drawing.Point(289, 73);
            this.textLabel.Name = "textLabel";
            this.textLabel.Size = new System.Drawing.Size(180, 20);
            this.textLabel.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(220, 352);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(177, 13);
            this.label5.TabIndex = 57;
            this.label5.Text = "Must be five digits. Example: 82520 ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(214, 378);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(276, 13);
            this.label9.TabIndex = 58;
            this.label9.Text = "  Must be three characters. Examples: AMS, BSC, ENG.  ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(220, 404);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(324, 13);
            this.label10.TabIndex = 59;
            this.label10.Text = "To search by course level, enter the first digit of the course number.";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(157, 449);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(148, 13);
            this.label24.TabIndex = 60;
            this.label24.Text = "Enter full or partial course title.";
            // 
            // listLabels
            // 
            this.listLabels.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listLabels.FormattingEnabled = true;
            this.listLabels.Location = new System.Drawing.Point(594, 56);
            this.listLabels.Name = "listLabels";
            this.listLabels.Size = new System.Drawing.Size(190, 589);
            this.listLabels.TabIndex = 22;
            this.listLabels.SelectedIndexChanged += new System.EventHandler(this.listLabels_SelectedIndexChanged);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(594, 37);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(91, 13);
            this.label25.TabIndex = 62;
            this.label25.Text = "Chosen Searches";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Enabled = false;
            this.btnSearch.Location = new System.Drawing.Point(594, 662);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(187, 23);
            this.btnSearch.TabIndex = 23;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Location = new System.Drawing.Point(594, 717);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(190, 23);
            this.btnRemove.TabIndex = 25;
            this.btnRemove.Text = "Remove Selected Item";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // buttonClearList
            // 
            this.buttonClearList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClearList.Location = new System.Drawing.Point(594, 746);
            this.buttonClearList.Name = "buttonClearList";
            this.buttonClearList.Size = new System.Drawing.Size(190, 23);
            this.buttonClearList.TabIndex = 26;
            this.buttonClearList.Text = "Clear List";
            this.buttonClearList.UseVisualStyleBackColor = true;
            this.buttonClearList.Click += new System.EventHandler(this.buttonClearList_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEdit.Location = new System.Drawing.Point(594, 691);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(187, 23);
            this.buttonEdit.TabIndex = 24;
            this.buttonEdit.Text = "Edit Selected Item";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(796, 24);
            this.menuStrip1.TabIndex = 63;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.saveToolStripMenuItem.Text = "Save Searches";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.loadToolStripMenuItem.Text = "Load Searches";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // Lookup_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 772);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonClearList);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.listLabels);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textLabel);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.btnClearForm);
            this.Controls.Add(this.btnAddList);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.comboUGR);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.textInstructor);
            this.Controls.Add(this.comboTime);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.checkSun2);
            this.Controls.Add(this.checkSat2);
            this.Controls.Add(this.checkFri2);
            this.Controls.Add(this.checkThurs2);
            this.Controls.Add(this.checkWed2);
            this.Controls.Add(this.checkTues2);
            this.Controls.Add(this.checkMon2);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.checkSun1);
            this.Controls.Add(this.checkSat1);
            this.Controls.Add(this.checkFri1);
            this.Controls.Add(this.checkThurs1);
            this.Controls.Add(this.checkWed1);
            this.Controls.Add(this.checkTues1);
            this.Controls.Add(this.checkMon1);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textTitle);
            this.Controls.Add(this.textSubject);
            this.Controls.Add(this.textNumber);
            this.Controls.Add(this.textHours);
            this.Controls.Add(this.textCRN);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.labelStatus2);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelDistanceLearning);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboLevel);
            this.Controls.Add(this.comboStatus2);
            this.Controls.Add(this.comboStatus);
            this.Controls.Add(this.comboDepartment);
            this.Controls.Add(this.comboCollege);
            this.Controls.Add(this.comboDistanceLearning);
            this.Controls.Add(this.comboCampus);
            this.Controls.Add(this.comboSession);
            this.Controls.Add(this.comboTerm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(812, 799);
            this.Name = "Lookup_Form";
            this.Text = "Lookup_Form";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboTerm;
        private System.Windows.Forms.ComboBox comboSession;
        private System.Windows.Forms.ComboBox comboCampus;
        private System.Windows.Forms.ComboBox comboDistanceLearning;
        private System.Windows.Forms.ComboBox comboCollege;
        private System.Windows.Forms.ComboBox comboDepartment;
        private System.Windows.Forms.ComboBox comboStatus;
        private System.Windows.Forms.ComboBox comboStatus2;
        private System.Windows.Forms.ComboBox comboLevel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelDistanceLearning;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelStatus2;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textCRN;
        private System.Windows.Forms.TextBox textHours;
        private System.Windows.Forms.TextBox textNumber;
        private System.Windows.Forms.TextBox textSubject;
        private System.Windows.Forms.TextBox textTitle;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.CheckBox checkMon1;
        private System.Windows.Forms.CheckBox checkTues1;
        private System.Windows.Forms.CheckBox checkWed1;
        private System.Windows.Forms.CheckBox checkThurs1;
        private System.Windows.Forms.CheckBox checkFri1;
        private System.Windows.Forms.CheckBox checkSat1;
        private System.Windows.Forms.CheckBox checkSun1;
        private System.Windows.Forms.CheckBox checkSun2;
        private System.Windows.Forms.CheckBox checkSat2;
        private System.Windows.Forms.CheckBox checkFri2;
        private System.Windows.Forms.CheckBox checkThurs2;
        private System.Windows.Forms.CheckBox checkWed2;
        private System.Windows.Forms.CheckBox checkTues2;
        private System.Windows.Forms.CheckBox checkMon2;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox comboTime;
        private System.Windows.Forms.TextBox textInstructor;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox comboUGR;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btnAddList;
        private System.Windows.Forms.Button btnClearForm;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox textLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.ListBox listLabels;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button buttonClearList;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}