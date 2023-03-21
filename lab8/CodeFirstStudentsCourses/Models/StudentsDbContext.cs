using Microsoft.EntityFrameworkCore;

namespace CodeFirstStudentsCourses.Models
{
    public class StudentsDbContext: DbContext
    {
        public StudentsDbContext(DbContextOptions<StudentsDbContext> options): base(options)
        {

        }
        public DbSet<Student> Students { get;set; }
        public DbSet<Course> Courses { get;set; }
    }
}
