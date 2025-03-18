using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Commands.ReviewCommands;
using RentACar.Application.IRepositories.IReviewRepository;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Mediator.Handlers.ReviewHandlers.Write
{
    public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand>
    {
        private readonly IReviewWriteRepository _reviewWriteRepository;

        public CreateReviewCommandHandler(IReviewWriteRepository reviewWriteRepository)
        {
            _reviewWriteRepository = reviewWriteRepository;
        }

        public async Task Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            await _reviewWriteRepository.AddAsync(new()
            {
                CustomerName = request.CustomerName,
                CustomerImage = request.CustomerImage,
                Comment = request.Comment,
                RatingValue = request.RatingValue,
                CarId = request.CarId,
                ReviewDate = DateTime.Parse(DateTime.Now.ToString())
            });
            await _reviewWriteRepository.SaveAsync();
        }
    }
}
