<br />
<div align="center">
  
  <h3 align="center">MVC task 7 </h3>

</div>

## Task Requirements
<br/>

- Try ur first .NetCore MVC WebApp, implement the following operations on Car Class:
	- Operations:
		- GetAllCars
		- SelectCarById
		- CreateNewCar
		- Edit/UpdateCar
		- DeleteCar

	- Car Class
		- Num (int)
		- Color (string)
		- Model (string)
		- Manfacture (string)

<br/>

## Steps
1. You need to download *.Net5* from *https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-5.0.408-windows-x64-installer*

2. Create *ASP.NetCoreEmpty* -> *.Net 5.0*
3. Create *Controllers* folder and add the *Car* controller inside
4. In the *Startup.cs* file, edit:
    ```C#
    app.UseEndpoints(endpoints =>   //Add Entries to Routing Table
                {
                    endpoints.MapControllerRoute
                (
                    name: "myOwnRoute",
                    pattern: "{Controller=Car}/{Action=getAll}/{id?}"
                );
                });
    ```
	replace the controller name and action with yours
	and
	```C#
	public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }
	```