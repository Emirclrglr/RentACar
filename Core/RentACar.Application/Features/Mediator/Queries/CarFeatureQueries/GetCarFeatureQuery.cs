using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Results.CarFeatureResults;

namespace RentACar.Application.Features.Mediator.Queries.CarFeatureQueries
{
    public class GetCarFeatureQuery:IRequest<IQueryable<GetCarFeatureQueryResult>>
    {
    }
}
