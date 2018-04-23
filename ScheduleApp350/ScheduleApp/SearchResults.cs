using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CourseClass;

namespace SearchResultsClass
{

    public enum SORTTYPE {COURSECODE, DAY, PROF, CREDITS, STARTTIME, ENDTIME, RELEVANCY};

    public class SearchResults
    {
        public List<Course> courses;         // Courses ordered from most relevant to least by default.  
        public string query;                 // The query passed to searchForQuery()
        public string correctedQuery;        // The spell-checked version of query
        public List<int> courseRelevance;    // Stores the relevance of each course in the results. courseRelevance[i] = relevance of courses[i] 
        public Dictionary<int, int> relevance; 

        public SearchResults()
        {
            this.query = "";
            this.correctedQuery = "";
            this.courses = new List<Course>();
            this.courseRelevance = new List<int>();
            this.relevance = new Dictionary<int, int>();
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

        public void SortCourses(SORTTYPE sortBy, bool ascending)
        {
            // Could use enum to make it obvious what integer to use for sortBy in the caller's code 
            // Credits, Course code, prof., course name, ...

            switch (sortBy)
            {
                case SORTTYPE.CREDITS:  // # of credits
                    courses = courses.OrderBy(x => x.getCredits()).ToList();
                    break;
                case SORTTYPE.COURSECODE:  // Course code
                    courses = courses.OrderBy(x => x.getCourseCode()).ToList();
                    break;
                case SORTTYPE.RELEVANCY:
                    sortByRelevance();
                    break;

                default:
                    break;
            }

            if (!ascending)
                courses.Reverse(); 
            
        }

        private void sortByRelevance()
        {
            // This function sorts courses by relevancy. Courses with the same relevancy are sorted by course code. 
            courses.Sort((c1, c2) => relevance[c2.getCourseID()].CompareTo(relevance[c1.getCourseID()])); // Sort by relevancy first

            // This part orders the results (for each different relevancy value) by department code and course number: 
            if (courses.Count > 1) // Only needs to sort if there is more than one result 
            {
                int start = 0;
                int currentRelevance = relevance[courses[0].getCourseID()];
                List<Course> sortedSubset = new List<Course>();

                for (int i = 0; i < courses.Count; i++)
                {
                    if (i == courses.Count - 1 || relevance[courses[i + 1].getCourseID()] != currentRelevance)
                    {
                        sortedSubset = courses.GetRange(start, i - start + 1).OrderBy(a => a.getCourseID()).ToList();  // Sort subset by department/course number

                        for (int k = start; k < i + 1; k++) // Copies the sorted subset back into the main list 
                        {
                            courses[k] = sortedSubset[k - start];
                        }

                        if (i != courses.Count - 1)  // If it isn't the last element 
                        {
                            currentRelevance = relevance[courses[i + 1].getCourseID()];  
                            start = i + 1;
                        }
                    }

                }
            }
        }

    }

}
