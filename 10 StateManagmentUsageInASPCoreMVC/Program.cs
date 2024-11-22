using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using StateManagementUsageInASPCoreMVC.Models;

var builder = WebApplication.CreateBuilder(args);

//Here we are add and configure the Entity framework core DBContext service
builder.Services.AddDbContext<EFCoreDbContext>(options =>

//Configure the DbContext to use SQL server with connection string from config
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"))

);

//Here we are add and configure the Distributed Sql Server Cache for Session storage
builder.Services.AddDistributedSqlServerCache(options => {

    //Set the conn string for connecting to the SQL server where session data will be stored 
    options.ConnectionString = builder.Configuration.GetConnectionString("DefaultSQLConnection");
    //Set the database schema where the session table will be located 
    options.SchemaName = "dbo";
    //Set the table name where the session data will be stored 
    options.TableName = "MySessions";

});


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSingleton<ICustomCookieService, CustomCookieService>();

//Configuring Session service to our application

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(60);
    options.IOTimeout = TimeSpan.FromSeconds(60);
    options.Cookie.Name = ".StateManagementUsageInASPCoreMVC.Session";
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential= true;
    options.Cookie.Path = "/";
    options.Cookie.SecurePolicy= CookieSecurePolicy.Always;
});

// ConfigureApplicationCookie is an extension method given by ASP.NET Core to configure
//the properites of the cookie used for application 
//builder.Services.ConfigureApplicationCookie(options =>
//{

//    options.Cookie.Domain = "localhost"; //Here we need to set the domain for the cookie

//    options.Cookie.Path = "/";//It will available within the entire application

//    options.Cookie.MaxAge = TimeSpan.FromDays(2);//It will expire in 2 day

//    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;//These will ensure cookies will be sent over only in HTTPS(true)

//    options.Cookie.HttpOnly = false;//It will prevent the client-side scripts(XSS attacks) from accessing the cookie

//    options.Cookie.IsEssential = true;//It will represent the cookie is required to funcation in the application
//    options.SlidingExpiration = true;   // Automatically renew the cookie if it's accessed within the expiration time

//});

//We need to add the IHttpContextAccessor service to the dependency injection IOC containers

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
//app.UseCookiePolicy();
app.UseAuthorization();


//Configuring Session Middileware to our application 
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
