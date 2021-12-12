using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XtramileSolutions.API.Models
{
    public class WeatherLive : City
    {
        public class Cond
        {
            [JsonProperty("id")]
            public int ID;

            [JsonProperty("main")]
            public string state;

            [JsonProperty("description")]
            public string Description;

            [JsonProperty("icon")]
            public string IconID;
        }

        public class Coord
        {
            [JsonProperty("lat")]
            public float Latitude;

            [JsonProperty("lon")]
            public float Longitude;

            public Coord() { }
            public Coord(float latitude, float longitude)
            {
                this.Longitude = longitude;
                this.Latitude = latitude;
            }
        }

        public class fall
        {
            [JsonProperty("1h")]
            public float h1;

            [JsonProperty("3h")]
            public float h3;
        }

        [JsonProperty("coord")]
        public Coord Coordinate;

        [JsonProperty("weather")]
        public Cond[] Condition;

        [JsonProperty("rain")]
        public fall Rain;

        [JsonProperty("snow")]
        public fall Snow;

        [JsonProperty("dt")]
        public float Date;

        [JsonProperty("name")]
        public string CityName;
    }
}
