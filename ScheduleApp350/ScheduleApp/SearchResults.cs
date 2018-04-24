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
        public Dictionary<int, int> relevance; 

        public SearchResults()
        {
            this.query = "";
            this.correctedQuery = "";
            this.courses = new List<Course>();
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
        public int getCourseRelevance(int id)
        {
            if (relevance.ContainsKey(id))
                return relevance[id];
            else
                return -1; // Course is not in the search results
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
                case SORTTYPE.DAY:
                    courses = courses.OrderBy(x => Int32.MaxValue - boolArrayToInt(x.getDay().ToArray())).ToList();
                    break; 
                case SORTTYPE.RELEVANCY:
                    courses.Sort((c1, c2) => relevance[c2.getCourseID()].CompareTo(relevance[c1.getCourseID()])); // Sort by relevancy
                    break;

                default:
                    break;
            }

            if (!ascending)
                courses.Reverse();

            alphabetize(sortBy);
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

        private Int32 boolArrayToInt(bool[] input)
        {
            System.Collections.BitArray arr = new System.Collections.BitArray(input);
            byte[] data = new byte[4];
            arr.CopyTo(data, 0);
            return BitConverter.ToInt32(data, 0);
        }

        private double getSortableValue(SORTTYPE type, int index)
        {
            switch (type)
            {
                case SORTTYPE.CREDITS:
                    return (double)courses[index].getCredits();
                case SORTTYPE.DAY:
                    return (double)(Int32.MaxValue - boolArrayToInt(courses[index].getDay().ToArray()));
                case SORTTYPE.PROF:
                    return (double)CourseInfoClass.CourseInfo.Create().prof_database.FindIndex(x => x.Equals(courses[index].getProf()));
                case SORTTYPE.STARTTIME:
                    return courses[index].getTime().Item1;
                case SORTTYPE.ENDTIME:
                    return courses[index].getTime().Item2;
                case SORTTYPE.RELEVANCY:
                    return (double)relevance[courses[index].getCourseID()]; 

                default:
                    return -1.0;
            }

        }

        private void alphabetize(SORTTYPE groupBy)
        {
            // This part orders the results (for each different relevancy value) by department code and course number: 
            if (courses.Count > 1) // Only needs to sort if there is more than one result 
            {
                int start = 0;
                int currentRelevance = relevance[courses[0].getCourseID()];

                double currentValue = getSortableValue(groupBy, 0);

                List<Course> sortedSubset = new List<Course>();

                for (int i = 0; i < courses.Count; i++)
                {
                    if (i == courses.Count - 1 || getSortableValue(groupBy, i + 1) != currentValue)
                    {
                        sortedSubset = courses.GetRange(start, i - start + 1).OrderBy(a => a.getCourseID()).ToList();  // Sort subset by department/course number

                        for (int k = start; k < i + 1; k++) // Copies the sorted subset back into the main list 
                        {
                            courses[k] = sortedSubset[k - start];
                        }

                        if (i != courses.Count - 1)  // If it isn't the last element 
                        {
                            currentValue = getSortableValue(groupBy, i + 1);
                            start = i + 1;
                        }
                    }

                }
            }


        }

    }

}
