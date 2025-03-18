using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Domain.Entities.Common;

namespace RentACar.Domain.Entities
{
    public class Car:BaseEntity
    {
        public string Model { get; set; }
        public string CoverIMG { get; set; }
        public string BigIMG { get; set; }
        public int Kilometer { get; set; }
        public string Transmission { get; set; }
        public byte Seats { get; set; }
        public byte Luggage { get; set; }
        public string FuelType { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public ICollection<CarFeature> CarFeatures { get; set; }
        public ICollection<CarDescription> CarDescriptions { get; set; }
        public ICollection<CarPricing> CarPricings { get; set; }
        public ICollection<CarBooking> CarBookings { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
