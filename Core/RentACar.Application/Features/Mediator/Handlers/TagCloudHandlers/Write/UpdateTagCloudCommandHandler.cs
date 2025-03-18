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
    public class UpdateTagCloudCommandHandler : IRequestHandler<UpdateTagCloudCommand>
    {
        private readonly IReadRepository<TagCloud> _readRepository;
        private readonly IWriteRepository<TagCloud> _writeRepository;

        public UpdateTagCloudCommandHandler(IWriteRepository<TagCloud> writeRepository, IReadRepository<TagCloud> readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task Handle(UpdateTagCloudCommand request, CancellationToken cancellationToken)
        {
            var tagClouds = await _readRepository.GetByIdAsync(request.Id);
            tagClouds.Id = request.Id;
            tagClouds.Title = request.Title;
            tagClouds.BlogId = request.BlogId;
            await _writeRepository.SaveAsync();
        }
    }
}
