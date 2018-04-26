using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using CourseClass;
using CourseInfoClass;
using SpellingCorrector;
using SearchResultsClass;

namespace SearchClass
{

    public class Search
    {
        
        private static Search singleton;

        public static Search Create()
        {
            if (singleton == null)
            {
                singleton = new Search();
            }
            return singleton;
        }      

        public static Search Create(string spelling_db)
        {
            if (singleton == null)
            {
                singleton = new Search(spelling_db);
            }
            return singleton;
        }        
             
        public AdvancedOptions options;   // For storing advanced search options 
        private Spelling spelling;         // Instance of Spelling object from Spelling.cs 
        private string courseDictionary;   // Stores course dictionary filename for use by spellchecker and course search 
        public SearchResults lastSearchResults;  // Stores the search results after using searchForQuery()

        private Search()  // Constructor 
        {
            this.spelling = new Spelling("course_dictionary.txt");
            this.courseDictionary = "course_dictionary.txt";

            this.lastSearchResults = new SearchResults();
            this.options = new AdvancedOptions();
        }

        public Search(string courseDictionary)  // Constructor 
        {
            this.spelling = new Spelling(courseDictionary);
            this.courseDictionary = courseDictionary;

            this.lastSearchResults = new SearchResults();
            this.options = new AdvancedOptions();
        }

        // This function creates a list of Courses that match a given query or are close enough to be recognized by the spell-checker. 
        // It also creates a string containing the spell-checked version of the user's query. 
        // All these search results are placed in the lastSearchResults struct, which can be accessed using the getters. 
        // The query can be a course name or course code. Courses that don't match the query at all are not included in the results. 
        public void searchForQuery(string query)
        {
            if (string.IsNullOrWhiteSpace(query))  // For the user gives a blank query, display all the courses 
            {
                lastSearchResults.correctedQuery = "";
                lastSearchResults.query = "";
                addAllCourses();
                return;
            }

            string correctedQuery = "";   // Stores the spell-checked version of the user's query. 
            List<List<int>> matching = new List<List<int>>();    // A list where each index represents a word in the query. For each word, there is a list of ints. These ints are the course IDs of courses containing that word in their name or course code. 
            KeyValuePair<string, List<int>> result = new KeyValuePair<string, List<int>>(); // Stores the results from the spellchecker

            ///////////// Take query, split into words, and run spell checker on each word   ///////////////

            List<string> querySplit = query.Trim().Split().ToList();

            foreach (var word in querySplit)
            {
                // Needs tweaked:    ? 
                if (word.Length > 4 || (querySplit.Count == 1 && word.Length > 2))   // Doesn't correct words smaller than 5 characters, unless it's a single word query. Doing so could lead to bad search results. 
                    result = spelling.CorrectExt(word, true);
                else
                    result = spelling.CorrectExt(word, false);

                // For single letter queries, list classes whose first letter in course name/code matches letter? 

                if (result.Value[0] != 0)  // If the word in the query doesn't match anything in the dictionary and cannot be corrected with the spell-checker, don't add to the corrected query 
                {
                    correctedQuery += result.Key + " ";
                }

                matching.Add(result.Value.GetRange(0, result.Value.Count));
                if (matching.Last().Count != 0)
                    matching.Last().RemoveAt(0);
            }

            correctedQuery = correctedQuery.TrimEnd(' ');  // Removes any extra spaces at the end 
            lastSearchResults.correctedQuery = correctedQuery; // Setting correctedQuery in the lastSearchResults struct 
            lastSearchResults.query = query;                   // Setting query in the lastSearchResults struct 

            storeSearchResults(matching, querySplit, correctedQuery);  // Calculate the relevance for each course that matched the query, and store that along with all the courses in results 

        }

