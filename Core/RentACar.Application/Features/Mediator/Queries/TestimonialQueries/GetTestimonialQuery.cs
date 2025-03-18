using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Results.TestimonialResults;

namespace RentACar.Application.Features.Mediator.Queries.TestimonialQueries
{
    public class GetTestimonialQuery:IRequest<IQueryable<GetTestimonialQueryResult>>
    {
    }
}
