<br />
<div align="center">
  
  <h3 align="center">MVC task 8 </h3>

</div>

## Task Requirements
<br/>

1. Try to use any existing database you made before, scaffold it usig "EFCore Power Tool",  
and make ASP.NetCore MVC webApp implement all CRUD operation using this DB. 


2. ASP.NetCore MVC webApp which manages Students and thier Courses:
    - Create All CRUD operations to manage your Student's courses
    - Use EF_Core Code First to create CrsStudents_DB
    - 1:M relationship (1 Student : M Cources)

    Student shoud have the following properties:
    - ID
    - Name
    - Gender
    - email
    - phoneNum
    - Birthdate

    Course shoud have the following properties:
    - ID
    - Topic
    - CourseGrade


3. Try the following:
    - Use TagHelpers in your views
    - Use _layout page as a master template for your application
    - Try to make your webApp have a nice look by applying different styles and bootstrap, use:"Styling & Bundling"
    - Use client-side packages to apply Validation on your application
    - Try to use "_ViewStart & _ViewImport"

	
4. Try to Display Environment Variable data in your page

<hr>
<hr>
<br/>

## 1. Try to use any existing database you made before, scaffold it usig "EFCore Power Tool",  
and make ASP.NetCore MVC webApp implement all CRUD operation using this DB. 


## Steps
1. Create new project *ASP.NetCoreEmpty* -> *.Net 5.0*
2. From *NuGet package manager*, install *Microsoft.EntityFrameworkCore.SqlServer* version **5.0.10** and *Microsoft.EntityFrameworkCore.Tools* same version
3. Scaffold the existing database:

    In Package Manager Console, use the following command to scaffold the existing database:
    ```
    Scaffold-DbContext "Server=.;Initial Catalog=Identity-DB;Integrated Security=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
    ```
    replace *Identity-DB;* with your database name

4. Add connection string in the *AppSetting* file

5. In the *Startup.cs* file, add
    ```C#
    services.AddControllersWithViews();
                services.AddDbContext<IdentityDBContext>(op =>
                    op.UseSqlServer(Configuration.GetConnectionString("myConn"))
                );
    ```

6. Add *Controllers* folder, then add controller of client and add the logic and the view of each action

7. From *NuGet package manager*, install *Microsoft.AspNetCore.Mvc.TagHelpers*

8. To add *TagHelpers* which is needed for stylying, right click on the project, then add item -> Razor View Imports 

    then add in it this line to be applied for all pages
    ```C#
    @addTagHelper "*, Microsoft.AspNetCore.Mvc.TagHelpers"
    ```


9. To add styles, right click on the project, Create *wwwroot* folder and add css and js folders inside
    - right click on the project -> add client-side libirary -> twitter-bootstrap
    - right click on the project -> add client-side libirary -> jquery
    - right click on the project -> add client-side libirary -> jquery-validate
    - right click on the project -> add client-side libirary -> jquery-validation-unobtrusive

10. In the shared folder, right click-> add razor layout for the *_Layout.cshtml*
11. Right click on the project -> add item -> razor view start -> edit the line inside to 
    ```C#
        Layout = "~/Views/Shared/_Layout.cshtml";
    ```
12. In the *_Layout.cshtml* page, grab the styles and scripts, and add this line 
    ```C#
    @RenderSection("Scripts", required:false)
    ```

Snapshots:

