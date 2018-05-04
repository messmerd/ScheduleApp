namespace ScheduleApp
{
    partial class AppWindow
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

        // DONT TOUCH ANYTHING BELOW THIS LINE
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Calendar.DrawTool drawTool2 = new Calendar.DrawTool();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppWindow));
            this.calendar_UI = new Calendar.DayView();
            this.menuTabs = new System.Windows.Forms.TabControl();
            this.searchTab = new System.Windows.Forms.TabPage();
            this.autocorrect_label = new System.Windows.Forms.Label();
            this.clickHelp1 = new System.Windows.Forms.Label();
            this.userHelpLabel = new System.Windows.Forms.Label();
            this.gccLogo = new System.Windows.Forms.PictureBox();
            this.scheduleTitle = new System.Windows.Forms.Label();
            this.filter_UI = new System.Windows.Forms.GroupBox();
            this.clear_adv = new System.Windows.Forms.Button();
            this.probability_combobox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rmp_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.professor_adv_label = new System.Windows.Forms.Label();
            this.adv_building_label = new System.Windows.Forms.Label();
            this.allNoneCheckBox = new System.Windows.Forms.CheckBox();
            this.professor_adv = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.secondTime_UI = new System.Windows.Forms.NumericUpDown();
            this.building_adv = new System.Windows.Forms.ComboBox();
            this.firstTime_UI = new System.Windows.Forms.NumericUpDown();
            this.between_label = new System.Windows.Forms.Label();
            this.F_checkBox = new System.Windows.Forms.CheckBox();
            this.R_checkBox = new System.Windows.Forms.CheckBox();
            this.W_checkBox = new System.Windows.Forms.CheckBox();
            this.T_checkBox = new System.Windows.Forms.CheckBox();
            this.M_checkBox = new System.Windows.Forms.CheckBox();
            this.day_label = new System.Windows.Forms.Label();
            this.advSearchBtn = new System.Windows.Forms.Button();
            this.searchBtn = new System.Windows.Forms.Button();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.searchResult_UI = new System.Windows.Forms.ListView();
            this.creditsCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.courseCodeCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.professorCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nameCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timeCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.daysCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.capacityCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rmpCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.probCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.scheduleTab = new System.Windows.Forms.TabPage();
            this.credits_notify_label = new System.Windows.Forms.Label();
            this.removeHelp = new System.Windows.Forms.Label();
            this.clearAll = new System.Windows.Forms.Button();
            this.scheduleView = new System.Windows.Forms.ListView();
            this.schedule_creditsCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.schedule_codeCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.schedule_profCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.schedule_nameCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.schedule_timeCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.schedule_buildingCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.schedule_roomCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.schedule_daysCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuBar = new System.Windows.Forms.MenuStrip();
            this.appMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.themes_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.nightTheme = new System.Windows.Forms.ToolStripMenuItem();
            this.blueTheme = new System.Windows.Forms.ToolStripMenuItem();
            this.crimsonTheme = new System.Windows.Forms.ToolStripMenuItem();
            this.classicTheme = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.menuTabs.SuspendLayout();
            this.searchTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gccLogo)).BeginInit();
            this.filter_UI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rmp_numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondTime_UI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstTime_UI)).BeginInit();
            this.scheduleTab.SuspendLayout();
            this.menuBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // calendar_UI
            // 
            drawTool2.DayView = this.calendar_UI;
            this.calendar_UI.ActiveTool = drawTool2;
            this.calendar_UI.AllowInplaceEditing = false;
            this.calendar_UI.AllowScroll = false;
            this.calendar_UI.DaysToShow = 5;
            this.calendar_UI.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.calendar_UI.HalfHourHeight = 11;
            this.calendar_UI.Location = new System.Drawing.Point(15, 210);
            this.calendar_UI.Name = "calendar_UI";
            this.calendar_UI.SelectedAppointment = null;
            this.calendar_UI.SelectionEnd = new System.DateTime(((long)(0)));
            this.calendar_UI.SelectionStart = new System.DateTime(((long)(0)));
            this.calendar_UI.Size = new System.Drawing.Size(822, 321);
            this.calendar_UI.StartDate = new System.DateTime(((long)(0)));
            this.calendar_UI.TabIndex = 3;
            this.calendar_UI.Text = "Schedule";
            this.calendar_UI.WorkingHourEnd = 22;
            this.calendar_UI.WorkingMinuteEnd = 0;
            this.calendar_UI.WorkingMinuteStart = 0;
            // 
            // menuTabs
            // 
            this.menuTabs.Controls.Add(this.searchTab);
            this.menuTabs.Controls.Add(this.scheduleTab);
            this.menuTabs.ItemSize = new System.Drawing.Size(200, 27);
            this.menuTabs.Location = new System.Drawing.Point(0, 27);
            this.menuTabs.Name = "menuTabs";
            this.menuTabs.SelectedIndex = 0;
            this.menuTabs.Size = new System.Drawing.Size(862, 575);
            this.menuTabs.TabIndex = 0;
            this.menuTabs.Click += new System.EventHandler(this.menuTabs_Click);
            // 
            // searchTab
            // 
            this.searchTab.BackColor = System.Drawing.Color.White;
            this.searchTab.Controls.Add(this.autocorrect_label);
            this.searchTab.Controls.Add(this.clickHelp1);
            this.searchTab.Controls.Add(this.userHelpLabel);
            this.searchTab.Controls.Add(this.gccLogo);
            this.searchTab.Controls.Add(this.scheduleTitle);
            this.searchTab.Controls.Add(this.filter_UI);
            this.searchTab.Controls.Add(this.advSearchBtn);
            this.searchTab.Controls.Add(this.searchBtn);
            this.searchTab.Controls.Add(this.searchBox);
            this.searchTab.Controls.Add(this.searchResult_UI);
            this.searchTab.Location = new System.Drawing.Point(4, 31);
            this.searchTab.Name = "searchTab";
            this.searchTab.Padding = new System.Windows.Forms.Padding(3);
            this.searchTab.Size = new System.Drawing.Size(854, 540);
            this.searchTab.TabIndex = 0;
            this.searchTab.Text = "Search";
            // 
            // autocorrect_label
            // 
            this.autocorrect_label.AutoSize = true;
            this.autocorrect_label.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autocorrect_label.ForeColor = System.Drawing.Color.IndianRed;
            this.autocorrect_label.Location = new System.Drawing.Point(106, 74);
            this.autocorrect_label.Name = "autocorrect_label";
            this.autocorrect_label.Size = new System.Drawing.Size(106, 13);
            this.autocorrect_label.TabIndex = 12;
            this.autocorrect_label.Text = "autocorrect_label";
            this.autocorrect_label.Visible = false;
            // 
            // clickHelp1
            // 
            this.clickHelp1.AutoSize = true;
            this.clickHelp1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clickHelp1.ForeColor = System.Drawing.Color.Black;
            this.clickHelp1.Location = new System.Drawing.Point(329, 504);
            this.clickHelp1.Name = "clickHelp1";
            this.clickHelp1.Size = new System.Drawing.Size(202, 16);
            this.clickHelp1.TabIndex = 10;
            this.clickHelp1.Text = "Double click to add a course!";
            // 
            // userHelpLabel
            // 
            this.userHelpLabel.AutoSize = true;
            this.userHelpLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.userHelpLabel.Location = new System.Drawing.Point(106, 87);
            this.userHelpLabel.Name = "userHelpLabel";
            this.userHelpLabel.Size = new System.Drawing.Size(11, 13);
            this.userHelpLabel.TabIndex = 9;
            this.userHelpLabel.Text = " ";
            // 
            // gccLogo
            // 
            this.gccLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gccLogo.Image = ((System.Drawing.Image)(resources.GetObject("gccLogo.Image")));
            this.gccLogo.Location = new System.Drawing.Point(12, 9);
            this.gccLogo.Name = "gccLogo";
            this.gccLogo.Size = new System.Drawing.Size(84, 84);
            this.gccLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gccLogo.TabIndex = 8;
            this.gccLogo.TabStop = false;
            // 
            // scheduleTitle
            // 
            this.scheduleTitle.AutoSize = true;
            this.scheduleTitle.Font = new System.Drawing.Font("Sitka Text", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scheduleTitle.ForeColor = System.Drawing.Color.Black;
            this.scheduleTitle.Location = new System.Drawing.Point(95, 6);
            this.scheduleTitle.Name = "scheduleTitle";
            this.scheduleTitle.Size = new System.Drawing.Size(341, 39);
            this.scheduleTitle.TabIndex = 7;
            this.scheduleTitle.Text = "GCC Scheduling Assistant";
            // 
            // filter_UI
            // 
            this.filter_UI.BackColor = System.Drawing.Color.White;
            this.filter_UI.Controls.Add(this.clear_adv);
            this.filter_UI.Controls.Add(this.probability_combobox);
            this.filter_UI.Controls.Add(this.label2);
            this.filter_UI.Controls.Add(this.rmp_numericUpDown);
            this.filter_UI.Controls.Add(this.label3);
            this.filter_UI.Controls.Add(this.professor_adv_label);
            this.filter_UI.Controls.Add(this.adv_building_label);
            this.filter_UI.Controls.Add(this.allNoneCheckBox);
            this.filter_UI.Controls.Add(this.professor_adv);
            this.filter_UI.Controls.Add(this.label1);
            this.filter_UI.Controls.Add(this.secondTime_UI);
            this.filter_UI.Controls.Add(this.building_adv);
            this.filter_UI.Controls.Add(this.firstTime_UI);
            this.filter_UI.Controls.Add(this.between_label);
            this.filter_UI.Controls.Add(this.F_checkBox);
            this.filter_UI.Controls.Add(this.R_checkBox);
            this.filter_UI.Controls.Add(this.W_checkBox);
            this.filter_UI.Controls.Add(this.T_checkBox);
            this.filter_UI.Controls.Add(this.M_checkBox);
            this.filter_UI.Controls.Add(this.day_label);
            this.filter_UI.Location = new System.Drawing.Point(202, 108);
            this.filter_UI.Name = "filter_UI";
            this.filter_UI.Size = new System.Drawing.Size(444, 100);
            this.filter_UI.TabIndex = 6;
            this.filter_UI.TabStop = false;
            this.filter_UI.Text = "Advanced";
            this.filter_UI.Visible = false;
            // 
            // clear_adv
            // 
            this.clear_adv.Location = new System.Drawing.Point(415, 71);
            this.clear_adv.Name = "clear_adv";
            this.clear_adv.Size = new System.Drawing.Size(24, 24);
            this.clear_adv.TabIndex = 20;
            this.clear_adv.Text = "X";
            this.clear_adv.UseVisualStyleBackColor = true;
            this.clear_adv.Click += new System.EventHandler(this.clearAdvBtn_Click);
            // 
            // probability_combobox
            // 
            this.probability_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.probability_combobox.FormattingEnabled = true;
            this.probability_combobox.Items.AddRange(new object[] {
            "Any",
            "high",
            "medium",
            "low"});
            this.probability_combobox.Location = new System.Drawing.Point(328, 44);
            this.probability_combobox.Name = "probability_combobox";
            this.probability_combobox.Size = new System.Drawing.Size(72, 21);
            this.probability_combobox.TabIndex = 19;
            this.probability_combobox.SelectedValueChanged += new System.EventHandler(this.probability_valueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(248, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Probability ≥";
            // 
            // rmp_numericUpDown
            // 
            this.rmp_numericUpDown.DecimalPlaces = 1;
            this.rmp_numericUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.rmp_numericUpDown.Location = new System.Drawing.Point(185, 45);
            this.rmp_numericUpDown.Maximum = new decimal(new int[] {
            45,
            0,
            0,
            65536});
            this.rmp_numericUpDown.Name = "rmp_numericUpDown";
            this.rmp_numericUpDown.Size = new System.Drawing.Size(43, 21);
            this.rmp_numericUpDown.TabIndex = 17;
            this.rmp_numericUpDown.ValueChanged += new System.EventHandler(this.rmp_valueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(142, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "RMP ≥";
            // 
            // professor_adv_label
            // 
            this.professor_adv_label.AutoSize = true;
            this.professor_adv_label.Location = new System.Drawing.Point(169, 72);
            this.professor_adv_label.Name = "professor_adv_label";
            this.professor_adv_label.Size = new System.Drawing.Size(66, 13);
            this.professor_adv_label.TabIndex = 15;
            this.professor_adv_label.Text = "Professor:";
            // 
            // adv_building_label
            // 
            this.adv_building_label.AutoSize = true;
            this.adv_building_label.Location = new System.Drawing.Point(19, 72);
            this.adv_building_label.Name = "adv_building_label";
            this.adv_building_label.Size = new System.Drawing.Size(57, 13);
            this.adv_building_label.TabIndex = 14;
            this.adv_building_label.Text = "Building:";
            // 
            // allNoneCheckBox
            // 
            this.allNoneCheckBox.AutoSize = true;
            this.allNoneCheckBox.Checked = true;
            this.allNoneCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.allNoneCheckBox.Location = new System.Drawing.Point(59, 45);
            this.allNoneCheckBox.Name = "allNoneCheckBox";
            this.allNoneCheckBox.Size = new System.Drawing.Size(74, 17);
            this.allNoneCheckBox.TabIndex = 13;
            this.allNoneCheckBox.Text = "All/None";
            this.allNoneCheckBox.UseVisualStyleBackColor = true;
            this.allNoneCheckBox.CheckedChanged += new System.EventHandler(this.allNoneCheck_checkChanged);
            // 
            // professor_adv
            // 
            this.professor_adv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.professor_adv.FormattingEnabled = true;
            this.professor_adv.Items.AddRange(new object[] {
            "Any"});
            this.professor_adv.Location = new System.Drawing.Point(238, 68);
            this.professor_adv.Name = "professor_adv";
            this.professor_adv.Size = new System.Drawing.Size(130, 21);
            this.professor_adv.TabIndex = 12;
            this.professor_adv.SelectedValueChanged += new System.EventHandler(this.professorValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(349, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "and";
            // 
            // secondTime_UI
            // 
            this.secondTime_UI.DecimalPlaces = 2;
            this.secondTime_UI.Location = new System.Drawing.Point(383, 21);
            this.secondTime_UI.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.secondTime_UI.Name = "secondTime_UI";
            this.secondTime_UI.Size = new System.Drawing.Size(50, 21);
            this.secondTime_UI.TabIndex = 10;
            this.secondTime_UI.Value = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.secondTime_UI.ValueChanged += new System.EventHandler(this.startEndTimes_valueChanged);
            // 
            // building_adv
            // 
            this.building_adv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.building_adv.FormattingEnabled = true;
            this.building_adv.Items.AddRange(new object[] {
            "Any",
            "HAL",
            "Hoyt",
            "Pew Fine Arts",
            "PLC",
            "Rockwell",
            "BAO",
            "STEM",
            "Other"});
            this.building_adv.Location = new System.Drawing.Point(77, 69);
            this.building_adv.Name = "building_adv";
            this.building_adv.Size = new System.Drawing.Size(86, 21);
            this.building_adv.TabIndex = 9;
            this.building_adv.SelectedValueChanged += new System.EventHandler(this.building_valueChanged);
            // 
            // firstTime_UI
            // 
            this.firstTime_UI.DecimalPlaces = 2;
            this.firstTime_UI.Location = new System.Drawing.Point(294, 21);
            this.firstTime_UI.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.firstTime_UI.Name = "firstTime_UI";
            this.firstTime_UI.Size = new System.Drawing.Size(50, 21);
            this.firstTime_UI.TabIndex = 8;
            this.firstTime_UI.ValueChanged += new System.EventHandler(this.startEndTimes_valueChanged);
            // 
            // between_label
            // 
            this.between_label.AutoSize = true;
            this.between_label.Location = new System.Drawing.Point(233, 23);
            this.between_label.Name = "between_label";
            this.between_label.Size = new System.Drawing.Size(55, 13);
            this.between_label.TabIndex = 7;
            this.between_label.Text = "between";
            // 
            // F_checkBox
            // 
            this.F_checkBox.AutoSize = true;
            this.F_checkBox.Checked = true;
            this.F_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.F_checkBox.Location = new System.Drawing.Point(198, 22);
            this.F_checkBox.Name = "F_checkBox";
            this.F_checkBox.Size = new System.Drawing.Size(32, 17);
            this.F_checkBox.TabIndex = 6;
            this.F_checkBox.Text = "F";
            this.F_checkBox.UseVisualStyleBackColor = true;
            this.F_checkBox.CheckedChanged += new System.EventHandler(this.daysAttr_checkChanged);
            // 
            // R_checkBox
            // 
            this.R_checkBox.AutoSize = true;
            this.R_checkBox.Checked = true;
            this.R_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.R_checkBox.Location = new System.Drawing.Point(163, 22);
            this.R_checkBox.Name = "R_checkBox";
            this.R_checkBox.Size = new System.Drawing.Size(34, 17);
            this.R_checkBox.TabIndex = 5;
            this.R_checkBox.Text = "R";
            this.R_checkBox.UseVisualStyleBackColor = true;
            this.R_checkBox.CheckedChanged += new System.EventHandler(this.daysAttr_checkChanged);
            // 
            // W_checkBox
            // 
            this.W_checkBox.AutoSize = true;
            this.W_checkBox.Checked = true;
            this.W_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.W_checkBox.Location = new System.Drawing.Point(126, 22);
            this.W_checkBox.Name = "W_checkBox";
            this.W_checkBox.Size = new System.Drawing.Size(37, 17);
            this.W_checkBox.TabIndex = 4;
            this.W_checkBox.Text = "W";
            this.W_checkBox.UseVisualStyleBackColor = true;
            this.W_checkBox.CheckedChanged += new System.EventHandler(this.daysAttr_checkChanged);
            // 
            // T_checkBox
            // 
            this.T_checkBox.AutoSize = true;
            this.T_checkBox.Checked = true;
            this.T_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.T_checkBox.Location = new System.Drawing.Point(93, 22);
            this.T_checkBox.Name = "T_checkBox";
            this.T_checkBox.Size = new System.Drawing.Size(33, 17);
            this.T_checkBox.TabIndex = 3;
            this.T_checkBox.Text = "T";
            this.T_checkBox.UseVisualStyleBackColor = true;
            this.T_checkBox.CheckedChanged += new System.EventHandler(this.daysAttr_checkChanged);
            // 
            // M_checkBox
            // 
            this.M_checkBox.AutoSize = true;
            this.M_checkBox.Checked = true;
            this.M_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.M_checkBox.Location = new System.Drawing.Point(59, 21);
            this.M_checkBox.Name = "M_checkBox";
            this.M_checkBox.Size = new System.Drawing.Size(35, 17);
            this.M_checkBox.TabIndex = 2;
            this.M_checkBox.Text = "M";
            this.M_checkBox.UseVisualStyleBackColor = true;
            this.M_checkBox.CheckedChanged += new System.EventHandler(this.daysAttr_checkChanged);
            // 
            // day_label
            // 
            this.day_label.AutoSize = true;
            this.day_label.Location = new System.Drawing.Point(19, 22);
            this.day_label.Name = "day_label";
            this.day_label.Size = new System.Drawing.Size(35, 13);
            this.day_label.TabIndex = 1;
            this.day_label.Text = "Day:";
            // 
            // advSearchBtn
            // 
            this.advSearchBtn.BackColor = System.Drawing.Color.Gainsboro;
            this.advSearchBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.advSearchBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.advSearchBtn.Location = new System.Drawing.Point(428, 79);
            this.advSearchBtn.Name = "advSearchBtn";
            this.advSearchBtn.Size = new System.Drawing.Size(87, 23);
            this.advSearchBtn.TabIndex = 3;
            this.advSearchBtn.Text = "Advanced";
            this.advSearchBtn.UseVisualStyleBackColor = false;
            this.advSearchBtn.Click += new System.EventHandler(this.advSearchBtn_Click);
            // 
            // searchBtn
            // 
            this.searchBtn.BackColor = System.Drawing.Color.Gainsboro;
            this.searchBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.searchBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.searchBtn.Location = new System.Drawing.Point(335, 79);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(87, 23);
            this.searchBtn.TabIndex = 2;
            this.searchBtn.Text = "Search";
            this.searchBtn.UseVisualStyleBackColor = false;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // searchBox
            // 
            this.searchBox.BackColor = System.Drawing.Color.White;
            this.searchBox.ForeColor = System.Drawing.Color.Gray;
            this.searchBox.Location = new System.Drawing.Point(102, 52);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(727, 21);
            this.searchBox.TabIndex = 1;
            this.searchBox.Text = "Search by course code or name...";
            this.searchBox.Enter += new System.EventHandler(this.searchBox_Enter);
            this.searchBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.input_KeyDown);
            this.searchBox.Leave += new System.EventHandler(this.searchBox_Leave);
            // 
            // searchResult_UI
            // 
            this.searchResult_UI.BackColor = System.Drawing.Color.White;
            this.searchResult_UI.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.creditsCol,
            this.courseCodeCol,
            this.professorCol,
            this.nameCol,
            this.timeCol,
            this.daysCol,
            this.capacityCol,
            this.rmpCol,
            this.probCol});
            this.searchResult_UI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.searchResult_UI.FullRowSelect = true;
            this.searchResult_UI.GridLines = true;
            this.searchResult_UI.HideSelection = false;
            this.searchResult_UI.LabelWrap = false;
            this.searchResult_UI.Location = new System.Drawing.Point(24, 111);
            this.searchResult_UI.Name = "searchResult_UI";
            this.searchResult_UI.Size = new System.Drawing.Size(805, 390);
            this.searchResult_UI.TabIndex = 4;
            this.searchResult_UI.UseCompatibleStateImageBehavior = false;
            this.searchResult_UI.View = System.Windows.Forms.View.Details;
            this.searchResult_UI.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.sortResults_columnClick);
            this.searchResult_UI.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.searchResult_UI_DoubleClick);
            // 
            // creditsCol
            // 
            this.creditsCol.Text = "Cred";
            this.creditsCol.Width = 41;
            // 
            // courseCodeCol
            // 
            this.courseCodeCol.Text = "Course Code";
            this.courseCodeCol.Width = 87;
            // 
            // professorCol
            // 
            this.professorCol.Text = "Professor";
            this.professorCol.Width = 128;
            // 
            // nameCol
            // 
            this.nameCol.Text = "Course Name";
            this.nameCol.Width = 219;
            // 
            // timeCol
            // 
            this.timeCol.Text = "Times";
            this.timeCol.Width = 84;
            // 
            // daysCol
            // 
            this.daysCol.Text = "Days";
            this.daysCol.Width = 44;
            // 
            // capacityCol
            // 
            this.capacityCol.Text = "Capacity";
            this.capacityCol.Width = 65;
            // 
            // rmpCol
            // 
            this.rmpCol.Text = "RMP";
            this.rmpCol.Width = 49;
            // 
            // probCol
            // 
            this.probCol.Text = "Prob.";
            this.probCol.Width = 50;
            // 
            // scheduleTab
            // 
            this.scheduleTab.Controls.Add(this.credits_notify_label);
            this.scheduleTab.Controls.Add(this.calendar_UI);
            this.scheduleTab.Controls.Add(this.removeHelp);
            this.scheduleTab.Controls.Add(this.clearAll);
            this.scheduleTab.Controls.Add(this.scheduleView);
            this.scheduleTab.Location = new System.Drawing.Point(4, 31);
            this.scheduleTab.Name = "scheduleTab";
            this.scheduleTab.Padding = new System.Windows.Forms.Padding(3);
            this.scheduleTab.Size = new System.Drawing.Size(854, 540);
            this.scheduleTab.TabIndex = 1;
            this.scheduleTab.Text = "Schedule";
            this.scheduleTab.UseVisualStyleBackColor = true;
            // 
            // credits_notify_label
            // 
            this.credits_notify_label.AutoSize = true;
            this.credits_notify_label.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.credits_notify_label.Location = new System.Drawing.Point(23, 178);
            this.credits_notify_label.Name = "credits_notify_label";
            this.credits_notify_label.Size = new System.Drawing.Size(118, 13);
            this.credits_notify_label.TabIndex = 4;
            this.credits_notify_label.Text = "credits_notify_label";
            // 
            // removeHelp
            // 
            this.removeHelp.AutoSize = true;
            this.removeHelp.Font = new System.Drawing.Font("Verdana", 7.75F, System.Drawing.FontStyle.Italic);
            this.removeHelp.Location = new System.Drawing.Point(23, 8);
            this.removeHelp.Name = "removeHelp";
            this.removeHelp.Size = new System.Drawing.Size(196, 13);
            this.removeHelp.TabIndex = 2;
            this.removeHelp.Text = "Double click to remove a course!";
            // 
            // clearAll
            // 
            this.clearAll.Location = new System.Drawing.Point(764, 181);
            this.clearAll.Name = "clearAll";
            this.clearAll.Size = new System.Drawing.Size(73, 23);
            this.clearAll.TabIndex = 1;
            this.clearAll.Text = "Clear All";
            this.clearAll.UseVisualStyleBackColor = true;
            this.clearAll.Click += new System.EventHandler(this.clearAll_Click);
            // 
            // scheduleView
            // 
            this.scheduleView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.schedule_creditsCol,
            this.schedule_codeCol,
            this.schedule_profCol,
            this.schedule_nameCol,
            this.schedule_timeCol,
            this.schedule_buildingCol,
            this.schedule_roomCol,
            this.schedule_daysCol});
            this.scheduleView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.scheduleView.FullRowSelect = true;
            this.scheduleView.GridLines = true;
            this.scheduleView.Location = new System.Drawing.Point(15, 25);
            this.scheduleView.Name = "scheduleView";
            this.scheduleView.Size = new System.Drawing.Size(822, 150);
            this.scheduleView.TabIndex = 0;
            this.scheduleView.UseCompatibleStateImageBehavior = false;
            this.scheduleView.View = System.Windows.Forms.View.Details;
            this.scheduleView.DoubleClick += new System.EventHandler(this.remove_DoubleClick);
            // 
            // schedule_creditsCol
            // 
            this.schedule_creditsCol.Text = "Credits";
            this.schedule_creditsCol.Width = 53;
            // 
            // schedule_codeCol
            // 
            this.schedule_codeCol.Text = "Course Code";
            this.schedule_codeCol.Width = 112;
            // 
            // schedule_profCol
            // 
            this.schedule_profCol.Text = "Professor";
            this.schedule_profCol.Width = 131;
            // 
            // schedule_nameCol
            // 
            this.schedule_nameCol.Text = "Course Name";
            this.schedule_nameCol.Width = 217;
            // 
            // schedule_timeCol
            // 
            this.schedule_timeCol.Text = "Times";
            this.schedule_timeCol.Width = 105;
            // 
            // schedule_buildingCol
            // 
            this.schedule_buildingCol.Text = "Building";
            this.schedule_buildingCol.Width = 67;
            // 
            // schedule_roomCol
            // 
            this.schedule_roomCol.Text = "Room";
            // 
            // schedule_daysCol
            // 
            this.schedule_daysCol.Text = "Days";
            this.schedule_daysCol.Width = 71;
            // 
            // menuBar
            // 
            this.menuBar.BackColor = System.Drawing.Color.White;
            this.menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.appMenu});
            this.menuBar.Location = new System.Drawing.Point(0, 0);
            this.menuBar.Name = "menuBar";
            this.menuBar.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuBar.Size = new System.Drawing.Size(863, 24);
            this.menuBar.TabIndex = 1;
            this.menuBar.Text = "File";
            // 
            // appMenu
            // 
            this.appMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.toolStripMenuItem2,
            this.themes_menu,
            this.toolStripMenuItem3,
            this.exitToolStripMenuItem});
            this.appMenu.Name = "appMenu";
            this.appMenu.Size = new System.Drawing.Size(37, 20);
            this.appMenu.Text = "File";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.importToolStripMenuItem.Text = "Import Schedule...";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.exportToolStripMenuItem.Text = "Export Schedule...";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(167, 6);
            // 
            // themes_menu
            // 
            this.themes_menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nightTheme,
            this.blueTheme,
            this.crimsonTheme,
            this.classicTheme});
            this.themes_menu.Name = "themes_menu";
            this.themes_menu.Size = new System.Drawing.Size(170, 22);
            this.themes_menu.Text = "Theme";
            // 
            // nightTheme
            // 
            this.nightTheme.CheckOnClick = true;
            this.nightTheme.Name = "nightTheme";
            this.nightTheme.Size = new System.Drawing.Size(146, 22);
            this.nightTheme.Text = "Night";
            this.nightTheme.Click += new System.EventHandler(this.themeToNight);
            // 
            // blueTheme
            // 
            this.blueTheme.CheckOnClick = true;
            this.blueTheme.Name = "blueTheme";
            this.blueTheme.Size = new System.Drawing.Size(146, 22);
            this.blueTheme.Text = "Blue";
            this.blueTheme.Click += new System.EventHandler(this.themeToBlue);
            // 
            // crimsonTheme
            // 
            this.crimsonTheme.CheckOnClick = true;
            this.crimsonTheme.Name = "crimsonTheme";
            this.crimsonTheme.Size = new System.Drawing.Size(146, 22);
            this.crimsonTheme.Text = "GCC Crimson";
            this.crimsonTheme.Click += new System.EventHandler(this.themeToGCC);
            // 
            // classicTheme
            // 
            this.classicTheme.Checked = true;
            this.classicTheme.CheckState = System.Windows.Forms.CheckState.Checked;
            this.classicTheme.Name = "classicTheme";
            this.classicTheme.Size = new System.Drawing.Size(146, 22);
            this.classicTheme.Text = "Classic";
            this.classicTheme.Click += new System.EventHandler(this.themeToClassic);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(167, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // AppWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 601);
            this.Controls.Add(this.menuTabs);
            this.Controls.Add(this.menuBar);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.MainMenuStrip = this.menuBar;
            this.Name = "AppWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GCC Scheduling Assistant";
            this.menuTabs.ResumeLayout(false);
            this.searchTab.ResumeLayout(false);
            this.searchTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gccLogo)).EndInit();
            this.filter_UI.ResumeLayout(false);
            this.filter_UI.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rmp_numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondTime_UI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstTime_UI)).EndInit();
            this.scheduleTab.ResumeLayout(false);
            this.scheduleTab.PerformLayout();
            this.menuBar.ResumeLayout(false);
            this.menuBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
                
        private System.Windows.Forms.TabControl menuTabs;
        private System.Windows.Forms.TabPage searchTab;
        private System.Windows.Forms.ListView searchResult_UI;
        private System.Windows.Forms.ColumnHeader creditsCol;
        private System.Windows.Forms.ColumnHeader courseCodeCol;
        private System.Windows.Forms.ColumnHeader professorCol;
        private System.Windows.Forms.ColumnHeader nameCol;
        private System.Windows.Forms.ColumnHeader timeCol;
        private System.Windows.Forms.ColumnHeader daysCol;
        private System.Windows.Forms.ColumnHeader capacityCol;
        private System.Windows.Forms.ColumnHeader rmpCol;
        private System.Windows.Forms.ColumnHeader probCol;
        private System.Windows.Forms.Button advSearchBtn;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.TabPage scheduleTab;
        private System.Windows.Forms.MenuStrip menuBar;
        private System.Windows.Forms.ToolStripMenuItem appMenu;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem themes_menu;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.Button clearAll;
        private System.Windows.Forms.ListView scheduleView;
        private System.Windows.Forms.GroupBox filter_UI;
        private System.Windows.Forms.Label day_label;
        private System.Windows.Forms.Label between_label;
        private System.Windows.Forms.CheckBox F_checkBox;
        private System.Windows.Forms.CheckBox R_checkBox;
        private System.Windows.Forms.CheckBox W_checkBox;
        private System.Windows.Forms.CheckBox T_checkBox;
        private System.Windows.Forms.CheckBox M_checkBox;
        private System.Windows.Forms.NumericUpDown firstTime_UI;
        private System.Windows.Forms.ComboBox building_adv;
        private System.Windows.Forms.ComboBox professor_adv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown secondTime_UI;
        private System.Windows.Forms.Label scheduleTitle;
        private System.Windows.Forms.Label userHelpLabel;
        private System.Windows.Forms.PictureBox gccLogo;
        private System.Windows.Forms.Label clickHelp1;
        private System.Windows.Forms.ColumnHeader schedule_creditsCol;
        private System.Windows.Forms.ColumnHeader schedule_codeCol;
        private System.Windows.Forms.ColumnHeader schedule_profCol;
        private System.Windows.Forms.ColumnHeader schedule_nameCol;
        private System.Windows.Forms.ColumnHeader schedule_timeCol;
        private System.Windows.Forms.ColumnHeader schedule_buildingCol;
        private System.Windows.Forms.ColumnHeader schedule_roomCol;
        private System.Windows.Forms.ColumnHeader schedule_daysCol;
        private System.Windows.Forms.CheckBox allNoneCheckBox;
        private System.Windows.Forms.Label removeHelp;
        private System.Windows.Forms.Label adv_building_label;
        private System.Windows.Forms.Label professor_adv_label;
        private System.Windows.Forms.Label label3;
        private Calendar.DayView calendar_UI;
        private System.Windows.Forms.ToolStripMenuItem nightTheme;
        private System.Windows.Forms.ToolStripMenuItem blueTheme;
        private System.Windows.Forms.ToolStripMenuItem crimsonTheme;
        private System.Windows.Forms.ToolStripMenuItem classicTheme;
        private System.Windows.Forms.NumericUpDown rmp_numericUpDown;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label autocorrect_label;
        private System.Windows.Forms.ComboBox probability_combobox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label credits_notify_label;
        private System.Windows.Forms.Button clear_adv;
    }
}

