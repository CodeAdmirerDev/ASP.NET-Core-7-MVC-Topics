using FiltersInASPNETCoreMVCApp.Data;
using FiltersInASPNETCoreMVCApp.Models;
using FiltersInASPNETCoreMVCApp.Models.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<CustomResultFilterApproachTwo>();
builder.Services.AddScoped<CustomAsyncCacheActionFilter>();

//Adding the custom filter globally in the middleware pipeline for all the controllers
builder.Services.AddControllers(options =>
{
    options.Filters.Add<CustomExceptionFilter>();
    options.Filters.Add<RedirectToSpecificErrorViewFilter>();
    //options.Filters.Add<CustomResultFilterApproachThree>(); // Register globally

});

//It will apply the Autorization filter globally 

//builder.Services.AddControllersWithViews(options =>
//{
//    options.Filters.Add<CustomAuthorizationFilter>();
//});

// Add response compression services
builder.Services.AddResponseCompression(options =>
{
    options.EnableForHttps = true; // Optionally enable for HTTPS
    options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "application/json" });
});

builder.Services.AddSingleton<ILoggerService, LoggerService>();

// Add response caching services
builder.Services.AddResponseCaching();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error"); // Handles exceptions like invalid views
    //app.UseStatusCodePages();//It will dispay the 404 friendly error message
    //app.UseStatusCodePagesWithRedirects("/Error/{0}"); // Handles HTTP status codes like 404
    app.UseStatusCodePagesWithReExecute("/Error/{0}");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// Enable response compression globally
app.UseResponseCompression();

app.UseRouting();

// Adding the response caching middleware
app.UseResponseCaching();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
