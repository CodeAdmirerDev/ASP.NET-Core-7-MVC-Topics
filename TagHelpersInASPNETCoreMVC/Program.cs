namespace TagHelpersInASPNETCoreMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

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

            /* So, with the below change, manually generating the link will not work if you run the application, 
            whereas the link generating with Tag Helpers will work as expected.
            */
            app.MapControllerRoute(
                name: "default",
                pattern: "codeadmirer/{controller=Home}/{action=Index}/{id?}");

            /*
            // If you want to execute the all method , uncomment this code
             app.MapControllerRoute(
                name: "default",
                pattern: "codeadmirer/{controller=Home}/{action=Index}/{id?}");
            */

            app.Run();
        }
    }
}
