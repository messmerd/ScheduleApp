using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ScheduleApp
{
    public class CandidateSchedule
    {
        public const string KEY_STRING = "SCHEDULING COURSES GCCMBAODMTF";

        public List<Course> schedule;                  // Stores all the courses in the user's schedule
        private List<Calendar.Appointment> m_Courses;  // Stores the calendar items 
        private CourseInfo DB;
        private int creditCount; //Current count of credits within user's schedule
        
        private static CandidateSchedule singleton;

        public static CandidateSchedule Create()
        {
            if (singleton == null)
            {
                singleton = new CandidateSchedule();
            }
            return singleton;
        }
     
        //builds an empty candidate schedule
        private CandidateSchedule()
        {
            schedule = new List<Course>();
            DB = CourseInfo.Create();
            creditCount = 0;
            m_Courses = new List<Calendar.Appointment>();
        }

        //adds a course to the candidate schedule based on course object,
        //along with any courses with the same course code
        public void addCourse(Course c)
        {
            if (schedule.Contains(c)) return;
            creditCount += c.getCredits();
            schedule.Add(c);
            
            int id = c.getCourseID();

            //adds courses with same name recursivly
            if ( id < DB.getNumCourses() - 1 && DB.getCourseCode(id + 1) == DB.getCourseCode(id))
            {
                addCourse(DB.getCourse(id + 1));
            }
            else if ( id > 0 && DB.getCourseCode(id - 1) == DB.getCourseCode(id))
            {
                addCourse(DB.getCourse(id - 1));
            }

            addToCalendar(id);
        }

        //adds a course to the candidate schedule based on course id
        public void addCourse(int id)
        
        {
            addCourse(DB.getCourse(id)); 
        }

        //removes the course with the given id along with all courses with the same course code
        //returns true if successful
        public bool removeCourse(int courseID)
        {
            List<int> toBeRemoved = new List<int>();
            foreach (var course in schedule)
            {
                //deals with items that have an ID greater than the max for the database
                if (courseID < DB.getNumCourses() && DB.getCourseCode(courseID) == course.getCourseCode())
                    toBeRemoved.Add(course.getCourseID());
                else if (courseID == course.getCourseID())
                    toBeRemoved.Add(course.getCourseID());
            }
            bool result = false;
            foreach (var allIDs in toBeRemoved) 
            {
                creditCount -= DB.getCredits(allIDs);

                m_Courses.RemoveAll(c => c.CourseID == allIDs);

                result = schedule.Remove(DB.getCourse(allIDs));
                updateConflictMarkers();
            }
            

            return result;
        }

        //removes all courses from the candidate schedule
        public void removeAllCourses()
        {
            creditCount = 0;
            schedule.Clear();
            m_Courses.Clear(); 
        }

        //returns true if the any course in the current candidate schedule has the given id
        public bool exists(int courseID)
        {
            foreach (var course in schedule)
            {
                if(course.getCourseID() == courseID) return true;
            }
            return false;
        }

        //Checks the total number of credits in the schedule. Returns -1 if there are too few credits, 0 if there are enough, and 1 if there are too many
        public int checkCreditCount()
        {
            int cred_status = creditCount < 12 ? -1 : 0;
            cred_status = creditCount > 17 ? 1 : cred_status;
            return cred_status; 
        }

        //creates the schedule from a json file, return true if successful
        public bool scheduleFromFile(string filepath) 
        {
            if(!File.Exists(filepath)) return false;
            string allCourses = System.IO.File.ReadAllText(filepath);

            if (!allCourses.StartsWith(KEY_STRING)) return false; //secondary check that file is correct type
            else allCourses = allCourses.Replace(KEY_STRING, null).Trim();
            
            List<string> listOfCourses = new List<string>(allCourses.Split('\n'));
            removeAllCourses(); //replaces current candidate schedule

            foreach (var course in listOfCourses)
            {
                List<string> importedCourse = new List<string>(course.Split('\t'));

                int id;
                if (Int32.TryParse(importedCourse[importedCourse.Count - 1], out id) &&
                    DB.getCourseCode(id) == System.Text.RegularExpressions.Regex.Replace(importedCourse[0], @"\s+", " ")) ;
                else continue;

                importedCourse.RemoveAt(importedCourse.Count - 1);
                addCourse(DB.getCourse(id));
                

                creditCount += DB.getCredits(id);
                checkCreditCount();
            }
            return true;
        }

        //creates a json file from the schedule, returns the string to write
        public string scheduleToFile() 
        {
            string file = KEY_STRING + "\n"; //marks first line for verifying file
            // Create a file to write to.
            foreach (var course in schedule)
            {
                file = file + course.getAllInfo() + "\n";
            }
            
            return file;
        }

        //returns a list of courses that conflict with the course with the given id, including itself
        public List<Course> checkTimeConflict(int id)
        {
            return checkTimeConflict(CourseInfo.Create().getCourse(id)); 
        }

        //returns a list of courses that conflict with the given course, including itself
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

            if (conflicts.Count != 0)
                conflicts.Add(c);    // Adds itself to the list of conflicting courses 

            return conflicts;
        }

        // This function adds a course to the Calendar UI
        private void addToCalendar(int id)
        {
            addToCalendar(DB.getCourse(id));
        }

        // This function adds a course to the Calendar UI
        private void addToCalendar(Course course)
        {
            Tuple<int, int, int, int> course_time = course.getTimeHourMinute();
            if (course_time.Item1 == -1 || !course.getDay().Contains(true))  // Course does not have a time or doesn't have a day
                return; 

            Calendar.Appointment m_course;

            for (int day = 0; day < 5; day++)
            {
                if (course.getDay()[day])
                {
                    m_course = new Calendar.Appointment();
                    m_course.StartDate = new DateTime(2010, 2, 1 + day, course_time.Item1, course_time.Item2, 0);
                    m_course.EndDate = new DateTime(2010, 2, 1 + day, course_time.Item3, course_time.Item4, 0);
                    m_course.Title = course.getCourseCode() + " " + course.getLongName();
                    m_course.CourseID = course.getCourseID();
                    m_course.Locked = true; 
                    m_Courses.Add(m_course);

                }
            }

            updateConflictMarkers();
        }

        // Looks at all the courses in the schedule and marks conflicting courses in the calendar red and non-conflicting courses white
        private void updateConflictMarkers()
        {
            foreach (var c1 in m_Courses)
            {
                
                if (checkTimeConflict(c1.CourseID).Count > 1)
                {
                    c1.Color = System.Drawing.Color.Red;
                }
                else
                {
                    c1.Color = System.Drawing.Color.White; 
                }
            }         
        }
        // getter for creditCount
        public int getCreditCount()
        {
            return creditCount; 
        }
        //getter for m_Courses
        public List<Calendar.Appointment> getCalendarItems()
        {
            return m_Courses; 
        }
        //getter for schedule
        public List<Course> getCourses()
        {
            return schedule; 
        }

    }
}
