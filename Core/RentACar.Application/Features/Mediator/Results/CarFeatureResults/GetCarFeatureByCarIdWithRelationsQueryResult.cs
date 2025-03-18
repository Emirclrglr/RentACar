using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Domain.Entities.Common;

namespace RentACar.Application.Features.Mediator.Results.CarFeatureResults
{
    public class GetCarFeatureByCarIdWithRelationsQueryResult : BaseEntity
    {
        public int FeatureId { get; set; }
        public int CarId { get; set; }
        public string CarBrand { get; set; }
        public string CarModel { get; set; }
        public string CarFeatureName { get; set; }
        public bool IsAvailable { get; set; }
    }
}
