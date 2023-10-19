using ShopTARge22.Core.DTO.WeatherForecastsDTOs;
using ShopTARge22.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARge22.ApplicationServices.Services
{
    public class WeatherForecastServices : IWeatherForecastServices
    {
        WeatherResponseRootDTO IWeatherForecastServices.GetForecast(string city)
        {
            string idOpenWeather = "61db3921e67b92739e34a4b29843bb79";
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&appid={idOpenWeather}";

            return null;

        }
    }
}
