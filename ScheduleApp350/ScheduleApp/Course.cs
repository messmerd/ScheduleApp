using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScheduleApp
{
    // HAL, HH = HOYT, PFAC = Pew Fine Arts, OFFCP = Study abroad, etc, PLC = Physical Learning cnter, RH = Rockwell, 
    // TBA = N/A, BAO = ???
    public enum Build { NONE, BAO, HAL, HH, OFFCP, PFAC, PLC, RH, RO, STEM, TBA };

    // This class contains all information about a specific course after it is parsed from courseinfo
    public struct Course
    {
        #region Member variables 
        private Build building;
        private string room;

        private string courseDept;
        private string courseNum;
        private string courseSect;
        private string courseCode; // = courseDept + courseNum.toString();

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
        #endregion 

        // Constructor that uses a course id
        public Course(int courseID)  
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

        // Constructor that uses data parsed from the database file to create a course instance. This is used in the CourseInfo class
        public Course(List<string> parsedCourse, int courseID, double rmp) 
        {
            this.allInfo = System.Text.RegularExpressions.Regex.Replace(string.Join("\t", parsedCourse.ToArray()) + "\t" + courseID.ToString(), @" +", " "); 
 
            this.courseID = courseID;
            
            this.professor = new Professor(parsedCourse[11], parsedCourse[12], rmp);

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
                start = t1 + (double)t2 / 100.0;
            }
            else start = -1.0;
            

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
                stop = t1 + (double)t2 / 100.0;
            }
            else stop = -1.0;
            
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
            parsedCourse[0] = System.Text.RegularExpressions.Regex.Replace(parsedCourse[0], @"\s+", " ");
            courseDept = parsedCourse[0].Split(null, 3)[0];
            courseNum = parsedCourse[0].Split(null, 3)[1];
            courseSect = parsedCourse[0].Split(null, 3)[2];
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

        #region Various getters 
        //returns true if the course is full
        public bool isFull() 
        {
            return capacity-enrollment <= 0;
        }

        // Getter for courseID, Note: courseID is NOT the same as courseCode
        public int getCourseID()   
        {
            return courseID;
        }

        //Getter for building
        public Build getBuilding()   
        {
            return building;
        }

        //Getter for room
        public string getRoom()   
        {
            return room;
        }

        //getter for courseDept
        public string getCourseDept()   
        {
            return courseDept;
        }

        //getter for courseNum
        public string getCourseNum()   
        {
            return courseNum;
        }

        //getter for courseSect
        public string getCourseSect()   
        {
            return courseSect;
        }

        //getter for courseCode
        public string getCourseCode()   
        {
            return courseCode;
        }

        //getter for shortName
        public string getShortName()   
        {
            return shortName;
        }

        //getter for longName
        public string getLongName()   
        {
            return longName;
        }

        //getter for enrollment
        public int getEnrollment()   
        {
            return enrollment;
        }

        //getter for capacity
        public int getCapacity()  
        {
            return capacity;
        }

        //getter for day
        public List<bool> getDay()  
        {
            return day;
        }

        //getter for time
        public Tuple<double, double> getTime()   
        {
            return time;
        }

        //returns the string equivalent of getProbabilityInt
        public string getProbability()  
        {
            switch (getProbabilityInt())
            {
                case 0:
                    return "high";
                case 1:
                    return "medium";
                case 2:
                    return "low";
                case 3:
                    return "low";
                default: // It should never activate this case, but we put it in to account for corner cases
                    return "low";
            }
        }

        
        //calculates and returns the probability of a student being able to get into a course using a heuristic 
        // Returns a 0, 1, 2, or 3. 0 is high probability, 3 is low.
        public int getProbabilityInt()  
        {
            int probScore = 0;

            bool[] cases = {
                (this.getTime().Item1 > 8.00 && this.getTime().Item1 < 11.00),
                (this.getProf().rmp >= 3.5),
                (this.capacity - this.enrollment <= 3)
            };

            foreach (var caseItem in cases)
            {
                if (caseItem) probScore++;
            }

            // If the class is full, it has a default probability of low, otherwise we return our calculated score
            return this.capacity - this.enrollment == 0 ? 3 : probScore;
        }

        //returns time as a tuple of strings
        public Tuple<string, string> getTimeString()   
        {
            Tuple<int, int, int, int> temp = getTimeHourMinute();
            if (temp.Item1 == -1.0) return new Tuple<string,string>("",""); //No time is given
            return Tuple.Create(temp.Item1.ToString("00") + ":" + temp.Item2.ToString("00"), temp.Item3.ToString("00") + ":" + temp.Item4.ToString("00"));
        }

        //returns time as a tuple of ints
        public Tuple<int, int, int, int> getTimeHourMinute() 
        {
            if (time.Item1 == -1.0) return new Tuple<int,int,int,int>(-1, -1, -1, -1); //No time is given
            int t1 = (int)time.Item1;
            int t2 = (int)Math.Round((time.Item1 % 1) * 100.0);
            int t3 = (int)time.
                Item2;
            int t4 = (int)Math.Round((time.Item2 % 1) * 100.0);

            return Tuple.Create(t1, t2, t3, t4);
        }

        //getter for professor
        public Professor getProf()   
        {
            return professor;
        }

        //getter for credits
        public int getCredits()   
        {
            return credits;
        }

        //getter for allInfo
        public string getAllInfo()  
        {
            return allInfo;
        }

        //getter for RMPScore
        public double getRMPScore() 
        {
            return professor.rmp;
        }
        #endregion

    };

    // This stores information about a professor
    public struct Professor //struct for the professor object
    {
        public string first, last;
        public double rmp;

        //constructor for professor
        public Professor(string first, string last, double rmp)
        {
            this.first = first;
            this.last = last;
            this.rmp = rmp;
        }
    }
}
