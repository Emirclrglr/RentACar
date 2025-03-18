using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Results.ReservationResults;
using RentACar.Domain.Entities.Common;

namespace RentACar.Application.Features.Mediator.Queries.ReservationQueries
{
    public class GetReservationByIdQuery:BaseEntity, IRequest<GetReservationByIdQueryResult>
    {
        public GetReservationByIdQuery(int id)
        {
            Id = id;
        }
    }
}
