using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Domain.Entities.Common;

namespace RentACar.Application.Features.Mediator.Results.CarDescriptionResults
{
    public class GetCarDescriptionByIdQueryResult:BaseEntity
    {
        public string Details { get; set; }
        public int CarId { get; set; }
    }
}
