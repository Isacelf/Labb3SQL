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
                Console.WriteLine("[1] Show students"); //Labb3
                Console.WriteLine("[2] Show a specific class"); //Labb3
                Console.WriteLine("[3] Show all Courses"); // Ny - Visa aktiva kurser
                Console.WriteLine("[4] Show all Employees"); // Ny - Antal lärare och information om lärare
                Console.WriteLine("[5] Add new Employee"); //Labb 3
                Console.WriteLine("[6] Exit program");
                Console.WriteLine("");
                Console.WriteLine("Pick a number: [1]-[6]");
                string input = Console.ReadLine();


                switch (input)
                {
                    case "1":
                        Console.Clear();
                        Methods.GetStudents();
                        break;

                    case "2":
                        Console.Clear();
                        Methods.StudentInClass();
                        break;

                    case "3":
                        Console.Clear();
                        Methods.ActiveCourses();
                        break;

                    case "4":
                        Console.Clear();
                        Methods.Employees();
                        break;

                    case "5":
                        Console.Clear();
                        Methods.AddEmployee();
                        break;

                    case "6":
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

