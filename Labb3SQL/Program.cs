namespace Labb3AnropaSQL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello and welcome to the School Menu!");

            while (true)
            {
                Console.WriteLine("[Menu]");
                Console.WriteLine("[1] Show students");
                Console.WriteLine("[2] Show a specific class");
                Console.WriteLine("[3] Add new Employee");
                Console.WriteLine("[4] Exit program");
                Console.WriteLine("");
                Console.WriteLine("Pick a number: [1]-[4]");
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
                        Methods.AddEmployee();
                        break;

                    case "4":
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

