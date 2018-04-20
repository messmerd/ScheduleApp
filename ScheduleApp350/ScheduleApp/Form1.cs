using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CourseClass;
using SearchClass;
using CourseInfoClass;
using System.IO;

namespace ScheduleApp
{
    public partial class AppWindow : Form
    {
        public const string emptySearchBarText = "Search by course code or name...";
        Search search = Search.Create("course_dictionary.txt");
        CourseInfo info = CourseInfo.Create();

        public AppWindow()
        {
            InitializeComponent();
            initializeProfessorComboBox();
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





        
        /**************************************** Themes ******************************************/


        private void themeToNight(object sender, EventArgs e)
        {
            // 38 50 56 <- background and surrounding stuff
            // 0 150 136 <- buttons
            // 168 183 185 <- text color
            // 48 64 71 <- search bar
            // 89 102 107 <- unfocused search bar
        }

        private void themeToBlue(object sender, EventArgs e)
        {

        }

        private void themeToGCC(object sender, EventArgs e)
        {

        }

        private void themeToClassic(object sender, EventArgs e)
        {

            scheduleTitle.ForeColor = Color.Black;

            
            menuBar.BackColor = Color.White;
            searchBox.BackColor = Color.White;
            searchTab.BackColor = Color.White;
            searchResult_UI.BackColor = Color.White;
            searchResult_UI.ForeColor = Color.Black;
            scheduleView.BackColor = Color.White;
            scheduleTab.BackColor = Color.White;
            appMenu.BackColor = Color.White;

            
            filter_UI.BackColor = Color.White;
            filter_UI.ForeColor = Color.Black;

            searchBtn.BackColor = Color.Gainsboro;
            advSearchBtn.BackColor = Color.Gainsboro;
            searchBtn.BackColor = Color.Gainsboro;

            
            searchBtn.ForeColor = Color.Black;
            advSearchBtn.ForeColor = Color.Black;

        }
        /******************************************************************************************/






        /**********************Create UI Search Results Fns****************************************/
        private void searchBtn_Click(object sender, EventArgs e)
        {

            Search search = Search.Create("course_dictionary.txt");
            if (searchBox.Text != emptySearchBarText)
                search.searchForQuery(searchBox.Text);
            else
                search.searchForQuery("");
            List<Course> searchResults = search.lastSearchResults.getCourses();

            searchResult_UI.Items.Clear(); // Remove previous search results

            foreach (var course in searchResults)
            {
                var courseToAdd = setSearchRow(course);
                var listViewItem = new ListViewItem(courseToAdd);
                searchResult_UI.Items.Add(listViewItem);
            }
            clickHelp1.Text = "Double click to add a course!";
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
            row[8] = "low"; // placeholder ... 
            row[9] = c.getCourseID().ToString();
            return row;
        }
        /***************************************************************************************/


        /***********************Add to Schedule**************************************************/


        private void searchResult_UI_DoubleClick(object sender, MouseEventArgs e)
        {
            if(searchResult_UI.SelectedItems.Count >= 0)
            {
                int courseID = int.Parse(searchResult_UI.SelectedItems[0].SubItems[9].Text);

                
                Course scheduleCourse = new Course(courseID);

                var courseToAdd = setScheduleRow(scheduleCourse);
                var listViewItem = new ListViewItem(courseToAdd);
                scheduleView.Items.Add(listViewItem);
                clickHelp1.Text = "\"" + scheduleCourse.getCourseCode() + "\" successfully added.";
            }
            
        }

        private string[] setScheduleRow(Course c)
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
            row[8] = c.getCourseID().ToString();
            return row;

        }

        private void clearAll_Click(object sender, EventArgs e)
        {
            scheduleView.Items.Clear(); // what the user sees
        }

        
        private void remove_DoubleClick(object sender, EventArgs e)
        {
            if (scheduleView.SelectedItems.Count >= 0)
            {
                scheduleView.SelectedItems[0].Remove();
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
            Stream jsonFileStream = null;
            OpenFileDialog openJsonDialog = new OpenFileDialog();

            openJsonDialog.InitialDirectory = "c:\\";
            openJsonDialog.Filter = "json files (*.json)";
            openJsonDialog.FilterIndex = 2;
            openJsonDialog.RestoreDirectory = true;

            if (openJsonDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((jsonFileStream = openJsonDialog.OpenFile()) != null)
                    {
                        using (jsonFileStream)
                        {
                            // TODO: Code to stream and save to the user's candidate schedule in here (Michael)
                            // Write an additional function, don't actually write the code here
                            // You might want to delete the stream from this method and just include it 
                            // inside the method you're going to write
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream jsonSaveStream = null;
            SaveFileDialog saveJsonDialog = new SaveFileDialog();

            saveJsonDialog.Filter = "json files (*.json)";
            saveJsonDialog.FilterIndex = 2;
            saveJsonDialog.RestoreDirectory = true;

            if (saveJsonDialog.ShowDialog() == DialogResult.OK)
            {
                if ((jsonSaveStream = saveJsonDialog.OpenFile()) != null)
                {
                    // TODO: Save the Json file to their computer
                    // You might want to make a multiline string variable to do so.
                    // Its just a normal string, except using """stuff""" instead of "stuff"
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
    }
}
