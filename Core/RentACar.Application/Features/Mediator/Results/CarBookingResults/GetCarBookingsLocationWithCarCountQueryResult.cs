using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Results.CarBookingResults
{
    public class GetCarBookingsLocationWithCarCountQueryResult
    {
        public string LocationName { get; set; }
        public int VehicleCount { get; set; }
    }
}
