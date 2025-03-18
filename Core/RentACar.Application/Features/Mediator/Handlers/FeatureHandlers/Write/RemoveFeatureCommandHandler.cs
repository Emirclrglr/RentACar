using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Commands.FeatureCommands;
using RentACar.Application.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Mediator.Handlers.FeatureHandlers.Write
{
    public class RemoveFeatureCommandHandler : IRequestHandler<RemoveFeautreCommand>
    {
        private readonly IWriteRepository<Feature> _writeRepository;
        private readonly IReadRepository<Feature> _readRepository;

        public RemoveFeatureCommandHandler(IReadRepository<Feature> readRepository, IWriteRepository<Feature> writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task Handle(RemoveFeautreCommand request, CancellationToken cancellationToken)
        {
            var values = await _readRepository.GetByIdAsync(request.Id, false);
            _writeRepository.Remove(values);
            await _writeRepository.SaveAsync();
        }
    }
}
