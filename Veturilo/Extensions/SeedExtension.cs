using Veturilo.Infrastructure.Entities;
using Veturilo.Infrastructure.Repositories;

namespace Veturilo.API.Extensions
{
    public static class SeedExtension
    {
        public static void SeedStations(this WebApplication? app)
        {
            var stationRepository = app?.Services.GetService<IBaseRepository<Station>>();
            stationRepository?.Add(new Station
            {
                Address = "Aleja komisji edukacji narodowej 26",
                Name = "A125"
            });

        }
    }
}
