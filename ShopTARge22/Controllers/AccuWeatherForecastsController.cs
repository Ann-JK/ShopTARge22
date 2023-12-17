using Microsoft.AspNetCore.Mvc;
using ShopTARge22.Core.ServiceInterface;
using ShopTARge22.Models.AccuWeatherForecasts;

namespace ShopTARge22.Controllers
{
    public class AccuWeatherForecastsController : Controller
    {
        private readonly IAccuWeatherForecastsServices _accuWeatherForecastsServices;

        public AccuWeatherForecastsController 
            (IAccuWeatherForecastsServices accuWeatherForecastsServices) 
        {
            _accuWeatherForecastsServices = accuWeatherForecastsServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SearchCity(AccuWeatherSearchCityViewModel vm)
        {
            if (ModelState.IsValid) 
            {
                return RedirectToAction("City", "AccuWeatherForecasts", new { city = model.City});
            }
        }

        [HttpGet]
        public async Task<IActionResult> City(string city)
        {
            AccuWeatherResultDTOs dto = new();
            AccuWeatherLocationResultDTO dtoLocation = new();

            dtoLocation.City = city;


        }

    }
}
