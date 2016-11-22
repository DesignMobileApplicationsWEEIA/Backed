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
               Content = null
            };

            var weeiaPlaces = new List<Place>()
            {
                new Place() {Latitude = 51.752497, Longitude = 19.453010},
                new Place() {Latitude = 51.75532, Longitude = 19.453509}
            };

            var weeiaFaculties = new List<Faculty>()
            {
                new Faculty()
                {
                   Logo = weeiaLogo,
                   Name = "WEEIA_LOGO",
                   ShortName = "weeia"
                }
            };

            var weeia = new Building()
            {
                Address = "Bohdana Stefanowskiego 18/22, Łódź",
                Places = weeiaPlaces,
                Description = "Wydział Elektrotechniki, Elektroniki, Informatyki i Automatyki Politechniki Łódzkiej",
                Faculties = new List<Faculty>()
                
            };

            weeiaPlaces.ForEach(x => x.Building = weeia);
        }
    }
}
