using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourseClass
{
    public enum Build { BAO, HAL, HH, OFFCP, PFAC, PLC, RH, RO, STEM, TBD, NONE };

    public struct Course
    {
        public Build building;
        public int room;

        public string courseDept;
        public int courseNum;
        public char courseSect;
        public string courseCode;// = courseDept + courseNum.toString();

        public string shortName;
        public string longName;

        public int enrollment;
        public int capacity;

        public List<Tuple<double, double>> time;

        public Tuple<string, string> professor;


        private int courseID;
        private string courseName;
        // Other attributes of the course go here

        public Course(int courseID)  // Constructor
        {
            this.courseID = courseID;
            //  ... (other Class attributes to be set here)
            this.courseName = "<course name>";  // Temporary, of course
                                                // We need to have a Course Database class that contains a function (a factory?) which helps create Course structs from course IDs. 
            this.professor = Tuple.Create<string, string>(null, null);

            this.time = new List<Tuple<double, double>> {
                Tuple.Create<double, double>(0, 0),
                Tuple.Create<double, double>(0, 0),
                Tuple.Create<double, double>(0, 0),
                Tuple.Create<double, double>(0, 0),
                Tuple.Create<double, double>(0, 0)
            };

            this.building = Build.NONE;
            this.room = 0;

            courseDept = "";
            courseNum = 0;
            courseSect = 'A';
            courseCode = courseDept + " " + courseNum + " " + courseSect;

            shortName = "";
            longName = "";

            enrollment = 0;
            capacity = 0;
        }

        public string getCourseName()
        {
            return courseName;
        }

        public int getCourseID()  // Note: courseID is NOT the same as courseCode 
        {
            return courseID;
        }
    };
}
