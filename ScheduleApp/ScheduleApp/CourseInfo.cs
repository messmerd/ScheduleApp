using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;
using CourseClass;
using Excel = Microsoft.Office.Interop.Excel;       //Microsoft Excel 14 object in references-> COM tab

namespace CourseInfoClass
{
    public class CourseInfo
    {
        private static CourseInfo singleton;

        public static CourseInfo Create()
        {

            if (singleton == null)
            {
                singleton = new CourseInfo();
            }
            return singleton;

        }

        public static CourseInfo Create(string db_filename)
        {

            if (singleton == null)
            {
                singleton = new CourseInfo(db_filename);
            }
            return singleton;

        }


        private CourseInfo()
        {
             database = new List<Course>();
             prof_database = new List<Professor>();
             parseTextFile("course_database.txt");    // This function was causing the program to hang so it is commented out for now
        }

        private CourseInfo(string db_filename)
        {
            database = new List<Course>();
            prof_database = new List<Professor>();
            parseTextFile(db_filename);    // This function was causing the program to hang so it is commented out for now
        }

        public List<Course> database;
        public List<Professor> prof_database;
        private int numCourses;

        private void parseCSV()
        {
            string fileName = "course_database.xlsx";
            System.IO.FileInfo f = new System.IO.FileInfo(fileName);
            string fullname = f.FullName;
            Console.WriteLine("File('{0}') has path '{1}'", fileName, fullname);

            //https://coderwall.com/p/app3ya/read-excel-file-in-c

            //Create COM Objects. Create a COM object for everything that is referenced
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(fullname);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            Console.WriteLine("File('{0}') has path '{1}'", fileName, fullname);


            int rowCount = 762;
            int colCount = 13;
            numCourses = 0;

            //iterate over the rows and columns and print to the console as it appears in the file
            //excel is not zero based!!
            for (int i = 2; i <= rowCount; i++)//CourseCode	ShortTitle	LongTitle	BeginTime	EndTime	Meets	Building	Room	Enrollment	Capacity
            {
                List<string> parsedCourse = new List<string>();
                for (int j = 1; j <= colCount; j++)
                {
                    Console.WriteLine("i = {0}, j = {1}\n", i, j);
                    if (xlRange.Cells[i, j].Value2 != null)
                        parsedCourse.Add(xlRange.Cells[i, j].Value2.ToString());
                    else parsedCourse.Add("0");
                }
                Course nextCourse = new Course(parsedCourse, numCourses);
                database.Add(nextCourse);
                numCourses++;
            }
        
        }

        private void parseTextFile(string filename)
        {
            List<string> fileContents = new List<string>();
            try
            {
                fileContents = File.ReadAllLines(filename).ToList();
                fileContents.RemoveAt(0);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\n");
                return;
            }

            numCourses = fileContents.Count;
            int i = 0;
            foreach (string line in fileContents)  //CourseCode	ShortTitle	LongTitle	BeginTime	EndTime	Meets	Building	Room	Enrollment	Capacity
            {
                List<string> parsedCourse = new List<string>();
                parsedCourse = line.Split('\t').ToList();  // The text file is tab delimited 
                while (parsedCourse.Count < 13)
                {
                    parsedCourse.Add("0"); 
                }
                database.Add(new Course(parsedCourse, i));
                prof_database.Add(new Professor(parsedCourse[11], parsedCourse[12]));
                i++;
            }
        }

        public Course getCourse(int id)
        {
            return database[id]; 
        }

        public int getNumCourses()
        {
            return numCourses; 
        }

        public Build getBuilding(int id) 
        {
            return database[id].getBuilding();
        }

        public string getRoom(int id) 
        {
            return database[id].getRoom(); 
        }

        public string getCourseDept(int id)  
        {
            return database[id].getCourseDept();
        }

        public string getCourseNum(int id)  
        {
            return database[id].getCourseNum();
        }

        public string getCourseSect(int id)  
        {
            return database[id].getCourseSect(); 
        }

        public string getCourseCode(int id)   
        {
            return database[id].getCourseCode(); 
        }

        public string getShortName(int id)  
        {
            return database[id].getShortName();
        }

        public string getLongName(int id)  
        {
            return database[id].getLongName();
        }

        public int getEnrollment(int id)  
        {
            return database[id].getEnrollment();
        }

        public int getCapacity(int id)   
        {
            return database[id].getCapacity();
        }

        public List<bool> getDay(int id)  
        {
            return database[id].getDay();
        }

        public Tuple<double, double> getTime(int id)  
        {
            return database[id].getTime();
        }

        public Professor getProf(int id)  
        {
            return database[id].getProf();
        }

        public int getCredits(int id)  
        {
            return database[id].getCredits();
        }

    }

}
