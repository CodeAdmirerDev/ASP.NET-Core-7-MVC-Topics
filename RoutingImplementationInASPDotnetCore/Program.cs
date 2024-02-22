namespace RoutingImplementationInASPDotnetCore
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

            app.UseRouting();//This will be Used for Routing

            app.UseAuthorization();
            //https://localhost:7296/ChatGPT/Browse
            app.MapControllerRoute(
                name: "ChatGPTSearch",
                pattern: "ChatGPT/Browse",
                defaults:new {controller = "ChatGPT", action= "Search" });

            //https://localhost:7296/InfoAboutChatGPT/4
            app.MapControllerRoute(
    name: "ChatGPTInfo",
    pattern: "InfoAboutChatGPT/{version:int}",
    defaults: new { controller = "ChatGPT", action = "InfoAboutChatGPT" });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
