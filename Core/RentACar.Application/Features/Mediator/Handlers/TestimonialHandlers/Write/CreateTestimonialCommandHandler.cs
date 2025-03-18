using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Commands.TestimonialCommands;
using RentACar.Application.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Mediator.Handlers.TestimonialHandlers.Write
{
    public class CreateTestimonialCommandHandler : IRequestHandler<CreateTestimonialCommand>
    {
        private readonly IWriteRepository<Testimonial> _writeRepository;

        public CreateTestimonialCommandHandler(IWriteRepository<Testimonial> writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task Handle(CreateTestimonialCommand request, CancellationToken cancellationToken)
        {
            await _writeRepository.AddAsync(new()
            {
                ImageURL = request.ImageURL,
                TestimonialComment = request.TestimonialComment,
                TestimonialName = request.TestimonialName,
                TestimonialTitle = request.TestimonialTitle
            });
            await _writeRepository.SaveAsync();
        }
    }
}
