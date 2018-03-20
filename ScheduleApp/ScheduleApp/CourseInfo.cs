using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CourseClass;

namespace CourseInfoClass
{
    public class CourseInfo
    {
        List<Course> database;

        void parseCSV()
        {
            string parsedIn;
            while (false)
            {//CourseCode	ShortTitle	LongTitle	BeginTime	EndTime	Meets	Building	Room	Enrollment	Capacity
                Course nextCourse;
                

                Build result;  //BAO, HAL, HH, OFFCP, PFAC, PLC, RH, RO, STEM, TBD, NONE
                if (Enum.TryParse(parsedIn, out result)) { nextCourse.building = result; }
                else { nextCourse.building = Build.NONE; }
                database.Add(nextCourse);
            }
        }
    }
}