![1](https://user-images.githubusercontent.com/61587804/226497076-8e2db3d5-2119-43ed-ab54-f806dcc9d102.png)

![2](https://user-images.githubusercontent.com/61587804/226497079-b313501f-7fd8-4fcd-a066-1d24a4d2b33e.png)

![3](https://user-images.githubusercontent.com/61587804/226497082-36c521f3-758e-463b-aec7-8d13e92428d9.png)

![4](https://user-images.githubusercontent.com/61587804/226497085-575d682e-1731-4241-b354-3b880b0796b0.png)

![5](https://user-images.githubusercontent.com/61587804/226497089-68e33494-7384-4e28-aec2-8c398be6e802.png)



<hr>
<hr>

## 2. ASP.NetCore MVC webApp which manages Students and thier Courses:

- Create All CRUD operations to manage your Student's courses
- Use EF_Core Code First to create CrsStudents_DB
- 1:M relationship (1 Student : M Cources)

    Student shoud have the following properties:
    - ID
    - Name
    - Gender
    - email
    - phoneNum
    - Birthdate

    Course shoud have the following properties:
    - ID
    - Topic
    - CourseGrade

## Steps


1. Create new project *ASP.NetCoreEmpty* -> *.Net 5.0*
2. From *NuGet package manager*, install *Microsoft.EntityFrameworkCore.SqlServer* version **5.0.10** and *Microsoft.EntityFrameworkCore.Tools* same version

3. From *NuGet package manager*, install *Microsoft.AspNetCore.Mvc.TagHelpers*

4. To add *TagHelpers* which is needed for stylying, right click on the project, then add item -> Razor View Imports 

    then add in it this line to be applied for all pages
    ```C#
    @addTagHelper "*, Microsoft.AspNetCore.Mvc.TagHelpers"
    ```


5. To add styles, right click on the project, Create *wwwroot* folder and add css and js folders inside
    - right click on the project -> add client-side libirary -> twitter-bootstrap
    - right click on the project -> add client-side libirary -> jquery
    - right click on the project -> add client-side libirary -> jquery-validate
    - right click on the project -> add client-side libirary -> jquery-validation-unobtrusive

6. In the shared folder, right click-> add razor layout for the *_Layout.cshtml*
7. In the *_Layout.cshtml* page, grab the styles and scripts, and add this line 
    ```C#
    @RenderSection("Scripts", required:false)
    ```

8. Right click on the project -> add item -> razor view start -> edit the line inside to 
    ```C#
        Layout = "~/Views/Shared/_Layout.cshtml";
    ```
9. Add
    ```C#
    app.UseStaticFiles();
    ```
    to the *Configure* function in the *Startup.cs* file
10. Create *Models* folder

12. Create your own classes in the *Models* folder

11. Create *StudentsDbContext* file, which inherits from DbContext and pass the *DbContextOptions* to the base, then add the *DbSet* of Students and Courses

11. Add connection string in the *AppSetting* file

12. Add *Controllers* folder, then add controller of client and add the logic and the view of each action

13. In the *Startup.cs* file, add
    ```C#
    services.AddControllersWithViews();
    services.AddDbContext<StudentsDbContext>(op =>
        op.UseSqlServer(Configuration.GetConnectionString("myConn"))
    );
    ```
    and add this in the *Configure* function 
    ```C#
    endpoints.MapControllerRoute
                (
                    name: "myOwnRoute",
                    pattern:"{Controller=Students}/{Action=Index}/{id?}"
                );
    ```

14. Open *"Package manager console"* and write *add-migration initial-migration* then *update-database*

<hr>
<hr>

## 3. Try the following:
- Use TagHelpers in your views
- Use _layout page as a master template for your application
- Try to make your webApp have a nice look by applying different styles and bootstrap, use:"Styling & Bundling"
- Use client-side packages to apply Validation on your application
- Try to use "_ViewStart & _ViewImport"

### Already done in previous problems

<hr>
<hr>

## 4. Try to Display Environment Variable data in your page

## Steps
We can Continue on the previos project

1. Inject *IWebHostEnvironment env* in the constructor of Home controller, then you can access them like 
    ```C#
    var environmentName = _env.EnvironmentName;
    ViewData["EnvironmentName"] = environmentName;
    ```

2. Edit the startup route to be
```C#
endpoints.MapControllerRoute
                (
                    name: "myOwnRoute",
                    pattern: "{Controller=Home}/{Action=Index}"
                );
```

Snapshots:

![1](https://user-images.githubusercontent.com/61587804/226497172-061e56db-b578-4505-81ec-46767bcd2ae0.png)

![2](https://user-images.githubusercontent.com/61587804/226497174-39b3b5da-e90c-45f2-8d0d-089f45766e70.png)

![3](https://user-images.githubusercontent.com/61587804/226497177-2350337b-64db-439c-bce3-17a3c38a7a75.png)

![4](https://user-images.githubusercontent.com/61587804/226497180-8193badb-754b-41a1-a4c3-c68af76cf873.png)

![5](https://user-images.githubusercontent.com/61587804/226497166-5aac5226-6f89-4d06-a0eb-cd06352216c2.png)

![6](https://user-images.githubusercontent.com/61587804/226497167-624ecc67-e886-4232-af33-c0e9a9cc95a2.png)

![7](https://user-images.githubusercontent.com/61587804/226497168-cc4d5316-1aee-4417-a803-b9b794d1cd7b.png)

![8](https://user-images.githubusercontent.com/61587804/226497170-a264fc6d-9bc6-447f-b464-1c1e087f8a43.png)

![9](https://user-images.githubusercontent.com/61587804/226497171-f79e69ad-c8c3-489d-b4d7-426551490e0f.png)
