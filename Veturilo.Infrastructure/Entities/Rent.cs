using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veturilo.Infrastructure.Entities
{
    public class Rent : IEntity
    {
        public int Id { get; set; }
        public User User { get; set; } = null!;
        public Station StationFrom { get; set; } = null!;
        public Station StationTo { get; set; } = null!;
        public DateTime DateStart { get; set; }
        public DateTime? DateStop { get; set; } = null;
        public double? FinalPrice { get; set; } = null;
    }
}
