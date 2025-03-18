using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Domain.Entities.Common;

namespace RentACar.Application.Features.Mediator.Results.CarFeatureResults
{
    public class GetCarFeatureQueryResult:BaseEntity
    {
        public int CarId { get; set; }
        public int FeatureId { get; set; }
        public bool IsAvailable { get; set; }
    }
}
