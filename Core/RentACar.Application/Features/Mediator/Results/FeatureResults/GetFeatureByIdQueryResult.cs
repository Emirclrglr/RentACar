using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Domain.Entities.Common;

namespace RentACar.Application.Features.Mediator.Results.FeatureResults
{
    public class GetFeatureByIdQueryResult:BaseEntity
    {
        public string FeatureName { get; set; }
    }
}
