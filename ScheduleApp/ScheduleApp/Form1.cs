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

namespace ScheduleApp
{
    public partial class AppWindow : Form
    {
        public AppWindow()
        {
            InitializeComponent();
        }




        /**********************Create UI Search Results Fns****************************************/
        private void searchBtn_Click(object sender, EventArgs e)
        {

            Search search = new Search("course_dictionary.txt");
            search.searchForQuery(searchBox.Text);
            List<Course> searchResults = search.lastSearchResults.getCourses();

            foreach (var returnedCourse in searchResults)
            {
                var courseToAdd = setRow(returnedCourse);
                var listViewItem = new ListViewItem(courseToAdd);
                searchResult_UI.Items.Add(listViewItem);
            }
        }

        private string getDays(Course returnedCourse)
        {
            string returnedDays = "";
            string[] potentialDays = { "M", "T", "W", "R", "F" }; 

            for(int i = 0; i < potentialDays.Length; i++) // since potentialDays.Length == Course.day.Length, and List has no Length member
            {
                if (returnedCourse.day[i]) returnedDays += potentialDays[i];
            }

            return returnedDays;
        }

        private string[] setRow(Course returnedCourse)
        {
            string[] row = new string[50]; // row buffer

            // These should really be getters
            row[0] = ""; // Leave this blank due to how ListViewItem() is constructed
            row[1] = returnedCourse.credits.ToString(); // placeholder
            row[2] = returnedCourse.courseCode;
            row[3] = returnedCourse.professor.Item1 + returnedCourse.professor.Item2;
            row[4] = returnedCourse.longName;
            row[5] = returnedCourse.time.Item1.ToString() + "-" + returnedCourse.time.Item2.ToString();
            row[6] = getDays(returnedCourse);
            row[7] = returnedCourse.enrollment.ToString() + "/" + returnedCourse.capacity.ToString();
            row[8] = "4.2"; // placeholder until Sprint 2
            row[9] = "low"; // placeholder ... 
            return row;
        }
        /***************************************************************************************/





        /*************************************adv search****************************************/
        private void advSearchBtn_Click(object sender, EventArgs e)
        {

            if (searchResult_UI.Location.Y == 131)
            {
                searchResult_UI.Location = new Point(99, 218);
                searchResult_UI.Height -= 87;
                filter_UI.Show();
            }
            else
            {
                filter_UI.Hide();
                searchResult_UI.Location = new Point(99, 131);
                searchResult_UI.Height += 87;
            }

        }
        /**************************************************************************************/



        /**************************************JSON Transfer (Sprint 2)***************************************/
        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog jsonImport = new OpenFileDialog();
            jsonImport.Filter = "JSON | *.json";
            jsonImport.Title = "Import a JSON file with a schedule that you or someone else has created";
           // if(jsonImport.ShowDialog() = DialogResult.OK)
            {

            }
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog jsonSave = new SaveFileDialog();
            jsonSave.Filter = "JSON | *.json";
            jsonSave.Title = "Save your schedule as a JSON file";
            jsonSave.ShowDialog();
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
