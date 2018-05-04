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
            CourseInfo database = CourseInfo.Create("course_database.txt", "rmp_database.txt");  // Creates CourseInfo singleton
            Search search = Search.Create("course_dictionary.txt");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ScheduleApp.AppWindow());

            UnitTests test = new UnitTests();

            // This code is for testing the course search and spell-checking features 

            // Creates an instance of the Search class using course_dictionary.txt for spell-checking and mini course database 
            //Search search = new Search("course_dictionary.txt");

            Console.WriteLine("Running Test 1...\n ");
            printSuccess(test.test1());
            Console.WriteLine("Running Test 2...\n ");
            printSuccess(test.test2());
            Console.WriteLine("Running Test 3...\n ");
            printSuccess(test.test3());
           
        }

        static void printSuccess(bool success)
        {
            if (success)
            {
                Console.WriteLine("The Test was Successful\n");
            }
            else
            {
                Console.WriteLine("ERROR: Something went wrong and the test Failed\n");
            }
        }
    }

}