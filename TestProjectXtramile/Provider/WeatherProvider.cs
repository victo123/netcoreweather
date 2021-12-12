using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TestProjectXtramile.Extensions;
using XtramileSolutions.API.Models;
using XtramileSolutions.API.ViewModels;

namespace XtramileSolutions.API.Provider
{
    public interface IWeatherService
    {
        WeatherViewModel GetWeatherByCity(long cityId);

    }

    public class WeatherProvider : IWeatherService
    {
        
        public WeatherProvider() 
        {
        }

        public WeatherViewModel GetWeatherByCity(long cityId)
        {
            String tokenkey = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["TokenOpenWeather"];
            Weather weather;
            try
            {
                var response = new HttpClient().GetAsync("https://api.openweathermap.org/data/2.5/weather?" +
                "id=" + cityId +
                "&appid=" + tokenkey).Result.Content.ReadAsStringAsync().Result;

                weather = JsonConvert.DeserializeObject<Weather>(response);
            }
            catch
            {
                var response = System.IO.File.ReadAllText("MockData/weather.json");

                var listWeather = JsonConvert.DeserializeObject<List<Weather>>(response);
                weather = listWeather.Where(x => x.City.Id == cityId).FirstOrDefault();
            }

            var celcius = ConvertDegrees.ToCelcius(weather.Main.Temp);
            var fahrenheit = ConvertDegrees.Tofahrenheit(celcius);

            WeatherViewModel weatherViewModel = new WeatherViewModel()
            {
                Location = weather.City != null ? 
                    weather.City.Name + ", Coordinates : longlitude = " + weather.City.coord.Lon.ToString() + "; latitude = " + weather.City.coord.Lat.ToString() :
                    weather.CityName + ", Coordinates : longlitude = " + weather.Coordinate.Longitude.ToString() + "; latitude = " + weather.Coordinate.Latitude.ToString(),
                Time = DateTime.UnixEpoch.AddSeconds(weather.Time != 0 ? weather.Time : weather.Date).ToString("dd-MMMM-yyyy hh:mm:ss"),
                Wind = "Speed : " + weather.Wind.Speed.ToString() + ", Degrees : " + weather.Wind.Deg.ToString(),
                Visibility = weather.Clouds.All,
                SkyCondition = weather.WeatherElement[0].Main.ToString(),
                TemperatureInCelcius = celcius,
                TemperatureInFahrenheith = fahrenheit,
                DewPoint = weather.Main.Humidity.ToString(),
                RelativeHumidity = weather.Main.Humidity.ToString(),
                Pressure = weather.Main.Pressure.ToString()
            };


            return weatherViewModel;
        }
    }
}
