using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Domain.Entities;
using RentACar.Domain.Entities.Common;

namespace RentACar.Application.Features.Mediator.Results.CarBookingResults
{
    public class GetCarBookingQueryResult : BaseEntity
    {
        public int CarId { get; set; }
    }
}
