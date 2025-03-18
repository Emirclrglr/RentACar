using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Results.TestimonialResults;
using RentACar.Domain.Entities.Common;

namespace RentACar.Application.Features.Mediator.Queries.TestimonialQueries
{
    public class GetTestimonialByIdQuery:BaseEntity,IRequest<GetTestimonialByIdQueryResult>
    {
        public GetTestimonialByIdQuery(int id)
        {
            Id = id;
        }
    }
}
