using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HotelManagement
{
    //public class Weather
    //{











    //}
    //public enum DirectionEnum
    //{
    //    North,
    //    North_North_East,
    //    North_East,
    //    East_North_East,
    //    East,
    //    East_South_East,
    //    South_East,
    //    South_South_East,
    //    South,
    //    South_South_West,
    //    South_West,
    //    West_South_West,
    //    West,
    //    West_North_West,
    //    North_West,
    //    North_North_West,
    //    Unknown
    //}
    //public class Clouds
    //{
    //    private const string AllSelector = "all";

    //    public double All { get; private set; }

    //    public Clouds(JToken cloudsData)
    //    {
    //        All = double.Parse(cloudsData.SelectToken(AllSelector).ToString());
    //    }
    //}
    //public class Query
    //{


    //    private const string BaseAdress = "http://api.openweathermap.org/data/2.5/";
    //    private const string ValidCod = "200";
    //    private const string COD = "cod";
    //    private const string CoordSelector = "coord";
    //    private const string WeatherSelector = "weather";
    //    private const string BaseSelector = "base";
    //    private const string MainSelector = "main";
    //    private const string VisibilitySelector = "visibility";
    //    private const string WindSelector = "wind";
    //    private const string RaidSelector = "raid";
    //    private const string SnowSelector = "snow";
    //    private const string CloudsSelector = "clouds";
    //    private const string SysSelector = "sys";
    //    private const string IdSelector = "id";
    //    private const string NameSelector = "name";
    //    private const string CODSelector = "cod";

    //    public bool ValidRequest { get; private set; }
    //    public string Base { get; private set; }
    //    public Coord Coord { get; private set; }
    //    public List<Weather> Weathers { get; private set; }
    //    public Main Main { get; private set; }
    //    public double Visibility { get; private set; }
    //    public Wind Wind { get; private set; }
    //    public Rain Rain { get; private set; }
    //    public Snow Snow { get; private set; }
    //    public Clouds Clouds { get; private set; }
    //    public Sys Sys { get; private set; }
    //    public int ID { get; private set; }
    //    public string Name { get; private set; }
    //    public int Cod { get; private set; }

    //    public Query(string apiKey, string queryStr)
    //    {
    //        Weathers = new List<Weather>();

    //        JObject jsonData = JObject.Parse(new System.Net.WebClient().DownloadString(string.Format(Query.BaseAdress + "weather?id={0}&appid={1}", queryStr, apiKey)));
    //        if (jsonData.SelectToken(COD).ToString() == Query.ValidCod)
    //        {
    //            ValidRequest = true;
    //            Coord = new Coord(jsonData.SelectToken(CoordSelector));

    //            foreach (JToken weather in jsonData.SelectToken(WeatherSelector))
    //                Weathers.Add(new Weather(weather));

    //            Base = jsonData.SelectToken(BaseSelector).ToString();
    //            Main = new Main(jsonData.SelectToken(MainSelector));

    //            if (jsonData.SelectToken(VisibilitySelector) != null)
    //                Visibility = double.Parse(jsonData.SelectToken(VisibilitySelector).ToString());

    //            Wind = new Wind(jsonData.SelectToken(WindSelector));

    //            if (jsonData.SelectToken(RaidSelector) != null)
    //                Rain = new Rain(jsonData.SelectToken(RaidSelector));

    //            if (jsonData.SelectToken(SnowSelector) != null)
    //                Snow = new Snow(jsonData.SelectToken(SnowSelector));

    //            Clouds = new Clouds(jsonData.SelectToken(CloudsSelector));
    //            Sys = new Sys(jsonData.SelectToken(SysSelector));
    //            ID = int.Parse(jsonData.SelectToken(IdSelector).ToString());
    //            Name = jsonData.SelectToken(NameSelector).ToString();
    //            Cod = int.Parse(jsonData.SelectToken(CODSelector).ToString());
    //        }
    //        else
    //        {
    //            ValidRequest = false;
    //        }
    //    }
    //}
    //public class Main
    //{
    //    private const string Temp = "temp";
    //    private const string TempMin = "temp_min";
    //    private const string TempMax = "temp_max";
    //    private const string PressureSelector = "pressure";
    //    private const string HumiditySelector = "humidity";
    //    private const string SeaLevelSelector = "sea_level";
    //    private const string GroundLevel = "grnd_level";

    //    public Temperature Temperature { get; private set; }
    //    public double Pressure { get; private set; }
    //    public double Humdity { get; private set; }
    //    public double SeaLevelAtm { get; private set; }
    //    public double GroundLevelAtm { get; private set; }

    //    public Main(JToken mainData)
    //    {
    //        Temperature = new Temperature(double.Parse(mainData.SelectToken(Temp).ToString()),
    //            double.Parse(mainData.SelectToken(TempMin).ToString()), double.Parse(mainData.SelectToken(TempMax).ToString()));

    //        Pressure = double.Parse(mainData.SelectToken(PressureSelector).ToString());
    //        Humdity = double.Parse(mainData.SelectToken(HumiditySelector).ToString());

    //        if (mainData.SelectToken(SeaLevelSelector) != null)
    //            SeaLevelAtm = double.Parse(mainData.SelectToken(SeaLevelSelector).ToString());

    //        if (mainData.SelectToken(GroundLevel) != null)
    //            GroundLevelAtm = double.Parse(mainData.SelectToken(GroundLevel).ToString());
    //    }
    //}

}
namespace OpenWeatherApi
{
    public enum DirectionEnum
    {
        North,
        North_North_East,
        North_East,
        East_North_East,
        East,
        East_South_East,
        South_East,
        South_South_East,
        South,
        South_South_West,
        South_West,
        West_South_West,
        West,
        West_North_West,
        North_West,
        North_North_West,
        Unknown
    }
    public class Clouds
    {
        private const string AllSelector = "all";
        public double All { get; private set; }

