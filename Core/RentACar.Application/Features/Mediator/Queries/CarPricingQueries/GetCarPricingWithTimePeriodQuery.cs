using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Results.CarPricingResults;

namespace RentACar.Application.Features.Mediator.Queries.CarPricingQueries
{
    public class GetCarPricingWithTimePeriodQuery : IRequest<IQueryable<GetCarPricingWithTimePeriodQueryResult>>
    {
    }
}
