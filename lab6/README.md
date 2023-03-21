

<!-- PROJECT LOGO -->
<br />
<div align="center">
  
  <h3 align="center">MVC task 6 </h3>

</div>

## Task Requirements
<br/>

1. Try to Deploy any previuose MVC Application on IIS, and make your partner try to access your hosted webApp.


2. Implement "Identity" on MVC webApp:
	- using CodeFirst, generate table "Client": 
		(ClientName, Password, Address, Mobile, Email)
	- Name your database "Identity-DB"
	- Create UserIdentity with any Claims, and implement (Register, login, logout) 


3. Create MVC webApp "Individual User template" with External Login:
	- Use any provider except Google (Microsoft, Facebook, Twitter, etc...)


<br/>
<br/>
<br/>

## 1. Try to Deploy any previuose MVC Application on IIS, and make your partner try to access your hosted webApp.
<br/>

## Steps
First of all you must prepare your machine

Deploying ASP.net MVC Application: 

control pannel -> programs -> turn windows feature on/off -> Search for IIS (Internet Information Services) section and select 

- Web Management Tools -> 
	IIS managment console -> check

- World Wid Web Services -> 
	Common Http Features -> check All

- Application Development Features -> 
	.Net Extensiblity 4.8 & ASP.NET 4.8 -> check

-------------------------------------
Now, let's get started:

1. Get any old application
2. Right click on the project, choose publish, then folder
3. Rename the profile name from *more actions* then *rename*
4. Publish it

<br>

4. Run <b>IIS</b> as an adminstrator 
5. Default Web Site -> directly browsing, make it enable
6. Right click on default web site -> add application
7. To allow users: Right click on the application -> edit permission -> security>> edit>> add>> advanced>> find>> IUSer, IIS_Iuser, then give them full control

Now you can test your application

-------------------------------------
-------------------------------------

## 2. Implement "Identity" on MVC webApp:

- using CodeFirst, generate table "Client": 
    (ClientName, Password, Address, Mobile, Email)
- Name your database "Identity-DB"
- Create UserIdentity with any Claims, and implement (Register, login, logout) 


## Steps

1. Create pprojct using *Visual Studio*
    - Choose *ASP.NET Web Application (.NET Framework)*
    - Choose MVC, Authentication -> None

2. Download **EntityFrameWork** from the NuGet manager for the project
3. Create the required classes
    -  Create your classes (Client class) in the Models folder with proper data annotation
    - In the *configuration* tag inside *web.config* file, Add the *ConnectionString* 
        - You can get your connection string from *SQL sever object properities* in Visual Studio
       : View ->  SQL sever object Explorer -> Right click -> properities, then copy the connection string and chamge the database name to *Identity-DB*

       ```C#
        <connectionStrings>
            <add name="IdentityConn" connectionString="Data Source=(localdb)\ProjectModels;Initial Catalog=Identity-DB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False" providerName="System.Data.SqlClient"/>
        </connectionStrings>
       ```
    - Create the *LoginContext* file in the Models folder. This class inherits from *DbContext*
       - The construstor inherts from **base("*connectionName*")**
       - Add DbSet of clients
       ```C#
        public DbSet<Client> Clients {get; set;}
       ```
4. Add *[Authorize]* data annotation before the home controller to handle users authorization
5. Right click on *controllers* and press add new controller (ClientController), Add *[AllowAnonymous]* annotation for the controller  
    - This controller has (Register, Login, Logout) actions
    - Add *Register* View as create , repeat for *Login* view

6. To make it easier to navigate, add *ActionLink* in the shared layout 

7. Make Sure to install ***Microsoft.Owin.Host.SystemWeb*** and ***Microsoft.Owin.Security.Cookies*** from NuGet pakage manager

8. Right click on the project and add **OWIN startup class**, keep its name as it is
    - Add *app.UseCookieAuthentication* and define the *AuthenticationType* and the *LoginPath*
    ```C#
    app.UseCookieAuthentication(new Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions()
            {
                AuthenticationType = "AppCookie",
                LoginPath = new PathString("/Client/Login")
            });
    ```
9. In the *Register* action add
    ```C#
    if (ModelState.IsValid)
            {
                LoginContext Context = new LoginContext();
                Context.Clients.Add(client);
                Context.SaveChanges();

                var userIdentity = new ClaimsIdentity(new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, client.ClientName),
                    new Claim(ClaimTypes.Email, client.Email),
                    new Claim("Password", client.Password)
                }, "AppCookie");

                Request.GetOwinContext().Authentication.SignIn(userIdentity);

                RedirectToAction("Index", "Home");

            }
    ```
    to define the claims of the user

10. In the *Logout* action add
    ```C#
    Request.GetOwinContext().Authentication.SignOut("AppCookie");

                return RedirectToAction("Login");
    ```

11. In the *Login* action add
    ```C#
    LoginContext Context = new LoginContext();
            var loggedUser = Context.Clients.FirstOrDefault(c=>c.Email == client.Email && c.Password == client.Password);

            if (loggedUser != null)
            {
                var signinIdentity = new ClaimsIdentity(new List<Claim>()
                    {
                        new Claim(ClaimTypes.Email, client.Email),
                        new Claim("Password", client.Password)
                    }, "AppCookie");

                Request.GetOwinContext().Authentication.SignIn(signinIdentity);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("Name", "User doesn't exist");
            }

    ```

That's all for this App


-------------------------------------
-------------------------------------
## 3. Create MVC webApp "Individual User template" with External Login:
- Use any provider except Google (Microsoft, Facebook, Twitter, etc...)

## Steps

1. Create pprojct using *Visual Studio*
    - Choose *ASP.NET Web Application (.NET Framework)*
    - Choose MVC, Authentication -> Individual Accounts
2. To get your Facebook App ID and App Secret, you can follow these steps:

    - Go to the Facebook Developer Dashboard (https://developers.facebook.com/).
    - Click on "Create App" or select an existing app if you already have one.
    - Choose "For Everything Else" as the app purpose and enter the name of your app.
    - On the left-hand side menu, click on "Settings".
    - Under the "Basic" tab, you should see your "App ID" and "App Secret".
    - Copy and paste your "App ID" and "App Secret" into the appropriate fields in your C# application.
3. Navigate to the *Startup.cs* file -> right click on *ConfigureAuth* -> go to definition, thenn put the keys

