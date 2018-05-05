using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;

namespace ScheduleApp
{
    // This class is used as a common database for all course and professor information. It is a singleton
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

        public static CourseInfo Create(string db_filename, string rmp_filename)
        {

            if (singleton == null)
            {
                singleton = new CourseInfo(db_filename, rmp_filename);
            }
            return singleton;

        }

        // default constructor
        private CourseInfo()
        {
             database = new List<Course>();
             prof_database = new List<Professor>();
             parseTextFile("course_database.txt", "rmp_database.txt");    
        }

        //construtor based on a given database filename
        private CourseInfo(string course_filename, string rmp_filename)
        {
            database = new List<Course>();
            prof_database = new List<Professor>();
            parseTextFile(course_filename, rmp_filename);  
        }

        private List<Course> database;           // Database of all the courses 
        private List<Professor> prof_database;   // Database of all the professors                  
         
        //function that parses the database file (if it is .txt) and stores it
        private void parseTextFile(string course_filename, string rmp_filename)
        {
            // Get all course info lines, store each line as an element in a list
            List<string> fileContents = new List<string>();
            try
            {
                fileContents = File.ReadAllLines(course_filename).ToList();
                fileContents.RemoveAt(0);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\n");
                return;
            }

            // Get RMP data from the rmp_database.txt, store each line as an element in a list
            // database created with a python script that scraped and parsed html from grove city college on the rmp website
            List<string> rmp_data = new List<string>();
            try
            {
                rmp_data = File.ReadAllLines(rmp_filename).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\n");
                return;
            }

            int i = 0;

            double rmp = 3.8; // default value, the RMP average. Only assigned if professor does not exist on ratemyprofessors.com

            foreach (string line in fileContents)  // CourseCode	ShortTitle	LongTitle	BeginTime	EndTime	Meets	Building	Room	Enrollment	Capacity
            {
                List<string> parsedCourse = new List<string>();
                parsedCourse = line.Split('\t').ToList();  // The text file is tab delimited 
                while (parsedCourse.Count < 13) // go through each attribute
                {
                    parsedCourse.Add("0"); 
                }

                // Don't add duplicate professors or empty strings:
                if (!prof_database.Any(x => x.first == parsedCourse[11] && x.last == parsedCourse[12]))
                {
                    if (parsedCourse[11] != "" && parsedCourse[12] != "")
                    {
                        foreach (var dataline in rmp_data) // each professor triple (lastname firstname rmpscore)
                        {
                            if (dataline.Split()[0] == parsedCourse[12] && dataline.Split()[1] == parsedCourse[11]) // if it is equal to the professor in the database
                            {
                                if (Double.TryParse(dataline.Split()[2], out rmp))
                                {
                                    rmp = Double.Parse(dataline.Split()[2]); // extract that rmp score
                                }
                            }
                        }
                    }
                    prof_database.Add(new Professor(parsedCourse[11], parsedCourse[12], rmp)); // initialize that professor with that rmp score
                }
                else
                {
                    rmp = prof_database.Find(x => x.first == parsedCourse[11] && x.last == parsedCourse[12]).rmp; 
                }

                // add the parsed course to the database
                database.Add(new Course(parsedCourse, i, rmp));
                
                i++;
            }
            prof_database = prof_database.OrderBy(x => x.last).ToList();
        }

        #region Various getters
        public Course getCourse(int id)
        {
            return database[id]; 
        }

        public int getNumCourses()
        {
            return database.Count; 
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

        public string getAllInfo(int id)
        {
            return database[id].getAllInfo();
        }

        public int getNumProfs()
        {
            return prof_database.Count; 
        }

        public Professor getProfInDatabase(int prof_id)
        {
            return prof_database[prof_id];
        }

        #endregion

    }

}
