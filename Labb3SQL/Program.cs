using Labb3SQL.Models;

namespace Labb3AnropaSQL
{
    internal class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                Console.Clear();
                Console.WriteLine("[Menu]");
                Console.WriteLine("[1] Show specific student"); //Labb3
                Console.WriteLine("[2] Show all students"); //Labb4
                Console.WriteLine("[3] Show a specific class"); //Labb3
                Console.WriteLine("[4] Show all Courses"); // Labb4 - Visa aktiva kurser
                Console.WriteLine("[5] Show all Employees"); // Labb4 - Antal lärare och information om lärare
                Console.WriteLine("[6] Add new Employee"); //Labb 3
                Console.WriteLine("[7] Exit program");
                Console.WriteLine("");
                Console.WriteLine("Pick a number: [1]-[7]");
                string input = Console.ReadLine();


                switch (input)
                {
                    case "1":
                        Console.Clear();
                        Methods.GetStudents();
                        break;

                    case "2":
                        Console.Clear();
                        Methods.ShowAllStudents(); 
                        break;
                  
                    case "3":
                        Console.Clear();
                        Methods.StudentInClass();
                        break;

                    case "4":
                        Console.Clear();
                        Methods.ActiveCourses();
                        break;

                    case "5":
                        Console.Clear();
                        Methods.Employees();
                        break;

                    case "6":
                        Console.Clear();
                        Methods.AddEmployee();
                        break;

                    case "7":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Error, not a valid input, try again!");
                        System.Threading.Thread.Sleep(2000);
                        break;
                }
            }
        }
    }
}

