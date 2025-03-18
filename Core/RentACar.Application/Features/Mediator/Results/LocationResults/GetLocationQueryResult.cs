using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Domain.Entities.Common;

namespace RentACar.Application.Features.Mediator.Results.LocationResults
{
    public class GetLocationQueryResult:BaseEntity
    {
        public string LocationName { get; set; }
    }
}
