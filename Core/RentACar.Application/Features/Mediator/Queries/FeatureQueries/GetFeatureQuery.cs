using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Results.FeatureResults;

namespace RentACar.Application.Features.Mediator.Queries.FeatureQueries
{
    public class GetFeatureQuery:IRequest<IQueryable<GetFeatureQueryResult>>
    {
    }
}
