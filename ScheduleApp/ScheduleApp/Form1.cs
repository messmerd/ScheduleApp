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

namespace ScheduleApp
{
    public partial class AppWindow : Form
    {
        
        public const string emptySearchBarText = "Search by course code or name...";
        Search search = Search.Create("course_dictionary.txt");
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


        private void themeSelector_SelectedIndexChanged(Object sender, EventArgs e)
        {
            int selectedTheme = themeSelector.SelectedIndex;
            switch (selectedTheme)
            {
                case 0:
                    themeToClassic();
                    
                    break;
                case 1:
                    themeToNight();
                    
                    break;
                case 2:
                    themeToBlue();
                    
                    break;
                case 3:
                    themeToGCC();
                    
                    break;
            }
        }
        /***************************************************************************************************/


        private void themeToNight()
        {

        }

        private void themeToBlue()
        {

        }

        private void themeToGCC()
        {

        }

        private void themeToClassic()
        {

        }

        /**********************Create UI Search Results Fns****************************************/
        private void searchBtn_Click(object sender, EventArgs e)
        {

            Search search = Search.Create("course_dictionary.txt");
            if (searchBox.Text != emptySearchBarText)
                search.searchForQuery(searchBox.Text);
            else
                search.searchForQuery("");
            List<Course> searchResults = search.lastSearchResults.getCourses();

            // TODO: Implement advanced search filter here

            searchResult_UI.Items.Clear(); // Remove previous search results 

            foreach (var course in searchResults)
            {
                var courseToAdd = setRow(course);
                var listViewItem = new ListViewItem(courseToAdd);
                searchResult_UI.Items.Add(listViewItem);
                // TODO: Dynamically create add/remove buttons to candidate schedule structure
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

        private string[] setRow(Course c) // c = the course
        {
            string[] row = new string[50]; // row buffer

            row[0] = c.getCredits().ToString();
            row[1] = c.getCourseCode();
            //if (c.getProf().first == null || c.getProf().first == "") row[2] = " ";
            //else  row[2] = c.getProf().first[0] + ". " + c.getProf().last;
            row[2] = c.getProf().last + ", " + c.getProf().first; 
            row[3] = c.getLongName();
            row[4] = c.getTimeString().Item1 + "-" + c.getTimeString().Item2;
            row[5] = getDays(c);
            row[6] = c.getEnrollment().ToString() + "/" + c.getCapacity().ToString();
            row[7] = c.getProf().rmp.ToString(); // placeholder until Sprint 2
            row[8] = "low"; // placeholder ... 
            return row;
        }
        /***************************************************************************************/


        /***********************Add to Schedule**************************************************/

/*
        private void SearchReult_UI_MouseDoubleClick(object sender, MouseEventArgs e)
        {

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
