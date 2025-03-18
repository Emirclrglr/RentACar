using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Domain.Entities.Common;

namespace RentACar.Domain.Entities
{
    public class Location:BaseEntity
    {
        public string LocationName { get; set; }
        public ICollection<CarBooking> CarBookings { get; set; }
    }
}
