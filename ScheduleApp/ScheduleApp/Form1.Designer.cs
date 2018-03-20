namespace ScheduleApp
{
    partial class masterContainer
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
            this.menuTabs = new System.Windows.Forms.TabControl();
            this.searchTab = new System.Windows.Forms.TabPage();
            this.searchResults = new System.Windows.Forms.ListView();
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.scheduleTab = new System.Windows.Forms.TabPage();
            this.menuTabs.SuspendLayout();
            this.searchTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuTabs
            // 
            this.menuTabs.Controls.Add(this.searchTab);
            this.menuTabs.Controls.Add(this.scheduleTab);
            this.menuTabs.Location = new System.Drawing.Point(1, 2);
            this.menuTabs.Name = "menuTabs";
            this.menuTabs.SelectedIndex = 0;
            this.menuTabs.Size = new System.Drawing.Size(1008, 726);
            this.menuTabs.TabIndex = 0;
            // 
            // searchTab
            // 
            this.searchTab.Controls.Add(this.searchResults);
            this.searchTab.Controls.Add(this.advSearchBtn);
            this.searchTab.Controls.Add(this.searchBtn);
            this.searchTab.Controls.Add(this.textBox1);
            this.searchTab.Location = new System.Drawing.Point(4, 22);
            this.searchTab.Name = "searchTab";
            this.searchTab.Padding = new System.Windows.Forms.Padding(3);
            this.searchTab.Size = new System.Drawing.Size(1000, 700);
            this.searchTab.TabIndex = 0;
            this.searchTab.Text = "Search";
            this.searchTab.UseVisualStyleBackColor = true;
            // 
            // searchResults
            // 
            this.searchResults.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.searchResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.creditsCol,
            this.courseCodeCol,
            this.professorCol,
            this.nameCol,
            this.startEndCol,
            this.daysCol,
            this.capacityCol,
            this.rmpCol,
            this.probCol});
            this.searchResults.Location = new System.Drawing.Point(99, 126);
            this.searchResults.Name = "searchResults";
            this.searchResults.Size = new System.Drawing.Size(808, 520);
            this.searchResults.TabIndex = 4;
            this.searchResults.UseCompatibleStateImageBehavior = false;
            this.searchResults.View = System.Windows.Forms.View.Details;
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
            this.searchBtn.Location = new System.Drawing.Point(420, 83);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(75, 23);
            this.searchBtn.TabIndex = 2;
            this.searchBtn.Text = "search";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(99, 57);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(808, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "search for courses...";
            // 
            // scheduleTab
            // 
            this.scheduleTab.Location = new System.Drawing.Point(4, 22);
            this.scheduleTab.Name = "scheduleTab";
            this.scheduleTab.Padding = new System.Windows.Forms.Padding(3);
            this.scheduleTab.Size = new System.Drawing.Size(1000, 700);
            this.scheduleTab.TabIndex = 1;
            this.scheduleTab.Text = "Schedule";
            this.scheduleTab.UseVisualStyleBackColor = true;
            // 
            // masterContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.menuTabs);
            this.Name = "masterContainer";
            this.Text = "Form1";
            this.menuTabs.ResumeLayout(false);
            this.searchTab.ResumeLayout(false);
            this.searchTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl menuTabs;
        private System.Windows.Forms.TabPage searchTab;
        private System.Windows.Forms.ListView searchResults;
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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TabPage scheduleTab;
    }
}

