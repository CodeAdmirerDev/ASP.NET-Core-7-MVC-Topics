using DataPassingTechniques.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace DataPassingTechniques.Controllers
{
    public class SampleTempDataController : Controller
    {
        public IActionResult GetCountryDetails()
        {

            TempData["CountryName"] = "India";
            //TempData["CountryCode"] = "IN";
            ViewData["CountryCode"] = "IN";

            TempData.Keep();
            return RedirectToAction("ContactUs");
        }

        public IActionResult ContactUs()
        {
            ViewData["CountryName"] = TempData.Peek("CountryName");
           //for all TempData keys
            TempData.Keep();
            // for specific TempData key
            TempData.Keep("CountryName");
            return View();
        }


        public IActionResult GetCountryDetailsJson()
        {

            CountryViewModel countryViewModel = new CountryViewModel();

            Country country = new Country();

            country.CountryCode = "IN";
            country.CountryDescription = "India";
            country.CountryName = "Bharath";
            country.CountryCapital = "Delhi";
            country.CountryPopulation = 14300000000000;


            CountryCurrency countryCurrency = new CountryCurrency();
            countryCurrency.CountryCurrencyValue = 82;
            countryCurrency.CountryCurrencyName = "Rupee";
            countryCurrency.CountryCurrencyCode = "INR";

            CountryIncomeSources countryIncomeSources = new CountryIncomeSources();

            countryIncomeSources.Agriculture = "55";
            countryIncomeSources.ITExports = "20";
            countryIncomeSources.ITTax = "15";
            countryIncomeSources.Tourism = "10";


            countryViewModel.country = country;
            countryViewModel.CountryIncomeSources = countryIncomeSources;
            countryViewModel.CountryCurrency = countryCurrency;

            string countryViewModelJson= JsonSerializer.Serialize(countryViewModel);

            TempData["countryDetailsJson"] = countryViewModelJson;

            return View();
        }
    }
}
