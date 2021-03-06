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
        public bool test1() //searching for a specific professor (Britton Wolfe); courseIDs should be 184, 186, and 187.
        {
            Search search = Search.Create("course_database.txt");
            CourseInfo DB = CourseInfo.Create();
            search.options.clear();
            search.options.firstNameProfessor = "Britton";
            search.options.lastNameProfessor = "Wolfe";
            search.searchForQuery(null);
            search.advancedSearchFilter();

            foreach (var course in search.lastSearchResults.getCourses())
            {
                int courseID = course.getCourseID();
                if (courseID != 184 && courseID != 186 && courseID != 187)
                {
                    return false;
                }
            }

            if (search.lastSearchResults.getCourses().Count != 3) 
            {
                return false; 
            }

            return true;
        }

        public bool test2() //search database with nothing entered (all courses in database will be returned); course ID's are 0 through 760
        {
            
            Search search = Search.Create("course_dictionary.txt");
            CourseInfo DB = CourseInfo.Create();
            search.options.clear();
            search.options.firstNameProfessor = "";
            search.options.lastNameProfessor = "";
            search.searchForQuery("");
            search.advancedSearchFilter();

            int i = 0;
            foreach(var course in search.lastSearchResults.getCourses())
            {
                if (i++ != course.getCourseID())
                {
                    return false;
                }
            }
            if (i != DB.getNumCourses()) return false;
            if (i != 761) return false; 

            return true;
        }

        public bool test3() //search for professor (Britton Wolfe) while Software is written in regular search box; courseID's are 186, 187
        {
            Search search = Search.Create("course_database.txt");
            CourseInfo DB = CourseInfo.Create();
            search.options.clear();
            search.options.firstNameProfessor = "Britton";
            search.options.lastNameProfessor = "Wolfe";
            search.searchForQuery("Software");
            search.advancedSearchFilter();

            if (search.lastSearchResults.getCourses().Count != 2)
            {
                return false;
            }

            foreach (var course in search.lastSearchResults.getCourses())
            {
                int courseID = course.getCourseID();
                if (courseID != 186 && courseID != 187)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
