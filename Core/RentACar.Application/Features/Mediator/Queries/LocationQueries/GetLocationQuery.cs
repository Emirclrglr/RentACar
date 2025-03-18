using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Results.LocationResults;

namespace RentACar.Application.Features.Mediator.Queries.LocationQueries
{
    public class GetLocationQuery:IRequest<IQueryable<GetLocationQueryResult>>
    {
    }
}
