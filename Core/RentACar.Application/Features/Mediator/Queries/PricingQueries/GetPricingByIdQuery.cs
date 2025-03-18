using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Results.PricingResults;
using RentACar.Domain.Entities.Common;

namespace RentACar.Application.Features.Mediator.Queries.PricingQueries
{
    public class GetPricingByIdQuery:BaseEntity, IRequest<GetPricingByIdQueryResult>
    {
        public GetPricingByIdQuery(int id)
        {
            Id = id;
        }
    }
}
