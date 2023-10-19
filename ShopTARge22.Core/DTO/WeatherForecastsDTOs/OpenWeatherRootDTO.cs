using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShopTARge22.Core.DTO.WeatherForecastsDTOs
{
    public class OpenWeatherRootDTO
    {
        [JsonPropertyName("coord")]
        public Coord Coordinates;

        [JsonPropertyName("weather")]
        public List<Weather> Weather;

        [JsonPropertyName("base")]
        public Base Base;

        [JsonPropertyName("main")]
        public Main Main;

        [JsonPropertyName("visibility")]
        public string Visibility;

        [JsonPropertyName("wind")]
        public Wind Wind;

        [JsonPropertyName("rain")]
        public Rain Rain;

        [JsonPropertyName("clouds")]
        public Clouds Clouds;

        [JsonPropertyName("dt")]
        public int Dt;

        [JsonPropertyName("sys")]
        public System System;

        [JsonPropertyName("timezone")]
        public int Timezone;

        [JsonPropertyName("id")]
        public int Id;

        [JsonPropertyName("name")]
        public string Name;

        [JsonPropertyName("cod")]
        public int Code;

    }

    public class Coord
    {
        [JsonPropertyName("lon")]
        public float Longitude;

        [JsonPropertyName("lat")]
        public float Latitude;
        
    }

    public class Weather
    {
        [JsonPropertyName("id")]
        public int Id;

        [JsonPropertyName("main")]
        public string Main;

        [JsonPropertyName("description")]
        public string Description;

        [JsonPropertyName("icon")]
        public string Icon;
    }

    public class Base
    {
        [JsonPropertyName("stations")]
        public string Stations;
    }

    public class Main 
    {
        [JsonPropertyName("temp")]
        public float Temperature;

        [JsonPropertyName("feels_like")]
        public string FeelsLike;

        [JsonPropertyName("temp_min")]
        public float TempMin;

        [JsonPropertyName("temp_max")]
        public float TempMax;

        [JsonPropertyName("pressure")]
        public int Pressure;

        [JsonPropertyName("humidity")]
        public int Humidity;

        [JsonPropertyName("sea_level")]
        public int SeaLevel;

        [JsonPropertyName("grnd_level")]
        public int GroundLevel;
    }

    public class Wind 
    {
        [JsonPropertyName("speed")]
        public float Speed;

        [JsonPropertyName("deg")]
        public int Degrees;

        [JsonPropertyName("gust")]
        public float Gust;
    }

    public class Rain 
    {
        [JsonPropertyName("1h")]
        public float InHour;

    }

    public class Clouds
    {
        [JsonPropertyName("all")]
        public int AllClouds;
    }

    public class System
    {
        [JsonPropertyName("type")]
        public int Type;

        [JsonPropertyName("id")]
        public int Id;

        [JsonPropertyName("country")]
        public string Country;

        [JsonPropertyName("sunrise")]
        public int Sunrise;

        [JsonPropertyName("sunset")]
        public int Sunset;
    }

}
