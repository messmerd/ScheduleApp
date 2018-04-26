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
        public const string KEY_STRING = "SCHEDULING COURSES GCCMBAODMTF\n";

        public int cred_total; //current count of credits within user's schedule
        public int cred_statis; //reports if schedule is less than 12 (-1), 12 to 17 (0), or greater than 17 (1)
        public List<Course> schedule;
        public List<Calendar.Appointment> m_Courses;
        public CourseInfo DB;
        public int creditCount { get; set; } //current count of credits within user's schedule
        public int creditSituation { get; set; } //reports if schedule is less than 12 (-1), 12 to 17 (0), or greater than 17 (1)

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
            cred_total = 0;
            cred_statis = -1;
            m_Courses = new List<Calendar.Appointment>();
        }
        /*
        CandidateSchedule(string filename) // factory constructor using JSON, sprint 2
        {

        }
        */

        public void add_ob(Course c)
        //adds a course to the candidate schedule based on course object,
        //along with any courses with the same course code
        {
            if (schedule.Contains(c)) return;
            cred_total += c.getCredits();
            checkCreditCount();
            schedule.Add(c);
            
            int id = c.getCourseID();
            //adds courses with same name recursivly
            if ( id < DB.getNumCourses() - 1 && DB.getCourseCode(id + 1) == DB.getCourseCode(id))
            {
                add_ob(DB.getCourse(id + 1));
            }
            else if ( id > 0 && DB.getCourseCode(id - 1) == DB.getCourseCode(id))
            {
                add_ob(DB.getCourse(id - 1));
            }

            //bool timeConflict = checkTimeConflict(id);
            List<Course> timeConflicts = checkTimeConflict(c);
            if (timeConflicts.Count > 1)  // There's at least one time conflict 
            {
                // Alert the user here, or something 
            }

            addToCalendar(id);
        }

        public void add_id(int id)
        //adds a course to the candidate schedule based on course id
        {
            add_ob(DB.getCourse(id)); 
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
                cred_total -= DB.getCredits(allIDs);
                checkCreditCount();

                m_Courses.RemoveAll(c => c.CourseID == allIDs);

                result = schedule.Remove(DB.getCourse(allIDs));
                updateConflictMarkers();
            }
            

            return result;
        }

        //removes all courses from the candidate schedule
        public void removeAllCourses()
        {
            cred_total = 0;
            checkCreditCount();
            schedule.Clear();
            m_Courses.Clear(); 
        }

        public bool exists(int courseID)
        //returns true if the any course in the current candidate schedule has the given id
        {
            foreach (var course in schedule)
            {
                if(course.getCourseID() == courseID) return true;
            }
            return false;
        }

        //changes the variable creditSituation based on the total number of credits in the schedule
        public void checkCreditCount()
        {
            cred_statis = cred_total < 12 ? -1 : 0;
            cred_statis = cred_total > 17 ? 1 : 0;
        }

        //creates the schedule from a json file, return true if successful
        public bool scheduleFromFile(string filepath) 
        {
            if(!File.Exists(filepath)) return false;
            string allCourses = System.IO.File.ReadAllText(filepath);

            if (!allCourses.StartsWith(KEY_STRING)) return false; //secondary check that file is correct type
            else allCourses.Replace(KEY_STRING, null);

            List<string> listOfCourses = new List<string>(allCourses.Split('\n'));
            removeAllCourses(); //replaces current candidate schedule

            int i = 0;
            foreach (var course in listOfCourses)
            {
                List<string> importedCourse = new List<string>(course.Split('\t'));

                int id;
                if (Int32.TryParse(importedCourse[importedCourse.Count - 1], out id) &&
                    DB.getCourseCode(id) == System.Text.RegularExpressions.Regex.Replace(importedCourse[0], @"\s+", " ")) ;
                else id = DB.getNumCourses() + i++;

                importedCourse.RemoveAt(importedCourse.Count - 1);
                if (id < DB.getNumCourses()) add_ob(DB.getCourse(id));
                else add_ob(new Course(importedCourse, id));

                if (id < DB.getNumCourses()) add_ob(DB.getCourse(id));
                else add_ob(new Course(importedCourse, id));

                creditCount += DB.getCredits(id);
                checkCreditCount();
            }
            return true;
        }

        //creates a json file from the schedule, return true if successful
        public bool scheduleToFile(string filepath) 
        {
            if (File.Exists(filepath)) return false;
            using (StreamWriter sw = File.CreateText(filepath))
            {
                sw.Write(KEY_STRING);//marks first line for verifying file
                // Create a file to write to.
                foreach (var course in schedule)
                {
                    sw.WriteLine(course.getAllInfo());
                }
            }
            return true;
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
                    m_course.CourseID = id;
                    m_course.Locked = true; 
                    m_Courses.Add(m_course);

                }
            }

            updateConflictMarkers();
        }

        // Looks at all the courses in the schedule and marks conflicting courses red and non-conflicting courses white
        // This could probably be written more efficiently 
        private void updateConflictMarkers()
        {
            List<int> conflictIDs = new List<int>(); 

            foreach (var c1 in m_Courses)
            {
                c1.Color = System.Drawing.Color.White; 
                foreach (var conflict in checkTimeConflict(c1.CourseID))
                {
                    if (!conflictIDs.Contains(conflict.getCourseID()))
                        conflictIDs.Add(conflict.getCourseID());
                }
            }

            foreach (var c1 in m_Courses)
            {
                if (conflictIDs.Contains(c1.CourseID))
                {
                    c1.Color = System.Drawing.Color.Red; 
                }
                else
                {
                    c1.Color = System.Drawing.Color.White; 
                }
            }
                 
        }

    }
}
