using DependencyInjectionCoreApp.Models;

namespace DependencyInjectionCoreApp.Repositories
{
    public class BankRepository : IBankRepository
    {



        public BankRepository()
        {

            string filePath = @"E:\\ASPNET7\\ASP.NET-Core-7-MVC-Topics\\DependencyInjectionCoreApp\\Logs\\ServiceLifeTimeLog.txt";

            string dataOfMsg = $"Bank repo Object is created :@{DateTime.Now.ToString()}";

            using(StreamWriter writer = new StreamWriter(filePath,true))
            {
                writer.WriteLine(dataOfMsg);
            }

        }

        public List<Bank> BankDataSource()
        {
            //List<Bank> listBanks = new List<Bank>();
            //listBanks.Add(new Bank() { BankRegNo=1,BankName="HDFC",BankType="Savings",BankAddress="HYD"});

            //listBanks.Add(new Bank() { BankRegNo = 2, BankName = "IDFC", BankType = "Investment", BankAddress = "HYD" });

            //listBanks.Add(new Bank() { BankRegNo = 3, BankName = "ICICI", BankType = "Savings", BankAddress = "HYD" });

            //return listBanks;

            return new List<Bank>() { new Bank() { BankRegNo = 1, BankName = "HDFC", BankType = "Savings", BankAddress = "HYD" } ,
                new Bank() { BankRegNo = 2, BankName = "IDFC", BankType = "Investment", BankAddress = "HYD" },
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
