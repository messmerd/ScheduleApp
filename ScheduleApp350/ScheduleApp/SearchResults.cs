using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScheduleApp
{
    public enum SORTTYPE { BUILDING=-1, CAPACITY=-2, COURSECODE=1, COURSENAME=3, CREDITS=0, DAY=5, ENDTIME=-3, ENROLLMENT=6, PROBABILITY=8, PROFESSOR=2, RMP=7, RELEVANCY=-4, STARTTIME=4 };
 
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
        public Course getCourse(int id)
        {
            return courses.ElementAt(id); 
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
            switch (sortBy)
            {
                case SORTTYPE.BUILDING:
                    courses = courses.OrderBy(x => (int)x.getBuilding()).ToList();
                    break;
                case SORTTYPE.CAPACITY:
                    courses = courses.OrderBy(x => x.getCapacity()).ToList();
                    break;
                case SORTTYPE.COURSECODE: 
                    courses = courses.OrderBy(x => x.getCourseID()).ToList();  // Assumes course database is ordered alphabetically by course code. x.getCourseCode() could also work with some changes.
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
                case SORTTYPE.PROBABILITY:  
                    courses = courses.OrderBy(x => x.getProbabilityInt()).ToList();
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

        private int getSortableValueForDay(List<bool> input)
        {
            int sum = 0;
            for (int i = 0; i < 5; i++)
            {
                sum += (input[i] ? 1 : 0) * (1 << (4 - i));
            }
            return Int32.MaxValue - (sum + input.Count(x => !x) * 32);
        }

        private bool attributesAreEqual(SORTTYPE type, int index1, int index2)
        {
            switch (type)
            {
                case SORTTYPE.BUILDING: 
                    return courses[index1].getBuilding().Equals(courses[index2].getBuilding());
                case SORTTYPE.CAPACITY:
                    return courses[index1].getCapacity().Equals(courses[index2].getCapacity());
                case SORTTYPE.COURSECODE:
                    return courses[index1].getCourseCode().Equals(courses[index2].getCourseCode());
                case SORTTYPE.COURSENAME:
                    return courses[index1].getLongName().Equals(courses[index2].getLongName()); 
                case SORTTYPE.CREDITS:
                    return courses[index1].getCredits().Equals(courses[index2].getCredits());
                case SORTTYPE.DAY:
                    return courses[index1].getDay().Equals(courses[index2].getDay());
                case SORTTYPE.ENDTIME:
                    return courses[index1].getTime().Item2.Equals(courses[index2].getTime().Item2);
                case SORTTYPE.ENROLLMENT:
                    return courses[index1].getEnrollment().Equals(courses[index2].getEnrollment());
                case SORTTYPE.PROBABILITY:   
                    return courses[index1].getProbabilityInt().Equals(courses[index2].getProbabilityInt());
                case SORTTYPE.PROFESSOR:  
                    return courses[index1].getProf().Equals(courses[index2].getProf());
                case SORTTYPE.RELEVANCY:
                    return relevance[courses[index1].getCourseID()].Equals(relevance[courses[index2].getCourseID()]);
                case SORTTYPE.RMP:
                    return courses[index1].getProf().rmp.Equals(courses[index2].getProf().rmp);
                case SORTTYPE.STARTTIME:
                    return courses[index1].getTime().Item1.Equals(courses[index2].getTime().Item1);
                default:
                    return true;
            }
        }

        // This part orders the results (for each different groupBy value) by department code and course number: 
        private void alphabetize(SORTTYPE groupBy)
        {
            if (courses.Count > 1 && groupBy != SORTTYPE.COURSECODE) // Only needs to sort if there is more than one result, and if sorting by course code, it's already alphabetized 
            {
                int start = 0;
                List<Course> sortedSubset = new List<Course>();

                for (int i = 0; i < courses.Count; i++)
                {
                    if (i == courses.Count - 1 || !attributesAreEqual(groupBy, i, i + 1))  
                    {
                        sortedSubset = courses.GetRange(start, i - start + 1).OrderBy(a => a.getCourseID()).ToList();  // Sort subset by department/course number (alphabetical order)

                        for (int k = start; k < i + 1; k++) // Copies the sorted subset back into the main list 
                        {
                            courses[k] = sortedSubset[k - start];
                        }

                        if (i != courses.Count - 1)  // If it isn't the last element 
                        {
                            start = i + 1;
                        }
                    }

                }
            }


        }


    }

}
