using ManagingTrainees_TracksAndCourses.Models;
using ManagingTrainees_TracksAndCourses.RepoServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ManagingTrainees_TracksAndCourses.Data;

namespace ManagingTrainees_TracksAndCourses
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("myConn") ?? throw new InvalidOperationException("Connection string 'myConn' not found.");

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<MainDbContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("myConn")));
            builder.Services.AddDbContext<ManagingTrainees_TracksAndCoursesContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("ManagingTrainees_TracksAndCoursesContextConnection"))
            );

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ManagingTrainees_TracksAndCoursesContext>();


            //DI Container ==> Create & inject services
            //anyone request service of type "ITraineeRepository"
            //create & inject obj of type "TraineeRepoService" , with Scoped lifetime
            builder.Services.AddScoped<ITraineeRepository, TraineeRepoService>();
            builder.Services.AddScoped<ITrackRepository, TrackRepoService>();
            builder.Services.AddScoped<ICourseRepository, CourseRepoService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
             
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            // to enable login partial view
            app.MapRazorPages();
            app.Run();
        }
    }
}