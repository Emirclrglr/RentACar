using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Domain.Entities.Common;

namespace RentACar.Application.Features.Mediator.Results.CarResults
{
    public class GetBrandsByCarCountQueryResult
    {
        public string BrandName { get; set; }
        public int VehicleCount { get; set; }
    }
}
