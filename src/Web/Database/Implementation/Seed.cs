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

            var weeiaPlaces = new List<Place>()
            {
                new Place() {Latitude = 51.752497, Longitude = 19.453010},
                new Place() {Latitude = 51.75532, Longitude = 19.453509},
            };

            var logoRes = context.Logos.Add(weeiaLogo);

            context.Places.AddRange(weeiaPlaces);
            context.Faculties.Add(new Faculty()
            {
                Logo = logoRes.Entity,
                Name = "WEEIA_LOGO",
                ShortName = "weeia",
            });
            context.Buildings.Add(new Building()
            {
                Address = "Bohdana Stefanowskiego 18/22, Łódź",
                Places = context.Places.ToList(),
                Description = "Wydział Elektrotechniki, Elektroniki, Informatyki i Automatyki Politechniki Łódzkiej",
                Faculties = context.Faculties.ToList(),
                Name = "Weeia"
            });

        }
    }
}
