using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ManagingTrainees_TracksAndCourses.Models
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options): base(options)
        {

        }
        public DbSet<Track> Tracks { get;set; }
        public DbSet<Trainee> Trainees { get;set; }
        public DbSet<Course> Courses { get;set; }
        //public DbSet<TraineeCourse> TraineeCourses { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //modelBuilder.Entity<TraineeCourse>()
        //    //            .HasKey(tc => new { tc.TraineeID, tc.CourseID });
        //}
    }
}
