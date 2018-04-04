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

namespace ScheduleApp
{
    public partial class AppWindow : Form
    {
        public const string emptySearchBarText = "Search by course code or name...";
        Search search = Search.Create("course_dictionary.txt");
        List<Course> schedule = new List<Course>();

        public AppWindow()
        {
            InitializeComponent();
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
            searchResult_UI.Columns[9].Width = 0; // hide the ID column, we need this information to add courses later

            foreach (var course in searchResults)
            {
                var courseToAdd = setSearchRow(course);
                var listViewItem = new ListViewItem(courseToAdd);
                searchResult_UI.Items.Add(listViewItem);
            }
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
                
                schedule.Add(scheduleCourse);

                var courseToAdd = setScheduleRow(scheduleCourse);
                var listViewItem = new ListViewItem(courseToAdd);
                scheduleView.Items.Add(listViewItem);
                
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
            return row;

        }

        private void clearAll_Click(object sender, EventArgs e)
        {
            schedule.Clear(); // backend schedule
            scheduleView.Items.Clear(); // what the user sees
        }

        
        private void removeBtn_Click(object sender, EventArgs e)
        {
            string btnName = this.Name;

            switch (btnName)
            {
                case "_0":
                    
                    break;
                case "_1":
                    break;
                case "_2":
                    break;
                case "_3":
                    break;
                case "_4":
                    break;
                case "_5":
                    break;
                case "_6":
                    break;
                case "_7":
                    break;
                case "_8":
                    break;
                case "_9":
                    break;
            }
        }
        /*
        private void removeAtScheduleView(int index)
        {
            if (scheduleView.Items[index] != null)
            {
                schedule.removeCourse()
                scheduleView.Items.RemoveAt(index);
            }
        }

        private void removeCourse()
        {
            for(var course in schedule)
            {
                if(course.getCourseID )
            }
        }
        */

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
            bool[] checkboxes = { M_checkBox.Checked, T_checkBox.Checked, W_checkBox.Checked, R_checkBox.Checked, F_checkBox.Checked };
            for(int i = 0; i < checkboxes.Count(); i++)
            {
                if (checkboxes[i])
                {
                    search.options.day[i] = true;
                }
                else
                {
                    search.options.day[i] = false;
                }
            }
        }

        private void startEndTimes_valueChanged(object sender,  EventArgs e)
        {
            search.options.timeStart = (double)firstTime_UI.Value;
            search.options.timeEnd = (double)secondTime_UI.Value;
        }

        
         private void allNoneCheck_checkChanged(object sender, EventArgs e)
         {
            
            if (allNoneCheckBox.Checked)
            {
                M_checkBox.Checked = true;
                T_checkBox.Checked = true;
                W_checkBox.Checked = true;
                R_checkBox.Checked = true;
                F_checkBox.Checked = true;
            }
            else
            {
                M_checkBox.Checked = false;
                T_checkBox.Checked = false;
                W_checkBox.Checked = false;
                R_checkBox.Checked = false;
                F_checkBox.Checked = false;
            }
         }
       

        /**************************************************************************************/



        /**************************************JSON Transfer (Sprint 2)***************************************/
        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* 
            OpenFileDialog jsonImport = new OpenFileDialog();
            jsonImport.Filter = "JSON | *.json";
            jsonImport.Title = "Import a JSON file with a schedule that you or someone else has created";
           // if(jsonImport.ShowDialog() = DialogResult.OK)
            {

            }
            */
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {   /*
            SaveFileDialog jsonSave = new SaveFileDialog();
            jsonSave.Filter = "JSON | *.json";
            jsonSave.Title = "Save your schedule as a JSON file";
            jsonSave.ShowDialog();
            */
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
