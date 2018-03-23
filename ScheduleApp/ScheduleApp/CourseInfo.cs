using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CourseClass;
using Excel = Microsoft.Office.Interop.Excel;       //Microsoft Excel 14 object in references-> COM tab

namespace CourseInfoClass
{
    public class CourseInfo
    {
        private static CourseInfo singleton;

        public static CourseInfo DB
         {
            get 
            {
                if (singleton == null)
                {
                    singleton = new CourseInfo();
                }
                return singleton;
            }
         }

        private CourseInfo()
         {
             database = new List<Course>();
             //parseCSV();    // This function was causing the program to hang so it is commented out for now
         }

        public List<Course> database;

        private void parseCSV()
        {
            //https://coderwall.com/p/app3ya/read-excel-file-in-c
            
            //Create COM Objects. Create a COM object for everything that is referenced
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"sandbox_test.xlsx");
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = 762;
            int colCount = 13;

            //iterate over the rows and columns and print to the console as it appears in the file
            //excel is not zero based!!
            for (int i = 2; i <= rowCount; i++)//CourseCode	ShortTitle	LongTitle	BeginTime	EndTime	Meets	Building	Room	Enrollment	Capacity
            {
                List<string> parsedCourse = new List<string>();
                for (int j = 1; j <= colCount; j++)
                {
                    parsedCourse.Add(xlRange.Cells[i, j].Value2.ToString());   
                }
                Course nextCourse = new Course(parsedCourse);
                database.Add(nextCourse);
            }
        }

        public void Create()
        {
            // Doesn't have to do anything 
        }

        public int getNumCourses()
        {
            return 761; 
        }

    }
}
