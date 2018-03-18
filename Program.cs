using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using SpellingCorrector;

public class Program
{

    static void Main(string[] args)
    {
        // This code is for testing the course search and spell-checking features 

        // Creates an instance of the Search class using course_dictionary.txt for spell-checking and mini course database 
        Search search = new Search("course_dictionary.txt");

        Console.WriteLine("Type a course name or course code and press Enter to search for it. \nPress Enter without typing anything to exit.\n ");

        string query = " ";
        List<Course> searchResults;
        int i = 0;

        // This code is for 
        while (query.Length != 0)
        {
            query = Console.ReadLine();
            Console.WriteLine();
            if (query.Length == 0)
                break;
            search.searchForQuery(query);
            searchResults = search.lastSearchResults.getCourses();

            if (searchResults.Count != 0)
            {
                i = 0;
                if (search.lastSearchResults.getCorrectedQuery() != query.ToLower())  // If your query had a spelling mistake
                    Console.WriteLine("Did you mean {0}?", search.lastSearchResults.getCorrectedQuery());
                Console.WriteLine("Top 20 search results for {0}, ordered by best match: ", query);
                foreach (var match in searchResults)
                {
                    Console.WriteLine("CourseID = {0}, relevance = {1}", match.getCourseID(), search.lastSearchResults.getCourseRelevance()[i]);
                    if (i == 19) { break; }  // Only show top 20 search results
                    i++;
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No course was found for the query {0}. \n", query);
            }
        }

    }

}



public class Search
{
    private advancedOptions options;   // For storing advanced search options 
    private Spelling spelling;         // Instance of Spelling object from Spelling.cs 
    private string courseDictionary;   // Stores course dictionary filename for use by spellchecker and course search 
    public results lastSearchResults;  // Stores the search results after using searchForQuery()

    public struct results
    {
        public List<Course> courses;       // Courses ordered from most relevant to least 
        public string query;               // The query passed to searchForQuery()
        public string correctedQuery;      // The spell-checked version of query
        public List<int> courseRelevance;  // Stores the relevance of each course in the results. courseRelevance[i] = relevance of courses[i] 

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

    }

    private struct advancedOptions
    {
        public int rmp; // Rate My Professor rating 
        // Put other advanced options here later 
    }

    public Search()  // Constructor 
    {
        this.spelling = new Spelling("course_dictionary.txt");
        this.courseDictionary = "course_dictionary.txt";

        this.lastSearchResults.query = "";
        this.lastSearchResults.correctedQuery = "";
        this.lastSearchResults.courses = new List<Course>();
        this.lastSearchResults.courseRelevance = new List<int>();

        this.options.rmp = 0; // Rate my professor rating
        // Other advanced options will go here 
    }

    public Search(string courseDictionary)  // Constructor 
    {
        this.spelling = new Spelling(courseDictionary);
        this.courseDictionary = courseDictionary;

        this.lastSearchResults.query = "";
        this.lastSearchResults.correctedQuery = "";
        this.lastSearchResults.courses = new List<Course>();
        this.lastSearchResults.courseRelevance = new List<int>();

        this.options.rmp = 0;  // Rate my professor rating 
        // Other advanced options will go here.
    }

    // This function creates a list of Courses that match a given query or are close enough to be recognized by the spell-checker. 
    // It also creates a string containing the spell-checked version of the user's query. 
    // All these search results are placed in the lastSearchResults struct, which can be accessed using the getters. 
    // The query can be a course name or course code. The results are organized from best match to worst. Courses that don't match at all are not included. 
    public void searchForQuery(string query)
    {
        string correctedQuery = "";   // Stores the spell-checked version of the user's query. 
        List<List<int>> matching = new List<List<int>>();    // A list where each index represents a word in the query. For each word, there is a list of ints. These ints are the course IDs of courses containing that word in their name or course code. 
        Dictionary<int, int> bestMatches = new Dictionary<int, int>(); // Maps course IDs to their relevance (how many of the words in the query match words in the course title or course code)
        KeyValuePair<string, List<int>> result = new KeyValuePair<string, List<int>>(); // Stores the results from the spellchecker

        List<string> querySplit = query.Split().ToList();
        List<int> temp = new List<int>();

        foreach (var word in querySplit)
        {
            // Needs tweaked:    ? 
            if (word.Length > 4 || (querySplit.Count == 1 && word.Length > 2))   // Doesn't correct words smaller than 5 characters, unless it's a single word query. Doing so could lead to bad search results. 
                result = spelling.CorrectExt(word, true);
            else
                result = spelling.CorrectExt(word, false);

            // For single letter queries, list classes whose first letter in course name/code matches letter? 

            correctedQuery += result.Key;
            if (word != querySplit.Last())
                correctedQuery += " ";

            temp.Clear();
            foreach (var item in result.Value)
            {
                temp.Add(item);
            }

            matching.Add(temp);
            if (matching.Last().Count != 0)
                matching.Last().RemoveAt(0);
        }

        foreach (var match in matching)  // For each word of corrected query 
        {
            foreach (var id in match)    // For each course ID of courses that contain the corrected query word in their title or course code 
            {
                if (bestMatches.ContainsKey(id))
                {
                    bestMatches[id]++;  // Increment the number of matching words for the course "id"  
                    // If it matches the department code rather than just part of the course title, maybe the relevance should be increased an extra amount for better results?   
                }
                else
                {
                    bestMatches[id] = 1; // This course has one matching word 
                }
                // Note: Courses whose titles or course codes match more words of the corrected query have a higher "relevance" and will appear at the top of search results. 
            }
        }

        var bestMatchesList = bestMatches.ToList();
        bestMatchesList.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));  // Sorts the courses by relevance. Most relevant first. 

        // Need function (a factory, maybe) to generate and return a course struct from a course id. 
        // This could be done by a CourseInfo class, which acts as a database. 
        // Or maybe it should just be done by a Class constructor that accesses the database class. It is being done this way for now. 

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

}

public struct Course
{
    private int courseID;
    private string courseName;
    // Other attributes of the course go here

    public Course(int courseID)  // Constructor
    {
        this.courseID = courseID;
        //  ... (other Class attributes to be set here)
        this.courseName = "<course name>";  // Temporary, of course
        // We need to have a Course Database class that contains a function (a factory?) which helps create Course structs from course IDs. 

    }

    public string getCourseName()
    {
        return courseName;
    }

    public int getCourseID()  // Note: courseID is NOT the same as courseCode 
    {
        return courseID;
    }

}

