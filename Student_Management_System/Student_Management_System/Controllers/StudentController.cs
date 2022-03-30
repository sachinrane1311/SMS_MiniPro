using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Student_Management_System.DataBaseContext;
using Student_Management_System.Models;

namespace Student_Management_System.Controllers
{
    public class StudentController
    {
        internal void StudentRole()
        {

            SmsDbContext ctx = new SmsDbContext();
            User user = new User();
            Console.WriteLine("-----------------------------");
            Console.WriteLine(" Welcome " + user.name + " !!!");
            Console.WriteLine(" You've Logged in as a Admin !");
            Boolean flag = true;
            while (flag)
            {

            Console.WriteLine("-----------------------------");

            Console.WriteLine("1-showDetails\n2-updateDetails\n3-Logout");
            
            Console.WriteLine("-----------------------------");

                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.WriteLine("Show Details");
                       // showDetails();
                        break;

                    case 2:
                        Console.WriteLine("Update Details");
                        updateDetails();
                        break;

                    case 3:
                        Console.WriteLine("Logout !!!");
                        flag = false;
                        break;

                }

            }
        }


        private void updateDetails()
        {
            Console.WriteLine("------ Update Student ------");
            Console.WriteLine("Enter ID :");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("New Password :");
            String newPassword = Console.ReadLine();
            Console.WriteLine("New Course :");
            String newCourse = Console.ReadLine();

            SmsDbContext ctx = new();
            User usr = ctx.Users.Find(id);
            Student stud = ctx.Students.Find(id);

            usr.password = newPassword;
            stud.course = newCourse;

            ctx.Students.Update(stud);
            ctx.Users.Update(usr);
            ctx.SaveChanges();

            Console.WriteLine("------------------------");
            Console.WriteLine(usr.name + " updated !!!!");
            Console.WriteLine("------------------------");
        }

    }

}
