using System;
using Student_Management_System.Controllers;

namespace Student_Management_System
{
    class Program
    {
        static void Main(string[] args)
        {
            //AdminController admn = new AdminController();
            //admn.AddAdmin();
        startpoint:

            Console.Clear();
            Console.WriteLine("==========================================");
            Console.WriteLine("|   Welcome to SMS by project group 10   |");
            while (true)
            {
                Console.WriteLine("==========================================");
                Console.WriteLine(" 1-Login \n 2-Registration \n 0-Refresh");
                Console.WriteLine("==========================================");

                int option = Convert.ToInt32(Console.ReadLine());

                UserController userControl = new UserController();

                switch (option)
                {
                    case 1:
                        userControl.userLogin();
                        break;

                    case 2:
                        userControl.userRegistration();
                        break;

                    case 0:
                        goto startpoint;

                    default:
                        Console.WriteLine("Wrong Choice!!!");
                        break;
                }
            }

        }
    }
}
