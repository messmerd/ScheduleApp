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

        // DONT TOUCH THESE
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ToolStripComboBox classicToolStripMenuItem;
            this.menuTabs = new System.Windows.Forms.TabControl();
            this.searchTab = new System.Windows.Forms.TabPage();
            this.filter_UI = new System.Windows.Forms.GroupBox();
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
            this.button20 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
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
            this.notifyOnScheduleConflictToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            classicToolStripMenuItem = new System.Windows.Forms.ToolStripComboBox();
            this.menuTabs.SuspendLayout();
            this.searchTab.SuspendLayout();
            this.scheduleTab.SuspendLayout();
            this.menuBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // classicToolStripMenuItem
            // 
            classicToolStripMenuItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            classicToolStripMenuItem.Items.AddRange(new object[] {
            "Classic",
            "Dark",
            "Blue",
            "Grove City Pride"});
            classicToolStripMenuItem.Name = "classicToolStripMenuItem";
            classicToolStripMenuItem.Size = new System.Drawing.Size(152, 23);
            // 
            // menuTabs
            // 
            this.menuTabs.Controls.Add(this.searchTab);
            this.menuTabs.Controls.Add(this.scheduleTab);
            this.menuTabs.ItemSize = new System.Drawing.Size(200, 27);
            this.menuTabs.Location = new System.Drawing.Point(1, 27);
            this.menuTabs.Name = "menuTabs";
            this.menuTabs.SelectedIndex = 0;
            this.menuTabs.Size = new System.Drawing.Size(1008, 701);
            this.menuTabs.TabIndex = 0;
            // 
            // searchTab
            // 
            this.searchTab.Controls.Add(this.filter_UI);
            this.searchTab.Controls.Add(this.searchResult_UI);
            this.searchTab.Controls.Add(this.advSearchBtn);
            this.searchTab.Controls.Add(this.searchBtn);
            this.searchTab.Controls.Add(this.searchBox);
            this.searchTab.Location = new System.Drawing.Point(4, 31);
            this.searchTab.Name = "searchTab";
            this.searchTab.Padding = new System.Windows.Forms.Padding(3);
            this.searchTab.Size = new System.Drawing.Size(1000, 666);
            this.searchTab.TabIndex = 0;
            this.searchTab.Text = "Search";
            this.searchTab.UseVisualStyleBackColor = true;
            // 
            // filter_UI
            // 
            this.filter_UI.Location = new System.Drawing.Point(398, 112);
            this.filter_UI.Name = "filter_UI";
            this.filter_UI.Size = new System.Drawing.Size(200, 100);
            this.filter_UI.TabIndex = 6;
            this.filter_UI.TabStop = false;
            this.filter_UI.Text = "filter";
            this.filter_UI.Visible = false;
            // 
            // searchResult_UI
            // 
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
            this.searchResult_UI.Location = new System.Drawing.Point(99, 131);
            this.searchResult_UI.Name = "searchResult_UI";
            this.searchResult_UI.Size = new System.Drawing.Size(808, 518);
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
            this.courseCodeCol.Width = 85;
            // 
            // professorCol
            // 
            this.professorCol.Text = "Professor";
            this.professorCol.Width = 67;
            // 
            // nameCol
            // 
            this.nameCol.Text = "Course Name";
            this.nameCol.Width = 257;
            // 
            // startEndCol
            // 
            this.startEndCol.Text = "Start-End Time";
            this.startEndCol.Width = 92;
            // 
            // daysCol
            // 
            this.daysCol.Text = "Days";
            // 
            // capacityCol
            // 
            this.capacityCol.Text = "Capacity";
            // 
            // rmpCol
            // 
            this.rmpCol.Text = "RMP Rating";
            // 
            // probCol
            // 
            this.probCol.Text = "Probability";
            // 
            // advSearchBtn
            // 
            this.advSearchBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.advSearchBtn.Location = new System.Drawing.Point(501, 83);
            this.advSearchBtn.Name = "advSearchBtn";
            this.advSearchBtn.Size = new System.Drawing.Size(75, 23);
            this.advSearchBtn.TabIndex = 3;
            this.advSearchBtn.Text = "advanced";
            this.advSearchBtn.UseVisualStyleBackColor = true;
            this.advSearchBtn.Click += new System.EventHandler(this.advSearchBtn_Click);
            // 
            // searchBtn
            // 
            this.searchBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.searchBtn.Location = new System.Drawing.Point(420, 83);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(75, 23);
            this.searchBtn.TabIndex = 2;
            this.searchBtn.Text = "search";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(99, 57);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(808, 20);
            this.searchBox.TabIndex = 1;
            this.searchBox.Text = "search for courses...";
            this.searchBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // scheduleTab
            // 
            this.scheduleTab.Controls.Add(this.button20);
            this.scheduleTab.Controls.Add(this.button19);
            this.scheduleTab.Controls.Add(this.button18);
            this.scheduleTab.Controls.Add(this.button5);
            this.scheduleTab.Controls.Add(this.button4);
            this.scheduleTab.Controls.Add(this.button3);
            this.scheduleTab.Controls.Add(this.button2);
            this.scheduleTab.Controls.Add(this.button1);
            this.scheduleTab.Controls.Add(this.listView1);
            this.scheduleTab.Location = new System.Drawing.Point(4, 31);
            this.scheduleTab.Name = "scheduleTab";
            this.scheduleTab.Padding = new System.Windows.Forms.Padding(3);
            this.scheduleTab.Size = new System.Drawing.Size(1000, 666);
            this.scheduleTab.TabIndex = 1;
            this.scheduleTab.Text = "Schedule";
            this.scheduleTab.UseVisualStyleBackColor = true;
            // 
            // button20
            // 
            this.button20.BackColor = System.Drawing.Color.Red;
            this.button20.Location = new System.Drawing.Point(578, 143);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(25, 25);
            this.button20.TabIndex = 8;
            this.button20.Text = "X";
            this.button20.UseVisualStyleBackColor = false;
            // 
            // button19
            // 
            this.button19.BackColor = System.Drawing.Color.Red;
            this.button19.Location = new System.Drawing.Point(578, 174);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(25, 25);
            this.button19.TabIndex = 7;
            this.button19.Text = "X";
            this.button19.UseVisualStyleBackColor = false;
            // 
            // button18
            // 
            this.button18.BackColor = System.Drawing.Color.Red;
            this.button18.Location = new System.Drawing.Point(578, 205);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(25, 25);
            this.button18.TabIndex = 6;
            this.button18.Text = "X";
            this.button18.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Red;
            this.button5.Location = new System.Drawing.Point(578, 54);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(25, 25);
            this.button5.TabIndex = 5;
            this.button5.Text = "X";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Red;
            this.button4.Location = new System.Drawing.Point(578, 83);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(25, 25);
            this.button4.TabIndex = 4;
            this.button4.Text = "X";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Red;
            this.button3.Location = new System.Drawing.Point(578, 112);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(25, 25);
            this.button3.TabIndex = 3;
            this.button3.Text = "X";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(578, 234);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(25, 25);
            this.button2.TabIndex = 2;
            this.button2.Text = "X";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(623, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(63, 23);
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
            this.listView1.Location = new System.Drawing.Point(7, 25);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(565, 234);
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
            // 
            // mock_courseName
            // 
            this.mock_courseName.Text = "Name";
            this.mock_courseName.Width = 141;
            // 
            // mock_prof
            // 
            this.mock_prof.Text = "Professor";
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
            this.menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuBar.Location = new System.Drawing.Point(0, 0);
            this.menuBar.Name = "menuBar";
            this.menuBar.Size = new System.Drawing.Size(1008, 24);
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
            classicToolStripMenuItem});
            this.themesToolStripMenuItem.Name = "themesToolStripMenuItem";
            this.themesToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.themesToolStripMenuItem.Text = "Themes";
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
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // AppWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.menuTabs);
            this.Controls.Add(this.menuBar);
            this.MainMenuStrip = this.menuBar;
            this.Name = "AppWindow";
            this.Text = "Grove City College Schedule Help";
            this.menuTabs.ResumeLayout(false);
            this.searchTab.ResumeLayout(false);
            this.searchTab.PerformLayout();
            this.scheduleTab.ResumeLayout(false);
            this.menuBar.ResumeLayout(false);
            this.menuBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
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
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
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
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.GroupBox filter_UI;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
    }
}

