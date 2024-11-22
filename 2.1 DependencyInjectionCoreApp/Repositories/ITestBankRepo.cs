using DependencyInjectionCoreApp.Models;

namespace DependencyInjectionCoreApp.Repositories
{
    public interface ITestBankRepo
    {

        List<Bank> GetBanksInfoFromTestBankRepo();
    }
}
