using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleApp
{
    public class UnitTests
    {
        //all tests are based on requirement 7 (professor searching) of the sprint 1 testing plan, tests b-d
        public bool test1() //searching for a specific teacher
        {
            /*

            if(results == )
            {
                return true;
            }
            else
            {
                return false;
            }
            */
            return true;
        }

        public bool test2() //search databse with nothing entered (all courses in database will be returned)
        {
            
            Search search = Search.Create("course_dictionary.txt");
            CourseInfo DB = CourseInfo.Create();
            search.searchForQuery(null);
            int i = 0;
            foreach(var course in search.lastSearchResults.getCourses())
            {
                if (i++ != course.getCourseID())
                {
                    return false;
                }
            }
            if (i != DB.getNumCourses()) return false;
            
            return true;
        }

        public bool test3() //search for professor while something is written in regular search box
        {
            /*
            if(results == )
            {
                return true;
            }
            else
            {
                return false;
            }
             * */
            return true;
        }
    }
}
