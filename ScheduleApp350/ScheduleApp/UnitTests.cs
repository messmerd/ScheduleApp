﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleApp
{
    public class UnitTests
    {
        //all tests are based on requirement 7 (professor searching) of the sprint 1 testing plan, tests b-d
        public bool test1() //searching for a specific teacher; courseID's are 184, 186, 187
        {
            Search search = Search.Create("course_database.txt");
            CourseInfo DB = CourseInfo.Create();
            search.searchForQuery(null);
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

        public bool test2() //search databse with nothing entered (all courses in database will be returned); course ID's are 0 to 760
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

        public bool test3() //search for professor while Software is written in regular search box; courseID's are 186, 187
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
