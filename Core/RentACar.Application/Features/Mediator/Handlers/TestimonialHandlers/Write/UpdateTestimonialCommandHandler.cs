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
    public class UpdateTestimonialCommandHandler : IRequestHandler<UpdateTestimonialCommand>
    {
        private readonly IWriteRepository<Testimonial> _writeRepository;

        public UpdateTestimonialCommandHandler(IWriteRepository<Testimonial> writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
        {
            _writeRepository.Update(new()
            {
                Id = request.Id,
                ImageURL = request.ImageURL,
                TestimonialComment = request.TestimonialComment,
                TestimonialName = request.TestimonialName,
                TestimonialTitle = request.TestimonialTitle
            });
            await _writeRepository.SaveAsync();
        }
    }
}
