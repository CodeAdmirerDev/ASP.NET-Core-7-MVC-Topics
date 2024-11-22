using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using LearningMVC.Data;
using LearningMVC.Areas.Identity.Data;
using LearningMVC.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("LearningMVCContextConnection") ?? throw new InvalidOperationException("Connection string 'LearningMVCContextConnection' not found.");
builder.Services.AddDbContext<LearningMVCContext>(options => options.UseSqlServer(connectionString));

var connectionStringForExampleContext = builder.Configuration.GetConnectionString("ExampleContextConnection") ?? throw new InvalidOperationException("Connection string 'ExampleContextConnection' not found.");
builder.Services.AddDbContext<ExampleContext>(o => o.UseSqlServer(connectionStringForExampleContext));



builder.Services.AddDefaultIdentity<LearningMVCUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<LearningMVCContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
