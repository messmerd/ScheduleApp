using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using CourseClass;
using SearchClass; 
using CourseInfoClass;
using SpellingCorrector;
using System.Windows.Forms;

public class Program
{

    static void Main(string[] args)
    {
        CourseInfo.DB.Create();  // Creates CourseInfo singleton
        Search search = SearchClass.Search.Create("course_dictionary.txt");

        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new ScheduleApp.AppWindow());
        
        
        // This code is for testing the course search and spell-checking features 

        // Creates an instance of the Search class using course_dictionary.txt for spell-checking and mini course database 
        //Search search = new Search("course_dictionary.txt");

        Console.WriteLine("Type a course name or course code and press Enter to search for it. \nType 'exit' to exit.\n ");

        string query = "-1";
        List<Course> searchResults;
        int i = 0;

        // This code is for manually testing the search function and spell-checking 
        while (query.ToLower() != "exit")
        {
            query = Console.ReadLine();
            Console.WriteLine();
            if (query.ToLower() == "exit")
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
                    Console.WriteLine("CourseID = {0}, relevance = {1}, name = {2}", match.getCourseID(), search.lastSearchResults.getCourseRelevance()[i],search.getDictionaryFileContents()[match.getCourseID()]);
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

public class CourseList 
{
    public List<Course> courses;         // Courses ordered from most relevant to least 
    public List<Course> courses_ordered; // Courses ordered in a certain way 
    public string query;                 // The query passed to searchForQuery()
    public string correctedQuery;        // The spell-checked version of query
    public List<int> courseRelevance;    // Stores the relevance of each course in the results. courseRelevance[i] = relevance of courses[i] 

    public CourseList()
    {
        this.query = "";
        this.correctedQuery = "";
        this.courses = new List<Course>();
        this.courses_ordered = new List<Course>();
        this.courseRelevance = new List<int>();
    }


    // Getters: 
    public List<Course> getCourses()
    {
        return courses;
    }
    public List<Course> getCoursesOrdered()
    {
        return courses_ordered;
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
