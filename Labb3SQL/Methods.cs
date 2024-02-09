using Labb3SQL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Labb3AnropaSQL
{
    internal class Methods : DbContext
    {
       
        public static void GetStudents()
        {
            using SkolaDbContext context = new SkolaDbContext();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Select an option:");
                Console.WriteLine("[1] Sort and display students");
                Console.WriteLine("[2] Select a specific student by StudentID");
                Console.WriteLine("[3] Show all students and their information");
                Console.WriteLine("[4] Go back to main menu");

                string userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "1":
                        SortAndDisplayStudents(context);
                        break;
                    case "2":
                        SelectSpecificStudent(context);
                        break;
                    case "3":
                        ShowAllStudents(context);
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again!");
                        break;
                }

                Console.WriteLine("Press ENTER to continue.");
                Console.ReadLine();
            }
        }
    

    public static void SortAndDisplayStudents(SkolaDbContext context)
    {
        Console.Clear();
        Console.WriteLine("Select how to sort students:");
        Console.WriteLine("[1] First Name");
        Console.WriteLine("[2] Last Name");

        string sortBy = Console.ReadLine();

        Console.Clear();
        Console.WriteLine("Select sorting order:");
        Console.WriteLine("[1] Ascending");
        Console.WriteLine("[2] Descending");

        string sortOrder = Console.ReadLine();

        var sortedStudents = sortBy switch
        {
            "1" => sortOrder == "1" ?
                    context.Students.OrderBy(s => s.Förnamn) :
                    context.Students.OrderByDescending(s => s.Förnamn),

            "2" => sortOrder == "1" ?
                    context.Students.OrderBy(s => s.Efternamn) :
                    context.Students.OrderByDescending(s => s.Efternamn),

            _ => null
        };

        if (sortedStudents != null)
        {
            Console.Clear();
            Console.WriteLine($"Students sorted by {(sortBy == "1" ? "first name" : "last name")} in {(sortOrder == "1" ? "ascending" : "descending")} order:\n");

            foreach (var student in sortedStudents)
            {
                Console.WriteLine($"{student.Förnamn} {student.Efternamn}\nStudentID: {student.ElevId}\n");
            }
        }
        else
        {
            Console.WriteLine("Invalid choice. Try again!");
        }
    }

    public static void SelectSpecificStudent(SkolaDbContext context)
        {
            Console.WriteLine("Select a student by entering StudentID:");
            if (int.TryParse(Console.ReadLine(), out int selectedStudentId))
            {
                var selectedStudent = context.Students.FirstOrDefault(s => s.ElevId == selectedStudentId);
                if (selectedStudent != null)
                {
                    Console.Clear();
                    Console.WriteLine($"Summary for student {selectedStudent.Förnamn} {selectedStudent.Efternamn} (StudentID: {selectedStudent.ElevId}):");
                    Console.WriteLine($"Class: {selectedStudent.Klassnamn}");
                    Console.WriteLine($"Social security number: {selectedStudent.Personnummer}");

                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Invalid student ID. Try again!");
                }
            }
            else
            {
                Console.WriteLine("Invalid input for student ID.");
            }
        }

        public static void ShowAllStudents(SkolaDbContext context)
        {
            Console.Clear();
            Console.WriteLine("All students and their information:\n");

            foreach (var student in context.Students)
            {
                Console.WriteLine($"Student: {student.Förnamn} {student.Efternamn}");
                Console.WriteLine($"StudentID: {student.ElevId}");
                Console.WriteLine($"Class: {student.Klassnamn}");
                Console.WriteLine($"Social security number: {student.Personnummer}");
                Console.WriteLine();
            }
        }


        public static void StudentInClass()
        {
            using SkolaDbContext context = new SkolaDbContext();

            Console.Clear();
            Console.WriteLine("Here are all the different classes");

            var distinctClass = context.Students.GroupBy(s => s.Klassnamn).Select(group => group.First());

            int classIndex = 1;
            foreach (Student item in distinctClass)
            {
                Console.WriteLine($"[{classIndex}]. {item.Klassnamn}");
                classIndex++;
            }

            Console.WriteLine("Pick a class by selecting a number");
            if (int.TryParse(Console.ReadLine(), out int selectedClassIndex) && selectedClassIndex >= 1 && selectedClassIndex <= 3)
            {
                var selectedClass = distinctClass.Skip(selectedClassIndex - 1).First().Klassnamn;
                var studentsInSelectedClass = context.Students.Where(s => s.Klassnamn == selectedClass);

                Console.Clear();
                Console.WriteLine($"Students in the class {selectedClass}\n");
                foreach (Student s in studentsInSelectedClass)
                {
                    Console.WriteLine($"{s.Förnamn} {s.Efternamn}\nStudentID: {s.ElevId}\n");
                }
            }
            else
            {
                Console.WriteLine("Invalid input");
            }

            Console.WriteLine("Press ENTER to continue.");
            Console.ReadLine();
            Console.Clear();
        }


        public static void AddEmployee()
        {
            using SkolaDbContext context = new SkolaDbContext();

            Console.WriteLine("New information about the employee");
            Console.Write("Name: ");
            string Name = Console.ReadLine();

            Console.WriteLine("Enter the Social Security Number");
            Console.Write("Number: ");
            string SocialSecurityNumber = Console.ReadLine();

            Console.WriteLine("PositionID, 1-4");
            Console.WriteLine("PositionID 1: Principal");
            Console.WriteLine("PositionID 2: Teacher");
            Console.WriteLine("PositionID 3: Cleaner");
            Console.WriteLine("PositionID 4: Chef");


            int PositionID = int.Parse(Console.ReadLine());

            Personal newTeacher = new Personal
            {
                Namn = Name,
                Personnummer = SocialSecurityNumber,
                BefattningsId = PositionID

            };

            context.Personals.Add(newTeacher);
            context.SaveChanges();


            Console.WriteLine("New teacher has been added to the database.");
            Console.WriteLine($"Summary: {Name} (SSN: {SocialSecurityNumber}) has been assigned the position with PositionID: {PositionID}.");

            Console.WriteLine("Press ENTER to continue.");
            Console.ReadLine();
            Console.Clear();
        }

        public static void ActiveCourses() 
        {
            using SkolaDbContext context = new SkolaDbContext();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("[1] Show active courses");
                Console.WriteLine("[2] Exit");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        {
                            Console.Clear();
                            var activeCourses = context.Kurs.OrderBy(k => k.Kursnamn).ToList();
                            Console.WriteLine("Active Courses:");
                            Console.WriteLine(new string('*', 50));
                            foreach (var course in activeCourses)
                            {
                                Console.WriteLine($"ID: {course.KursId}");
                                Console.WriteLine($"Course Name: {course.Kursnamn}");
                                Console.WriteLine(new string('-', 50));
                            }
                        }
                        break;

                    case "2":
                        Console.WriteLine("Exiting");
                        return;
                }
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();


            }

        }

        public static void Employees() 
        {
            using SkolaDbContext context = new SkolaDbContext();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose department to show the amount of employees");
                Console.WriteLine("[1] Teachers");
                Console.WriteLine("[2] Principals");
                Console.WriteLine("[3] Cleaners");
                Console.WriteLine("[4] Chefs");
                Console.WriteLine("[5] Exit");

                Console.Write("Enter your choice: ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        {
                            Console.Clear();
                            Console.WriteLine("Number of Teachers employees:");
                            int personCount1 = context.Personals.Count(t => t.BefattningsId == 2); 
                            Console.WriteLine($"There are currently {personCount1} Teachers Employed.");
                        }
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("Number of Principals employees:");
                        int personCount2 = context.Personals.Count(t => t.BefattningsId == 1); 
                        Console.WriteLine($"There are currently {personCount2} Principals Employed.");
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine("Number of Cleaners employees:");
                        int personCount3 = context.Personals.Count(t => t.BefattningsId == 3); 
                        Console.WriteLine($"There are currently {personCount3} Cleaners Employed.");
                        break;

                    case "4":
                        Console.Clear();
                        Console.WriteLine("Number of Chefs employees:");
                        int personCount4 = context.Personals.Count(t => t.BefattningsId == 4);
                        Console.WriteLine($"There are currently {personCount4} Chefs Employed.");
                        break;

                    case "5":
                        Console.WriteLine("Exiting");
                        return;
                }

                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            }
        }
    }
}