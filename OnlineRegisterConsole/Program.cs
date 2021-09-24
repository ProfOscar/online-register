using System;
using OnlineRegisterClassLibrary;

namespace OnlineRegisterConsole
{
    class Program
    {
        const string SCRIPT_PATH = @"C:\data\onlineregister\";
        static DbTools db = new DbTools(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\data\onlineregister\register.mdf;Integrated Security=True;Connect Timeout=30");
        
        static void Main(string[] args)
        {
            Console.Title = "Online Register";
            char choice = ' ';
            do
            {
                Console.WriteLine("*** ONLINE REGISTER BY VALLAURI ***\n");
                Console.WriteLine("1 - Initialize Student");
                Console.WriteLine("2 - ");
                Console.WriteLine("3 - ");
                Console.WriteLine("4 - ");
                Console.WriteLine("----------------");
                Console.WriteLine("5 - View Data");
                Console.WriteLine("----------------");
                Console.WriteLine("B - Backup Data");
                Console.WriteLine("T - Restore Data");
                Console.WriteLine("R - Reset Data");
                Console.WriteLine("----------------");
                Console.WriteLine("X - EXIT\n");
                choice = Console.ReadKey(true).KeyChar;
                switch (choice)
                {
                    case '1':
                        // Console.WriteLine("Call student list");
                        InitializeStudent();
                        break;
                    case '2':
                        Console.WriteLine("Call class list");
                        break;
                    case '5':
                        ViewData();
                        break;
                    default:
                        Console.WriteLine("Work in progress");
                        break;
                }
            } while (choice != 'X' && choice != 'x');
        }

        private static void InitializeStudent()
        {
            Console.Write("\n*** INITIALIZE STUDENT TABLE ***\n");
            Console.WriteLine(db.ExecuteSqlScript(SCRIPT_PATH + "StudentCreateTable.sql"));
            Console.Write(db.ExecuteSqlScript(SCRIPT_PATH + "StudentInsert.sql"));
            Console.Write("\n****************\n\n");
        }

        public static void ViewData()
        {
            Console.Write("\n*** STUDENTS ***\n");
            Console.Write(db.GetTableList("Student"));
            Console.Write("****************\n\n");
        }
    }
}
