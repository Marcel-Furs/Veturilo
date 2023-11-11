using AutoMapper;
using Veturilo.API.Dto;
using Veturilo.Infrastructure.Entities;

namespace Veturilo.API.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Rent, RentDto>()
                .ForMember(x => x.StationFromName, y => y.MapFrom(x => x.StationFrom.Name))
                .ForMember(x => x.StationToName, y => y.MapFrom(x => x.StationTo.Name))
                .ForMember(x => x.BikeName, y => y.MapFrom(x => x.Bike.Name));
                
        }
    }
}
