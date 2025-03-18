using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Results.CarBookingResults;

namespace RentACar.Application.Features.Mediator.Queries.CarBookingQueries
{
    public class GetCarBookingsLocationWithCarCountQuery:IRequest<IQueryable<GetCarBookingsLocationWithCarCountQueryResult>>
    {
    }
}
