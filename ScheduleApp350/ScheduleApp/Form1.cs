using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ScheduleApp
{
    public partial class AppWindow : Form
    {
        public const string emptySearchBarText = "Search by course code or name...";
        Search search = Search.Create("course_dictionary.txt");
        CourseInfo DB = CourseInfo.Create();
        CandidateSchedule schedule = CandidateSchedule.Create();

        public AppWindow()
        {
            InitializeComponent();
            initializeProfessorComboBox();
            searchResult_UI.ShowItemToolTips = true;
            //searchResult_UI.HideSelection = true;
            

            calendar_UI.StartDate = new DateTime(2010,2,1,0,0,0);  // I chose this date so that the calendar starts on Monday the 1st 
            //calendar_UI.NewAppointment += new Calendar.NewAppointmentEventHandler(dayView1_NewAppointment);
            calendar_UI.SelectionChanged += new EventHandler(dayView1_SelectionChanged);
            calendar_UI.ResolveAppointments += new Calendar.ResolveAppointmentsEventHandler(this.dayView1_ResolveAppointments);

            calendar_UI.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dayView1_MouseMove);

            // Use a line like this to change the visual theme of the calendar:
            calendar_UI.Renderer = new Calendar.Office11Renderer();    // Can also use Calendar.Office12Renderer

            clickHelp1.Text = "Double click to add a course!";
        }

        private void initializeProfessorComboBox()
        {
            foreach (var prof in DB.prof_database)
                professor_adv.Items.Add(prof.last + ", " + prof.first);
        }

        /**********************Text Inside Search****************************************/
        private void searchBox_Enter(object sender, EventArgs e)
        {
            searchBox.Text = Search.Create().lastSearchResults.getQuery(); 
            searchBox.ForeColor = Color.Black;
        }

        private void searchBox_Leave(object sender, EventArgs e)
        {
            if (searchBox.Text == "")
            {
                searchBox.Text = emptySearchBarText;
                searchBox.ForeColor = Color.Gray;
            }
        }
        /******************************************************************************************/




        /************************Calendar-Related**************************************************/

        
        private void dayView1_ResolveAppointments(object sender, Calendar.ResolveAppointmentsEventArgs args)
        {
            
            List<Calendar.Appointment> m_Apps = new List<Calendar.Appointment>();

            foreach (Calendar.Appointment m_App in CandidateSchedule.Create().getCalendarItems())
                if ((m_App.StartDate >= args.StartDate) &&
                    (m_App.StartDate <= args.EndDate))
                    m_Apps.Add(m_App);

            args.Appointments = m_Apps;
             
        }
        
        
        private void dayView1_SelectionChanged(object sender, EventArgs e)
        {
            //string text = dayView1.SelectionStart.ToString() + ":" + dayView1.SelectionEnd.ToString();
            //label3.Text = calendar_UI.SelectionStart.ToString() + ":" + calendar_UI.SelectionEnd.ToString();
            //Console.WriteLine(text);
        }
        
        private void dayView1_MouseMove(object sender, MouseEventArgs e)
        {
            //professor_adv_label.Text = calendar_UI.GetTimeAt(e.X, e.Y).ToString();
            //string text = dayView1.GetTimeAt(e.X, e.Y).ToString();
            //Console.WriteLine(text);
        }

        /*
        void dayView1_NewAppointment(object sender, Calendar.NewAppointmentEventArgs args)
        {
            Calendar.Appointment m_Appointment = new Calendar.Appointment();

            m_Appointment.StartDate = args.StartDate;
            m_Appointment.EndDate = args.EndDate;
            m_Appointment.Title = args.Title;

            CandidateSchedule.Create().m_Courses.Add(m_Appointment);
        }*/

        /*
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            dayView1.HalfHourHeight = trackBar1.Value;
        }
         * /

        /******************************************************************************************/




        /**************************************** Themes ******************************************/


        private void themeToNight(object sender, EventArgs e)
        {
            // 38 50 56 <- background and surrounding stuff
            // 0 150 136 <- buttons
            // 168 183 185 <- text color
            // 48 64 71 <- search bar
            // 89 102 107 <- unfocused search bar


            /*
            // Base color
            scheduleTitle.ForeColor = Color.Black;

            menuBar.BackColor = Color.White;
            searchBox.BackColor = Color.White;
            searchTab.BackColor = Color.White;
            searchResult_UI.BackColor = Color.White;
            searchResult_UI.ForeColor = Color.Black;
            scheduleView.BackColor = Color.White;
            scheduleTab.BackColor = Color.White;
            appMenu.BackColor = Color.White;

            // Adv Filter elements
            filter_UI.BackColor = Color.White;
            filter_UI.ForeColor = Color.Black;

            // Button backgrounds
            searchBtn.BackColor = Color.Gainsboro;
            advSearchBtn.BackColor = Color.Gainsboro;
            searchBtn.BackColor = Color.Gainsboro;

            // Button fonts
            searchBtn.ForeColor = Color.Black;
            advSearchBtn.ForeColor = Color.Black;
            */


            foreach (var course in CandidateSchedule.Create().getCalendarItems())
            {
                course.BorderColor = Color.DarkGray;
            }

            calendar_UI.Invalidate(); // Updates the Calendar
        }

        private void themeToBlue(object sender, EventArgs e)
        {
            calendar_UI.Renderer = new Calendar.Office12Renderer();  // Calendar theme - this one looks blue
            foreach (var course in CandidateSchedule.Create().getCalendarItems())
            {
                course.BorderColor = Color.RoyalBlue; 
            }

            calendar_UI.Invalidate(); // Updates the Calendar
        }

        private void themeToGCC(object sender, EventArgs e)
        {
            foreach (var course in CandidateSchedule.Create().getCalendarItems())
            {
                course.BorderColor = Color.Crimson;
            }

            calendar_UI.Invalidate(); // Updates the Calendar
        }

        private void themeToClassic(object sender, EventArgs e)
        {
            calendar_UI.Renderer = new Calendar.Office11Renderer();  // Calendar theme
            foreach (var course in CandidateSchedule.Create().getCalendarItems())
            {
                course.BorderColor = Color.DarkSlateGray;
            }


            // 
            scheduleTitle.ForeColor = Color.Black;

            
            menuBar.BackColor = Color.White;
            searchBox.BackColor = Color.White;
            searchTab.BackColor = Color.White;
            searchResult_UI.BackColor = Color.White;
            searchResult_UI.ForeColor = Color.Black;
            scheduleView.BackColor = Color.White;
            scheduleTab.BackColor = Color.White;
            appMenu.BackColor = Color.White;

            // Adv Filter
            filter_UI.BackColor = Color.White;
            filter_UI.ForeColor = Color.Black;

            // Buttons
            searchBtn.BackColor = Color.Gainsboro;
            advSearchBtn.BackColor = Color.Gainsboro;
            searchBtn.BackColor = Color.Gainsboro;

            // Button font color
            searchBtn.ForeColor = Color.Black;
            advSearchBtn.ForeColor = Color.Black;

            calendar_UI.Invalidate(); // Updates the Calendar

        }
        /******************************************************************************************/






        /**********************Create UI Search Results Fns****************************************/
        private void searchBtn_Click(object sender, EventArgs e)
        {

            // Remove previous search results upon performing another search
            searchResult_UI.Items.Clear();

            if (searchBox.Text != emptySearchBarText)
                search.searchForQuery(searchBox.Text);
            else
                search.searchForQuery(""); // search for all courses

            search.advancedSearchFilter(); 
            search.lastSearchResults.SortCourses(SORTTYPE.RELEVANCY, false);  // Sort by descending relevancy 

            populateSearch(search.lastSearchResults.getCourses());
        }

        private void populateSearch(List<Course> results)
        {
            foreach (var course in results)
            {
                var courseToAdd = setSearchRow(course);
                var listViewItem = new ListViewItem(courseToAdd);
                listViewItem.Name = course.getCourseID().ToString();
                listViewItem.UseItemStyleForSubItems = false;

                for (int j = 0; j < listViewItem.SubItems.Count; j++)
                {
                    listViewItem.SubItems[j].BackColor = schedule.exists(course.getCourseID()) ? Color.GreenYellow : Color.White;
                }

                if (schedule.checkTimeConflict(course).Count > 1)
                {
                    listViewItem.SubItems[4].BackColor = Color.Red;
                    listViewItem.ToolTipText = "This course conflicts with your schedule";
                }
                searchResult_UI.Items.Add(listViewItem);
            }
        }

        private void refreshSearchItemColors(List<Course> results)
        {
            int i = 0;
            foreach (ListViewItem item in searchResult_UI.Items)
            {
                item.UseItemStyleForSubItems = false;

                for (int j = 0; j < item.SubItems.Count; j++)
                {
                    item.SubItems[j].BackColor = schedule.exists(results[i].getCourseID()) ? Color.GreenYellow : Color.White;
                }

                if (schedule.checkTimeConflict(results[i]).Count > 1)
                {
                    item.SubItems[4].BackColor = Color.Red;
                    item.ToolTipText = "This course conflicts with your schedule";
                }
                i++;
                
            }
        }

        // search by pressing enter, must have the search box focused
        private void input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) searchBtn_Click(sender, e);
        }

        private string getDays(Course c)
        {
            string res = "";
            string[] all_days = { "M", "T", "W", "R", "F" }; 

            for(int i = 0; i < all_days.Length; i++) // since potentialDays.Length == Course.day.Length, and List has no Length member
            {
                if (c.getDay()[i]) res += all_days[i];
            }

            return res;
        }

        private string[] setSearchRow(Course c) // c = the course
        {
            string[] row = new string[50]; // row buffer

            row[0] = c.getCredits().ToString();
            row[1] = c.getCourseCode();
            row[2] = c.getProf().last + ", " + c.getProf().first;
            row[3] = c.getLongName();
            row[4] = c.getTimeString().Item1 + "-" + c.getTimeString().Item2;
            row[5] = getDays(c);
            row[6] = c.getEnrollment().ToString() + "/" + c.getCapacity().ToString();
            row[7] = c.getProf().rmp.ToString(); // placeholder until Sprint 2
            row[8] = c.getProbability();
            return row;
        }
        /***************************************************************************************/


        /***********************Add to Schedule**************************************************/


        private void searchResult_UI_DoubleClick(object sender, MouseEventArgs e)
        {
            if(searchResult_UI.SelectedItems.Count >= 0)
            {
                int courseID = int.Parse(searchResult_UI.SelectedItems[0].Name);
                if (!schedule.exists(courseID)) 
                {
                    schedule.addCourse(courseID);

                    updateScheduleUI(); 

                    clickHelp1.ForeColor = Color.Green;
                    clickHelp1.Text = "\"" + DB.getCourseCode(courseID) + "\" successfully added.";
                    calendar_UI.Invalidate(); // Updates the Calendar
                    refreshSearchItemColors(search.lastSearchResults.getCourses());
                    searchResult_UI.SelectedItems[0].Selected = false; 
                }
                else
                {
                    schedule.removeCourse(courseID);
                    updateScheduleUI(); 
                    clickHelp1.ForeColor = Color.Red;
                    clickHelp1.Text = "\"" + DB.getCourseCode(courseID) + "\" was removed from your schedule.";
                    refreshSearchItemColors(search.lastSearchResults.getCourses());
                    searchResult_UI.SelectedItems[0].Selected = false; 
                    
                }
                
            }
            
        }

        public string[] setScheduleRow(Course c)
        {
            string[] row = new string[50]; // row buffer

            row[0] = c.getCredits().ToString();//
            row[1] = c.getCourseCode();//
            row[2] = c.getProf().last + ", " + c.getProf().first;
            row[3] = c.getLongName();
            row[4] = c.getTimeString().Item1 + "-" + c.getTimeString().Item2;
            row[5] = c.getBuilding().ToString();
            row[6] = c.getRoom().ToString();
            row[7] = getDays(c);
            return row;

        }

        private void clearAll_Click(object sender, EventArgs e)
        {
            scheduleView.Items.Clear(); // what the user sees
            schedule.removeAllCourses();
            calendar_UI.Invalidate(); // Updates the Calendar
            refreshSearchItemColors(search.lastSearchResults.getCourses());
        }

        
        private void remove_DoubleClick(object sender, EventArgs e)
        {
            if (scheduleView.SelectedItems.Count >= 0)
            {
                int courseID = int.Parse(scheduleView.SelectedItems[0].Name);   
                schedule.removeCourse(courseID);
                updateScheduleUI(); 
                calendar_UI.Invalidate(); // Updates the Calendar
                refreshSearchItemColors(search.lastSearchResults.getCourses());
            }
        }

        private void updateScheduleUI()
        {
            scheduleView.Items.Clear();
            foreach (Course c in schedule.getCourses())
            {
                var courseToAdd = setScheduleRow(c);
                var listViewItem = new ListViewItem(courseToAdd);
                listViewItem.Name = c.getCourseID().ToString();
                if (schedule.checkTimeConflict(c).Count > 1)
                {
                    listViewItem.BackColor = Color.Red;
                }
                else
                {
                    listViewItem.BackColor = Color.White; 
                }
                scheduleView.Items.Add(listViewItem);
            }
        }


        /***************************************************************************************/





        /*************************************adv search****************************************/
        private void advSearchBtn_Click(object sender, EventArgs e)
        {
            int shift = 106;
            int x = searchResult_UI.Location.X;
            int y = searchResult_UI.Location.Y;

            if (!filter_UI.Visible)
            {
                searchResult_UI.Location = new Point(x, y + shift);
                searchResult_UI.Height -= shift;
                filter_UI.Show();
            }
            else
            {
                filter_UI.Hide();
                searchResult_UI.Location = new Point(x, y - shift);
                searchResult_UI.Height += shift;
            }

        }

        private void daysAttr_checkChanged(object sender, EventArgs e)
        {
            bool [] checkboxes = { M_checkBox.Checked, T_checkBox.Checked, W_checkBox.Checked, R_checkBox.Checked, F_checkBox.Checked };

            for(int i = 0; i < checkboxes.Count(); i++)
            {
                search.options.day[i] = checkboxes[i] ? true : false;
            }
        }

        private void startEndTimes_valueChanged(object sender,  EventArgs e)
        {
            search.options.timeStart = (double)firstTime_UI.Value;
            search.options.timeEnd = (double)secondTime_UI.Value;
        }

        private void building_valueChanged(object sender, EventArgs e)
        {
        
            string [] str = { "Any", "HAL", "Hoyt", "Other", "Pew Fine Arts", "PLC", "Rockwell", "BAO", "STEM" };

            Build[] enums = { Build.NONE, Build.HAL, Build.HH, Build.OFFCP, Build.PFAC, Build.PLC, Build.RH, Build.BAO, Build.STEM };

                           // same size for both
            for(var i = 0; i < str.Length; i++)
            {
                if (building_adv.Text == str[i]) search.options.building = enums[i];
            }
        }
        private void professorValueChanged(object sender, EventArgs e)
        {
            bool anyProf = professor_adv.Text == "Any";
            search.options.lastNameProfessor = !anyProf ? professor_adv.Text.Split(',')[0] : "";
            search.options.firstNameProfessor = !anyProf ? professor_adv.Text.Split(',')[1].Trim() : "";
        }
        
        private void allNoneCheck_checkChanged(object sender, EventArgs e)
        {
            CheckBox[] checkboxes = { M_checkBox, T_checkBox, W_checkBox, R_checkBox, F_checkBox };

            foreach (var checkbox in checkboxes)
            {
                checkbox.Checked = allNoneCheckBox.Checked ? true : false;
            }
        }

        private void rmp_valueChanged(object sender, EventArgs e)
        {
            // search.options.rmp = rmpBox.Value;
        }
        
        private void probability_valueChanged(object sender, EventArgs e)
        {
            //search.options.probability = probBox.Text;
        }
       

        /**************************************************************************************/



        /**************************************JSON Transfer***************************************/
        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openJson = new OpenFileDialog();
            openJson.Filter = "Json files (*.json)|*.json|Text files (*.txt)|*.txt";
            openJson.FilterIndex = 1;  // Json by default 
            //openJson.InitialDirectory = @"C:\";
            openJson.Title = "Browse Schedule Files";
            openJson.CheckFileExists = true;
            openJson.CheckPathExists = true;
            openJson.DefaultExt = "json";
            openJson.RestoreDirectory = true;

            openJson.ReadOnlyChecked = true;
            openJson.ShowReadOnly = true;

            if (openJson.ShowDialog() == DialogResult.OK)
            {
                // TODO: Code to stream and save to the user's candidate schedule in here (Michael)
                // Write a separate function, additionally may not want to use a file stream (I just assumed you do)
                // You might want to delete the stream from this method and just include it 
                // inside the method you're going to write
                if (!schedule.scheduleFromFile(openJson.FileName)) MessageBox.Show("The file either failed to open or \nhad an incorrect format.", "File Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            updateScheduleUI();
            calendar_UI.Invalidate(); // Updates the Calendar
            refreshSearchItemColors(search.lastSearchResults.getCourses());
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamWriter jsonSaveStream = null;
            SaveFileDialog saveJson = new SaveFileDialog();

            saveJson.Filter = "Json files (*.json)|*.json|Text files (*.txt)|*.txt";

            saveJson.FilterIndex = 1;  // Json by default 
            //openJson.InitialDirectory = @"C:\";
            saveJson.Title = "Browse Schedule Files";
            saveJson.CheckFileExists = true;
            saveJson.CheckPathExists = true;
            saveJson.DefaultExt = "json";
            saveJson.RestoreDirectory = true;

            if (saveJson.ShowDialog() == DialogResult.OK)
            {
                if ((jsonSaveStream = File.CreateText(saveJson.FileName)) != null)
                {
                    // TODO: Save the Json file to their computer
                    // Write a separate function, additionally may not want to use a file stream (I just assumed you do)
                    // You might want to make a multiline string variable to do so.
                    // Its just a normal string, except using """stuff""" instead of "stuff"
                    jsonSaveStream.Write(schedule.scheduleToFile());
                    jsonSaveStream.Close();
                }
            }
            
        }
        /***************************************************************************************************/


        /***********************************Quit Program****************************************************/
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            Application.Exit();
        }

        /***************************************************************************************************/

        /***********************************Click on tab****************************************************/
        private void menuTabs_Click(object sender, EventArgs e)
        {
            if (menuTabs.SelectedIndex == 1) // If the Schedule tab was clicked
            {
                clickHelp1.ForeColor = Color.Black;
                clickHelp1.Text = "Double click to add a course!";
            }
        }

        /***************************************************************************************************/
    }
}
