using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using CourseClass;
using CourseInfoClass;
using SpellingCorrector;

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
             
        private AdvancedOptions options;   // For storing advanced search options 
        private Spelling spelling;         // Instance of Spelling object from Spelling.cs 
        private string courseDictionary;   // Stores course dictionary filename for use by spellchecker and course search 
        public CourseList lastSearchResults;  // Stores the search results after using searchForQuery()

        

        private Search()  // Constructor 
        {
            this.spelling = new Spelling("course_dictionary.txt");
            this.courseDictionary = "course_dictionary.txt";

            this.lastSearchResults = new CourseList();
            this.options = new AdvancedOptions();
        }

        public Search(string courseDictionary)  // Constructor 
        {
            this.spelling = new Spelling(courseDictionary);
            this.courseDictionary = courseDictionary;

            this.lastSearchResults = new CourseList();

            this.options.rmp = 0;  // Rate my professor rating 
            this.options.probability = "low";
            // Other advanced options will go here.
        }

        // This function creates a list of Courses that match a given query or are close enough to be recognized by the spell-checker. 
        // It also creates a string containing the spell-checked version of the user's query. 
        // All these search results are placed in the lastSearchResults struct, which can be accessed using the getters. 
        // The query can be a course name or course code. The results are organized from best match to worst. Courses that don't match at all are not included. 

        // TODO: Refactor/split up this method (150 lines currently) before the final submission in May
        // Split into private methods
        public void searchForQuery(string query)
        {
            if (string.IsNullOrWhiteSpace(query))  // For the user gives a blank query, display all the courses 
            {
                lastSearchResults.correctedQuery = "";
                lastSearchResults.query = "";
                addAllCourses();
            }

            string correctedQuery = "";   // Stores the spell-checked version of the user's query. 
            List<List<int>> matching = new List<List<int>>();    // A list where each index represents a word in the query. For each word, there is a list of ints. These ints are the course IDs of courses containing that word in their name or course code. 
            Dictionary<int, int> bestMatches = new Dictionary<int, int>(); // Maps course IDs to their relevance (how many of the words in the query match words in the course title or course code)
            KeyValuePair<string, List<int>> result = new KeyValuePair<string, List<int>>(); // Stores the results from the spellchecker

            ///////////// Take query, split into words, and run spell checker on each word   ///////////////

            List<string> querySplit = query.Split().ToList();

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

            /////////////  Calculate the relevance for each course that matched the query  ///////////////

            int j = 0;
            foreach (var match in matching)  // For each word of corrected query 
            {

                foreach (var id in match)    // For each course ID of courses that contain the corrected query word in their title or course code 
                {
                    if (bestMatches.ContainsKey(id))
                    {
                        bestMatches[id]++;  // Increment the number of matching words for the course "id"  
                        // If it matches the department code rather than just part of the course title, the relevance will be increased an extra amount for better results (see below)   
                    }
                    else
                    {
                        bestMatches[id] = 1; // This course has one matching word 

                        // For the following line, if a course matches the query completely (every word), then that course is given one extra relevancy.
                        // I'm not sure if this will improve search results much. It's an experimental feature. It can be safely commented out to disable it. 
                        bestMatches[id] += (querySplit.Count != 1 && correctedQuery.Split().ToList().Count == querySplit.Count && correctedQuery.Split().All(i => spelling.getDictionaryFileContents()[id].ToLower().Split().Contains(i))) ? 1 : 0;
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
                                bestMatches[id]++;  // For now, increase the relevance by an extra 1. Remove this line to remove the effect of this whole feature.  
                        }
                    }

                    // Note: Courses whose titles or course codes match more words of the corrected query have a higher "relevance" and will appear at the top of search results. 
                }
                j++;
            }

            /////////////  Sort the search results by relevance   ///////////////

            List<KeyValuePair<int, int>> bestMatchesList = bestMatches.ToList();
            bestMatchesList.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));  // Sorts the courses by relevance. Most relevant first. 

            // This part orders the results (for each different relevancy value) by department code and course number: 
            if (bestMatchesList.Count > 1) // Only needs to sort if there is more than one result 
            {
                int start = 0;
                int currentRelevance = bestMatchesList[0].Value;
                List<KeyValuePair<int, int>> sortedSubset = new List<KeyValuePair<int, int>>();
                for (int i = 0; i < bestMatchesList.Count; i++)
                {
                    if (i == bestMatchesList.Count - 1 || bestMatchesList[i + 1].Value != currentRelevance)
                    {
                        sortedSubset = bestMatchesList.GetRange(start, i - start + 1).OrderBy(a => a.Key).ToList();  // Sort subset by department/course number

                        for (int k = start; k < i + 1; k++) // Copies the sorted subset back into the main list 
                        {
                            bestMatchesList[k] = sortedSubset[k - start];
                        }

                        if (i != bestMatchesList.Count - 1)  // If it isn't the last element 
                        {
                            currentRelevance = bestMatchesList[i + 1].Value;
                            start = i + 1;
                        }
                    }

                }
            }

            // Need function (a factory, maybe) to generate and return a course struct from a course id. 
            // This could be done by a CourseInfo class, which acts as a database. 
            // Or maybe it should just be done by a Class constructor that accesses the database class. It is being done this way for now. 

            /////////////  Store search results in lastSearchResults  ///////////////

            lastSearchResults.courseRelevance.Clear();  // Clear the results from the last search 
            lastSearchResults.courses.Clear();          // Clear the results from the last search 

            foreach (var course in bestMatchesList) // Iterate through the courses in the search results 
            {
                if (course.Value != 0)  // This condition is probably not needed. 
                {
                    lastSearchResults.courses.Add(new Course(course.Key));  // Add the courses to lastSearchResults struct 
                    lastSearchResults.courseRelevance.Add(course.Value);    // Add the course relevances to lastSearchResults struct 
                }
                else
                    Console.WriteLine("Error!"); // Shouldn't ever happen. Could remove this later 
            }

            lastSearchResults.correctedQuery = correctedQuery; // Setting correctedQuery in the lastSearchResults struct 
            lastSearchResults.query = query;                   // Setting correctedQuery in the lastSearchResults struct 
        }

        // Corrects a given course name or course code and returns the corrected version. 
        public string Correct(string query)
        {
            return spelling.Correct(query);
        }

        // Returns the dictionary file contents
        public List<string> getDictionaryFileContents()
        {
            return spelling.getDictionaryFileContents();
        }

        // Adds all the courses to the search results
        private void addAllCourses()
        {
            lastSearchResults.courseRelevance.Clear();  // Clear the results from the last search 
            lastSearchResults.courses.Clear();          // Clear the results from the last search 

            // Add all of the courses to the search results: 
            for (int i = 0; i < CourseInfo.Create().getNumCourses(); i++)   // Was i < spelling.getDictionaryFileContents().Count
            {
                lastSearchResults.courses.Add(new Course(i));
                lastSearchResults.courseRelevance.Add(1);      // Should it be 0?  
            }
        }
    }

    public struct AdvancedOptions
    {
        public int rmp; // Rate My Professor rating 
        public string probability; // high, medium, or low
        // Put other advanced options here later 

    }

}
