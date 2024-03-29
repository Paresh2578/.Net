using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace logInAndRegisterUsingSession.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
  //      [Column("Name" , TypeName ="varchar(100)")]
        public String Name { get; set; }

        [Required]
//        [Column("Email", TypeName = "varchar(100)")]
        public String Email { get; set; }

        [Required]
       // [Column("Password", TypeName = "varchar(100)")]
        public String Password { get; set; }
    }
}
