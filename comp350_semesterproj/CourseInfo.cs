using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace comp350_semesterproj
{
    class CourseInfo
    {
        List<Course> database;

        public void parseCSV()
        {
            while (false)
            {//CourseCode	ShortTitle	LongTitle	BeginTime	EndTime	Meets	Building	Room	Enrollment	Capacity
                Course nextCourse;
                

                Build result;  //BAO, HAL, HH, OFFCP, PFAC, PLC, RH, RO, STEM, TBD, NONE
                if (Enum.TryParse(myname, out result)) nextCourse.building = result;
                else nextCourse.building = Build.NONE;
                database.Add(nextCourse);
            }
        }
    }
}
