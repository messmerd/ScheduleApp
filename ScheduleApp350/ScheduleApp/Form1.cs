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
using System.Runtime.InteropServices;


namespace ScheduleApp
{
    public enum THEME { CLASSIC, NIGHT, BLUE, GCC }; // An enum for each of the different themes
    
    //class for the program window itself
    public partial class AppWindow : Form
    {
        public const string emptySearchBarText = "Search by course code or name..."; // The text when the searchBox is unfocused
        Search search = Search.Create("course_dictionary.txt");  // Create our databases and the candidate schedule
        CourseInfo DB = CourseInfo.Create();                     // Used for accessing the course database
        CandidateSchedule schedule = CandidateSchedule.Create(); // Used for accessing the candidate schedule

        // enum for keeping track of what sort is applied on which attribute:
        SortOrder[] sort_status = { SortOrder.None, SortOrder.None, SortOrder.None, SortOrder.None, SortOrder.None, SortOrder.None, SortOrder.None, SortOrder.None, SortOrder.None };
        int cur_attr = 0; // The current attribute being clicked
        public static THEME currentTheme; // enum for keeping track of current theme

        //constructor
        public AppWindow()
        {
            InitializeComponent();
            initializeProfessorComboBox();

            currentTheme = THEME.CLASSIC; // Start using the Classing theme

            calendar_UI.StartDate = new DateTime(2010,2,1,0,0,0);  // I chose this date so that the calendar starts on Monday the 1st 
            calendar_UI.ResolveAppointments += new Calendar.ResolveAppointmentsEventHandler(this.dayView1_ResolveAppointments);
            calendar_UI.DoubleClick += new EventHandler(this.dayView1_MouseDoubleClick); // For double-clicking on calendar items
            calendar_UI.Renderer = new Calendar.Office11Renderer(calendar_UI);    // Begin using the Classic theme

            calendar_UI.HalfHourHeight = 11;  // Spacing between half hours in the calendar
            calendar_UI.StartHour = 8;
            calendar_UI.WorkingHourStart = 8;

            clearAdvBtn_Click(this, new EventArgs()); // Reset all the advanced options
            clickHelp1.Text = "Double click to add a course!";

            updateScheduleUI();
        }

        //orders professor first and last name in combobox for the advanced search 
        private void initializeProfessorComboBox()
        {

            for (int i = 0; i < DB.getNumProfs(); i++)
            {
                Professor prof = DB.getProfInDatabase(i);
                if ((prof.last + ", " + prof.first).Trim() != ",")  // Doesn't add blank professor names 
                {
                    professor_adv.Items.Add(prof.last + ", " + prof.first);
                }
            }
        }

        /**********************Text Inside Search****************************************/
        #region 
        // Displays the last thing the user entered in the search box when search box is clicked
        private void searchBox_Enter(object sender, EventArgs e)
        {
            searchBox.Text = Search.Create().lastSearchResults.getQuery(); // calls search if user presses enter instead of the search button
            searchBox.ForeColor = Color.Black;
        }

        // If the user didn't type anything in search box, leaving it resets the text inside
        private void searchBox_Leave(object sender, EventArgs e)
        {
            if (searchBox.Text == "")
            {
                searchBox.Text = emptySearchBarText; // Sets combobox to default text "Search for..."
                searchBox.ForeColor = Color.Gray;
            }
        }
        #endregion 
        /******************************************************************************************/


        /************************Calendar-Related**************************************************/
        #region

        // needed for adding courses to the calendar
        private void dayView1_ResolveAppointments(object sender, Calendar.ResolveAppointmentsEventArgs args)
        {
            
            List<Calendar.Appointment> m_Apps = new List<Calendar.Appointment>();

            foreach (Calendar.Appointment m_App in CandidateSchedule.Create().getCalendarItems())
                if ((m_App.StartDate >= args.StartDate) &&
                    (m_App.StartDate <= args.EndDate))
                    m_Apps.Add(m_App);

            args.Appointments = m_Apps;  
        }

        // function for double clicking courses in calendar -- shows a messagebox with course info
        private void dayView1_MouseDoubleClick(object sender, EventArgs e)
        {
            if (calendar_UI.SelectedAppointment != null)
            {
                int id = calendar_UI.SelectedAppointment.CourseID;
                MessageBox.Show(getCalendarPopupString(id));
                calendar_UI.SelectedAppointment = null;  // Unselects course in calendar
            }
        }

