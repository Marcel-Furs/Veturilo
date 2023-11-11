using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veturilo.Infrastructure.Entities
{
    public class Bike : IEntity
    {
        public static readonly string AvailableStatus = "Available";
        public static readonly string UnavailableStatus = "Unavailable";


        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Status { get; set; } = null!;

        public Station Station { get; set; } = null!;

    }
}
