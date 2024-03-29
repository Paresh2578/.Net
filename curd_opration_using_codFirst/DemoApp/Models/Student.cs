using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DemoApp.Models
{
    public class Student
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Column("StudentName", TypeName = "varchar(100)")]
        public required string Name { get; set; }
        public int Age { get; set; }

        public string gender { get; set; }
    }
}
