using DependencyInjectionCoreApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionCoreApp.Repositories
{
    public class TestBankRepo : ITestBankRepo
    {
        private readonly IBankRepository _bankRepository;

        public TestBankRepo(IBankRepository bankRepository) {
            _bankRepository = bankRepository;
        }

        public List<Bank> GetBanksInfoFromTestBankRepo()
        {
            return _bankRepository.GetAllBanks();

        }


    }
}
