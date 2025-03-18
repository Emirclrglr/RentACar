using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Results.LocationResults;
using RentACar.Domain.Entities.Common;

namespace RentACar.Application.Features.Mediator.Queries.LocationQueries
{
    public class GetLocationByIdQuery:BaseEntity,IRequest<GetLocationByIdQueryResult>
    {
        public GetLocationByIdQuery(int id)
        {
            Id = id;
        }
    }
}
