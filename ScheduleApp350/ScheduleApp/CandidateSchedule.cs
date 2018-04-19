using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseClass;
using CourseInfoClass;
using ScheduleApp;
using System.Windows.Forms;

namespace ScheduleApp
{
    public class CandidateSchedule
    {
        public List<Course> schedule;
        public CourseInfo DB;

        CandidateSchedule()
        {
            schedule = new List<Course>();
            DB = CourseInfo.Create();
        }

        /*
        CandidateSchedule(string filename) // factory constructor using JSON, sprint 2
        {

        }
        */

        public void add(Course c)
        {
            schedule.Add(c);
        }

        public List<int> addCourseByObject(Course c)
        {
            return addCourseByID(c.getCourseID());
        }


        public List<int> addCourseByID(int id)
        {
            List<int> additional = new List<int>();
            schedule.Add(new Course(id));
            for (int j = 0; j < 2; j++)
            {
                int i = id;
                while (DB.getCourseDept(i) == DB.getCourseDept(id) && DB.getCourseNum(i) == DB.getCourseNum(id))
                {
                    if (DB.getCourseSect(i).Contains(DB.getCourseSect(id)) ||
                        DB.getCourseSect(id).Contains(DB.getCourseSect(i)) ||
                        DB.getCourseSect(id).Contains("L") ||
                        DB.getCourseSect(id).Contains("M") ||
                        DB.getCourseSect(id).Contains("N") ||
                        DB.getCourseSect(id).Contains("O") ||
                        DB.getCourseSect(id).Contains("P") ||
                        DB.getCourseSect(id).Contains("Q"))
                        additional.Add(i);
                    if (j == 0) i++;
                    else i--;
                }
            }
            return additional;
            // For adding/removing courses, there may be an associated coourse/lab. 
            //Should ask user if they want to add/remove this as well. 
        }

        
        public bool removeCourse(int courseID)
        {
            return schedule.Remove(DB.getCourse(courseID));
        }

        public void removeAllCourses()
        {
            schedule.Clear();
        }

        public bool checkInSchedule(int courseID)
        {
            foreach (var course in schedule)
            {
                if (course.getCourseID() == courseID)
                {
                    return true;
                }
            }
            return false;
        }

        public bool scheduleFromFile() //creates the schedule from a json file, return true if successful
        {
            return false;
        }

        public bool scheduleToFile() //creates a json file from the schedule, return true if successful
        {

            return false;
        }
    }
}