        // displays an info box containing information about a course
        string getCalendarPopupString(int id)
        {
            // Gets all courses with same course code: 
            List<int> ids = new List<int>(); 
            for (int i = 0; i < DB.getNumCourses(); i++)
            {
                if (DB.getCourseCode(i) == DB.getCourseCode(id))
                    ids.Add(i);
            }
            
            string val = DB.getCourseCode(ids[0]) + "\n";
            val += DB.getLongName(ids[0]) + "\n";
            val += "with " + DB.getProf(ids[0]).first + " " + DB.getProf(ids[0]).last + "\n\n";

            int credits = 0;
            foreach (int course_id in ids)
            {
                val += DB.getCourse(course_id).getTimeString().Item1 + " to " + DB.getCourse(course_id).getTimeString().Item2;
                val += " on " + getDays(DB.getCourse(course_id)) + " in " + DB.getBuilding(course_id) + " " + DB.getRoom(course_id) + "\n";
                credits += DB.getCredits(course_id);
            }

            val += "\n" + credits.ToString() + " total credits\n";
            val += DB.getEnrollment(ids[0]).ToString() + " seats taken out of " + DB.getCapacity(ids[0]).ToString() + "\n";
            return val;
        }
         #endregion 
        /******************************************************************************************/


        /**************************************** Themes ******************************************/
        #region
        //sets theme checkboxes in the dropdown menu
        private void adjustCheckstates()
        { 
            if(currentTheme == THEME.NIGHT)
            {
                classicTheme.CheckState = CheckState.Unchecked;
                nightTheme.CheckState = CheckState.Checked;
                crimsonTheme.CheckState = CheckState.Unchecked;
                blueTheme.CheckState = CheckState.Unchecked;
            }
            if (currentTheme == THEME.BLUE)
            {
                classicTheme.CheckState = CheckState.Unchecked;
                nightTheme.CheckState = CheckState.Unchecked;
                crimsonTheme.CheckState = CheckState.Unchecked;
                blueTheme.CheckState = CheckState.Checked;
            }
            if (currentTheme == THEME.GCC)
            {
                classicTheme.CheckState = CheckState.Unchecked;
                nightTheme.CheckState = CheckState.Unchecked;
                crimsonTheme.CheckState = CheckState.Checked;
                blueTheme.CheckState = CheckState.Unchecked;
            }
            if (currentTheme == THEME.CLASSIC)
            {
                classicTheme.CheckState = CheckState.Checked;
                nightTheme.CheckState = CheckState.Unchecked;
                crimsonTheme.CheckState = CheckState.Unchecked;
                blueTheme.CheckState = CheckState.Unchecked;
            }
        }

        //sets theme to night
        private void themeToNight(object sender, EventArgs e)
        {
            currentTheme = THEME.NIGHT;
            adjustCheckstates();
            updateCalendarTheme();

            var veryDarkGray = Color.FromArgb(51, 51, 51);

            // Base color
            scheduleTitle.ForeColor = Color.White;

            menuBar.BackColor = Color.White;
            searchBox.BackColor = Color.White;
            searchTab.BackColor = veryDarkGray;
            searchResult_UI.BackColor = Color.LightGray; 
            searchResult_UI.ForeColor = Color.Black;
            scheduleView.BackColor = Color.LightGray; 
            scheduleTab.BackColor = veryDarkGray;
            appMenu.BackColor = Color.White;

            // Adv Filter elements
            filter_UI.BackColor = veryDarkGray;
            filter_UI.ForeColor = Color.White;

            // Button backgrounds
            searchBtn.BackColor = Color.Gainsboro;
            advSearchBtn.BackColor = Color.Gainsboro;
            searchBtn.BackColor = Color.Gainsboro;

            // Button fonts
            searchBtn.ForeColor = Color.Black;
            advSearchBtn.ForeColor = Color.Black;

            autocorrect_label.ForeColor = Color.White;
            removeHelp.ForeColor = Color.White;
            credits_notify_label.ForeColor = Color.White;
            calendar_info_label.ForeColor = Color.White;

            clickHelp1.ForeColor = Color.White;

            updateScheduleUI(); 
            refreshSearchItemColors(search.lastSearchResults.getCourses());
            calendar_UI.Invalidate(); // Updates the Calendar
        }

