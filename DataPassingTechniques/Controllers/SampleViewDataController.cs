using DataPassingTechniques.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataPassingTechniques.Controllers
{
    public class SampleViewDataController : Controller
    {
        // GET: SampleViewDataController
        public ActionResult Index()
        {
            //Synatx for ViewData
            // ViewData is a Dicitonary type and is supported key value pair <string, Object>
            // ViewData["KeyName"] = "Your value/ Object data";

            //Eg:
            ViewData["UserName"] = "Suri";

            return View();
        }



        // GET: SampleViewDataController/GetCountryDetails
        public ActionResult GetCountryDetails()
        {

            ViewData["Heading"] = "Below are the Country Details";

            Country countryObj = new Country();

            countryObj.CountryName = "India";
            countryObj.CountryCapital = "New Delhi";
            countryObj.CountryCode = "In";
            countryObj.CountryPopulation = 141000000;
            countryObj.CountryDescription = "India got the freedom on 1947";

            ViewData["countryObjInfoFromSample"] = countryObj;

            //ViewData will not available for subsequent request 
            ViewData["countryObjInfoFromHome"] = countryObj; //ViewData["countryObjInfo"]; -- it is from HomeController Index method


            return View();
        }


        // GET: SampleViewDataController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SampleViewDataController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SampleViewDataController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SampleViewDataController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SampleViewDataController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SampleViewDataController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SampleViewDataController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
