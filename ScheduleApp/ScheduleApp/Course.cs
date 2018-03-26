using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CourseInfoClass;

namespace CourseClass
{
    public enum Build { BAO, HAL, HH, OFFCP, PFAC, PLC, RH, RO, STEM, TBD, NONE };

    public struct Course
    {

        // TODO: Write Getters for members used in searchBtn event handler
        private Build building;
        private string room;

        private string courseDept;
        private string courseNum;
        private string courseSect;
        private string courseCode;// = courseDept + courseNum.toString();

        private string shortName;
        private string longName;

        private int enrollment;
        private int capacity;

        private List<bool> day;
        private Tuple<double, double> time;

        private Tuple<string, string> professor;

        private int credits;

        private int courseID;

        public Course(int courseID)  // Constructor
        {
            CourseInfo DB = CourseInfo.Create();
            this.courseID = courseID;
            this.professor = DB.getProf(courseID);

            this.time = DB.getTime(courseID);
            this.day = DB.getDay(courseID); 
            
            this.building = DB.getBuilding(courseID);
            this.room = DB.getRoom(courseID);

            this.courseDept = DB.getCourseDept(courseID);
            this.courseNum = DB.getCourseNum(courseID);
            this.courseSect = DB.getCourseSect(courseID);
            this.courseCode = DB.getCourseCode(courseID);

            this.shortName = DB.getShortName(courseID);
            this.longName = DB.getLongName(courseID);

            this.enrollment = DB.getEnrollment(courseID);
            this.capacity = DB.getCapacity(courseID);

            this.credits = DB.getCredits(courseID);
        }

        public Course(List<string> parsedCourse, int courseID) // Constructor
        {
            this.courseID = courseID;
            
            this.professor = Tuple.Create<string, string>(parsedCourse[11], parsedCourse[12]);

            //parsedCourse[3], parsedCourse[4]
            //s.Split(':')[3]
            int j, t1, t2;
            string s1, s2;
            double start, stop;

            if (parsedCourse[3].Contains(":"))
            {
                s1 = parsedCourse[3].Split(':')[0];
                s2 = parsedCourse[3].Split(':')[1];
                if (Int32.TryParse(s1, out j))
                    t1 = j;
                else
                    t1 = 0;
                if (Int32.TryParse(s2, out j))
                    t2 = j;
                else
                    t2 = 0;
            }
            else t1 = t2 = 0;
            start = t1 + (double)t2 / 100.0;

            if (parsedCourse[4].Contains(":"))
            {
                s1 = parsedCourse[4].Split(':')[0];
                s2 = parsedCourse[4].Split(':')[1];
                if (Int32.TryParse(s1, out j))
                    t1 = j;
                else
                    t1 = 0;
                if (Int32.TryParse(s2, out j))
                    t2 = j;
                else
                    t2 = 0;
            }
            else t1 = t2 = 0;
            stop = t1 + (double)t2 / 100.0;

            this.time = Tuple.Create<double, double>(start, stop);
            this.day = new List<bool>
            {
                parsedCourse[5].Contains("M"),
                parsedCourse[5].Contains("T"),
                parsedCourse[5].Contains("W"),
                parsedCourse[5].Contains("R"),
                parsedCourse[5].Contains("F")
            };

            Build result;//BAO, HAL, HH, OFFCP, PFAC, PLC, RH, RO, STEM, TBD, NONE
            if (Enum.TryParse(parsedCourse[5], out result)) { building = result; }//fix building loc
            else { building = Build.NONE; }
            this.room = parsedCourse[7];

            // parsedCourse[0]
            courseDept = System.Text.RegularExpressions.Regex.Split(parsedCourse[0], @"\s+")[0];
            courseNum = System.Text.RegularExpressions.Regex.Split(parsedCourse[0], @"\s+")[1];
            courseSect = System.Text.RegularExpressions.Regex.Split(parsedCourse[0], @"\s+")[2];
            courseCode = courseDept + " " + courseNum + " " + courseSect;

            shortName = parsedCourse[1];
            longName = parsedCourse[2];

            if (Int32.TryParse(parsedCourse[8], out j))
                enrollment = j;
            else
                enrollment = 0;
            if (Int32.TryParse(parsedCourse[9], out j))
                capacity = j;
            else
                capacity = 0;

            if (Int32.TryParse(parsedCourse[10], out j))
                credits = j;
            else
                credits = 0;
        }

        public int getCourseID()  // Note: courseID is NOT the same as courseCode 
        {
            return courseID;
        }

        public Build getBuilding()   
        {
            return building;
        }

        public string getRoom()   
        {
            return room;
        }

        public string getCourseDept()   
        {
            return courseDept;
        }

        public string getCourseNum()   
        {
            return courseNum;
        }

        public string getCourseSect()   
        {
            return courseSect;
        }

        public string getCourseCode()   
        {
            return courseCode;
        }

        public string getShortName()   
        {
            return shortName;
        }

        public string getLongName()   
        {
            return longName;
        }

        public int getEnrollment()   
        {
            return enrollment;
        }

        public int getCapacity()  
        {
            return capacity;
        }

        public List<bool> getDay()  
        {
            return day;
        }

        public Tuple<double, double> getTime()   
        {
            return time;
        }

        public Tuple<string, string> getTimeString()
        {
            if (time.Item1 == 0) return null;//No time is given
            int t1 = (int)time.Item1;
            int t2 = (int)((time.Item1%1)*100.0);
            int t3 = (int)time.Item2;
            int t4 = (int)((time.Item2 % 1) * 100.0);
            
            return Tuple.Create(t1 + ":" + t2, t3 + ":" + t4);
        }

        public Tuple<string, string> getProf()   
        {
            return professor;
        }

        public int getCredits()   
        {
            return credits;
        }
    };
}