        //sets theme to blue
        private void themeToBlue(object sender, EventArgs e)
        {
            currentTheme = THEME.BLUE;
            adjustCheckstates();
            updateCalendarTheme(); 

            scheduleTitle.ForeColor = Color.White;
            menuBar.BackColor = Color.White;
            searchBox.BackColor = Color.White;
            searchTab.BackColor = Color.MidnightBlue;

            searchResult_UI.ForeColor = Color.Black;
            searchResult_UI.BackColor = Color.White;
            scheduleView.ForeColor = Color.Black;
            scheduleTab.BackColor = Color.MidnightBlue;
            appMenu.BackColor = Color.White;

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

            clickHelp1.ForeColor = Color.White;

            removeHelp.ForeColor = Color.White;  // This is the "Double click to remove courses" text
            autocorrect_label.ForeColor = Color.White;
            credits_notify_label.ForeColor = Color.White;
            calendar_info_label.ForeColor = Color.White;

            updateScheduleUI();
            refreshSearchItemColors(search.lastSearchResults.getCourses());
            calendar_UI.Invalidate(); // Updates the Calendar
        }

        //sets theme to GCC crimson
        private void themeToGCC(object sender, EventArgs e)
        {
            currentTheme = THEME.GCC;

            adjustCheckstates();
            updateCalendarTheme(); 

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

            clickHelp1.ForeColor = Color.White;
            
            removeHelp.ForeColor = Color.White;  // This is the "Double click to remove courses" text
            autocorrect_label.ForeColor = Color.White;
            credits_notify_label.ForeColor = Color.White;
            calendar_info_label.ForeColor = Color.White;

            updateScheduleUI();
            refreshSearchItemColors(search.lastSearchResults.getCourses());
            calendar_UI.Invalidate(); // Updates the Calendar
        }

        //sets theme to classic
        private void themeToClassic(object sender, EventArgs e)
        {
            currentTheme = THEME.CLASSIC;
            adjustCheckstates();
            updateCalendarTheme(); 

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
           
            clickHelp1.ForeColor = Color.Black;

            credits_notify_label.ForeColor = Color.Black;
            autocorrect_label.ForeColor = Color.Red;
            calendar_info_label.ForeColor = Color.Black;

            removeHelp.ForeColor = Color.Black;  // This is the "Double click to remove courses" text
            updateScheduleUI();
            refreshSearchItemColors(search.lastSearchResults.getCourses());
            calendar_UI.Invalidate(); // Updates the Calendar

        }

        //updates calendar items with the current theme
        private void updateCalendarTheme()
        {
            Color color = Color.Black; 
            switch (currentTheme)
            {
                case THEME.BLUE:
                    calendar_UI.Renderer = new Calendar.Office12Renderer();
                    color = Color.MidnightBlue;
                    break;
                case THEME.CLASSIC:
                    calendar_UI.Renderer = new Calendar.Office11Renderer();
                    color = Color.DarkSlateGray;
                    break;
                case THEME.GCC:
                    calendar_UI.Renderer = new Calendar.GCCCrimsonRenderer();
                    color = Color.Crimson;
                    break;
                case THEME.NIGHT:
                    calendar_UI.Renderer = new Calendar.NightRenderer();
                    color = Color.DarkGray;
                    break;
                default:
                    break;
            }

            foreach (var calendar_item in schedule.getCalendarItems())  // Sets border color of each calendar item 
            {
                calendar_item.BorderColor = color;
            }
        }

        #endregion
        /******************************************************************************************/        


        /*************************Sort Search Result Column****************************************/
        #region 
        //initial function for sorting
        private void sortResults_columnClick(object sender, ColumnClickEventArgs e)
        {
            set_sort_type(e.Column); // sets whether it should be by relevancy, asc, or desc order
            sort_col(e.Column); // performs the ordering, and sets the new search results
            searchResult_UI.SetSortIcon(e.Column, sort_status[e.Column]);  // Sets the arrow icon 
        }

        //sets the type of sorting type the user desires
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

        //sorts columns
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

        #endregion
        /******************************************************************************************/

        /*********************************Create UI Search Fns*************************************/
        #region 
        //event listener for button clicks (when user clicks the search button)
        private void searchBtn_Click(object sender, EventArgs e)
        {
            // Remove previous search results upon performing another search
            searchResult_UI.Items.Clear();

            if (searchBox.Text != emptySearchBarText)  // If the user entered something to search for
                search.searchForQuery(searchBox.Text); // Search for query
            else
                search.searchForQuery(""); // search for all courses

            search.advancedSearchFilter(); // Filter the results according to the advanced options 
            search.lastSearchResults.SortCourses(SORTTYPE.RELEVANCY, false);  // Sort by relevancy 

            int column = sort_status.ToList().FindIndex(x => x != SortOrder.None);
            if (column != -1)
            {
                searchResult_UI.SetSortIcon(column, SortOrder.None);  // Resets the arrow icon on the column
                sort_status[column] = SortOrder.None; 
            }

            populateSearch(search.lastSearchResults.getCourses());  // Populate the search results UI
            display_corrected_query();    // Displays the "Did you mean  ______?" text 

            searchBox.SelectionStart = 0; // automatically highlights the users last query, so they can search again quickly
            searchBox.SelectionLength = searchBox.Text.Length;
        }

