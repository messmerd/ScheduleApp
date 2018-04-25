using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CourseClass;

namespace SearchResultsClass
{
    public enum SORTTYPE { BUILDING, CAPACITY, COURSECODE, COURSENAME, CREDITS, DAY, ENDTIME, ENROLLMENT, PROBABILITY, PROFESSOR, RMP, RELEVANCY, STARTTIME };
 
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
            // RMP, name, capacity, probability
            switch (sortBy)
            {
                case SORTTYPE.BUILDING:  // Not implemented yet 
                    break;
                case SORTTYPE.CAPACITY:
                    courses = courses.OrderBy(x => x.getCapacity()).ToList();
                    break;
                case SORTTYPE.COURSECODE: 
                    courses = courses.OrderBy(x => x.getCourseCode()).ToList();
                    break;
                case SORTTYPE.COURSENAME:
                    courses = courses.OrderBy(x => x.getLongName()).ToList();
                    break;
                case SORTTYPE.CREDITS: 
                    courses = courses.OrderBy(x => x.getCredits()).ToList();
                    break;
                case SORTTYPE.DAY:
                    courses = courses.OrderBy(x => getSortableValueForDay(x.getDay())).ToList();
                    break;
                case SORTTYPE.ENDTIME:
                    courses = courses.OrderBy(x => x.getTime().Item2).ToList();
                    break;
                case SORTTYPE.ENROLLMENT:
                    courses = courses.OrderBy(x => x.getEnrollment()).ToList();
                    break;
                case SORTTYPE.PROBABILITY:        // Doesn't work yet. 
                    courses = courses.OrderBy(x => x.getProbability()).ToList();
                    break;
                case SORTTYPE.PROFESSOR:
                    courses = courses.OrderBy(x => x.getProf().last + x.getProf().first).ToList();
                    break;
                case SORTTYPE.RMP:
                    courses = courses.OrderBy(x => x.getProf().rmp).ToList();
                    break;
                case SORTTYPE.RELEVANCY:
                    courses = courses.OrderBy(x => relevance[x.getCourseID()]).ToList();
                    break;
                case SORTTYPE.STARTTIME:  
                    courses = courses.OrderBy(x => x.getTime().Item1).ToList();
                    break;
                default:
                    break;
            }

            if (!ascending)
                courses.Reverse();

            alphabetize(sortBy);
        }

        private double getSortableValueForDay(List<bool> input)
        {
            int sum = 0;
            for (int i = 0; i < 5; i++)
            {
                sum += (input[i] ? 1 : 0) * (1 << (4 - i));
            }
            return Int32.MaxValue - (sum + input.Count(x => !x) * 32);
        }

        private double getSortableValue(SORTTYPE type, int index)
        {
            switch (type)
            {
                case SORTTYPE.BUILDING:      // Still needs to be done 
                    return -1.0;
                case SORTTYPE.CAPACITY:
                    return courses[index].getCapacity();
                case SORTTYPE.COURSECODE:
                    return courses[index].getCourseID(); 
                case SORTTYPE.COURSENAME:
                    return -1.0;             // Still needs to be done
                case SORTTYPE.CREDITS:
                    return courses[index].getCredits();
                case SORTTYPE.DAY:
                    return getSortableValueForDay(courses[index].getDay());
                case SORTTYPE.ENDTIME:
                    return courses[index].getTime().Item2;
                case SORTTYPE.ENROLLMENT:
                    return courses[index].getEnrollment(); 
                case SORTTYPE.PROBABILITY:   // Still needs to be done  
                    return -1.0; 
                case SORTTYPE.PROFESSOR:     // This relies on the fact that the professor database is sorted alphabetically 
                    return CourseInfoClass.CourseInfo.Create().prof_database.FindIndex(x => x.Equals(courses[index].getProf()));
                case SORTTYPE.RELEVANCY:
                    return relevance[courses[index].getCourseID()]; 
                case SORTTYPE.RMP:
                    return courses[index].getProf().rmp;
                case SORTTYPE.STARTTIME:
                    return courses[index].getTime().Item1;
                
                default:
                    return -1.0;
            }

        }

        private void alphabetize(SORTTYPE groupBy)
        {
            // This part orders the results (for each different groupBy value) by department code and course number: 
            if (courses.Count > 1) // Only needs to sort if there is more than one result 
            {
                int start = 0;
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
