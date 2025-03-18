using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Results.PricingResults;

namespace RentACar.Application.Features.Mediator.Queries.PricingQueries
{
    public class GetPricingQuery:IRequest<IQueryable<GetPricingQueryResult>>
    {
    }
}
