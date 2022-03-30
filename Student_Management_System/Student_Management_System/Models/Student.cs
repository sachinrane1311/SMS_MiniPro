using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Student_Management_System.Models;

namespace Student_Management_System.Models
{
    public class Student 
    {
        [Key]
        public int studentId { get; set; }
        [Column("Course")]
        [Required(ErrorMessage = "Please Enter your Course")]
        public string course { get; set; }

        [ForeignKey("userID")]
        public virtual User user { get; set; }
    }
}
