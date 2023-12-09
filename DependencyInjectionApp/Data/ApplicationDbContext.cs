using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DependencyInjectionApp.Models;

namespace DependencyInjectionApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<DependencyInjectionApp.Models.Emp> Emp { get; set; } = default!;
    }
}
