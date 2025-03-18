using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Domain.Entities.Common;

namespace RentACar.Application.Features.Mediator.Results.CarBookingResults
{
    public class GetCarBookingWithCarNameAndBrandNameQueryResult : BaseEntity
    {
        public string CarName { get; set; }
        public int CarId { get; set; }
        public string BrandName { get; set; }
        public decimal Price { get; set; }
        public string PricingName { get; set; }
        public string CarImage { get; set; }
    }
}
