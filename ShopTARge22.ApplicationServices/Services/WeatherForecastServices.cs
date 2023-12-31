﻿using Nancy.Json;
using ShopTARge22.Core.DTO.WeatherForecastsDTOs;
using ShopTARge22.Core.ServiceInterface;
using System.Net;

namespace ShopTARge22.ApplicationServices.Services
{
    public class WeatherForecastServices : IWeatherForecastServices
    {
        public async Task<OpenWeatherResultDTO> OpenWeatherResult(OpenWeatherResultDTO dto)
        {
            string idOpenWeather = "61db3921e67b92739e34a4b29843bb79";
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={dto.City}&units=metric&appid={idOpenWeather}";


            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                WeatherResponseRootDTO weatherResult = new JavaScriptSerializer().Deserialize<WeatherResponseRootDTO>(json);
                dto.City = weatherResult.Name;
                dto.Temp = weatherResult.Main.Temp;
                dto.FeelsLike = weatherResult.Main.FeelsLike;
                dto.Humidity = weatherResult.Main.Humidity;
                dto.Pressure = weatherResult.Main.Pressure;
                dto.WindSpeed = weatherResult.Wind.Speed;
                dto.Description = weatherResult.Weather[0].Description;

            }
            
            return dto;

        }
    }
}
