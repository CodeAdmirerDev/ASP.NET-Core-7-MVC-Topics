using Microsoft.EntityFrameworkCore;
namespace StateManagementUsageInASPCoreMVC.Models
{
    public class EFCoreDbContext :DbContext
    {
        public EFCoreDbContext(DbContextOptions<EFCoreDbContext> options): base(options)
        {
            
        }
    }
}
