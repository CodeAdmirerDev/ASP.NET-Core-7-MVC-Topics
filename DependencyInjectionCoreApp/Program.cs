using DependencyInjectionCoreApp.Models;

namespace DependencyInjectionCoreApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // To Add MVC services to the container
            builder.Services.AddMvc();

            //Add application services 

           // builder.Services.Add(new ServiceDescriptor(typeof(IBankRepository),new TestBankRepository()));  //By defalut it is singleton
            //builder.Services.Add(new ServiceDescriptor(typeof(IBankRepository),typeof(BankRepository),ServiceLifetime.Singleton)); 
            //builder.Services.Add(new ServiceDescriptor(typeof(IBankRepository), typeof(BankRepository), ServiceLifetime.Transient)); 
            //builder.Services.Add(new ServiceDescriptor(typeof(IBankRepository), typeof(BankRepository), ServiceLifetime.Scoped));
            

            //******Other way to add it *********
            builder.Services.AddSingleton<IBankRepository,BankRepository>();
            //builder.Services.AddSingleton(typeof(IBankRepository), typeof(BankRepository));
            //builder.Services.AddScoped<IBankRepository, BankRepository>();
            //builder.Services.AddTransient<IBankRepository, BankRepository>();


            var app = builder.Build();

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });

            //app.MapGet("/suri", () => "Hello World!");

            app.Run();
        }
    }
}
