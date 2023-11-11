using Veturilo.Infrastructure.Entities;

namespace Veturilo.API.Dto
{
    public class RentDto
    {
        public int Id { get; set; }
        public string StationFromName { get; set; } = null!;
        public string StationToName { get; set; } = null!;
        public DateTime DateStart { get; set; }
        public DateTime? DateStop { get; set; } = null;
        public double? FinalPrice { get; set; } = null;
        public string BikeName { get; set; } = null!;
    }
}
