﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;


namespace ScheduleApp
{
    public enum THEME { CLASSIC, NIGHT, BLUE, GCC };
    
    public partial class AppWindow : Form
    {
        public const string emptySearchBarText = "Search by course code or name...";
        Search search = Search.Create("course_dictionary.txt");
        CourseInfo DB = CourseInfo.Create();
        CandidateSchedule schedule = CandidateSchedule.Create();
        SortOrder[] sort_status = { SortOrder.None, SortOrder.None, SortOrder.None, SortOrder.None, SortOrder.None, SortOrder.None, SortOrder.None, SortOrder.None, SortOrder.None };
        int cur_attr = 0;
        public static THEME currentTheme;

        public AppWindow()
        {
            InitializeComponent();
            initializeProfessorComboBox();
            searchResult_UI.ShowItemToolTips = true;
            //searchResult_UI.HideSelection = true;

            currentTheme = THEME.CLASSIC; 

            calendar_UI.StartDate = new DateTime(2010,2,1,0,0,0);  // I chose this date so that the calendar starts on Monday the 1st 
            //calendar_UI.NewAppointment += new Calendar.NewAppointmentEventHandler(dayView1_NewAppointment);
            calendar_UI.SelectionChanged += new EventHandler(dayView1_SelectionChanged);
            calendar_UI.ResolveAppointments += new Calendar.ResolveAppointmentsEventHandler(this.dayView1_ResolveAppointments);

            calendar_UI.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dayView1_MouseMove);

            // Use a line like this to change the visual theme of the calendar:
            calendar_UI.Renderer = new Calendar.Office11Renderer(calendar_UI);    // Can also use Calendar.Office12Renderer
            calendar_UI.HalfHourHeight = 11;  // was 18
            calendar_UI.StartHour = 8;
            calendar_UI.WorkingHourStart = 8;

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
            currentTheme = THEME.NIGHT; 
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
              
            // More need to be added  
            
            */


            foreach (var course in CandidateSchedule.Create().getCalendarItems())
            {
                course.BorderColor = Color.DarkGray;
            }

            if (clickHelp1.ForeColor == Color.Yellow)
                clickHelp1.ForeColor = Color.Green;
            if (clickHelp1.ForeColor == Color.LightSalmon)
                clickHelp1.ForeColor = Color.Red;
            if (clickHelp1.ForeColor == Color.White)
                clickHelp1.ForeColor = Color.Black;


            calendar_UI.Invalidate(); // Updates the Calendar
        }

        private void themeToBlue(object sender, EventArgs e)
        {
            currentTheme = THEME.BLUE; 
            calendar_UI.Renderer = new Calendar.Office12Renderer();  // Calendar theme - this one looks blue
            foreach (var course in CandidateSchedule.Create().getCalendarItems())
            {
                course.BorderColor = Color.MidnightBlue; 
            }

            scheduleTitle.ForeColor = Color.White;
            //Color.CornflowerBlue;
            //Color.DarkBlue
            menuBar.BackColor = Color.CornflowerBlue;
            searchBox.BackColor = Color.White;
            searchTab.BackColor = Color.MidnightBlue;
            searchResult_UI.BackColor = Color.CornflowerBlue;
            searchResult_UI.ForeColor = Color.Black;
            scheduleView.BackColor = Color.CornflowerBlue;
            scheduleView.ForeColor = Color.Black;
            scheduleTab.BackColor = Color.MidnightBlue;
            appMenu.BackColor = Color.CornflowerBlue;

            // Adv Filter
            filter_UI.BackColor = Color.DarkBlue;
            filter_UI.ForeColor = Color.White;

            // Buttons
            searchBtn.BackColor = Color.Gainsboro;
            advSearchBtn.BackColor = Color.Gainsboro;
            searchBtn.BackColor = Color.Gainsboro;

            // Button font color
            searchBtn.ForeColor = Color.Black;
            advSearchBtn.ForeColor = Color.Black;

            if (clickHelp1.ForeColor == Color.Green)
                clickHelp1.ForeColor = Color.Yellow;
            if (clickHelp1.ForeColor == Color.Red)
                clickHelp1.ForeColor = Color.LightSalmon;
            if (clickHelp1.ForeColor == Color.Black)
                clickHelp1.ForeColor = Color.White;

            removeHelp.ForeColor = Color.White;  // This is the "Double click to remove courses" text

            calendar_UI.Invalidate(); // Updates the Calendar
        }

