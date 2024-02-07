namespace DependencyInjectionCoreApp.Models
{
    public interface IBankRepository
    {
        Bank GetBankInfoByRegNo(int BankRegNo);
        List<Bank> GetAllBanks();
    }
}
