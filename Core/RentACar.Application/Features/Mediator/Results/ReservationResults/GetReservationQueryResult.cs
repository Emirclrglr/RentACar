using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Domain.Entities;
using RentACar.Domain.Entities.Common;

namespace RentACar.Application.Features.Mediator.Results.ReservationResults
{
    public class GetReservationQueryResult:BaseEntity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Age { get; set; }
        public DateOnly DriverLicenseDate { get; set; }
        public string? Description { get; set; }
        public string Status { get; set; }
        public int CarId { get; set; }
        public int PickUpLocationId { get; set; }
        public int DropOffLocationId { get; set; }
    }
}
