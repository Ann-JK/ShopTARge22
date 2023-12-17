using Nancy.Json;
using ShopTARge22.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARge22.ApplicationServices.Services
{
    public class AccuWeatherForecastsServices : IAccuWeatherForecastsServices
    {
        string API_Key = "TODO";


        public async Task<AccuWeatherLocationResultDTO> AccuWeatherGet(AccuWeatherLocationResultDTO dtoLocation)
        {

            try
            {

                var url1 = $"http://dataservice.accuweather.com/locations/v1/cities/search?apikey={API_Key}&q={dtoLocation.City}";

                using (WebClient client = new WebClient())
                {
                    string json = client.DownloadString(url1);
                    List<AccuWeatherLocationRootDTO> accuGet = new JavaScriptSerializer().Deserialize<List<AccuWeatherLocationRootDTO>>(json);

                    dtoLocation.Key = accuGet[0].Key;
                    dtoLocation.Country = accuGet[0].Country;
                    dtoLocation.LocalizedName = accuGet[0].LocalizedName;
                }
            }
            catch (Exception ex) { Console.WriteLine("City not available. Try another city"); }
            return dtoLocation;

        }


        public async Task<AccuWeatherResultDTOs> AccuWeatherResult(AccuWeatherResultDTOs dto, AccuWeatherLocationResultDTO dto1)
        {
            await AccuWeatherGet(dto1);

            if (!string.IsNullOrEmpty(dto1.Key))
            {
                string url = $"http://dataservice.accuweather.com/currentconditions/v1/{dto1.Key}?apikey={API_Key}&details=true";

                using (WebClient client = new WebClient())
                {
                    string json = client.DownloadString(url);
                    List<AccuWeatherRootDTOs> accuResult = new JavaScriptSerializer().Deserialize<List<AccuWeatherRootDTOs>>(json);

                    dto.Temperature = accuResult[0].Temperature.Metric.Value;
                    dto.RealFeelTemperature = accuResult[0].RealFeelTemperature.Metric.Value;
                    dto.RelativeHumidity = accuResult[0].RelativeHumidity;
                    dto.Wind = accuResult[0].Wind.Speed.Metric.Value;
                    dto.Pressure = accuResult[0].Pressure.Metric.Value;
                    dto.WeatherText = accuResult[0].WeatherText;
                }
            }

            return dto;
        }
    }
}
