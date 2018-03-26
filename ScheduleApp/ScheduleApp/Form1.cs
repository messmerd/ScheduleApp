﻿using System;
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
        public AppWindow()
        {
            InitializeComponent();
        }

        /**********************Text Inside Search****************************************/
        private void searchBox_Enter(object sender, EventArgs e)
        {
            searchBox.Text = "";
        }

        private void searchBox_Leave(object sender, EventArgs e)
        {
            if (searchBox.Text == "")
            {
                searchBox.Text = "Search by course code or name...";
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
            search.searchForQuery(searchBox.Text);
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
            row[2] = c.getProf().Item1 + " " + c.getProf().Item2;
            row[3] = c.getLongName();
            row[4] = c.getTime().Item1.ToString() + "-" + c.getTime().Item2.ToString();
            row[5] = getDays(c);
            row[6] = c.getEnrollment().ToString() + "/" + c.getCapacity().ToString();
            row[7] = "4.2"; // placeholder until Sprint 2
            row[8] = "low"; // placeholder ... 
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
