using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MapProcassor.Models
{
    public class CityData
    {
        const string str = "https://simplemaps.com/static/data/country-cities/ua/ua_spreadsheet.json";

        public List<List<string>> GetInfo()
        {
            WebRequest req = WebRequest.Create(str);
            req.Method = "GET";

            var res = req.GetResponseAsync().Result;
            List<List<string>> b;
            using (var s = new StreamReader(res.GetResponseStream()))
            {
                b = FromJson(s.ReadToEnd());
            }
            b.RemoveAt(0);

            return b;
        }

        public List<City> GetCities() => GetCities(GetInfo());
        public List<City> GetCities(List<List<string>> cityData)
        {
            var cityList = new List<City>();
            foreach(string s in CityPreset())
            {
                cityList.Add(new City()
                {
                    CityName = s,
                    Capital = "minor"
                });
            }

            foreach (var city in cityData)
            {
                cityList.Add(
                    new City()
                    {
                        CityName = city[0],
                        Lat = double.Parse(string.IsNullOrEmpty(city[1]) ? "0" : city[1], CultureInfo.InvariantCulture),
                        Lon = double.Parse(string.IsNullOrEmpty(city[2]) ? "0" : city[2], CultureInfo.InvariantCulture),
                        Country = city[3],
                        ISO = city[4],
                        AdminName = city[5],
                        Capital = city[6],
                        Population = int.Parse(string.IsNullOrEmpty(city[7]) ? "0" : city[7])
                    }
                );
            }

            return cityList;
        }

        public static List<List<string>> FromJson(string json) => JsonConvert.DeserializeObject<List<List<string>>>(json, Converter.Settings);

        private static List<string> CityPreset()
        {
            var preset = new List<string>()
            {
                "Миколаїв",
                "Вилкове",
                "Оріхів",
                "Гуляйполе",
                "Велика Новосілка",
                "Курахове",
                "Констянтинівка",
                "Слов'янськ",
                "Краматорськ",
                "Куп'янске",
                "Шевченкове",
                "Овруч",
                "Старокостянтинів",
                "Славутич",
                "Білопілля",
                "Миропілля",
                "Краснопілля",
                "Золочів",
                "Добропілля",
                "Констянтинівка",
                "Сіверськ",
                "Торецьк",
                "Констянтинівка",
                "Дружківка",
                "Барвінкове",
                "Балаклія",
                "Броди",
                "Яремче",
                "Гадяч",
                "Канів",
                "Лиман",
                "Переяслав",
                "Яготин",
                "Пирятин",
                "Лохвиця",
                "Гадяч",
                "Іловайськ",
                "Харцизськ",
                "Авдіївка",
                "Єнакіїве",
                "Мар'їнка",
                "Старобєшиве",
                "Сіверськ",
                "Торецьк",
                "Святогірськ",
                "Соледар",
                "Ларине",
                "Маріуполь",
                "Євпаторія",
                "Форос",
                "Оленівка",
                "Залізний порт",
                "Залізний порт",
                "Світлодарськ",
                "Соледар",
                "Попасна",
                "Гірське",
                "Кремінна",
                "Маріуполь",
                "о.Зміїний",
                "Докучаєвськ",
                "Іловайськ",
                "Піски",
            };
            return preset;
        }
    }
}
