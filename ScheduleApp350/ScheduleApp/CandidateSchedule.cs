using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseClass;
using CourseInfoClass;
using ScheduleApp;
using System.Windows.Forms;
using System.IO;

namespace ScheduleApp
{
    public class CandidateSchedule
    {
        public List<Course> schedule;
        public List<Calendar.Appointment> m_Courses;
        public CourseInfo DB;
        public int creditCount; //current count of credits within user's schedule
        public int creditSituation; //reports if schedule is less than 12 (-1), 12 to 17 (0), or greater than 17 (1)

        private static CandidateSchedule singleton;

        public static CandidateSchedule Create()
        {
            if (singleton == null)
            {
                singleton = new CandidateSchedule();
            }
            return singleton;
        }
     

        private CandidateSchedule()
        {
            schedule = new List<Course>();
            DB = CourseInfo.Create();
            creditCount = 0;
            creditSituation = -1;
            m_Courses = new List<Calendar.Appointment>();
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

        public List<int> addCourse(Course c)
        {
            List<int> additional = new List<int>();
            creditCount += c.getCredits();
            checkCreditCount();
            schedule.Add(c);
            int id = c.getCourseID();

            // This loop is untested. I don't think it would work as intended 
            for (int j = 0; j < 2; j++)
            {
                int i = id;
                while (i > 0 && i < DB.getNumCourses() && DB.getCourseDept(i) == c.getCourseDept() && DB.getCourseNum(i) == c.getCourseNum())
                {
                    if (DB.getCourseSect(i).Contains(c.getCourseSect()) ||
                        c.getCourseSect().Contains(DB.getCourseSect(i)) ||
                        c.getCourseSect().Contains("L") ||
                        c.getCourseSect().Contains("M") ||
                        c.getCourseSect().Contains("N") ||
                        c.getCourseSect().Contains("O") ||
                        c.getCourseSect().Contains("P") ||
                        c.getCourseSect().Contains("Q"))
                        additional.Add(i);
                    if (j == 0)
                        i++;
                    else
                        i--;
                }
            }

            //bool timeConflict = checkTimeConflict(id);
            bool timeConflict = checkTimeConflict(c).Count > 1;
            addToCalendar(id, timeConflict);

            return additional;
            // For adding/removing courses, there may be an associated coourse/lab. 
            //Should ask user if they want to add/remove this as well. 
        }

        public List<int> addCourse(int id) //implement credit counting
        {
            return addCourse(DB.getCourse(id));  
        }

        
        public bool removeCourse(int courseID)
        {
            creditCount -= DB.getCredits(courseID);
            checkCreditCount();

            m_Courses.RemoveAll(c => c.Title.Contains(DB.getCourseCode(courseID)));

            return schedule.Remove(DB.getCourse(courseID));
        }

        public void removeAllCourses()
        {
            creditCount = 0;
            checkCreditCount();
            schedule.Clear();
            m_Courses.Clear(); 
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

        public void checkCreditCount()
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
        }

        public bool scheduleFromFile(string filename) //creates the schedule from a json file, return true if successful
        {
            if(!File.Exists(filename)) return false;
            string json = System.IO.File.ReadAllText(filename);

            return false;
        }

        public bool scheduleToFile(string filename) //creates a json file from the schedule, return true if successful
        {
            //TODO:
            //convert course to a single string w/ all info, one course per line
            
            //string json = JsonConvert.SerializeObject(objOrArray);
            //File.WriteAllText(filename, json);

            return false;
        }

        public bool checkTimeConflict_old(int id)
        {
            return checkTimeConflict_old(CourseInfo.Create().getCourse(id));
        }

        public bool checkTimeConflict_old(Course obj)
        {
            foreach (Course index in schedule)
            {
                if (index.getCourseID() == obj.getCourseID()) continue;
                for (int i = 0; i < index.getDay().Count; i++)
                {
                    if (!index.getDay()[i] && !obj.getDay()[i]) continue;
                    if (((index.getTime().Item1 >= obj.getTime().Item1 &&
                        index.getTime().Item1 <= obj.getTime().Item2) ||
                        (index.getTime().Item2 >= obj.getTime().Item1 &&
                        index.getTime().Item2 <= obj.getTime().Item2)) ||

                        ((obj.getTime().Item1 >= index.getTime().Item1 &&
                        obj.getTime().Item1 <= index.getTime().Item2) ||
                        (obj.getTime().Item2 >= index.getTime().Item1 &&
                        obj.getTime().Item2 <= index.getTime().Item2))) return true;
                }
            }
            return false;
        }


        public List<Course> checkTimeConflict(int id)
        {
            return checkTimeConflict(CourseInfo.Create().getCourse(id)); 
        }

        public List<Course> checkTimeConflict(Course c)
        {
            List<Course> conflicts = new List<Course>();
            if (c.getTime().Item1 == -1.0)
                return conflicts;
            foreach (Course course in schedule)
            {
                if (course.getCourseID() == c.getCourseID() || course.getTime().Item1 == -1.0) continue;
                for (int i = 0; i < 5; i++)
                {
                    if (c.getDay()[i] && course.getDay()[i] && c.getTime().Item1 <= course.getTime().Item2 && c.getTime().Item2 >= course.getTime().Item1)
                        conflicts.Add(course);
                }
            }
            return conflicts;
        }

        void addToCalendar(int id, bool conflict)
        {
            // This function adds a course to the Calendar UI 
            
            Tuple<int, int, int, int> course_time = DB.getCourse(id).getTimeHourMinute();
            if (course_time.Item1 == -1 || !DB.getDay(id).Contains(true))  // Course does not have a time or doesn't have a day
                return; 

            Calendar.Appointment m_course;

            for (int day = 0; day < 5; day++)
            {
                if (DB.getDay(id)[day])
                {
                    m_course = new Calendar.Appointment();
                    m_course.StartDate = new DateTime(2010, 2, 1 + day, course_time.Item1, course_time.Item2, 0);
                    m_course.EndDate = new DateTime(2010, 2, 1 + day, course_time.Item3, course_time.Item4, 0);
                    m_course.Title = DB.getCourse(id).getCourseCode() + " " + DB.getCourse(id).getLongName();
                    
                    if (conflict)
                        m_course.Color = System.Drawing.Color.Red;
                    else
                        m_course.Color = System.Drawing.Color.White;

                    m_Courses.Add(m_course);

                }
            }

            
        }


    }
}
