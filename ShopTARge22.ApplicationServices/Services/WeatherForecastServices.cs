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
        WeatherResponseDTO IWeatherForecastServices.getForecast(string city);
    }
}
