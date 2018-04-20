using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CourseClass;

namespace SearchResultsClass
{
    public class SearchResults
    {
        public List<Course> courses;         // Courses ordered from most relevant to least by default.  
        public string query;                 // The query passed to searchForQuery()
        public string correctedQuery;        // The spell-checked version of query
        public List<int> courseRelevance;    // Stores the relevance of each course in the results. courseRelevance[i] = relevance of courses[i] 

        public SearchResults()
        {
            this.query = "";
            this.correctedQuery = "";
            this.courses = new List<Course>();
            this.courseRelevance = new List<int>();
        }

        // Getters: 
        public List<Course> getCourses()
        {
            return courses;
        }
        public string getCorrectedQuery()
        {
            return correctedQuery;
        }
        public string getQuery()
        {
            return query;
        }
        public List<int> getCourseRelevance()
        {
            return courseRelevance;
        }

        public void SortCourses(int sortBy, bool ascending)
        {
            // Could use enum to make it obvious what integer to use for sortBy in the caller's code 
            // Credits, Course code, prof., course name, ...

            if (ascending)
            {
                switch (sortBy)
                {
                    case 0:  // # of credits
                        courses = courses.OrderBy(x => x.getCredits()).ToList();
                        break;
                    case 1:  // Course code
                        courses = courses.OrderBy(x => x.getCourseCode()).ToList();
                        break;

                    default:
                        break;
                }
            }
            else
            {
                switch (sortBy)
                {
                    case 0:  // # of credits
                        courses = courses.OrderByDescending(x => x.getCredits()).ToList();
                        break;

                    case 1:  // Course code
                        courses = courses.OrderByDescending(x => x.getCourseCode()).ToList();
                        break;

                    default:
                        break;
                }

            }
        }

    }





}
