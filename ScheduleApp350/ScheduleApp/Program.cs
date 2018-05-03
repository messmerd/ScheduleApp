using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using SpellingCorrector;
using System.Windows.Forms;

namespace ScheduleApp
{
    //Class that physically runs the program
    public class Program
    {
        [STAThreadAttribute]
        static void Main(string[] args)
        {
            CourseInfo database = CourseInfo.Create("course_database.txt");  // Creates CourseInfo singleton
            Search search = Search.Create("course_dictionary.txt");

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
                search.lastSearchResults.SortCourses(SORTTYPE.RELEVANCY, false);
                searchResults = search.lastSearchResults.getCourses();

                if (searchResults.Count != 0)
                {
                    i = 0;
                    if (search.lastSearchResults.getCorrectedQuery() != query.ToLower())  // If your query had a spelling mistake
                        Console.WriteLine("Did you mean {0}?", search.lastSearchResults.getCorrectedQuery());
                    Console.WriteLine("Top 20 search results for {0}, ordered by best match: ", query);
                    foreach (var match in searchResults)
                    {
                        Console.WriteLine("ID = {0}, relevance = {1}, name = {2}, StartTime = {3}", match.getCourseID(), search.lastSearchResults.getCourseRelevance(match.getCourseID()), search.lastSearchResults.getCourses()[i].getLongName(), search.lastSearchResults.getCourses()[i].getTime().Item1);  //  search.getDictionaryFileContents()[match.getCourseID()]
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

}