using System;
using System.Data.SqlClient;

namespace OnlineRegisterConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Online Register";
            char choice = ' ';
            do
            {
                Console.WriteLine("\n*** ONLINE REGISTER BY VALLAURI ***");
                Console.WriteLine("1 - Student List");
                Console.WriteLine("2 - Class List");
                Console.WriteLine("3 - ");
                Console.WriteLine("4 - ");
                Console.WriteLine("5 - ");
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
                        StudentList();
                        break;
                    case '2':
                        Console.WriteLine("Call class list");
                        break;
                    default:
                        Console.WriteLine("Work in progress");
                        break;
                }
            } while (choice != 'X' && choice != 'x');
        }

        public static void StudentList()
        {
            string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\data\onlineregister\register.mdf;Integrated Security=True;Connect Timeout=30";
            using (SqlConnection dbConn = new SqlConnection(connStr))
            {
                using (SqlCommand dbCmd = new SqlCommand("SELECT * FROM Student;", dbConn))
                {
                    dbConn.Open();
                    using (SqlDataReader dbReader = dbCmd.ExecuteReader())
                    {
                        while (dbReader.Read())
                        {
                            Console.WriteLine(dbReader.GetString(1) + " - " + dbReader.GetString(2));
                        }
                    }
                }
            }
        }
    }
}
