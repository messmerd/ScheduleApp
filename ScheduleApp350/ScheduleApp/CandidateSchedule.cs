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
        public int creditCount; //current count of credits within user's schedule
        public int creditSituation; //reports if schedule is less than 12 (-1), 12 to 17 (0), or greater than 17 (1)

        CandidateSchedule()
        {
            schedule = new List<Course>();
            DB = CourseInfo.Create();
            creditCount = 0;
            creditSituation = -1;
        }

        /*
        CandidateSchedule(string filename) // factory constructor using JSON, sprint 2
        {

        }
        */

        public void add(Course c)
        {
            schedule.Add(c);
            creditCount += c.getCredits();
            checkCreditCount();
        }

        public List<int> addCourseByObject(Course c)
        {
            creditCount += c.getCredits();
            checkCreditCount();
            return addCourseByID(c.getCourseID());
        }


        public List<int> addCourseByID(int id) //implement credit counting
        {
            List<int> additional = new List<int>();
            creditCount += DB.getCredits(id);
            checkCreditCount();
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
            creditCount -= DB.getCredits(courseID);
            checkCreditCount();
            return schedule.Remove(DB.getCourse(courseID));
        }

        public void removeAllCourses()
        {
            creditCount = 0;
            checkCreditCount();
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

<<<<<<< HEAD
        public void checkCreditCount() //for checking the current credit count. makes creditSituation -1 if less than 12 credits,
        //0 if 12 to 17 (range with no warning), and 1 if greater than 17 credits.
        {
            if (creditCount < 12)
            {
                creditSituation = -1;
            }
            else if (creditCount > 17)
            {
                creditSituation = 1;
            }
            else
            {
                creditSituation = 0;
            }
=======
        public bool scheduleFromFile() //creates the schedule from a json file, return true if successful
        {
            return false;
        }

        public bool scheduleToFile() //creates a json file from the schedule, return true if successful
        {

            return false;
>>>>>>> 618dac6cfbe90a530d195df601aa9c66f86da2f0
        }
    }
}