        // Calculates the relevancy of each item in the search results using a heuristic, then stores these values along with all the courses in the results. 
        private void storeSearchResults(List<List<int>> matching, List<string> querySplit, string correctedQuery)
        {
            lastSearchResults.courses.Clear();
            lastSearchResults.relevance.Clear(); 
            int j = 0;
            foreach (var match in matching)  // For each word of corrected query 
            {
                foreach (var id in match)    // For each course ID of courses that contain the corrected query word in their title or course code 
                {
                    if (lastSearchResults.relevance.ContainsKey(id)) //(bestMatches.ContainsKey(id))
                    {
                        lastSearchResults.relevance[id]++; //bestMatches[id]++;  // Increment the number of matching words for the course "id"  
                        // If it matches the department code rather than just part of the course title, the relevance will be increased an extra amount for better results (see below)   
                    }
                    else
                    {
                        lastSearchResults.courses.Add(new Course(id));
                        lastSearchResults.relevance[id] = 1; //bestMatches[id] = 1; // This course has one matching word 

                        // For the following line, if a course matches the query completely (every word), then that course is given one extra relevancy.
                        // I'm not sure if this will improve search results much. It's an experimental feature. It can be safely commented out to disable it. 
                        lastSearchResults.relevance[id] /*bestMatches[id]*/ += (querySplit.Count != 1 && correctedQuery.Split().ToList().Count == querySplit.Count && correctedQuery.Split().All(i => spelling.getDictionaryFileContents()[id].ToLower().Split().Contains(i))) ? 1 : 0;
                    }

                    // This loop adds extra relevance to results whose department code (part of its course code) matches part of the query 
                    // For example, CS courses have higher relevance in search results than the business courses that have "computer" in the name when the user searches for "computer"
                    foreach (string word in spelling.getDictionaryFileContents()[id].Split())
                    {

                        if (Regex.IsMatch(word, @"^\d+$"))  // Breaks once it reaches the course number 
                            break;
                        else
                        {
                            //Console.WriteLine("correctedQuery.Split()[j] = ,{0}, word.ToLower() = ,{1}, ", correctedQuery.Split()[j], word.ToLower());
                            if (j < correctedQuery.Split().ToList().Count && correctedQuery.Split()[j] == word.ToLower())    // If a word in the query matches a department code of a course, it counts extra towards the relevance of that course in the search results 
                                lastSearchResults.relevance[id]++; //bestMatches[id]++;  // For now, increase the relevance by an extra 1. Remove this line to remove the effect of this whole feature.  
                        }
                    }

                    // Note: Courses whose titles or course codes match more words of the corrected query have a higher "relevance" and will appear at the top of search results. 
                }
                j++;
            }


        }

        // Corrects a given course name or course code and returns the corrected version. 
        public string Correct(string query)
        {
            return spelling.Correct(query);
        }

        // Returns the dictionary file contents
        private List<string> getDictionaryFileContents()
        {
            return spelling.getDictionaryFileContents();
        }

        // Adds all the courses to the search results
        private void addAllCourses()
        {
            lastSearchResults.relevance.Clear();  // Clear the results from the last search 
            lastSearchResults.courses.Clear();          // Clear the results from the last search 

            // Add all of the courses to the search results: 
            for (int i = 0; i < CourseInfo.Create().getNumCourses(); i++)   // Was i < spelling.getDictionaryFileContents().Count
            {
                lastSearchResults.courses.Add(new Course(i));
                lastSearchResults.relevance[i] = 1;      // Should it be 0?  
            }
        }

