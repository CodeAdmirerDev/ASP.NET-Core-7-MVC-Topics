using DependencyInjectionCoreApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionCoreApp.Controllers
{
    public class BankMethodDIController : Controller
    {
        public JsonResult GetAllBankInfo([FromServices]IBankRepository bankRepository)
        {
            return Json(bankRepository.GetAllBanks());
        }

        public JsonResult GetBankInfoByBankName(string BankName)
        {

            //We can get the service manually(not like Constructor DI nor the Method DI) when ever it is required
            //To create service manually we need to use the RequestServices property of HttpContext .

            var services = this.HttpContext.RequestServices;

            IBankRepository? bankRepository = services.GetService<IBankRepository>();

            Bank? BankInfo = bankRepository.GetAllBanks().Where(bank=> bank.BankName==BankName).FirstOrDefault();
            return Json(BankInfo);
        }
    }
}
