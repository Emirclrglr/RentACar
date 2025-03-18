using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Commands.ReviewCommands;
using RentACar.Application.IRepositories.IReviewRepository;

namespace RentACar.Application.Features.Mediator.Handlers.ReviewHandlers.Write
{
    public class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommand>
    {
        private readonly IReviewReadRepository _reviewReadRepository;
        private readonly IReviewWriteRepository _reviewWriteRepository;

        public UpdateReviewCommandHandler(IReviewReadRepository reviewReadRepository, IReviewWriteRepository reviewWriteRepository)
        {
            _reviewReadRepository = reviewReadRepository;
            _reviewWriteRepository = reviewWriteRepository;
        }

        public async Task Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            var value = await _reviewReadRepository.GetByIdAsync(request.Id);
            value.CustomerName = request.CustomerName;
            value.CustomerImage = request.CustomerImage;
            value.Comment = request.Comment;
            value.RatingValue = request.RatingValue;
            value.ReviewDate = request.ReviewDate;
            value.CarId = request.CarId;
            await _reviewWriteRepository.SaveAsync();
        }
    }
}
