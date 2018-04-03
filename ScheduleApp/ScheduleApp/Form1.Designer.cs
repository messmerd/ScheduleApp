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
            this.menuTabs = new System.Windows.Forms.TabControl();
            this.searchTab = new System.Windows.Forms.TabPage();
            this.filter_UI = new System.Windows.Forms.GroupBox();
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
            this.searchResult_UI = new System.Windows.Forms.ListView();
            this.creditsCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.courseCodeCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.professorCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nameCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.startEndCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.daysCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.capacityCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rmpCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.probCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.advSearchBtn = new System.Windows.Forms.Button();
            this.searchBtn = new System.Windows.Forms.Button();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.scheduleTab = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.mock_credits = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mock_courseCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mock_courseName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mock_prof = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mock_room = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mock_building = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mock_time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mock_day = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuBar = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.themesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.themeSelector = new System.Windows.Forms.ToolStripComboBox();
            this.notifyOnScheduleConflictToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTabs.SuspendLayout();
            this.searchTab.SuspendLayout();
            this.filter_UI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.secondTime_UI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstTime_UI)).BeginInit();
            this.scheduleTab.SuspendLayout();
            this.menuBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuTabs
            // 
            this.menuTabs.Controls.Add(this.searchTab);
            this.menuTabs.Controls.Add(this.scheduleTab);
            this.menuTabs.ItemSize = new System.Drawing.Size(200, 27);
            this.menuTabs.Location = new System.Drawing.Point(0, 27);
            this.menuTabs.Name = "menuTabs";
            this.menuTabs.SelectedIndex = 0;
            this.menuTabs.Size = new System.Drawing.Size(1033, 701);
            this.menuTabs.TabIndex = 0;
            // 
            // searchTab
            // 
            this.searchTab.BackColor = System.Drawing.SystemColors.Window;
            this.searchTab.Controls.Add(this.filter_UI);
            this.searchTab.Controls.Add(this.searchResult_UI);
            this.searchTab.Controls.Add(this.advSearchBtn);
            this.searchTab.Controls.Add(this.searchBtn);
            this.searchTab.Controls.Add(this.searchBox);
            this.searchTab.Location = new System.Drawing.Point(4, 31);
            this.searchTab.Name = "searchTab";
            this.searchTab.Padding = new System.Windows.Forms.Padding(3);
            this.searchTab.Size = new System.Drawing.Size(1025, 666);
            this.searchTab.TabIndex = 0;
            this.searchTab.Text = "Search";
            // 
            // filter_UI
            // 
            this.filter_UI.BackColor = System.Drawing.SystemColors.Window;
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
            this.filter_UI.Location = new System.Drawing.Point(276, 112);
            this.filter_UI.Name = "filter_UI";
            this.filter_UI.Size = new System.Drawing.Size(444, 100);
            this.filter_UI.TabIndex = 6;
            this.filter_UI.TabStop = false;
            this.filter_UI.Text = "advanced";
            this.filter_UI.Visible = false;
            // 
            // professor_adv
            // 
            this.professor_adv.FormattingEnabled = true;
            this.professor_adv.Location = new System.Drawing.Point(126, 55);
            this.professor_adv.Name = "professor_adv";
            this.professor_adv.Size = new System.Drawing.Size(86, 21);
            this.professor_adv.TabIndex = 12;
            this.professor_adv.Text = "professor";
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
            this.secondTime_UI.Location = new System.Drawing.Point(384, 21);
            this.secondTime_UI.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.secondTime_UI.Name = "secondTime_UI";
            this.secondTime_UI.Size = new System.Drawing.Size(50, 21);
            this.secondTime_UI.TabIndex = 10;
            this.secondTime_UI.ValueChanged += new System.EventHandler(this.startEndTimes_valueChanged);
            // 
            // building_adv
            // 
            this.building_adv.FormattingEnabled = true;
            this.building_adv.Location = new System.Drawing.Point(22, 55);
            this.building_adv.Name = "building_adv";
            this.building_adv.Size = new System.Drawing.Size(86, 21);
            this.building_adv.TabIndex = 9;
            this.building_adv.Text = "building";
            // 
            // firstTime_UI
            // 
            this.firstTime_UI.DecimalPlaces = 2;
            this.firstTime_UI.Location = new System.Drawing.Point(293, 21);
            this.firstTime_UI.Maximum = new decimal(new int[] {
            12,
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
            this.between_label.Location = new System.Drawing.Point(232, 23);
            this.between_label.Name = "between_label";
            this.between_label.Size = new System.Drawing.Size(55, 13);
            this.between_label.TabIndex = 7;
            this.between_label.Text = "between";
            // 
            // F_checkBox
            // 
            this.F_checkBox.AutoSize = true;
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
            // searchResult_UI
            // 
            this.searchResult_UI.BackColor = System.Drawing.Color.White;
            this.searchResult_UI.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.creditsCol,
            this.courseCodeCol,
            this.professorCol,
            this.nameCol,
            this.startEndCol,
            this.daysCol,
            this.capacityCol,
            this.rmpCol,
            this.probCol});
            this.searchResult_UI.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.searchResult_UI.HoverSelection = true;
            this.searchResult_UI.Location = new System.Drawing.Point(31, 123);
            this.searchResult_UI.Name = "searchResult_UI";
            this.searchResult_UI.Size = new System.Drawing.Size(962, 537);
            this.searchResult_UI.TabIndex = 4;
            this.searchResult_UI.UseCompatibleStateImageBehavior = false;
            this.searchResult_UI.View = System.Windows.Forms.View.Details;
            // 
            // creditsCol
            // 
            this.creditsCol.Text = "Credits";
            // 
            // courseCodeCol
            // 
            this.courseCodeCol.Text = "Course Code";
            this.courseCodeCol.Width = 96;
            // 
            // professorCol
            // 
            this.professorCol.Text = "Professor";
            this.professorCol.Width = 140;
            // 
            // nameCol
            // 
            this.nameCol.Text = "Course Name";
            this.nameCol.Width = 257;
            // 
            // startEndCol
            // 
            this.startEndCol.Text = "Start-End Time";
            this.startEndCol.Width = 103;
            // 
            // daysCol
            // 
            this.daysCol.Text = "Days";
            // 
            // capacityCol
            // 
            this.capacityCol.Text = "Capacity";
            this.capacityCol.Width = 65;
            // 
            // rmpCol
            // 
            this.rmpCol.Text = "RMP Rating";
            this.rmpCol.Width = 77;
            // 
            // probCol
            // 
            this.probCol.Text = "Probability";
            this.probCol.Width = 78;
            // 
            // advSearchBtn
            // 
            this.advSearchBtn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.advSearchBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.advSearchBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.advSearchBtn.Location = new System.Drawing.Point(499, 83);
            this.advSearchBtn.Name = "advSearchBtn";
            this.advSearchBtn.Size = new System.Drawing.Size(87, 23);
            this.advSearchBtn.TabIndex = 3;
            this.advSearchBtn.Text = "advanced";
            this.advSearchBtn.UseVisualStyleBackColor = false;
            this.advSearchBtn.Click += new System.EventHandler(this.advSearchBtn_Click);
            // 
            // searchBtn
            // 
            this.searchBtn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.searchBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.searchBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.searchBtn.Location = new System.Drawing.Point(406, 83);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(87, 23);
            this.searchBtn.TabIndex = 2;
            this.searchBtn.Text = "search";
            this.searchBtn.UseVisualStyleBackColor = false;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // searchBox
            // 
            this.searchBox.ForeColor = System.Drawing.Color.Gray;
            this.searchBox.Location = new System.Drawing.Point(31, 57);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(962, 21);
            this.searchBox.TabIndex = 1;
            this.searchBox.Text = "Search by course code or name...";
            this.searchBox.Enter += new System.EventHandler(this.searchBox_Enter);
            this.searchBox.Leave += new System.EventHandler(this.searchBox_Leave);
            // 
            // scheduleTab
            // 
            this.scheduleTab.Controls.Add(this.button1);
            this.scheduleTab.Controls.Add(this.listView1);
            this.scheduleTab.Location = new System.Drawing.Point(4, 31);
            this.scheduleTab.Name = "scheduleTab";
            this.scheduleTab.Padding = new System.Windows.Forms.Padding(3);
            this.scheduleTab.Size = new System.Drawing.Size(1025, 666);
            this.scheduleTab.TabIndex = 1;
            this.scheduleTab.Text = "Schedule";
            this.scheduleTab.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(690, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "clear";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.mock_credits,
            this.mock_courseCode,
            this.mock_courseName,
            this.mock_prof,
            this.mock_room,
            this.mock_building,
            this.mock_time,
            this.mock_day});
            this.listView1.Location = new System.Drawing.Point(8, 25);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(676, 234);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // mock_credits
            // 
            this.mock_credits.Text = "Credits";
            // 
            // mock_courseCode
            // 
            this.mock_courseCode.Text = "Course Code";
            this.mock_courseCode.Width = 99;
            // 
            // mock_courseName
            // 
            this.mock_courseName.Text = "Name";
            this.mock_courseName.Width = 141;
            // 
            // mock_prof
            // 
            this.mock_prof.Text = "Professor";
            this.mock_prof.Width = 81;
            // 
            // mock_room
            // 
            this.mock_room.Text = "Room #";
            // 
            // mock_building
            // 
            this.mock_building.Text = "Building";
            // 
            // mock_time
            // 
            this.mock_time.Text = "Time";
            // 
            // mock_day
            // 
            this.mock_day.Text = "Day";
            // 
            // menuBar
            // 
            this.menuBar.BackColor = System.Drawing.SystemColors.MenuBar;
            this.menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuBar.Location = new System.Drawing.Point(0, 0);
            this.menuBar.Name = "menuBar";
            this.menuBar.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuBar.Size = new System.Drawing.Size(1028, 24);
            this.menuBar.TabIndex = 1;
            this.menuBar.Text = "File";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.toolStripMenuItem2,
            this.preferencesToolStripMenuItem,
            this.toolStripMenuItem3,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.importToolStripMenuItem.Text = "Import JSON...";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.exportToolStripMenuItem.Text = "Export JSON...";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(147, 6);
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.themesToolStripMenuItem,
            this.notifyOnScheduleConflictToolStripMenuItem});
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.preferencesToolStripMenuItem.Text = "Preferences";
            // 
            // themesToolStripMenuItem
            // 
            this.themesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.themeSelector});
            this.themesToolStripMenuItem.Name = "themesToolStripMenuItem";
            this.themesToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.themesToolStripMenuItem.Text = "Themes";
            // 
            // themeSelector
            // 
            this.themeSelector.Items.AddRange(new object[] {
            "Classic",
            "Dark",
            "Blue",
            "Grove City Crimson"});
            this.themeSelector.Name = "themeSelector";
            this.themeSelector.Size = new System.Drawing.Size(152, 23);
            this.themeSelector.Text = "Classic";
            this.themeSelector.SelectedIndexChanged += new System.EventHandler(this.themeSelector_SelectedIndexChanged);
            // 
            // notifyOnScheduleConflictToolStripMenuItem
            // 
            this.notifyOnScheduleConflictToolStripMenuItem.Name = "notifyOnScheduleConflictToolStripMenuItem";
            this.notifyOnScheduleConflictToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.notifyOnScheduleConflictToolStripMenuItem.Text = "Notify on schedule conflict";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(147, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // AppWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 725);
            this.Controls.Add(this.menuTabs);
            this.Controls.Add(this.menuBar);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.MainMenuStrip = this.menuBar;
            this.Name = "AppWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Grove City College Schedule Help";
            this.menuTabs.ResumeLayout(false);
            this.searchTab.ResumeLayout(false);
            this.searchTab.PerformLayout();
            this.filter_UI.ResumeLayout(false);
            this.filter_UI.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.secondTime_UI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstTime_UI)).EndInit();
            this.scheduleTab.ResumeLayout(false);
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
        private System.Windows.Forms.ColumnHeader startEndCol;
        private System.Windows.Forms.ColumnHeader daysCol;
        private System.Windows.Forms.ColumnHeader capacityCol;
        private System.Windows.Forms.ColumnHeader rmpCol;
        private System.Windows.Forms.ColumnHeader probCol;
        private System.Windows.Forms.Button advSearchBtn;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.TabPage scheduleTab;
        private System.Windows.Forms.MenuStrip menuBar;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem themesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem notifyOnScheduleConflictToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader mock_credits;
        private System.Windows.Forms.ColumnHeader mock_courseCode;
        private System.Windows.Forms.ColumnHeader mock_courseName;
        private System.Windows.Forms.ColumnHeader mock_prof;
        private System.Windows.Forms.ColumnHeader mock_room;
        private System.Windows.Forms.ColumnHeader mock_building;
        private System.Windows.Forms.ColumnHeader mock_time;
        private System.Windows.Forms.ColumnHeader mock_day;
        private System.Windows.Forms.GroupBox filter_UI;
        private System.Windows.Forms.ToolStripComboBox themeSelector;
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
    }
}

