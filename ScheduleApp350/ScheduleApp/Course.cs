using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CourseInfoClass;

namespace CourseClass
{
    // HAL, HH = HOYT, PFAC = Pew Fine Arts, OFFCP = Study abroad, etc, PLC = Physical Learning cnter, RH = Rockwell, 
    // TBA = N/A, BAO = ???
    public enum Build { BAO, HAL, HH, OFFCP, PFAC, PLC, RH, RO, STEM, TBA, NONE };

    public struct Course
    {
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

        private Professor professor;

        private int credits;

        private int courseID;

        private string allInfo;

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

            this.allInfo = DB.getAllInfo(courseID);
        }

        public Course(List<string> parsedCourse, int courseID) // Constructor
        {
            allInfo = "";
            foreach (string index in parsedCourse)
            {
                allInfo += index + "\t";
            }

            allInfo += courseID;

            this.courseID = courseID;
            
            this.professor = new Professor(parsedCourse[11], parsedCourse[12]);

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
            if (Enum.TryParse(parsedCourse[6], out result)) { building = result; }//fix building loc
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

        public bool isFull() //returns true if the course is full
        {
            return capacity-enrollment <= 0;
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

        public string getProbability(Course x)
        {
            int probScore = 0;
            string caseRes = "";

            bool[] cases = {
                (x.getTime().Item1 > 8.00 && x.getTime().Item1 < 11.00),
                (x.getProf().rmp >= 3.5),
                (x.capacity - x.enrollment <= 3)
            };

            foreach(var caseItem in cases)
            {
                if (caseItem) probScore++;
            }

            switch (probScore)
            {
                case 0:
                    caseRes = "high";
                    break;
                case 1:
                    caseRes = "medium";
                    break;
                case 2:
                    caseRes = "low";
                    break;
                case 3:
                    caseRes = "low/none";
                    break;
                default:
                    caseRes = "low/none";
                    break;
            }

            return x.capacity - x.enrollment == 0 ? "low/none" : caseRes;
        }

        public Tuple<string, string> getTimeString()
        {
            if (time.Item1 == 0) return new Tuple<string,string>("",""); //No time is given
            int t1 = (int)time.Item1;
            int t2 = (int)Math.Round((time.Item1 % 1) * 100.0);
            int t3 = (int)time.Item2;
            int t4 = (int)Math.Round((time.Item2 % 1) * 100.0);
            
            return Tuple.Create(t1.ToString("00") + ":" + t2.ToString("00"), t3.ToString("00") + ":" + t4.ToString("00"));
        }

        public Professor getProf()   
        {
            return professor;
        }

        public int getCredits()   
        {
            return credits;
        }

        public string getAllInfo()
        {
            return allInfo;
        }
    };

    public struct Professor
    {
        public string first, last;
        public double rmp;

        public Professor(string first, string last)
        {
            this.first = first;
            this.last = last;
            this.rmp = 4.2;  // Default value 
        }
    }
}