        public Clouds(JToken cloudsData)
        {
            All = double.Parse(cloudsData.SelectToken(AllSelector).ToString());
        }
    }
    public class Query
    {
        private const string BaseAdress = "http://api.openweathermap.org/data/2.5/";
        private const string ValidCod = "200";
        private const string COD = "cod";
        private const string CoordSelector = "coord";
        private const string WeatherSelector = "weather";
        private const string BaseSelector = "base";
        private const string MainSelector = "main";
        private const string VisibilitySelector = "visibility";
        private const string WindSelector = "wind";
        private const string RaidSelector = "raid";
        private const string SnowSelector = "snow";
        private const string CloudsSelector = "clouds";
        private const string SysSelector = "sys";
        private const string IdSelector = "id";
        private const string NameSelector = "name";
        private const string CODSelector = "cod";

        public bool ValidRequest { get; private set; }
        public string Base { get; private set; }
        public Coord Coord { get; private set; }
        public List<Weather> Weathers { get; private set; }
        public Main Main { get; private set; }
        public double Visibility { get; private set; }
        public Wind Wind { get; private set; }
        public Rain Rain { get; private set; }
        public Snow Snow { get; private set; }
        public Clouds Clouds { get; private set; }
        public Sys Sys { get; private set; }
        public int ID { get; private set; }
        public string Name { get; private set; }
        public int Cod { get; private set; }
            
