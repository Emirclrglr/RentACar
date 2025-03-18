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
    public class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommand>
    {
        private readonly IReviewReadRepository _reviewReadRepository;
        private readonly IReviewWriteRepository _reviewWriteRepository;

        public DeleteReviewCommandHandler(IReviewReadRepository reviewReadRepository, IReviewWriteRepository reviewWriteRepository)
        {
            _reviewReadRepository = reviewReadRepository;
            _reviewWriteRepository = reviewWriteRepository;
        }

        public async Task Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
        {
            var values = await _reviewReadRepository.GetByIdAsync(request.Id);
            _reviewWriteRepository.Remove(values);
            await _reviewWriteRepository.SaveAsync();
        }
    }
}
