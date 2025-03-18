using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Queries.TestimonialQueries;
using RentACar.Application.Features.Mediator.Results.TestimonialResults;
using RentACar.Application.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Mediator.Handlers.TestimonialHandlers.Read
{
    public class GetTestimonialQueryHandler : IRequestHandler<GetTestimonialQuery, IQueryable<GetTestimonialQueryResult>>
    {
        private readonly IReadRepository<Testimonial> _readRepository;

        public GetTestimonialQueryHandler(IReadRepository<Testimonial> readRepository)
        {
            _readRepository = readRepository;
        }

        public Task<IQueryable<GetTestimonialQueryResult>> Handle(GetTestimonialQuery request, CancellationToken cancellationToken)
        {
            var values = _readRepository.GetAll(false).Select(x => new GetTestimonialQueryResult
            {
                Id = x.Id,
                ImageURL = x.ImageURL,
                TestimonialComment = x.TestimonialComment,
                TestimonialName = x.TestimonialName,
                TestimonialTitle = x.TestimonialTitle
            });
            return Task.FromResult(values);
        }
    }
}
