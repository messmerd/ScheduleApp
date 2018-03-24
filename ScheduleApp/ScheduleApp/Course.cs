using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourseClass
{
    public enum Build { BAO, HAL, HH, OFFCP, PFAC, PLC, RH, RO, STEM, TBD, NONE };

    public struct Course
    {

        // TODO: Write Getters for members used in searchBtn event handler
        public Build building;
        public string room;

        public string courseDept;
        public string courseNum;
        public string courseSect;
        public string courseCode;// = courseDept + courseNum.toString();

        public string shortName;
        public string longName;

        public int enrollment;
        public int capacity;

        public List<bool> day;
        public Tuple<double, double> time;

        public Tuple<string, string> professor;

        public int credits;

        private int courseID;

        public Course(int courseID)  // Constructor
        {
            this.courseID = courseID;

            this.professor = Tuple.Create<string, string>(null, null);

            this.time = Tuple.Create<double, double>(0, 0);
            this.day = new List<bool>
            {
                false,
                false,
                false,
                false,
                false
            };

            this.building = Build.NONE;
            this.room = "0";

            courseDept = "";
            courseNum = "0";
            courseSect = "A";
            courseCode = courseDept + " " + courseNum + " " + courseSect;

            shortName = "";
            longName = "";

            enrollment = 0;
            capacity = 0;

            credits = 0;
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

            start = t1 + (double)t2 / 100.0;

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

            shortName = parsedCourse[2];
            longName = parsedCourse[3];

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

        public Build getBuilding()  // Note: courseID is NOT the same as courseCode 
        {
            return building;
        }

        public string getRoom()  // Note: courseID is NOT the same as courseCode 
        {
            return room;
        }

        public string getCourseDept()  // Note: courseID is NOT the same as courseCode 
        {
            return courseDept;
        }

        public string getCourseNum()  // Note: courseID is NOT the same as courseCode 
        {
            return courseNum;
        }

        public string getCourseSect()  // Note: courseID is NOT the same as courseCode 
        {
            return courseSect;
        }

        public string getCourseCode()  // Note: courseID is NOT the same as courseCode 
        {
            return courseCode;
        }

        public string getShortName()  // Note: courseID is NOT the same as courseCode 
        {
            return shortName;
        }

        public string getLongName()  // Note: courseID is NOT the same as courseCode 
        {
            return longName;
        }

        public int getEnrollment()  // Note: courseID is NOT the same as courseCode 
        {
            return enrollment;
        }

        public int getCapacity()  // Note: courseID is NOT the same as courseCode 
        {
            return capacity;
        }

        public List<bool> getDay()  // Note: courseID is NOT the same as courseCode 
        {
            return day;
        }

        public Tuple<double, double> getTime()  // Note: courseID is NOT the same as courseCode 
        {
            return time;
        }

        public Tuple<string, string> getProf()  // Note: courseID is NOT the same as courseCode 
        {
            return professor;
        }

        public int getCredits()  // Note: courseID is NOT the same as courseCode 
        {
            return credits;
        }
    };
}
