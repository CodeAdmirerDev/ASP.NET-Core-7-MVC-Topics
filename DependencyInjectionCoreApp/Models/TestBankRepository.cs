
namespace DependencyInjectionCoreApp.Models
{
    public class TestBankRepository : IBankRepository
    {


        public List<Bank> BankDataSource()
        {
            //List<Bank> listBanks = new List<Bank>();
            //listBanks.Add(new Bank() { BankRegNo=1,BankName="HDFC",BankType="Savings",BankAddress="HYD"});

            //listBanks.Add(new Bank() { BankRegNo = 2, BankName = "IDFC", BankType = "Investment", BankAddress = "HYD" });

            //listBanks.Add(new Bank() { BankRegNo = 3, BankName = "ICICI", BankType = "Savings", BankAddress = "HYD" });

            //return listBanks;

            return new List<Bank>() { new Bank() { BankRegNo = 1, BankName = "HDFC", BankType = "Savings", BankAddress = "HYD" } ,
                new Bank() { BankRegNo = 3, BankName = "ICICI", BankType = "Savings", BankAddress = "HYD" }
            };
        }


        public List<Bank> GetAllBanks()
        {
            return BankDataSource();
        }

        public Bank GetBankInfoByRegNo(int BankRegNo)
        {
            return BankDataSource().FirstOrDefault(bank => bank.BankRegNo == BankRegNo) ?? new Bank();
        }
    }
}
