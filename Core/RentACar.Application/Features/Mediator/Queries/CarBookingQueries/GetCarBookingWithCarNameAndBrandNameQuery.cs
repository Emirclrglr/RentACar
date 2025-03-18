using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Results.CarBookingResults;
using RentACar.Domain.Entities.Common;

namespace RentACar.Application.Features.Mediator.Queries.CarBookingQueries
{
    public class GetCarBookingWithCarNameAndBrandNameQuery : BaseEntity, IRequest<IQueryable<GetCarBookingWithCarNameAndBrandNameQueryResult>>
    {
        public GetCarBookingWithCarNameAndBrandNameQuery(int id)
        {
            LocationId = id;
        }

        public int LocationId { get; set; }

    }
}
