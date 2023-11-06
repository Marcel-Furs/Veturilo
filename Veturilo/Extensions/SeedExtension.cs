using System.Security.Cryptography;
using Veturilo.Application.Services;
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
            stationRepository?.Add(new Station
            {
                Address = "ul. Świętokrzyska 14",
                Name = "S001"
            });

            stationRepository?.Add(new Station
            {
                Address = "ul. Marszałkowska 22",
                Name = "M302"
            });

            stationRepository?.Add(new Station
            {
                Address = "Plac Zamkowy 5",
                Name = "Z055"
            });

            stationRepository?.Add(new Station
            {
                Address = "ul. Nowy Świat 33",
                Name = "N122"
            });

            stationRepository?.Add(new Station
            {
                Address = "ul. Krucza 12",
                Name = "K034"
            });

            stationRepository?.Add(new Station
            {
                Address = "Plac Konstytucji 3 Maja 7",
                Name = "K345"
            });

            stationRepository?.Add(new Station
            {
                Address = "Aleja Jana Pawła II 50",
                Name = "J129"
            });

            stationRepository?.Add(new Station
            {
                Address = "ul. Wilcza 22",
                Name = "W042"
            });

            stationRepository?.Add(new Station
            {
                Address = "Plac Teatralny 6",
                Name = "T013"
            });

            stationRepository?.Add(new Station
            {
                Address = "ul. Nowy Świat 17",
                Name = "N102"
            });

        }
        public static void SeedUsers(this WebApplication? app)
        {
            var userRepository = app?.Services.GetService<IBaseRepository<User>>();
            var hmacService = app?.Services.GetService<IPasswordService>();
            for(int i = 1; i <= 9; i++)
            {
                hmacService.CreateHash("test1234", out byte[] hash, out byte[] salt);
                userRepository?.Add(new User
                {
                    Id = i,
                    PasswordHash = hash,
                    PasswordSalt = salt,
                    Username = "user" + i
                });
            }
        }

        public static void SeedBikes(this WebApplication? app)
        {
            var bikeRepository = app?.Services.GetService<IBaseRepository<Bike>>();
            var stationRepository = app?.Services.GetService<IBaseRepository<Station>>();
            var stations = stationRepository?.GetAll().ToList();

            Random rand = new Random();
            for(int i = 1; i <= 50; i++)
            {
                bikeRepository.Add(new Bike
                {
                    Name = "Bike" + i,
                    Station = stations[rand.Next(0, stations.Count)],
                    Status = "Available"
                });
            }
        }
    }
}
