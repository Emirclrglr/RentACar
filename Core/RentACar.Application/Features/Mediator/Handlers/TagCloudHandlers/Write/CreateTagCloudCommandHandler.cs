using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Commands.TagCloudCommands;
using RentACar.Application.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Mediator.Handlers.TagCloudHandlers.Write
{
    public class CreateTagCloudCommandHandler : IRequestHandler<CreateTagCloudCommand>
    {
        private readonly IWriteRepository<TagCloud> _writeRepository;

        public CreateTagCloudCommandHandler(IWriteRepository<TagCloud> writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task Handle(CreateTagCloudCommand request, CancellationToken cancellationToken)
        {
            await _writeRepository.AddAsync(new()
            {
                Title = request.Title,
                BlogId = request.BlogId
            });
            await _writeRepository.SaveAsync();
        }
    }
}
