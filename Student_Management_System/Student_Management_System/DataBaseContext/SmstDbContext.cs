using Student_Management_System.Models;
using Microsoft.EntityFrameworkCore;


namespace Student_Management_System.DataBaseContext
{
    class SmsDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=SACHINRAN-VD\SQL2017; DataBase=SMS; User Id=sa; Password=cybage@123456;");
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Student> Students { get; set; }

    }
}
