

<!-- PROJECT LOGO -->
<br />
<div align="center">
  <a href="https://github.com/othneildrew/Best-README-Template">
  </a>

  <h3 align="center">MVC task 5 </h3>

</div>

## Task Requirements
<br/>

MVC webApp which manages Customers and thier Orders:
*  Create All CRUD operations to manage your Client's orders

*  Post/Edit methods should be tested for validation using (ModelState.IsValid) , 
		(Display VialidationSummary for all occurred errors)

*  Apply "RoutePrefix" on Customer controller 

*  Apply "Route Constraints" on your actions 

*  Implement Search for specific customer's orders

*  Create any custom dataAnnotation, and apply it on your classes

*  Handle errors in each Controller using different ErrorViewPage,
		try to display helpful error information everytime an error ocurred
	
*  Create a custom handleErrorAttribute, Override "OnException" method to implement custom ExceptionFilter to handle the following case:
    - get orders for user "but this user is not founded" - search for orders made by user that doesn't exists


Customer shoud have the following properties:
- ID
- Name
- Gender
- email
- phoneNum

Order shoud have the following properties:
- ID
- Date
- TotalPrice
[ForeignKey("Customer")]
- CustID

### Apply all necessary DataAnnotation on your classes
### It is 1:M relationship (1 Customer -> Many Orders)

<br/>
<br/>
<br/>

## Steps

### Create pprojct using *Visual Studio*
- Choose *ASP.NET Web Application (.NET Framework)*
- Choose MVC

### Create the required classes
-  Create your classes in the Models folder with proper data annotation
-  Right click on *controllers* and press add new controller 
    - Select EF controllers for *customer* and repeat for *Orders*
    
    And Voiala, Here's the first point Done. 
<hr>

### Let's start the actual Work
- Add these lines in the *layout.cshtml* file to make it easier to navigate
```C#
<li>@Html.ActionLink("Home", "Index", "Home", new { area = "" }, new { @class = "navbar-brand" })</li>

<li>@Html.ActionLink("About", "About", "Home", new { area = "" }, new { @class = "navbar-brand" })</li>

<li>@Html.ActionLink("Contact", "Contact", "Home", new { area = "" }, new { @class = "navbar-brand" })</li>

<li>@Html.ActionLink("Customers", "Index", "Customers", new { area = "" }, new { @class = "navbar-brand" })</li>

```
<hr>

### To display VialidationSummary for all occurred errors
Put this line in the view file in which you want to get a summary of errors
```C#
@Html.ValidationSummary(false, "", new { @class = "text-danger" })
```
this line already exists but you need to set it to <b>false</b> instead of true.

And here's the Second point done.
<hr>

### To apply "RoutePrefix" on Customer controller 
-  Add this line above the controller to Apply *"RoutePrefix"* on The whole controller
```C#
	[Route("Cutomers/Managing")] 
```
But first, You need to add this line in the *RegisterRoutes* function in the *RouteConfig* file in the *App_start* folder
```C#
	routes.MapMvcAttributeRoutes();
```
Don't forget to update the actionlink in the *Layout* file to:
```C#
<li>@Html.ActionLink("Customers", "Index", "Cutomers/Managing/Index", new { area = "" }, new { @class = "navbar-brand" })</li>
```
And here's the Third point done.
<hr>

### To apply "Route Constraints" on your actions
Make sure to add this line in the *RegisterRoutes* function in the *RouteConfig* file in the *App_start* folder
```C#
	routes.MapMvcAttributeRoutes();
```
and you can write any route you like for the actions like:
```C#
[Route("Viewing/Details/{id}")]
```
to the *Details* action in the Cutomer controller
- To test this point, write <b> *Viewing/Details/{id}*</b> after the basic link and replace *{id}* with 1 for example.

And here's the Fourth point done.
<hr>

### To implement Search for specific customer's orders
- Go to *index* view of orders and add 
```C#	
	@using (Html.BeginForm())
	{
	    <label>Search by Order</label>
        @Html.DropDownList("ID", new SelectList(ViewBag.customers, "ID", "Name"), htmlAttributes: new { @class = "form-control" })
	    <br />
	    <input type="submit" value="Filter" class="btn btn-default" />
	}
```
- Then modify the controller of order in the index action to be 
```C#
public ActionResult Index()
{
    ViewBag.customers = db.Customers.ToList();
    return View(db.Orders);
}

[HttpPost]
[UserNotFoundErrorHandler]
public ActionResult Index(int ID)
{
    ViewBag.customers = db.Customers.ToList();
    if (db.Orders.Where(o => o.CustID == ID).Count() == 0)
        throw new Exception();
    return View(db.Orders.Where(o => o.CustID == ID));
}
```	

And here's the Fifth point done.
<hr>

### To create any custom dataAnnotation
- create class that inherts from *ValidationAttribute* in the models folder
- Then override this function and write your own logic
```C#
public override bool IsValid(object value) 
```

Now you can use it as normal data annotaion

And here's the Sixth point done.
<hr>

### To handle errors in each Controller using different ErrorViewPage

- We need to Add this line in web.config file
```C#
<customErrors mode="On">
        <error statusCode="404" redirect="/Home/Contact" />
</customErrors>
```
In the *System.web* tag
- Then in the shared folder in views folder create the your custom *ErrorViewPage*
- write this in the top of the error view to use and show error info
```C#
	@model HandleErrorInfo
``` 
- Then add this annotation before the  controller 

And here's the Seventh point done.
<hr>

### To create a custom handleErrorAttribute
- Add your exception file into the *models* folder
- It inherts from <b>*HandleErrorAttribute*</b>
- Override OnException function
- Then use the handler as an annotation