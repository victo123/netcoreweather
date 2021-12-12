using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XtramileSolutions.API.Models;

namespace XtramileSolutions.API.Provider
{
    public interface ICityService
    {
        List<City> GetCityByCountry(string country);

    }
    public class CityProvider : ICityService
    {
        public CityProvider()
        {
        }

        public List<City> GetCityByCountry(string country)
        {

            var json = System.IO.File.ReadAllText("MockData/city.json");
            var AllCity = JsonConvert.DeserializeObject<List<City>>(json);

            var listCity = AllCity.Where(x => x.country == country).ToList();

            return listCity;
        }
    }
}
