using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static C__Advanced.Day1;

namespace C__Advanced
{
    internal class Day1
    {
        public static void Main(string[] args) 
        
        {
            // Finding duplicates in the char array - using hashset and list to compare.

            char[] charArray = { 'a', 'b', 'c', 'a', 'd', 'e', 'b', 'b', 'e', 'e' };
            List<char> duplicates = DuplicateFinder.FindDuplicates(charArray);

            foreach (char c in duplicates)
            {
                Console.WriteLine(c); // Output: a, b, e --> show only one of the duplicates (even its more)
            }

            // Make another function only with arrays.

            DuplicateFinder.FindDuplicatesOnlyWithArray(charArray);

            // do something with jagged arrays

            //boxing and unboxing arraylist

            //do something with list and dictonaries

            // --> get a person by ID

            /*
            The Assignment:
            Create a list object named courses to store instances of the Course class. Initialize it with at least four different courses.
            Create a list object named students to store instances of the Student class. Initialize it with at least four different students.*/
            /*

            Enrollment:
            Enroll students in courses by adding courses to their respective Courses list. Each student should be enrolled in at least two courses.
            Ensure that each course can have multiple students enrolled in it.
            
             Display:
            Display the enrollment details by iterating over each student and printing their name along with the courses they are enrolled in.
            Sample code to get start
             
            */

            // Create a list of courses
            List<Course> courses = new List<Course>
             {
                new Course("Introduction to Programming", 123),
                new Course("Data Structures and Algorithms", 456),
                new Course("Database Systems", 789),
                new Course("Software Engineering", 101112)
            };

            // Create a list of students
            List<Student> students = new List<Student>
            {
                new Student("John Doe", 20),
                new Student("Jane Smith", 21),
                new Student("Michael Johnson",22),
                new Student("Emily Davis", 23)
            };

            students[0].Courses.Add(courses[0]);
            students[0].Courses.Add(courses[2]);

            students[1].Courses.Add(courses[1]);
            students[1].Courses.Add(courses[3]);

            students[2].Courses.Add(courses[0]);
            students[2].Courses.Add(courses[1]);

            students[3].Courses.Add(courses[3]);
            students[3].Courses.Add(courses[0]);

            Console.WriteLine("Our Courses are...");
            int i = 1;


            foreach (Course course1 in courses)
            {
                Console.WriteLine($"Course{i++}: {course1.CourseName} / CourseID: {course1.CourseId}");
            }

            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("The students have chosen...");
            Console.WriteLine("");
            
            foreach (Student stud in students)
            {
                Console.WriteLine($"Name: {stud.Name} / ID: {stud.StudentId}");
                foreach (Course studCourseList in stud.Courses)
                {
                    Console.WriteLine($"{stud.Name} in course: {studCourseList.CourseName} / ID: {studCourseList.CourseId}");
                }
            }

            Console.WriteLine("------------------------------------------------");

        }

        public class Student
        {
            public int StudentId { get; set; }
            public string Name { get; set; }
            public List<Course> Courses { get; set; }

            public Student(string name, int id)
            {
                StudentId = id;
                Name = name;
                Courses = new List<Course>();
            }

        }
        public class Course
        {
            public int CourseId { get; set; }
            public string CourseName { get; set; }

            public Course(string name, int id)
            {
                CourseName = name;
                CourseId = id;
            }

        }


    }
}

