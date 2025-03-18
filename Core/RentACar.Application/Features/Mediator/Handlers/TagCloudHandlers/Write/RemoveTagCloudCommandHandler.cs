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
    public class RemoveTagCloudCommandHandler : IRequestHandler<RemoveTagCloudCommand>
    {
        private readonly IReadRepository<TagCloud> _readRepository;
        private readonly IWriteRepository<TagCloud> _writeRepository;

        public RemoveTagCloudCommandHandler(IWriteRepository<TagCloud> writeRepository, IReadRepository<TagCloud> readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task Handle(RemoveTagCloudCommand request, CancellationToken cancellationToken)
        {
            var tagCloud = await _readRepository.GetByIdAsync(request.Id, false);
            _writeRepository.Remove(tagCloud);
            await _writeRepository.SaveAsync();
        }
    }
}