        public Query(string apiKey, string queryStr)
        {
            Weathers = new List<Weather>();
            try
            {
                JObject jsonData = JObject.Parse(new System.Net.WebClient().DownloadString(string.Format(Query.BaseAdress + "weather?id={0}&appid={1}", queryStr, apiKey)));
                if (jsonData.SelectToken(COD).ToString() == Query.ValidCod)
                {
                    ValidRequest = true;
                    Coord = new Coord(jsonData.SelectToken(CoordSelector));

                    foreach (JToken weather in jsonData.SelectToken(WeatherSelector))
                        Weathers.Add(new Weather(weather));

                    Base = jsonData.SelectToken(BaseSelector).ToString();
                    Main = new Main(jsonData.SelectToken(MainSelector));

                    if (jsonData.SelectToken(VisibilitySelector) != null)
                        Visibility = double.Parse(jsonData.SelectToken(VisibilitySelector).ToString());

                    Wind = new Wind(jsonData.SelectToken(WindSelector));

                    if (jsonData.SelectToken(RaidSelector) != null)
                        Rain = new Rain(jsonData.SelectToken(RaidSelector));

                    if (jsonData.SelectToken(SnowSelector) != null)
                        Snow = new Snow(jsonData.SelectToken(SnowSelector));

                    Clouds = new Clouds(jsonData.SelectToken(CloudsSelector));
                    Sys = new Sys(jsonData.SelectToken(SysSelector));
                    ID = int.Parse(jsonData.SelectToken(IdSelector).ToString());
                    Name = jsonData.SelectToken(NameSelector).ToString();
                    Cod = int.Parse(jsonData.SelectToken(CODSelector).ToString());
                }
                else
                {
                    ValidRequest = false;
                }
            }
            catch 
            {
                ;
            }
           
        }
    }
    public class Main
    {
        private const string Temp = "temp";
        private const string TempMin = "temp_min";
        private const string TempMax = "temp_max";
        private const string PressureSelector = "pressure";
        private const string HumiditySelector = "humidity";
        private const string SeaLevelSelector = "sea_level";
        private const string GroundLevel = "grnd_level";

        public Temperature Temperature { get; private set; }
        public double Pressure { get; private set; }
        public double Humdity { get; private set; }
        public double SeaLevelAtm { get; private set; }
        public double GroundLevelAtm { get; private set; }

        public Main(JToken mainData)
        {
            Temperature = new Temperature(double.Parse(mainData.SelectToken(Temp).ToString()),
                double.Parse(mainData.SelectToken(TempMin).ToString()), double.Parse(mainData.SelectToken(TempMax).ToString()));

            Pressure = double.Parse(mainData.SelectToken(PressureSelector).ToString());
            Humdity = double.Parse(mainData.SelectToken(HumiditySelector).ToString());

            if (mainData.SelectToken(SeaLevelSelector) != null)
                SeaLevelAtm = double.Parse(mainData.SelectToken(SeaLevelSelector).ToString());

            if (mainData.SelectToken(GroundLevel) != null)
                GroundLevelAtm = double.Parse(mainData.SelectToken(GroundLevel).ToString());
        }
    }
    public class OpenWeatherAPI
    {
        string openWeatherAPIKey;
        public static List<City> lstCity = new List<City>();
        public OpenWeatherAPI(string apiKey)
        {
            openWeatherAPIKey = apiKey;
        }

        public void updateAPIKey(string apiKey)
        {
            openWeatherAPIKey = apiKey;
        }

        //Returns null if invalid request
        public Query query(string queryStr)
        {
            Query newQuery = new Query(openWeatherAPIKey, queryStr);
            if (newQuery.ValidRequest)
                return newQuery;
            return null;
        }
    }
    public class Rain
    {
        private const string ThreeHour = "3h";
        public double H3 { get; private set; }
        public Rain(JToken rainData)
        {
            if (rainData.SelectToken(ThreeHour) != null)
                H3 = double.Parse(rainData.SelectToken(ThreeHour).ToString());
        }

    }
    public class Snow
    {
        private const string ThreeHour = "3h";
        public double H3 { get; private set; }

