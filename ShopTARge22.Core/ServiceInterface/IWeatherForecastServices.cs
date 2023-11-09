using ShopTARge22.Core.DTO.WeatherForecastsDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARge22.Core.ServiceInterface
{
    public interface IWeatherForecastServices
    {
         public WeatherResponseRootDTO GetForecast(string city);
    }
}
