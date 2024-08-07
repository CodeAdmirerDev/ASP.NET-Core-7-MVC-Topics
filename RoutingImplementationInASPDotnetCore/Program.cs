﻿using RoutingImplementationInASPDotnetCore.Models.Constraints;

namespace RoutingImplementationInASPDotnetCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //Method 1: Configuring the Custom Route Constraint Service using the AddRouting Method​
            builder.Services.AddRouting(options =>
            {
                options.ConstraintMap.Add("alphabetWithNumeric", typeof(AlphabetWithNumericConstraint));
            });

            /*

                    //Method 2: Configuring the Custom Route Constraint Service using the Configure Method​
                    builder.Services.Configure<RouteOptions>(routeoptions =>
                    {
                        routeoptions.ConstraintMap.Add("alphabetWithNumeric", typeof(AlphabetWithNumericConstraint));
                    });

            */
            
            builder.Services.AddRouting(options =>
            {
                options.ConstraintMap.Add("workingDayConstraint", typeof(WorkingDayConstraint));
            });

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

            app.UseRouting();//This will be Used for Routing

            app.UseAuthorization();




            /*
             
                //Custom route in Convention based routing
                app.MapControllerRoute(
                    name: "ControllerWithMethodOnly",
                    pattern: "{controller}/{action}");

                app.MapControllerRoute(
                    name: "ControllerWithMethodAndParams",
                    pattern: "{controller}/{action}/{version:alphabetWithNumeric}",
                    defaults:new {controller= "ChatGPT", action= "Search" }
                    );
                app.MapControllerRoute(
                    name: "ControllerWithMethodForWeekday",
                    pattern: "{controller}/{action}/{enterTheDate:workingDayConstraint}",
                    defaults: new { controller = "ChatGPT", action = "IsWokringDay" }
                    );

            */

            /*

            //Configure Multiple Conventional Routing in ASP.NET Core MVC Application

            //https://localhost:7296/ChatGPT/Browse
            app.MapControllerRoute(
                name: "ChatGPTBrowse",
                pattern: "ChatGPT/Browse",
                defaults: new { controller = "ChatGPT", action = "Search" });


            //https://localhost:7296/IsWorkingDayInBharat/04-04-2024
            app.MapControllerRoute(
                name: "WorkingDayInfo",
                pattern: "IsWorkingDayInBharat/{inputDate:string}",
                defaults: new { controller = "ChatGPT", action = "IsWorkingDay" });

            */

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
