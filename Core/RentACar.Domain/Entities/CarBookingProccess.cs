using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Domain.Entities.Common;

namespace RentACar.Domain.Entities
{
    public class CarBookingProccess : BaseEntity
    {
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public int PickUpLocation { get; set; }
        public int DropOffLocation { get; set; }
        public DateOnly PickUpDate { get; set; }
        public DateOnly? DropOffDate { get; set; }
        public TimeOnly PickUpTime { get; set; }
        public TimeOnly? DropOffTime { get; set; }
        public string PickUpDescription { get; set; }
        public string? DropOffDescription { get; set; }
        public decimal TotalPrice { get; set; }
        public Customer Customer { get; set; }
    }
}
