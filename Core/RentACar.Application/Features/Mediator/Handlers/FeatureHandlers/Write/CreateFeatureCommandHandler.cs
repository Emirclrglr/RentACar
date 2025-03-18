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
    public class CreateFeatureCommandHandler : IRequestHandler<CreateFeatureCommand>
    {
        private readonly IWriteRepository<Feature> _writeRepository;

        public CreateFeatureCommandHandler(IWriteRepository<Feature> writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
        {
            await _writeRepository.AddAsync(new()
            {
                FeatureName = request.FeatureName,
            });
            await _writeRepository.SaveAsync();
        }

      
    }
}
