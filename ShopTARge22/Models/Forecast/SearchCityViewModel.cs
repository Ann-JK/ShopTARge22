using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace ShopTARge22.Models.Forecast
{
    public class SearchCityViewModel
    {
        [Required(ErrorMessage = "You must enter a city name!")]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Only text allowed")]
        [StringLength(20, MinimumLength = 2)]
        public string CityName { get; set; }
    }
}
