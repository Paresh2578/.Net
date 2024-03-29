visuusing Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DemoApp.Models
{
    public class StudentDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {
        }
    }
}
