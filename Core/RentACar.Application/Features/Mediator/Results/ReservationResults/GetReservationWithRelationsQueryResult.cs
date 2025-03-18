using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Domain.Entities.Common;

namespace RentACar.Application.Features.Mediator.Results.ReservationResults
{
    public class GetReservationWithRelationsQueryResult : BaseEntity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Age { get; set; }
        public DateOnly DriverLicenseDate { get; set; }
        public string? Description { get; set; }
        public string Status { get; set; }
        public string CarName { get; set; }
        public string PickUpLocationName { get; set; }
        public string DropOffLocationName { get; set; }
    }
}
