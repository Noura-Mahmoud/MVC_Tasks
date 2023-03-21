<br />
<div align="center">
  
  <h3 align="center">MVC task 9 </h3>

</div>

## Task Requirements
<br/>

## Create ASP.NetCore MVC webApp which manages Trainees and thier Tracks and Courses:
- Create All CRUD operations to manage your application
    - Use EF_Core Code First to create TraineesDB
    - Use Repositories and apply custom-servive-injection in your application 
    - Use TagHelpers in your views : &lt;environment&gt; , &lt;Partial&gt;
    - Use _layout page as a master template for your application
    - Try to make your webApp have a nice look by applying different styles and bootstrap, use:"Styling & Bundling"
    - Use client-side packages to apply Validation on your application
    - Try to use "_ViewStart & _ViewImport"
- Apply UI "User Identity" in your application (at least "Register,Login, Logout")
    - Try to Display Environment Variable data in any View using @inject

Track shoud have the following properties:
- ID
- Name
- Description
- 1 Track:M Trainees


Trainee shoud have the following properties:
- ID
- Name
- Gender
- email
- MobileNo
- Birthdate
- 1 Trainee: M courses

Course shoud have the following properties:
- ID
- Topic
- Grade
- 1 Trainee: M Courses

 Note: Apply data annotation on your classes 

<hr>

## Steps

1. Create *ASP.NET Core Web App (Model-View-Controller)* project
2. To Display Environment Variable data in any View using @inject:
    - Add 
    ```C#
    @inject Microsoft.AspNetCore.Hosting.IWebHostEnvironment envInject
    ```
    in the view (Home/Index) in which wou want to diaplay Environment name, and add it in a tag to display

3. We need to add our classes with proper data annotation in *Models* folder

4. From *NuGet package manager*, install *Microsoft.EntityFrameworkCore.SqlServer* version **7.0.4** and *Microsoft.EntityFrameworkCore.Tools* same version

5. Create *MainDbContext* file, which inherits from DbContext and pass the *DbContextOptions* to the base, then add the *DbSet* of Students and Courses

6. Add connection string in the *AppSetting* file

7. In the *Program.cs* file,
    after this line
    ```C#
    builder.Services.AddControllersWithViews();
    ```
    add
    ```C#
    var connectionString = builder.Configuration.GetConnectionString("myConn") ?? throw new InvalidOperationException("Connection string 'AppDbContextConnection' not found.");

    builder.Services.AddDbContext<MainDbContext>(
        op => op.UseSqlServer(connectionString)
        );
    ```

8. Open *"Package manager console"* and write *add-migration initial-migration* then *update-database*

9. To use Repositories and apply custom-servive-injection:
   -  Create new folder *RepoServices*
   - Add interfaces for Trainees, Courses and Tracks
   - Implement classes that inherit from these interface and write the logic of each function

10. Add needed controllers as read/write, and inject the custom services you created into the constructor of the controller

11. In the *program.cs* file, add

    ```C#
    builder.Services.AddControllersWithViews();
    builder.Services.AddScoped<ITraineeRepository, TraineeRepoService>();
    builder.Services.AddScoped<ITrackRepository, TrackRepoService>();
    builder.Services.AddScoped<ICourseRepository, CourseRepoService>();
    ```
12. Implement the actions in controllers you created using the created services, then add their veiws

13. To make dropdowm lists in the sites run properly, edit it in the view to be
    ```C#
    <select asp-for="Gender" asp-items= "@Html.GetEnumSelectList<Gender>()" class="form-control"></select>

    ```

14. To use TagHelpers in your views : &lt;environment&gt; , &lt;Partial&gt;
    - Create razor view for the patial view you want witha name for example *_PartialView*
    - You can apply it in the Index view of Home controller like
    ```C#
    <div>
        <environment include="Development">
            You are in a Development environment
        </environment>
        <environment exclude="Development">
            Watch out: This is not a Development environment
        </environment>
        <partial name="_PartialView"></partial>
    </div>
    ```

15. To apply UI "User Identity" in your application (at least "Register,Login, Logout")
    - Right click on project-> add new scaffolded item-> identity 
    - Check-> Register, Login, Logout
    - Add
    ```C#
    app.MapRazorPages();
    ```
    - Add partial view of *_LoginPartial* to the layout
    - Add migration while specifying the cpntext like
    ```
    Add-Migration addIdentity  -context ManagingTrainees_TracksAndCoursesContext

    Update-Database  -context ManagingTrainees_TracksAndCoursesContext
    ```
    
    Note: Add *Encrypt=false* to the new connection string 
    <!-- - Download https://learn.microsoft.com/en-us/aspnet/core/host-and-deploy/aspnet-core-module?view=aspnetcore-7.0

    - Publish your project from visual studio
    - Open IIS => Default website-> Add Application , edit permission  -->

    