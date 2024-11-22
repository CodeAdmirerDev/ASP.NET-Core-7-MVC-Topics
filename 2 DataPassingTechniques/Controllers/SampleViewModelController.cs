using DataPassingTechniques.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataPassingTechniques.Controllers
{
    public class SampleViewModelController : Controller
    {
        public IActionResult GetCountryDetails()
        {
            CountryViewModel countryViewModel = new CountryViewModel();

            Country country= new Country();

            country.CountryCode = "IN";
            country.CountryDescription = "India";
            country.CountryName = "Bharath";
            country.CountryCapital = "Delhi";
            country.CountryPopulation = 14300000000000;


            CountryCurrency countryCurrency = new CountryCurrency();
            countryCurrency.CountryCurrencyValue = 82;
            countryCurrency.CountryCurrencyName = "Rupee";
            countryCurrency.CountryCurrencyCode = "INR";

            CountryIncomeSources countryIncomeSources= new CountryIncomeSources();

            countryIncomeSources.Agriculture = "55";
            countryIncomeSources.ITExports = "20";
            countryIncomeSources.ITTax = "15";
            countryIncomeSources.Tourism = "10";


            countryViewModel.country = country;
            countryViewModel.CountryIncomeSources = countryIncomeSources;
            countryViewModel.CountryCurrency = countryCurrency;


            return View(countryViewModel);
        }
    }
}
