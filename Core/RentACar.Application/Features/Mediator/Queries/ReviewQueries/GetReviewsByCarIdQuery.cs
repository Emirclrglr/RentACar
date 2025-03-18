using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Results.ReviewResults;

namespace RentACar.Application.Features.Mediator.Queries.ReviewQueries
{
    public class GetReviewsByCarIdQuery:IRequest<IQueryable<GetReviewsByCarIdQueryResult>>
    {
        public int CarId { get; set; }

        public GetReviewsByCarIdQuery(int carId)
        {
            CarId = carId;
        }
    }
}
