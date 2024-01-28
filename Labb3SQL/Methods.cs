using Labb3SQL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb3AnropaSQL
{
    internal class Methods : DbContext
    {
        public static void GetStudents()
        {
            using SkolaDbContext context = new SkolaDbContext();

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

            Console.WriteLine("Press ENTER to continue.");
            Console.ReadLine();
            Console.Clear();
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

    }
}