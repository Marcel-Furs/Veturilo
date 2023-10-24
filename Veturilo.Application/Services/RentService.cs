using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veturilo.Application.Exceptions;
using Veturilo.Application.Utils;
using Veturilo.Infrastructure.Entities;
using Veturilo.Infrastructure.Repositories;

namespace Veturilo.Application.Services
{
    public class RentService : IRentService
    {
        private readonly IBaseRepository<User> userRepository;
        private readonly IBaseRepository<Station> stationRepository;
        private readonly IBaseRepository<Rent> rentRepository;
        private readonly IBaseRepository<Bike> bikeRepository;

        public RentService(IBaseRepository<User> userRepository,
            IBaseRepository<Station> stationRepository,
            IBaseRepository<Rent> rentRepository, 
            IBaseRepository<Bike> bikeRepository)
        {
            this.userRepository = userRepository;
            this.stationRepository = stationRepository;
            this.rentRepository = rentRepository;
            this.bikeRepository = bikeRepository;
        }

        public Rent EndBikeRental(int rentId, int stationToId)
        {
            throw new NotImplementedException();
        }

        public List<Station> GetAllStations()
        {
            return stationRepository.GetAll().ToList();
        }

        public Station GetStation(int id)
        {
            var station = stationRepository.Get(id) ?? throw new ItemNotExistsException(id, nameof(Station));
            return station;
        }

        public List<Bike> GetBikesFromStation(int stationId)
        {
            return bikeRepository.FindAll(x => x.Station.Id == stationId).ToList();
        }

        public List<Rent> GetUserRents(int userId)
        {
            return rentRepository.FindAll(x => x.User.Id == userId).ToList();
        }

        public Rent RentBike(int userId, int bikeId, int stationFromId)
        {
            var user = userRepository.Get(userId) ?? throw new ItemNotExistsException(userId, nameof(User)); 
            var bike = bikeRepository.Get(bikeId) ?? throw new ItemNotExistsException(bikeId, nameof(Bike)); 
            var stationFrom = stationRepository.Get(stationFromId) ?? throw new ItemNotExistsException(stationFromId, nameof(Station));

            var rent = new Rent
            {
                DateStart = DateTime.Now,
                StationFrom = stationFrom,
                User = user
            };
            return rentRepository.Add(rent);
        }

        public Rent FinishRentBike(int userId, int rentId, int stationToId)
        {
            var rent = rentRepository.Get(rentId) ?? throw new ItemNotExistsException(rentId, nameof(Rent));
            var user = userRepository.Get(userId) ?? throw new ItemNotExistsException(userId, nameof(User));
            var stationTo = stationRepository.Get(stationToId) ?? throw new ItemNotExistsException(stationToId, nameof(Station));

            if(rent.User.Id != userId)
            {
                throw new PermissionException($"Rent id {rentId} does not belong to user id {userId}");
            }

            if(rent.DateStop != null)
            {
                throw new OperationException("Cant finish finished rent");
            }

            rent.DateStop = DateTime.Now;
            rent.StationTo = stationTo;
            rent.FinalPrice = RentPriceUtil.CountFinalPrice(rent.DateStart, rent.DateStop.Value);
            return rentRepository.Update(rent);
        }
    }
}