        //fills the search results UI with the search results 
        private void populateSearch(List<Course> results)
        {
            foreach (var course in results)
            {
                var listViewItem = new ListViewItem(setSearchRow(course));
                listViewItem.Name = course.getCourseID().ToString();
                listViewItem.UseItemStyleForSubItems = false;

                // The next two parts set the colors of the results depending on whether the course has been added 
                //    to the schedule already or if it conflicts with items currently in schedule
                for (int j = 0; j < listViewItem.SubItems.Count; j++)
                {
                    listViewItem.SubItems[j].BackColor = schedule.exists(course.getCourseID()) ? Color.GreenYellow : searchResult_UI.BackColor;
                }

                if (schedule.checkTimeConflict(course).Count > 1)
                {
                    listViewItem.SubItems[4].BackColor = Color.Red;
                }

                searchResult_UI.Items.Add(listViewItem); // Adds the course to the search results UI
            }
        }

        //sets new colors to search results depending on prior course selections
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
                }
                i++;
                
            }
        }

        // search by pressing enter (must have the search box focused)
        private void input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) searchBtn_Click(sender, e);
        }

        // gets the days that a course meets as a string
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

        //sets the text for a row in the search results
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
            string rmp = c.getProf().rmp.ToString();
            if (c.getProf().rmp.ToString().Length == 1) rmp += ".0";
            row[7] = rmp;
            row[8] = c.getProbability();
            return row;
        }
        #endregion
        /***************************************************************************************/


        /***********************Add to Schedule**************************************************/
        #region
        //allows for adding and removing courses to/from schedule with double click when on the search result page
        private void searchResult_UI_DoubleClick(object sender, MouseEventArgs e)
        {
            if(searchResult_UI.SelectedItems.Count >= 0)
            {
                int courseID = int.Parse(searchResult_UI.SelectedItems[0].Name);
                if (!schedule.exists(courseID)) // If the course isn't currently in your schedule, need to add it to your schedule
                {
                    schedule.addCourse(courseID);  // Add the course to the schedule 
                    updateScheduleUI();            // Make the schedule UI reflect these changes

                    switch (currentTheme) // Sets clickHelp1 color based on current theme
                    {
                        case THEME.BLUE:
                            clickHelp1.ForeColor = Color.White;
                            break;
                        case THEME.NIGHT:
                            clickHelp1.ForeColor = Color.White;
                            break;
                        case THEME.GCC:
                            clickHelp1.ForeColor = Color.White;
                            break;
                        default:
                            clickHelp1.ForeColor = Color.Black;
                            break;
                    }

                    clickHelp1.Text = "\"" + DB.getCourseCode(courseID) + "\" successfully added.";
                    updateCalendarTheme(); 
                    calendar_UI.Invalidate(); // Updates the Calendar
                    refreshSearchItemColors(search.lastSearchResults.getCourses());
                    searchResult_UI.SelectedItems[0].Selected = false; 
                }
                else  // If course is already in the schedule, need to remove it  
                {
                    schedule.removeCourse(courseID); // Remove the course from the schedule
                    updateScheduleUI();              // Make the schedule UI reflect these changes

                    switch (currentTheme)            // Sets clickHelp1 color based on current theme
                    {
                        case THEME.BLUE:
                            clickHelp1.ForeColor = Color.White;
                            break;
                        case THEME.NIGHT:
                            clickHelp1.ForeColor = Color.White;
                            break;
                        case THEME.GCC:
                            clickHelp1.ForeColor = Color.White;
                            break;
                        default:
                            clickHelp1.ForeColor = Color.Black;
                            break;
                    }

                    clickHelp1.Text = "\"" + DB.getCourseCode(courseID) + "\" was removed from your schedule.";
                    refreshSearchItemColors(search.lastSearchResults.getCourses());
                    searchResult_UI.SelectedItems[0].Selected = false; 
                }
            }
        }

        //sets schedule row in accordance with selected course
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

        //clears schedule of selected courses
        private void clearAll_Click(object sender, EventArgs e)
        {
            scheduleView.Items.Clear(); // what the user sees
            schedule.removeAllCourses();
            calendar_UI.Invalidate(); // Updates the Calendar
            refreshSearchItemColors(search.lastSearchResults.getCourses());
            updateScheduleUI();
        }

        //remove courses from schedule with a double click
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

        //updates schedule after courses have been added or removed
        private void updateScheduleUI()
        {
            scheduleView.Items.Clear();
            foreach (Course c in schedule.getCourses().OrderBy(x => x.getCourseID()))
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

            if (schedule.checkCreditCount() == -1)
            {
                credits_notify_label.Text = "You have too few credits to be a full-time student";
                credits_notify_label.Visible = true;
            }
            if (schedule.checkCreditCount() == 0)
            {
                credits_notify_label.Visible = false;
            }
            if (schedule.checkCreditCount() == 1)
            {
                credits_notify_label.Text = "You have over 17 credits and may have to pay extra for tuition";
                credits_notify_label.Visible = true;
            }
        }

        #endregion
        /***************************************************************************************/


        /*************************************adv search****************************************/
        #region
        //drops down advanced search box after button is clicked
        private void advSearchBtn_Click(object sender, EventArgs e)
        {
            int shift = 106;
            int x = searchResult_UI.Location.X;
            int y = searchResult_UI.Location.Y;

            if (!filter_UI.Visible) // if the adv filter is not visible
            {
                searchResult_UI.Location = new Point(x, y + shift); // shift search results up vertiallcay
                autocorrect_label.Location = new Point(autocorrect_label.Location.X, autocorrect_label.Location.Y + shift); // shift label by same amount
                searchResult_UI.Height -= shift; // adjust the height so it doesnt overflow
                filter_UI.Show(); // then show it once these changes are done
            }
            else
            {
                filter_UI.Hide(); // The opposite of the "if" block
                searchResult_UI.Location = new Point(x, y - shift);
                autocorrect_label.Location = new Point(autocorrect_label.Location.X, autocorrect_label.Location.Y - shift);
                searchResult_UI.Height += shift;
            }

        }

        //checks to see if the days chosen attribute has been changed by the user
        private void daysAttr_checkChanged(object sender, EventArgs e)
        {
            // all checkboxes that potentially need to be changed
            bool [] checkboxes = { M_checkBox.Checked, T_checkBox.Checked, W_checkBox.Checked, R_checkBox.Checked, F_checkBox.Checked };

            for(int i = 0; i < checkboxes.Count(); i++)
            {
                // set the advanced options based on the search boxes
                search.options.day[i] = checkboxes[i] ? true : false;
            }
        }

        //checks to see if the start time chosen attribute has been changed by the user
        private void numericUpDownEx_ValueChanged(object sender, EventArgs e)
        {
            search.options.timeStart = (double)numericUpDownEx1.Value;
            search.options.timeEnd = (double)numericUpDownEx2.Value;
        }

        // Shows the auto correct label if the auto corrected string != the string the user typed in
        private void display_corrected_query()
        {
            if(search.lastSearchResults.getCorrectedQuery() != search.lastSearchResults.getQuery().ToLower() && searchResult_UI.Items.Count > 0)
            {
                autocorrect_label.Text = "Did you mean " + search.lastSearchResults.getCorrectedQuery() + "?";
                autocorrect_label.Visible = true;

                searchBox.SelectionStart = searchBox.Text.Length;
            }
            else if(searchResult_UI.Items.Count == 0) // No results appeared
            {
                autocorrect_label.Text = "No results. Try another query.";
                autocorrect_label.Visible = true;
            }
            else
            {
                autocorrect_label.Visible = false;
            }
        }

        //checks to see if the building attribute has been changed by the user
        private void building_valueChanged(object sender, EventArgs e)
        {
        
            // set advanced options with building based on what the user has selected in the UI
            string [] str = { "Any", "HAL", "Hoyt", "Other", "Pew Fine Arts", "PLC", "Rockwell", "BAO", "STEM" };

            Build[] enums = { Build.NONE, Build.HAL, Build.HH, Build.OFFCP, Build.PFAC, Build.PLC, Build.RH, Build.BAO, Build.STEM };

            for(var i = 0; i < str.Length; i++)
            {
                if (building_adv.Text == str[i]) search.options.building = enums[i];
            }
        }

        //checks to see if the professor attribute has been changed by the user
        private void professorValueChanged(object sender, EventArgs e)
        {
            bool anyProf = professor_adv.Text == "Any";
            search.options.lastNameProfessor = !anyProf ? professor_adv.Text.Split(',')[0] : "";
            search.options.firstNameProfessor = !anyProf ? professor_adv.Text.Split(',')[1].Trim() : "";
        }
        
        // Sets all or none of the checkboxes for the day-related advanced options if the user clicks the all/none box
        private void allNoneCheck_checkChanged(object sender, EventArgs e)
        {
            CheckBox[] checkboxes = { M_checkBox, T_checkBox, W_checkBox, R_checkBox, F_checkBox };

            foreach (var checkbox in checkboxes)
            {
                checkbox.Checked = allNoneCheckBox.Checked ? true : false;
            }
        }

        //checks to see if the rmp attribute has been changed by the user
        private void rmp_valueChanged(object sender, EventArgs e)
        {
            search.options.rmp = (double)rmp_numericUpDown.Value;
        }

        // sets advanced options based on what user has selected from the combobox
        private void probability_valueChanged(object sender, EventArgs e)
        {
            switch (probability_combobox.Text)
            {
                case "low":
                    search.options.probabilityScore = 2;
                    break;
                case "medium":
                    search.options.probabilityScore = 1;
                    break;
                case "high":
                    search.options.probabilityScore = 0;
                    break;
                default:
                    search.options.probabilityScore = -1;
                    break;
            }
        }

        // If the user does not want to see full classes or does, checks the appropriate checkbox
        private void showFullCheckbox_CheckChanged(object sender, EventArgs e)
        {
            search.options.showFull = showFullCheckbox.Checked ? true : false;
        }

        // restores all advanced options to default, both in the AdvancedOptions class and the UI
        private void clearAdvBtn_Click(object sender, EventArgs e)
        {
            search.options.clear(); // Resets all the options
            rmp_numericUpDown.Value = (decimal)0.0;
            
            probability_combobox.Text = "Any";
            
            numericUpDownEx1.Value = 0;
            numericUpDownEx2.Value = 24;
            
            building_adv.Text = "Any";

            allNoneCheckBox.Checked = true;
            allNoneCheck_checkChanged(sender, e);

            professor_adv.Text = "Any";

            showFullCheckbox.CheckState = CheckState.Checked;
            showFullCheckbox_CheckChanged(sender, e);
        }
        #endregion
        /**************************************************************************************/


        /**************************************JSON Transfer***************************************/
        #region
        //function that allows the import button to work 
        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openJson = new OpenFileDialog();
            openJson.Filter = "Json files (*.json)|*.json|Text files (*.txt)|*.txt";

            if (openJson.ShowDialog() == DialogResult.OK)
            {
                if (!schedule.scheduleFromFile(openJson.FileName)) MessageBox.Show("The file either failed to open or \nhad an incorrect format.", "File Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            updateScheduleUI();
            updateCalendarTheme(); 
            calendar_UI.Invalidate(); // Updates the Calendar
            refreshSearchItemColors(search.lastSearchResults.getCourses());
        }

        //function that allows the export button to work
        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamWriter jsonSaveStream = null;
            SaveFileDialog saveJson = new SaveFileDialog();

            saveJson.Filter = "Json files (*.json)|*.json|Text files (*.txt)|*.txt";

            if (saveJson.ShowDialog() == DialogResult.OK)
            {
                if ((jsonSaveStream = File.CreateText(saveJson.FileName)) != null)
                {
                    jsonSaveStream.Write(schedule.scheduleToFile());
                    jsonSaveStream.Close();
                }
            }
            
        }
        #endregion
        /***************************************************************************************************/


        /***********************************Quit Program****************************************************/
        #region 
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            Application.Exit();
        }
        #endregion 
        /***************************************************************************************************/


        /***********************************Click on tab****************************************************/
        #region 
        //resets the "Double click to add a course" text
        private void menuTabs_Click(object sender, EventArgs e)
        {
            if (menuTabs.SelectedIndex == 1) // If the Schedule tab was clicked
            {
                clickHelp1.Text = "Double click to add a course!";  // Just to reset the text 
            }
        }
        #endregion 
        /***************************************************************************************************/
    }

    // This is for the sort arrows on the search result columns: 
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

        //
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 msg, IntPtr wParam, ref HDITEM lParam);

        //
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
