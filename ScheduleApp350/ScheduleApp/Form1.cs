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
        CourseInfo info = CourseInfo.Create();
        CandidateSchedule schedule = CandidateSchedule.Create();

        public AppWindow()
        {
            InitializeComponent();
            initializeProfessorComboBox();

            calendar_UI.StartDate = new DateTime(2010,2,1,0,0,0);  // I chose this date so that the calendar starts on Monday the 1st 
            calendar_UI.NewAppointment += new Calendar.NewAppointmentEventHandler(dayView1_NewAppointment);
            calendar_UI.SelectionChanged += new EventHandler(dayView1_SelectionChanged);
            calendar_UI.ResolveAppointments += new Calendar.ResolveAppointmentsEventHandler(this.dayView1_ResolveAppointments);

            calendar_UI.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dayView1_MouseMove);

            // Use a line like this to change the visual theme of the calendar:
            calendar_UI.Renderer = new Calendar.Office11Renderer();    // Can also use Calendar.Office12Renderer

            clickHelp1.Text = "Double click to add a course!";
        }

        private void initializeProfessorComboBox()
        {
            foreach (var prof in info.prof_database)
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

            foreach (Calendar.Appointment m_App in CandidateSchedule.Create().m_Courses)
                if ((m_App.StartDate >= args.StartDate) &&
                    (m_App.StartDate <= args.EndDate))
                    m_Apps.Add(m_App);

            args.Appointments = m_Apps;
        }


        private void dayView1_SelectionChanged(object sender, EventArgs e)
        {
            //string text = dayView1.SelectionStart.ToString() + ":" + dayView1.SelectionEnd.ToString();
            label3.Text = calendar_UI.SelectionStart.ToString() + ":" + calendar_UI.SelectionEnd.ToString();
            //Console.WriteLine(text);
        }

        private void dayView1_MouseMove(object sender, MouseEventArgs e)
        {
            professor_adv_label.Text = calendar_UI.GetTimeAt(e.X, e.Y).ToString();
            //string text = dayView1.GetTimeAt(e.X, e.Y).ToString();
            //Console.WriteLine(text);
        }

        void dayView1_NewAppointment(object sender, Calendar.NewAppointmentEventArgs args)
        {
            Calendar.Appointment m_Appointment = new Calendar.Appointment();

            m_Appointment.StartDate = args.StartDate;
            m_Appointment.EndDate = args.EndDate;
            m_Appointment.Title = args.Title;

            CandidateSchedule.Create().m_Courses.Add(m_Appointment);
        }

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


            foreach (var course in CandidateSchedule.Create().m_Courses)
            {
                course.BorderColor = Color.DarkGray;
            }

            calendar_UI.Invalidate(); // Updates the Calendar
        }

        private void themeToBlue(object sender, EventArgs e)
        {
            calendar_UI.Renderer = new Calendar.Office12Renderer();  // Calendar theme - this one looks blue
            foreach (var course in CandidateSchedule.Create().m_Courses)
            {
                course.BorderColor = Color.RoyalBlue; 
            }

            calendar_UI.Invalidate(); // Updates the Calendar
        }

        private void themeToGCC(object sender, EventArgs e)
        {
            foreach (var course in CandidateSchedule.Create().m_Courses)
            {
                course.BorderColor = Color.Crimson;
            }

            calendar_UI.Invalidate(); // Updates the Calendar
        }

        private void themeToClassic(object sender, EventArgs e)
        {
            calendar_UI.Renderer = new Calendar.Office11Renderer();  // Calendar theme
            foreach (var course in CandidateSchedule.Create().m_Courses)
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
                searchResult_UI.Items.Add(listViewItem);
            }
        }

        // search by pressing enter, must have the search box focused
        private void input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) searchBtn_Click(sender, e);
        }

        private string getDays(Course returnedCourse)
        {
            string meetingDays = "";
            string[] potentialDays = { "M", "T", "W", "R", "F" }; 

            for(int i = 0; i < potentialDays.Length; i++) // since potentialDays.Length == Course.day.Length, and List has no Length member
            {
                if (returnedCourse.getDay()[i]) meetingDays += potentialDays[i];
            }

            return meetingDays;
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
                if (!schedule.checkInSchedule(courseID)) 
                {
                    Course scheduleCourse = new Course(courseID);

                    schedule.addCourse(courseID);
                    var courseToAdd = setScheduleRow(scheduleCourse);
                    var listViewItem = new ListViewItem(courseToAdd);
                    listViewItem.Name = courseID.ToString();
                    scheduleView.Items.Add(listViewItem);

                    clickHelp1.ForeColor = Color.Black;
                    clickHelp1.Text = "\"" + scheduleCourse.getCourseCode() + "\" successfully added.";
                    calendar_UI.Invalidate(); // Updates the Calendar
                }
                else
                {
                    clickHelp1.ForeColor = Color.Red;
                    clickHelp1.Text = "\"" + info.getCourseCode(courseID) + "\" is already in your schedule.";
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
            CandidateSchedule.Create().removeAllCourses();
            calendar_UI.Invalidate(); // Updates the Calendar
        }

        
        private void remove_DoubleClick(object sender, EventArgs e)
        {
            if (scheduleView.SelectedItems.Count >= 0)
            {
                int courseID = int.Parse(scheduleView.SelectedItems[0].Name);
                 
                scheduleView.SelectedItems[0].Remove();
                CandidateSchedule.Create().removeCourse(courseID);
                calendar_UI.Invalidate(); // Updates the Calendar
            }
        }
        

        /***************************************************************************************/





        /*************************************adv search****************************************/
        private void advSearchBtn_Click(object sender, EventArgs e)
        {
            int searchResult_shift = 106;

            if (!filter_UI.Visible)
            {
                searchResult_UI.Location = new Point(searchResult_UI.Location.X, searchResult_UI.Location.Y + searchResult_shift);
                searchResult_UI.Height -= searchResult_shift;
                filter_UI.Show();
            }
            else
            {
                filter_UI.Hide();
                searchResult_UI.Location = new Point(searchResult_UI.Location.X, searchResult_UI.Location.Y - searchResult_shift);
                searchResult_UI.Height += searchResult_shift;
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

            Tuple<string, Build>  [] options = {
                Tuple.Create("Any", Build.NONE),
                Tuple.Create("HAL", Build.HAL),
                Tuple.Create("Hoyt", Build.HH),
                Tuple.Create("Other", Build.OFFCP),
                Tuple.Create("Pew Fine Arts", Build.PFAC),
                Tuple.Create("PLC", Build.PLC),
                Tuple.Create("Rockwell", Build.RH),
                Tuple.Create("BAO", Build.BAO),
                Tuple.Create("STEM", Build.STEM)
            };

            foreach(var option in options)
            {
                if (building_adv.Text == option.Item1) search.options.building = option.Item2;
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

            if (openJson.ShowDialog() == DialogResult.OK)
            {
                // TODO: Code to stream and save to the user's candidate schedule in here (Michael)
                // Write a separate function, additionally may not want to use a file stream (I just assumed you do)
                // You might want to delete the stream from this method and just include it 
                // inside the method you're going to write
            }
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream jsonSaveStream = null;
            SaveFileDialog saveJson = new SaveFileDialog();

            saveJson.Filter = "Json files (*.json)|*.json|Text files (*.txt)|*.txt";

            if (saveJson.ShowDialog() == DialogResult.OK)
            {
                if ((jsonSaveStream = saveJson.OpenFile()) != null)
                {
                    // TODO: Save the Json file to their computer
                    // Write a separate function, additionally may not want to use a file stream (I just assumed you do)
                    // You might want to make a multiline string variable to do so.
                    // Its just a normal string, except using """stuff""" instead of "stuff"
                }
            }
            jsonSaveStream.Close();
        }
        /***************************************************************************************************/


        /***********************************Quit Program****************************************************/
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            Application.Exit();
        }

        /***************************************************************************************************/
    }
}