        public Snow(JToken snowData)
        {
            if (snowData.SelectToken(ThreeHour) != null)
                H3 = double.Parse(snowData.SelectToken(ThreeHour).ToString());
        }
    }
    public class Sys
    {
        private const string TypeSelector = "type";
        private const string IdSelector = "id";
        private const string MessageSelector = "message";
        private const string CountrySelector = "country";
        private const string SunriseSelector = "sunrise";
        private const string SunsetSelector = "sunset";

        public int Type { get; private set; }
        public int ID { get; private set; }
        public double Message { get; private set; }
        public string Country { get; private set; }
        public DateTime Sunrise { get; private set; }
        public DateTime Sunset { get; private set; }

        public Sys(JToken sysData)
        {
            if (sysData.SelectToken(TypeSelector) != null)
                Type = int.Parse(sysData.SelectToken(TypeSelector).ToString());

            if (sysData.SelectToken(IdSelector) != null)
                ID = int.Parse(sysData.SelectToken(IdSelector).ToString());

            Message = double.Parse(sysData.SelectToken(MessageSelector).ToString());
            Country = sysData.SelectToken(CountrySelector).ToString();
            Sunrise = convertUnixToDateTime(double.Parse(sysData.SelectToken(SunriseSelector).ToString()));
            Sunset = convertUnixToDateTime(double.Parse(sysData.SelectToken(SunsetSelector).ToString()));
        }

        private DateTime convertUnixToDateTime(double unixTime)
        {
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return dt.AddSeconds(unixTime).ToLocalTime();
        }
    }
    public class Temperature
    {
        private double current_kel_temp, temp_kel_min, temp_kel_max;
        public double CelsiusCurrent { get; private set; }
        public double FahrenheitCurrent { get; private set; }
        public double KelvinCurrent
        {
            get
            {
                return current_kel_temp;
            }
            set
            {
                current_kel_temp = value;
                CelsiusCurrent = convertToCelsius(value);
                FahrenheitCurrent = convertToFahrenheit(CelsiusCurrent);
            }
        }
        public double CelsiusMinimum { get; private set; }
        public double CelsiusMaximum { get; private set; }
        public double FahrenheitMinimum { get; private set; }
        public double FahrenheitMaximum { get; private set; }
        public double KelvinMinimum
        {
            get
            {
                return temp_kel_min;
            }
            set
            {
                temp_kel_min = value;
                CelsiusMinimum = convertToCelsius(value);
                FahrenheitMinimum = convertToFahrenheit(CelsiusMinimum);
            }
        }
        public double KelvinMaximum
        {
            get
            {
                return temp_kel_max;
            }
            set
            {
                temp_kel_max = value;
                CelsiusMaximum = convertToCelsius(value);
                FahrenheitMaximum = convertToFahrenheit(CelsiusMinimum);
            }
        }

        public Temperature(double temp, double min, double max)
        {
            KelvinCurrent = temp;
            KelvinMinimum = min;
            KelvinMaximum = max;
        }

        private double convertToFahrenheit(double celsius)
        {
            return Math.Round(((9.0 / 5.0) * celsius) + 32, 3);
        }

        private double convertToCelsius(double kelvin)
        {
            return Math.Round(kelvin - 273.15, 3);
        }
    }
    public class Weather
    {
        private const string IdSelector = "id";
        private const string MainSelector = "main";
        private const string DescriptionSelector = "description";
        private const string IconSelector = "icon";

        public int ID { get; private set; }
        public string Main { get; private set; }
        public string Description { get; private set; }
        public string Icon { get; private set; }

        public Weather(JToken weatherData)
        {
            ID = int.Parse(weatherData.SelectToken(IdSelector).ToString());
            Main = weatherData.SelectToken(MainSelector).ToString();
            Description = weatherData.SelectToken(DescriptionSelector).ToString();
            Icon = weatherData.SelectToken(IconSelector).ToString();
        }
    }
    public class Wind
    {
        public double SpeedMetersPerSecond { get; private set; }
        public double SpeedFeetPerSecond { get { return SpeedMetersPerSecond * 3.28084; } }
        public DirectionEnum Direction { get; private set; }
        public double Degree { get; private set; }
        public double Gust { get; private set; }

