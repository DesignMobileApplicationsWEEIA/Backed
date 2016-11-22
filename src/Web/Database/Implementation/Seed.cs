using System.Collections.Generic;
using System.Linq;
using Domain.Database.Interfaces;
using Domain.Model.Database;

namespace Web.Migrations
{
    public class Seed
    {
        public static void Init(IDbContext context)
        {
            if (context.Places.Any())
            {
                return;
            }

            var weeiaLogo = new Logo()
            {
               Content = null,
               ContentType = "png",
            };


            var logoRes = context.Logos.Add(weeiaLogo);

            var building = context.Buildings.Add(new Building()
            {
                Address = "Bohdana Stefanowskiego 18/22, Łódź",
                Description = "Wydział Elektrotechniki, Elektroniki, Informatyki i Automatyki Politechniki Łódzkiej",
                Name = "Weeia"
            });

            context.Faculties.Add(new Faculty()
            {
                LogoId = logoRes.Entity.Id,
                Name = "WEEIA_LOGO",
                ShortName = "weeia",
                BuildingId = building.Entity.Id
            });

            var weeiaPlaces = new List<Place>()
            {
                new Place() {Latitude = 51.752497, Longitude = 19.453010, BuildingId = building.Entity.Id},
                new Place() {Latitude = 51.75532, Longitude = 19.453509, BuildingId = building.Entity.Id},
            };
            context.Places.AddRange(weeiaPlaces);
            context.SaveChanges();
        }
    }
}
