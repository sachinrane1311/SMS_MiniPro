using Student_Management_System.DataBaseContext;
using Student_Management_System.Models;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Student_Management_System.Controllers
{
    class AdminController
    {
        public static void AdminRole()
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine(" Welcome Admin !!!");
            Console.WriteLine(" You've Logged in as a Admin !");
            Boolean flag = true;
            while (flag)
            {
                Console.WriteLine("-----------------------------");


                Console.WriteLine("1-Add_Student\n2-Delete_Student\n3-Update_Student\n4-Show_All_Students\n5-Logout");
                Console.WriteLine("-----------------------------");

                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        addStudent();
                        break;

                    case 2:
                        deleteStudent();
                        break;

                    case 3:
                        updateStudent();
                        break;

                    case 4:
                        showAll();
                        break;

                    case 5:
                        Console.WriteLine("Logout !!!");
                        Console.WriteLine("==============================");
                        flag = false;
                        break;

                }
            }
        }

        private static void showAll()
        {
            Console.WriteLine("--------- All Users Data ---------");

            SmsDbContext ctx = new SmsDbContext();
            List<User> usrs = ctx.Users.ToList();
            List<Student> stds = ctx.Students.ToList();

            foreach (User u in usrs)
            {
                foreach (Student s in stds)
                {
                    if (u.userID==s.studentId)
                    Console.WriteLine($"{u.userID} {u.name} {u.email} {s.course}"); 
                }

            }
            
            Console.WriteLine("----------------------------------");
        }

        private static void updateStudent()
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

        private static void deleteStudent()
        {
            Console.WriteLine("------ Delete Student ------");
            Console.WriteLine("Enter ID :");
            int id = Convert.ToInt32(Console.ReadLine());

            SmsDbContext ctx = new();
            User usr = ctx.Users.Find(id);
            Student stud = ctx.Students.Find(id);

            ctx.Users.Remove(usr);
            ctx.Students.Remove(stud);
            ctx.SaveChanges();

            Console.WriteLine("-----------------------------");
            Console.WriteLine(usr.name+"  Student  Deleted  ");
            Console.WriteLine("-----------------------------");
        }

        private static void addStudent()
        {
            Console.WriteLine("------- Add Student ------");
            Console.Write("Name : ");
            String studentName = Console.ReadLine();
            Console.Write("Email : ");
            String studentEmail = Console.ReadLine();
            Console.Write("Password : ");
            String studentPassword = Console.ReadLine();
            Console.Write("Course : ");
            String course = Console.ReadLine();
            Console.WriteLine("--------------------------");


            SmsDbContext ctx = new SmsDbContext();

            Student stud = new Student();
            User user = new User();

            user.name = studentName;
            user.email = studentEmail;
            user.password = studentPassword;
            user.role = "Student";
            user.student.course = course;

            user.student = stud;
            ctx.Users.Add(user);
            ctx.Students.Add(stud);

            ctx.SaveChanges();

            Console.WriteLine("-----------------------------");
            Console.WriteLine(studentName + " Added to SMS !!!");
            Console.WriteLine("-----------------------------");
        }


        public void AddAdmin()
        {
            SmsDbContext ctx = new SmsDbContext();
            Student NA = new Student();
            User admn = new User();
            admn.name = "admin";
            admn.email = "admin@gmail.com";
            admn.password = "12345";
            admn.role = "Admin";
            NA.course = "-";
            admn.student = NA;
            ctx.Users.Add(admn);
            ctx.Students.Add(NA);
            ctx.SaveChanges();
        }
    }
}