        public Wind(JToken windData)
        {
            SpeedMetersPerSecond = double.Parse(windData.SelectToken("speed").ToString());
            Degree = double.Parse(windData.SelectToken("deg").ToString());
            Direction = assignDirection(Degree);
            if (windData.SelectToken("gust") != null)
                Gust = double.Parse(windData.SelectToken("gust").ToString());
        }

        public string directionEnumToString(DirectionEnum dir)
        {
            switch (dir)
            {
                case DirectionEnum.East:
                    return "East";
                case DirectionEnum.East_North_East:
                    return "East North-East";
                case DirectionEnum.East_South_East:
                    return "East South-East";
                case DirectionEnum.North:
                    return "North";
                case DirectionEnum.North_East:
                    return "North East";
                case DirectionEnum.North_North_East:
                    return "North North-East";
                case DirectionEnum.North_North_West:
                    return "North North-West";
                case DirectionEnum.North_West:
                    return "North West";
                case DirectionEnum.South:
                    return "South";
                case DirectionEnum.South_East:
                    return "South East";
                case DirectionEnum.South_South_East:
                    return "South South-East";
                case DirectionEnum.South_South_West:
                    return "South South-West";
                case DirectionEnum.South_West:
                    return "South West";
                case DirectionEnum.West:
                    return "West";
                case DirectionEnum.West_North_West:
                    return "West North-West";
                case DirectionEnum.West_South_West:
                    return "West South-West";
                case DirectionEnum.Unknown:
                    return "Unknown";
                default:
                    return "Unknown";
            }
        }

        private DirectionEnum assignDirection(double degree)
        {
            if (fB(degree, 348.75, 360))
                return DirectionEnum.North;
            if (fB(degree, 0, 11.25))
                return DirectionEnum.North;
            if (fB(degree, 11.25, 33.75))
                return DirectionEnum.North_North_East;
            if (fB(degree, 33.75, 56.25))
                return DirectionEnum.North_East;
            if (fB(degree, 56.25, 78.75))
                return DirectionEnum.East_North_East;
            if (fB(degree, 78.75, 101.25))
                return DirectionEnum.East;
            if (fB(degree, 101.25, 123.75))
                return DirectionEnum.East_South_East;
            if (fB(degree, 123.75, 146.25))
                return DirectionEnum.South_East;
            if (fB(degree, 168.75, 191.25))
                return DirectionEnum.South;
            if (fB(degree, 191.25, 213.75))
                return DirectionEnum.South_South_West;
            if (fB(degree, 213.75, 236.25))
                return DirectionEnum.South_West;
            if (fB(degree, 236.25, 258.75))
                return DirectionEnum.West_South_West;
            if (fB(degree, 258.75, 281.25))
                return DirectionEnum.West;
            if (fB(degree, 281.25, 303.75))
                return DirectionEnum.West_North_West;
            if (fB(degree, 303.75, 326.25))
                return DirectionEnum.North_West;
            if (fB(degree, 326.25, 348.75))
                return DirectionEnum.North_North_West;
            return DirectionEnum.Unknown;
        }

        //fB = fallsBetween
        private bool fB(double val, double min, double max)
        {
            if ((min <= val) && (val <= max))
                return true;
            return false;
        }
    }

    public class Coord
    {
        private const string Long = "long";
        private const string Lat = "lat";

        public double Longitude { get; private set; }
        public double Latitude { get; private set; }

        public Coord(JToken coordData)
        {
            //Longitude = double.Parse(coordData.SelectToken(Long).ToString());
            Latitude = double.Parse(coordData.SelectToken(Lat).ToString());
        }
    }

    public class City
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }

        public City (int id , string name)
        {
            this.ID = id;
            this.Name = name;
        }

    }
}