        public void advancedSearchFilter()
        {
            List<int> removeIndices = new List<int>();

            // Filter start time 
            if (options.timeStart != -1.0)  // If the user has selected a start time preference 
            {
                removeIndices.Clear();
                // Creates list of indexes in lastSearchResults.getCourses() whose element (a course) doesn't match the start time preference 
                removeIndices = lastSearchResults.getCourses().Select((element, index) => element.getTime().Item1 < options.timeStart ? index : -1).Where(i => i != -1).ToList();
                removeIndices.Reverse();

                foreach (int index in removeIndices)
                {
                    lastSearchResults.relevance.Remove(lastSearchResults.getCourses()[index].getCourseID());
                    lastSearchResults.courses.RemoveAt(index);
                }
            }

            // Filter end time
            if (options.timeEnd != -1.0)    // If the user has selected an end time preference 
            {
                removeIndices.Clear();
                // Creates list of indexes in lastSearchResults.getCourses() whose element (a course) doesn't match the start time preference 
                removeIndices = lastSearchResults.getCourses().Select((element, index) => element.getTime().Item2 > options.timeEnd ? index : -1).Where(i => i != -1).ToList();
                removeIndices.Reverse();

                foreach (int index in removeIndices)
                {
                    lastSearchResults.relevance.Remove(lastSearchResults.getCourses()[index].getCourseID());
                    lastSearchResults.courses.RemoveAt(index);
                }

            }

            // Filter day of week
            if (options.day.Contains(false))    // If the user has selected a day that they don't want included 
            {
                removeIndices.Clear();
                // Remove a course if a day which the potential course meets maps to false for that same day in options.day 
                // This one's a bit crazy... 
                removeIndices = lastSearchResults.getCourses().Select((element, index) => element.getDay().Select((elem, ind) => element.getDay()[ind] && !options.day[ind] ? true : false).Where(i => i).ToList().Count != 0 ? index : -1).Where(i => i != -1).ToList();
                removeIndices.Reverse();

                foreach (int index in removeIndices)
                {
                    lastSearchResults.relevance.Remove(lastSearchResults.getCourses()[index].getCourseID());
                    lastSearchResults.courses.RemoveAt(index);
                }

            }

            // Filter building 
            if (options.building != Build.NONE)  // If the building does not equal ANY (NONE)
            {
                removeIndices.Clear();
                removeIndices = lastSearchResults.getCourses().Select((element, index) => (int)element.getBuilding() != (int)options.building ? index : -1).Where(i => i != -1).ToList();
                removeIndices.Reverse();

                foreach (int index in removeIndices)
                {
                    lastSearchResults.relevance.Remove(lastSearchResults.getCourses()[index].getCourseID());
                    lastSearchResults.courses.RemoveAt(index);
                }

            }


            // Filter professor  
            if (options.firstNameProfessor != "" && options.lastNameProfessor != "")  // If the user wants to only show courses with a certain professor 
            {
                removeIndices.Clear();
                removeIndices = lastSearchResults.getCourses().Select((element, index) => (element.getProf().first != options.firstNameProfessor || element.getProf().last != options.lastNameProfessor) ? index : -1).Where(i => i != -1).ToList();
                removeIndices.Reverse();

                foreach (int index in removeIndices)
                {
                    lastSearchResults.relevance.Remove(lastSearchResults.getCourses()[index].getCourseID());
                    lastSearchResults.courses.RemoveAt(index);
                }

            }

            // Filter Full Classes
            if (!options.showFull)
            {
                removeIndices.Clear();
                removeIndices = lastSearchResults.getCourses().Select((element, index) => element.isFull() ? index : -1).Where(i => i != -1).ToList();
                removeIndices.Reverse();

                foreach (int index in removeIndices)
                {
                    lastSearchResults.relevance.Remove(lastSearchResults.getCourses()[index].getCourseID());
                    lastSearchResults.courses.RemoveAt(index);
                }
            }

            // Filter by RMP score
            if (options.rmp != -1.0)  // If the user has a preference for the professor's minimum RMP score 
            {
                removeIndices.Clear();
                removeIndices = lastSearchResults.getCourses().Select((element, index) => element.getProf().rmp < options.rmp ? index : -1).Where(i => i != -1).ToList();
                removeIndices.Reverse();

                foreach (int index in removeIndices)
                {
                    lastSearchResults.relevance.Remove(lastSearchResults.getCourses()[index].getCourseID());
                    lastSearchResults.courses.RemoveAt(index);
                }
            }

        }
        
        
    }

    public class AdvancedOptions
    {
        public double rmp;  // Filter by courses with professor with RateMyProfessor rating >= rmp. -1 means the user doesn't have a preference
        public string probability; // high, medium, or low

        // Put other advanced options here later 

        public double timeStart;  // Filter by courses that start at or after timeStart. -1 means the user doesn't have a preference 
        public double timeEnd;    // Filter by courses that end at or before timeEnd. -1 means the user doesn't have a preference

        public List<bool> day;    // Filter by courses that don't meet on days you don't want it to meet. If a value is false, it means you don't want a class that meets on that day. All true means user doesn't have a preference 

        public Build building;
        public string firstNameProfessor;
        public string lastNameProfessor;

        public bool showFull;

        public AdvancedOptions()
        {
            rmp = -1.0;  
            probability = ""; // high, medium, low, or low/none

            // Put other advanced options here later 

            timeStart = -1.0; 
            timeEnd = -1.0;
            day = (new bool[] {true,true,true,true,true}).ToList();
            building = Build.NONE;  // NONE in CourseClass will mean ANY building here. 
            firstNameProfessor = "";
            lastNameProfessor = "";
            showFull = true;
        }

    }

}