        private void themeToGCC(object sender, EventArgs e)
        {
            currentTheme = THEME.GCC; 
            calendar_UI.Renderer = new Calendar.GCCCrimsonRenderer();  // Calendar theme
            foreach (var course in CandidateSchedule.Create().getCalendarItems())
            {
                course.BorderColor = Color.Crimson;
            }


            scheduleTitle.ForeColor = Color.Black;
            
            menuBar.BackColor = Color.White;
            searchBox.BackColor = Color.White;
            
            searchTab.BackColor = Calendar.GCCCrimsonRenderer.TrueCrimsonLight;
            scheduleTab.BackColor = Calendar.GCCCrimsonRenderer.TrueCrimsonLight;

            searchResult_UI.BackColor = Color.White;
            scheduleView.BackColor = Color.White;
            
            searchResult_UI.ForeColor = Color.Black;
            
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

            if (clickHelp1.ForeColor == Color.Yellow)
                clickHelp1.ForeColor = Color.Green;
            if (clickHelp1.ForeColor == Color.LightSalmon)
                clickHelp1.ForeColor = Color.Red;
            if (clickHelp1.ForeColor == Color.White)
                clickHelp1.ForeColor = Color.Black;

            removeHelp.ForeColor = Color.White;  // This is the "Double click to remove courses" text

            calendar_UI.Invalidate(); // Updates the Calendar
        }

        private void themeToClassic(object sender, EventArgs e)
        {
            currentTheme = THEME.CLASSIC;
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

            if (clickHelp1.ForeColor == Color.Yellow)
                clickHelp1.ForeColor = Color.Green;
            if (clickHelp1.ForeColor == Color.LightSalmon)
                clickHelp1.ForeColor = Color.Red;
            if (clickHelp1.ForeColor == Color.White)
                clickHelp1.ForeColor = Color.Black;

            removeHelp.ForeColor = Color.Black;  // This is the "Double click to remove courses" text

            calendar_UI.Invalidate(); // Updates the Calendar

        }
        /******************************************************************************************/

        

        /*************************Sort Search Result Column****************************************/
        private void sortResults_columnClick(object sender, ColumnClickEventArgs e)
        {
            set_sort_type(e.Column); // sets whether it should be by relevancy, asc, or desc order
            sort_col(e.Column); // performs the ordering, and sets the new search results
            searchResult_UI.SetSortIcon(e.Column, sort_status[e.Column]);  // Sets the arrow icon 
        }

        private void set_sort_type(int index)
        {
            if(cur_attr != index)
            {
                for(int i = 0; i < sort_status.Length; i++)
                {
                    sort_status[i] = SortOrder.None; 
                }
            }

            cur_attr = index;

            if (sort_status[index] == SortOrder.None)
            {
                sort_status[index] = SortOrder.Ascending;
            }
            else if (sort_status[index] == SortOrder.Ascending)
            {
                sort_status[index] = SortOrder.Descending;
            }
            else
            {
                sort_status[index] = SortOrder.None;
            }
        }

