using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UniversalWeahterForecast.EntityLayer.Entitys;

namespace UniversalWeahterForecast.DataAccessLayer.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new UniversalWeatherForecastDbContext(serviceProvider.GetRequiredService<DbContextOptions<UniversalWeatherForecastDbContext>>()))
            {
                if (context.WeatherForecasts.Any())
                {
                    return;
                }
                Random rnd = new();

                context.CelestalBodies.AddRange(
                        new CelestalBody { Name = "Celestria", 	    IsPlanet = true,    WhoseSatellite = 0}, //1 //1+
                        new CelestalBody { Name = "Stellara",       IsPlanet = true,    WhoseSatellite = 0}, //2 //1
                        new CelestalBody { Name = "Cosmirova", 	    IsPlanet = true,    WhoseSatellite = 0}, //3 //2+
                        new CelestalBody { Name = "Galaxara", 		IsPlanet = true,    WhoseSatellite = 0}, //4 //2+
                        new CelestalBody { Name = "Lunatria", 		IsPlanet = true,    WhoseSatellite = 0}, //5 //1
                        new CelestalBody { Name = "Nebulonia",      IsPlanet = true,    WhoseSatellite = 0}, //6 //1
                        new CelestalBody { Name = "Astrionyx",  	IsPlanet = false,   WhoseSatellite = 1},
                        new CelestalBody { Name = "Galactrix",  	IsPlanet = false,   WhoseSatellite = 4},
                        new CelestalBody { Name = "Quasarion", 	    IsPlanet = false,   WhoseSatellite = 3},
                        new CelestalBody { Name = "Novaflare", 	    IsPlanet = false,   WhoseSatellite = 2},
                        new CelestalBody { Name = "Astrolynx", 	    IsPlanet = false,   WhoseSatellite = 4},
                        new CelestalBody { Name = "Orionex", 		IsPlanet = false,   WhoseSatellite = 3},
                        new CelestalBody { Name = "Astralspire", 	IsPlanet = false,   WhoseSatellite = 5},
                        new CelestalBody { Name = "Nebulique", 	    IsPlanet = false,   WhoseSatellite = 6}
                    );

                context.WeatherTypes.AddRange(
                        new WeatherType { Name = "Güneşli" },
                        new WeatherType { Name = "Parçalı Bulutlu" },
                        new WeatherType { Name = "Kapalı" },
                        new WeatherType { Name = "Yağışlı" },
                        new WeatherType { Name = "Sağnak Yağışlı" },
                        new WeatherType { Name = "Fırtına" }
                    );
                context.WeatherForecasts.AddRange(
                        new WeatherForecast { BodyId = 1,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now },
                        new WeatherForecast { BodyId = 1,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(1) },
                        new WeatherForecast { BodyId = 1,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(2) },
                        new WeatherForecast { BodyId = 1,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(3) },
                        new WeatherForecast { BodyId = 1,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(4) },
                        new WeatherForecast { BodyId = 1,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(5) },
                        new WeatherForecast { BodyId = 1,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(6) },
                        new WeatherForecast { BodyId = 2,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now },
                        new WeatherForecast { BodyId = 2,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(1) },
                        new WeatherForecast { BodyId = 2,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(2) },
                        new WeatherForecast { BodyId = 2,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(3) },
                        new WeatherForecast { BodyId = 2,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(4) },
                        new WeatherForecast { BodyId = 2,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(5) },
                        new WeatherForecast { BodyId = 2,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(6) },
                        new WeatherForecast { BodyId = 3,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now },
                        new WeatherForecast { BodyId = 3,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(1) },
                        new WeatherForecast { BodyId = 3,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(2) },
                        new WeatherForecast { BodyId = 3,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(3) },
                        new WeatherForecast { BodyId = 3,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(4) },
                        new WeatherForecast { BodyId = 3,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(5) },
                        new WeatherForecast { BodyId = 3,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(6) },
                        new WeatherForecast { BodyId = 4,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now },
                        new WeatherForecast { BodyId = 4,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(1) },
                        new WeatherForecast { BodyId = 4,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(2) },
                        new WeatherForecast { BodyId = 4,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(3) },
                        new WeatherForecast { BodyId = 4,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(4) },
                        new WeatherForecast { BodyId = 4,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(5) },
                        new WeatherForecast { BodyId = 4,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(6) },
                        new WeatherForecast { BodyId = 5,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now },
                        new WeatherForecast { BodyId = 5,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(1) },
                        new WeatherForecast { BodyId = 5,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(2) },
                        new WeatherForecast { BodyId = 5,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(3) },
                        new WeatherForecast { BodyId = 5,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(4) },
                        new WeatherForecast { BodyId = 5,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(5) },
                        new WeatherForecast { BodyId = 5,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(6) },
                        new WeatherForecast { BodyId = 6,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now },
                        new WeatherForecast { BodyId = 6,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(1) },
                        new WeatherForecast { BodyId = 6,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(2) },
                        new WeatherForecast { BodyId = 6,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(3) },
                        new WeatherForecast { BodyId = 6,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(4) },
                        new WeatherForecast { BodyId = 6,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(5) },
                        new WeatherForecast { BodyId = 6,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(6) },
                        new WeatherForecast { BodyId = 7,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now },
                        new WeatherForecast { BodyId = 7,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(1) },
                        new WeatherForecast { BodyId = 7,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(2) },
                        new WeatherForecast { BodyId = 7,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(3) },
                        new WeatherForecast { BodyId = 7,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(4) },
                        new WeatherForecast { BodyId = 7,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(5) },
                        new WeatherForecast { BodyId = 7,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(6) },
                        new WeatherForecast { BodyId = 8,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now },
                        new WeatherForecast { BodyId = 8,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(1) },
                        new WeatherForecast { BodyId = 8,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(2) },
                        new WeatherForecast { BodyId = 8,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(3) },
                        new WeatherForecast { BodyId = 8,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(4) },
                        new WeatherForecast { BodyId = 8,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(5) },
                        new WeatherForecast { BodyId = 8,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(6) },
                        new WeatherForecast { BodyId = 9,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now },
                        new WeatherForecast { BodyId = 9,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(1) },
                        new WeatherForecast { BodyId = 9,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(2) },
                        new WeatherForecast { BodyId = 9,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(3) },
                        new WeatherForecast { BodyId = 9,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(4) },
                        new WeatherForecast { BodyId = 9,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(5) },
                        new WeatherForecast { BodyId = 9,  TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(6) },
                        new WeatherForecast { BodyId = 10, TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now },
                        new WeatherForecast { BodyId = 10, TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(1) },
                        new WeatherForecast { BodyId = 10, TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(2) },
                        new WeatherForecast { BodyId = 10, TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(3) },
                        new WeatherForecast { BodyId = 10, TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(4) },
                        new WeatherForecast { BodyId = 10, TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(5) },
                        new WeatherForecast { BodyId = 10, TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(6) },
                        new WeatherForecast { BodyId = 11, TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now },
                        new WeatherForecast { BodyId = 11, TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(1) },
                        new WeatherForecast { BodyId = 11, TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(2) },
                        new WeatherForecast { BodyId = 11, TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(3) },
                        new WeatherForecast { BodyId = 11, TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(4) },
                        new WeatherForecast { BodyId = 11, TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(5) },
                        new WeatherForecast { BodyId = 11, TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(6) },
                        new WeatherForecast { BodyId = 12, TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now },
                        new WeatherForecast { BodyId = 12, TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(1) },
                        new WeatherForecast { BodyId = 12, TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(2) },
                        new WeatherForecast { BodyId = 12, TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(3) },
                        new WeatherForecast { BodyId = 12, TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(4) },
                        new WeatherForecast { BodyId = 12, TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(5) },
                        new WeatherForecast { BodyId = 12, TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(6) },
                        new WeatherForecast { BodyId = 13, TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now },
                        new WeatherForecast { BodyId = 13, TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(1) },
                        new WeatherForecast { BodyId = 13, TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(2) },
                        new WeatherForecast { BodyId = 13, TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(3) },
                        new WeatherForecast { BodyId = 13, TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(4) },
                        new WeatherForecast { BodyId = 13, TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(5) },
                        new WeatherForecast { BodyId = 13, TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(6) },
                        new WeatherForecast { BodyId = 14, TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now },
                        new WeatherForecast { BodyId = 14, TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(1) },
                        new WeatherForecast { BodyId = 14, TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(2) },
                        new WeatherForecast { BodyId = 14, TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(3) },
                        new WeatherForecast { BodyId = 14, TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(4) },
                        new WeatherForecast { BodyId = 14, TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(5) },
                        new WeatherForecast { BodyId = 14, TypeId = rnd.Next(1, 7), Temprature = rnd.Next(5, 30), WeatherTime = DateTime.Now.AddDays(6) }
                    );
                context.SaveChanges();
            }
        }
    }
}
