using System;
using System.Collections.Generic;
using System.Linq;
using Student_Management_System.Models;
using Student_Management_System.DataBaseContext;


namespace Student_Management_System.Controllers
{
    class UserController
    {
        public void userLogin()
        {
            Console.WriteLine("-------User's Login -------");
                Console.Write("Email : ");
                String email = Console.ReadLine();
                Console.Write("Password : ");
                String password = Console.ReadLine();
            Console.WriteLine("---------------------------");


            SmsDbContext dbctx = new SmsDbContext();
            List<User> userList = dbctx.Users.ToList();
            User searchedUser = new User();

            foreach (User u in userList)
            {
                if (u.email == email && u.password == password) 
                    searchedUser = u;
            }

            if (searchedUser != null)
            {
                if (searchedUser.role == "Student")
                {
                    StudentController studentControl = new StudentController();
                    studentControl.StudentRole();
                }
                else if (searchedUser.role == "Admin")
                {
                    AdminController.AdminRole();
                }
                else Console.WriteLine("Invalid Credentials !!!");
            }
            else Console.WriteLine("User Not Found !!!");

        }

        public void userRegistration()
        {
            Console.WriteLine("------- Student's Registration ------");
                Console.Write("Name : ");
                String studentName = Console.ReadLine();
                Console.Write("Email : ");
                String studentEmail = Console.ReadLine();
                Console.Write("Password : ");
                String studentPassword = Console.ReadLine();
                Console.Write("Course : ");
                String course = Console.ReadLine();
            Console.WriteLine("-------------------------------------");


            SmsDbContext ctx = new SmsDbContext();

            Student stud = new Student();
            User user = new User();

            user.name = studentName;
            user.email = studentEmail;
            user.password = studentPassword;
            user.role = "Student";
            
            stud.course = course;
            user.student = stud;

            ctx.Users.Add(user);
            ctx.Students.Add(stud);
            ctx.SaveChanges();


            Console.WriteLine("-----------------------------");
            Console.WriteLine(studentName + " registered !!!");
            Console.WriteLine("-----------------------------");
        }

    }
}