        private void sort_col(int i)
        {
            switch (sort_status[i])
            {
                case SortOrder.None:
                    search.lastSearchResults.SortCourses(SORTTYPE.RELEVANCY, false);
                    break;
                case SortOrder.Ascending:
                    search.lastSearchResults.SortCourses((SORTTYPE)i, true);
                    break;
                case SortOrder.Descending:
                    search.lastSearchResults.SortCourses((SORTTYPE)i, false);
                    break;
            }

            searchResult_UI.Items.Clear();
            populateSearch(search.lastSearchResults.getCourses());
            //refresh_search_results(search.lastSearchResults.getCourses());
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
                var listViewItem = new ListViewItem(setSearchRow(course));
                listViewItem.Name = course.getCourseID().ToString();
                listViewItem.UseItemStyleForSubItems = false;

                for (int j = 0; j < listViewItem.SubItems.Count; j++)
                {
                    listViewItem.SubItems[j].BackColor = schedule.exists(course.getCourseID()) ? Color.GreenYellow : searchResult_UI.BackColor;
                }

                if (schedule.checkTimeConflict(course).Count > 1)
                {
                    listViewItem.SubItems[4].BackColor = Color.Red;
                    listViewItem.ToolTipText = "This course conflicts with your schedule";
                }
                searchResult_UI.Items.Add(listViewItem);
            }
        }


        
        private void refresh_search_results(List<Course> results)
        {
            int i = 0;
            foreach (ListViewItem item in searchResult_UI.Items)
            {
                item.UseItemStyleForSubItems = false;
                //item.SubItems[0].Text = results[i].getCredits().ToString();
                //item.SubItems[1].Text = results[i].getCourseCode();
                //item.SubItems[2].Text = results[i].getProf().last + ", " + results[i].getProf().first;
                //item.SubItems[3].Text = results[i].getLongName();
                //item.SubItems[4].Text = results[i].getTimeString().Item1 + "-" + results[i].getTimeString().Item2;
                //item.SubItems[5].Text = getDays(results[i]);
                //item.SubItems[6].Text = results[i].getEnrollment().ToString() + "/" + results[i].getCapacity().ToString();
                //item.SubItems[7].Text = results[i].getProf().rmp.ToString(); // placeholder until Sprint 2
                //item.SubItems[8].Text = results[i].getProbability();
                int k = 0;
                setSearchRow(results[i]).ToList().ForEach(x => item.SubItems[k++].Text = x); 
                  
                for (int j = 0; j < item.SubItems.Count; j++)
                {
                    item.SubItems[j].BackColor = schedule.exists(results[i].getCourseID()) ? Color.GreenYellow : searchResult_UI.BackColor;
                }

                if (schedule.checkTimeConflict(results[i]).Count > 1)
                {
                    item.SubItems[4].BackColor = Color.Red;
                    item.ToolTipText = "This course conflicts with your schedule";
                }
                i++;

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
                    item.SubItems[j].BackColor = schedule.exists(results[i].getCourseID()) ? Color.GreenYellow : searchResult_UI.BackColor;
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

            for(int i = 0; i < all_days.Length; i++) 
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
                    switch (currentTheme)
                    {
                        case THEME.BLUE:
                            clickHelp1.ForeColor = Color.Yellow;
                            break;

                        default:
                            clickHelp1.ForeColor = Color.Green;
                            break;
                    }

                    clickHelp1.Text = "\"" + DB.getCourseCode(courseID) + "\" successfully added.";
                    calendar_UI.Invalidate(); // Updates the Calendar
                    refreshSearchItemColors(search.lastSearchResults.getCourses());
                    searchResult_UI.SelectedItems[0].Selected = false; 
                }
                else
                {
                    schedule.removeCourse(courseID);
                    updateScheduleUI();

                    switch (currentTheme)
                    {
                        case THEME.BLUE:
                            clickHelp1.ForeColor = Color.LightSalmon;
                            break;

                        default:
                            clickHelp1.ForeColor = Color.Red;
                            break;
                    }

                    clickHelp1.Text = "\"" + DB.getCourseCode(courseID) + "\" was removed from your schedule.";
                    refreshSearchItemColors(search.lastSearchResults.getCourses());
                    searchResult_UI.SelectedItems[0].Selected = false; 
                    
                }
            }
        }

        public string[] setScheduleRow(Course c)
        {
            string[] buf = new string[50]; // buf buffer

            buf[0] = c.getCredits().ToString();
            buf[1] = c.getCourseCode();
            buf[2] = c.getProf().last + ", " + c.getProf().first;
            buf[3] = c.getLongName();
            buf[4] = c.getTimeString().Item1 + "-" + c.getTimeString().Item2;
            buf[5] = c.getBuilding().ToString();
            buf[6] = c.getRoom().ToString();
            buf[7] = getDays(c);
            return buf;

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
                    listViewItem.BackColor = scheduleView.BackColor; 
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
            //openJson.FilterIndex = 1;  // Json by default 
            //openJson.InitialDirectory = @"C:\";
            //openJson.Title = "Browse Schedule Files";
            //openJson.CheckFileExists = true;
            //openJson.CheckPathExists = true;
            //openJson.DefaultExt = "json";
            //openJson.RestoreDirectory = true;

            //openJson.ReadOnlyChecked = true;
            //openJson.ShowReadOnly = true;

            if (openJson.ShowDialog() == DialogResult.OK)
            {
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

            //saveJson.FilterIndex = 1;  // Json by default 
            //openJson.InitialDirectory = @"C:\";
            //saveJson.Title = "Browse Schedule Files";
            //saveJson.CheckFileExists = true;
            //saveJson.CheckPathExists = true;
            //saveJson.DefaultExt = "json";
            //saveJson.RestoreDirectory = true;

            if (saveJson.ShowDialog() == DialogResult.OK)
            {
                if ((jsonSaveStream = File.CreateText(saveJson.FileName)) != null)
                {
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
                switch (currentTheme)
                {
                    case THEME.BLUE:
                        clickHelp1.ForeColor = Color.White;
                        break;

                    default:
                        clickHelp1.ForeColor = Color.Black;
                        break;
                }
                
                clickHelp1.Text = "Double click to add a course!";
            }
        }

        /***************************************************************************************************/
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class ListViewExtensions
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct HDITEM
        {
            public Mask mask;
            public int cxy;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string pszText;
            public IntPtr hbm;
            public int cchTextMax;
            public Format fmt;
            public IntPtr lParam;
            // _WIN32_IE >= 0x0300 
            public int iImage;
            public int iOrder;
            // _WIN32_IE >= 0x0500
            public uint type;
            public IntPtr pvFilter;
            // _WIN32_WINNT >= 0x0600
            public uint state;

            [Flags]
            public enum Mask
            {
                Format = 0x4,       // HDI_FORMAT
            };

            [Flags]
            public enum Format
            {
                SortDown = 0x200,   // HDF_SORTDOWN
                SortUp = 0x400,     // HDF_SORTUP
            };
        };

        public const int LVM_FIRST = 0x1000;
        public const int LVM_GETHEADER = LVM_FIRST + 31;

        public const int HDM_FIRST = 0x1200;
        public const int HDM_GETITEM = HDM_FIRST + 11;
        public const int HDM_SETITEM = HDM_FIRST + 12;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 msg, IntPtr wParam, ref HDITEM lParam);

        public static void SetSortIcon(this ListView listViewControl, int columnIndex, SortOrder order)
        {
            IntPtr columnHeader = SendMessage(listViewControl.Handle, LVM_GETHEADER, IntPtr.Zero, IntPtr.Zero);
            for (int columnNumber = 0; columnNumber <= listViewControl.Columns.Count - 1; columnNumber++)
            {
                var columnPtr = new IntPtr(columnNumber);
                var item = new HDITEM
                {
                    mask = HDITEM.Mask.Format
                };

                if (SendMessage(columnHeader, HDM_GETITEM, columnPtr, ref item) == IntPtr.Zero)
                {
                    throw new Win32Exception();
                }

                if (order != SortOrder.None && columnNumber == columnIndex)
                {
                    switch (order)
                    {
                        case SortOrder.Ascending:
                            item.fmt &= ~HDITEM.Format.SortDown;
                            item.fmt |= HDITEM.Format.SortUp;
                            break;
                        case SortOrder.Descending:
                            item.fmt &= ~HDITEM.Format.SortUp;
                            item.fmt |= HDITEM.Format.SortDown;
                            break;
                    }
                }
                else
                {
                    item.fmt &= ~HDITEM.Format.SortDown & ~HDITEM.Format.SortUp;
                }

                if (SendMessage(columnHeader, HDM_SETITEM, columnPtr, ref item) == IntPtr.Zero)
                {
                    throw new Win32Exception();
                }
            }
        }
    }


}
