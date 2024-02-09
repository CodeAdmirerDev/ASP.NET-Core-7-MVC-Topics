using DependencyInjectionCoreApp.Models;
using DependencyInjectionCoreApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionCoreApp.Controllers
{
    public class BankConstructorDIController : Controller
    {
        //With DI Implementation
        private readonly IBankRepository _bankRepository;
        public BankConstructorDIController(IBankRepository bankRepository)
        {
            _bankRepository = bankRepository;
        }

        public JsonResult GetAllBanksInfo()
        {
            return Json(_bankRepository.GetAllBanks());
        }




        //WithOut DI Implementation
        public JsonResult GetAllBanksInfoWithOutDI()
        {
            BankRepository bankRepository = new BankRepository();
            List<Bank> bankList = bankRepository.GetAllBanks();
            return Json(bankList);
        }

        public JsonResult GetBankInfoByRegNo(int BankRegNo)
        {
            //No need to create the object here , instead we will create the obj in the constructer
           // BankRepository bankRepository = new BankRepository();

           return Json(_bankRepository.GetBankInfoByRegNo(BankRegNo));

        }
    }
}
