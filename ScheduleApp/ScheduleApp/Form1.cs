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

        private void searchBtn_Click(object sender, EventArgs e)
        {

            //Search search = new Search("course_dictionary.txt");
            //search.searchForQuery(searchBox.Text);
            //List<Course> searchResults = search.lastSearchResults.getCourses();

            /*
            string[] row = new string[20];
            foreach (var item in searchResults)
                row[0] = "3", item.courseCode, "Dr. Foo", longName, time[0].Item1 + "-" + time[0].Item2, "MWF", enrollment.toString() + "/" + capacity.toString(), "low"};
                row[0] = 
                row[0]
                row[0]
                row[0]
                row[0]
                row[0]
                row[0]
                row[0]
                var listViewItem = new ListViewItem(row);
                searchResult_UI.Items.Add(listViewItem);
            }
            */
            /*
            string[] row = new string[9];
            for (var i = 0; i < 9; i++)
            {
                row[i] = i.ToString();
            }
            var listViewItem = new ListViewItem(row);
            searchResult_UI.Items.Add(listViewItem);
            */



        }

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

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog jsonImport = new OpenFileDialog();
            jsonImport.Filter = "JSON | *.json";
            jsonImport.Title = "Import a JSON file with a schedule that you or someone else has created";
            if(jsonImport.ShowDialog() = DialogResult.OK)
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            Application.Exit();
        }
    }
}
