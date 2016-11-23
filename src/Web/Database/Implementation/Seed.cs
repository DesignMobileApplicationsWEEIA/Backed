using System.Collections.Generic;
using System.IO;
using System.Linq;
using Domain.Database.Interfaces;
using Domain.Model.Database;

namespace Web.Migrations
{
    public class Seed
    {
        public static void Init(IDbContext context, string logosPath)
        {
            if (context.Places.Any())
            {
                return;
            }

            var weeiaLogo = new Logo
            {
               Content = File.ReadAllBytes($"{logosPath}/logo-weeia.png"),
               ContentType = "png",
            };


            var logoRes = context.Logos.Add(weeiaLogo);

            var weeia = context.Buildings.Add(new Building
            {
                Address = "Bohdana Stefanowskiego 18/22, Łódź",
                Description = "Wydział Elektrotechniki, Elektroniki, Informatyki i Automatyki Politechniki Łódzkiej",
                Name = "Weeia"
            });

            context.Faculties.Add(new Faculty
            {
                LogoId = logoRes.Entity.Id,
                Name = "WEEIA_LOGO",
                ShortName = "weeia",
                BuildingId = weeia.Entity.Id
            });

            var weeiaPlaces = new List<Place>
            {
                new Place {Latitude = 51.752497, Longitude = 19.453010, BuildingId = weeia.Entity.Id},
                new Place {Latitude = 51.75532, Longitude = 19.453509, BuildingId = weeia.Entity.Id},
            };
            context.Places.AddRange(weeiaPlaces);



            var ctiLogo = new Logo
            {
                Content = File.ReadAllBytes($"{logosPath}cti.jpg"),
                ContentType = "jpg",
            };


            var citlogores = context.Logos.Add(ctiLogo);

            var cti = context.Buildings.Add(new Building
            {
                Address = "B-19, Wólczańska 217/223, 90-924 Łódź",
                Description = "Centrum Technologii Informatycznych – ogólnouczelniana jednostka Politechniki Łódzkiej. Zadaniem Centrum Technologii Informatycznych jest wspieranie kształcenia w zakresie budowania i wykorzystywania",
                Name = "CTI"
            });

            context.Faculties.Add(new Faculty
            {
                LogoId = citlogores.Entity.Id,
                Name = "CTI_LOGO",
                ShortName = "CTI",
                BuildingId = cti.Entity.Id
            });

            var ctiPlaces = new List<Place>
            {
                new Place {Latitude = 51.747054, Longitude = 19.455819, BuildingId = cti.Entity.Id},
                new Place {Latitude = 51.747364, Longitude = 19.455817, BuildingId = cti.Entity.Id},
            };
            context.Places.AddRange(ctiPlaces);
            context.SaveChanges();
        }
    }
}
