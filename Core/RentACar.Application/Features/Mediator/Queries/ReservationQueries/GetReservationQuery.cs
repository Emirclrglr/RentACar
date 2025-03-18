using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Results.ReservationResults;

namespace RentACar.Application.Features.Mediator.Queries.ReservationQueries
{
    public class GetReservationQuery:IRequest<IQueryable<GetReservationQueryResult>>
    {
    }
}
