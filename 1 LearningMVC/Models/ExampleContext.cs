using Microsoft.EntityFrameworkCore;
using LearningMVC.Areas.Identity.Data;

namespace LearningMVC.Models
{
    public class ExampleContext : DbContext
    {

        public ExampleContext(DbContextOptions<ExampleContext> options):base(options)
        {
        
        }
        //Add your model classes
        public DbSet<Dept> Department { get; set; }
        //Add your model classes
        public DbSet<LearningMVC.Areas.Identity.Data.LearningMVCRoles> LearningMVCRoles { get; set; } = default!;

    }
}
