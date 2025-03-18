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
    public class GetTestimonialByIdQueryHandler : IRequestHandler<GetTestimonialByIdQuery, GetTestimonialByIdQueryResult>
    {
        private readonly IReadRepository<Testimonial> _readRepository;

        public GetTestimonialByIdQueryHandler(IReadRepository<Testimonial> readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<GetTestimonialByIdQueryResult> Handle(GetTestimonialByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _readRepository.GetByIdAsync(request.Id);
            return new GetTestimonialByIdQueryResult
            {
                Id = values.Id,
                ImageURL = values.ImageURL,
                TestimonialComment = values.TestimonialComment,
                TestimonialName = values.TestimonialName,
                TestimonialTitle = values.TestimonialTitle
            };
        }
    }
}
