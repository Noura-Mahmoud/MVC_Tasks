using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ManagingTrainees_TracksAndCourses.Data;

public class ManagingTrainees_TracksAndCoursesContext : IdentityDbContext<IdentityUser>
{
    public ManagingTrainees_TracksAndCoursesContext(DbContextOptions<ManagingTrainees_TracksAndCoursesContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
