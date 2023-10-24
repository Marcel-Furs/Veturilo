using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veturilo.Infrastructure.Entities;

namespace Veturilo.Application.Services
{
    public interface IRentService
    {
        public List<Station> GetAllStations();
        public List<Bike> GetBikesFromStation(int stationId);
        public Rent RentBike(int userId, int bikeId, int stationFromId);
        public Rent EndBikeRental(int rentId, int stationToId);
        public List<Rent> GetUserRents(int userId);
        public Station GetStation(int id);
    }
}
