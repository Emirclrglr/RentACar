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
    public class UpdateFeatureCommandHandler : IRequestHandler<UpdateFeatureCommand>
    {
        private readonly IWriteRepository<Feature> _writeRepository;

        public UpdateFeatureCommandHandler(IWriteRepository<Feature> writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task Handle(UpdateFeatureCommand request, CancellationToken cancellationToken)
        {
            _writeRepository.Update(new()
            {
                Id = request.Id,
                FeatureName = request.FeatureName
            });
            await _writeRepository.SaveAsync();
        }
    }
}
