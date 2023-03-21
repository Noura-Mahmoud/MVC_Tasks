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


Snapshots:

![1](https://user-images.githubusercontent.com/61587804/226496054-b5c909dc-edae-489b-b4d4-a6747768c1b0.png)

![2](https://user-images.githubusercontent.com/61587804/226496069-f5ba6b09-6383-4494-9749-b4f9c30f9824.png)

![3](https://user-images.githubusercontent.com/61587804/226496071-8cca3605-e2c3-41d6-b371-a8192333cc13.png)

![4](https://user-images.githubusercontent.com/61587804/226496075-eb55cf81-87ed-404e-bff8-db2ce0035dfa.png)

![5](https://user-images.githubusercontent.com/61587804/226496082-0a2fce3f-d031-43fa-866c-26a8c7e6de62.png)

![6](https://user-images.githubusercontent.com/61587804/226496087-70dbdaff-9d1b-4b21-a83e-f2d54f957c56.png)

![7](https://user-images.githubusercontent.com/61587804/226496090-fe640126-24bf-4162-86b7-e48efb48bc80.png)

![8](https://user-images.githubusercontent.com/61587804/226496095-5975d2bc-4a9d-4ad1-8e83-5c097018e150.png)

![9](https://user-images.githubusercontent.com/61587804/226496097-89418a36-f4c6-465c-a936-468f2d574a03.png)

![10](https://user-images.githubusercontent.com/61587804/226496099-3c86bb50-3e8e-4db7-b44b-71f006eee498.png)

![11](https://user-images.githubusercontent.com/61587804/226496100-92cf3845-9552-4984-9957-c28a95ab9b04.png)

![12](https://user-images.githubusercontent.com/61587804/226496101-4e04aee8-fcd0-4fc5-9adc-26bd7588379b.png)

![13](https://user-images.githubusercontent.com/61587804/226496106-bc8fb4a6-56b0-4351-9aa2-9e6e2c6bbab3.png)

![14](https://user-images.githubusercontent.com/61587804/226496110-e2b3efae-bef6-48ce-a7b3-9f3a99f85765.png)

![15](https://user-images.githubusercontent.com/61587804/226496112-449434f3-624b-4751-929f-2fd00edb431a.png)

![16](https://user-images.githubusercontent.com/61587804/226496115-309a9000-9455-4151-8a05-c1329d35050e.png)

![17](https://user-images.githubusercontent.com/61587804/226496121-9496a8c1-a6ac-49af-b94f-208eec232962.png)

    
