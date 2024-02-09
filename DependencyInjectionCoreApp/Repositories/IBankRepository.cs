using DependencyInjectionCoreApp.Models;

namespace DependencyInjectionCoreApp.Repositories
{
    public interface IBankRepository
    {
        Bank GetBankInfoByRegNo(int BankRegNo);
        List<Bank> GetAllBanks();
    }
}
