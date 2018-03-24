using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseClass;

namespace ScheduleApp
{
    class CandidateSchedule
    {
        private List<Course> schedule;

        CandidateSchedule()
        {
            
        }

        CandidateSchedule(string filename) // factory constructor using JSON, sprint 2
        {

        }


        public void addCourseByObject(Course c)
        {
            schedule.Add(c);
        }


        public void addCourseByID(int id)
        {

            schedule.Add(new Course(id));
        }


        public void removeCourse(int courseID)
        {
            foreach (var course in schedule)
            {
                if (course.getCourseID() == courseID)
                {
                    schedule.Remove(course);
                }
            }
        }

    }
}
