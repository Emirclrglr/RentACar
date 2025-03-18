using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Commands.CarFeatureCommands;
using RentACar.Application.IRepositories.ICarFeatureRepository;

namespace RentACar.Application.Features.Mediator.Handlers.CarFeatureHandlers.Write
{
    public class UpdateCarFeatureIsAvailableToTrueCommandHandler:IRequestHandler<UpdateCarFeatureIsAvailableToTrueCommand>
    {
        private readonly ICarFeatureWriteRepository _carFeatureWriteRepository;

        public UpdateCarFeatureIsAvailableToTrueCommandHandler(ICarFeatureWriteRepository carFeatureWriteRepository)
        {
            _carFeatureWriteRepository = carFeatureWriteRepository;
        }

        public async Task Handle(UpdateCarFeatureIsAvailableToTrueCommand request, CancellationToken cancellationToken)
        {
            await _carFeatureWriteRepository.ChangeCarFeatureIsAvailableToTrue(request.FeatureId);
            await _carFeatureWriteRepository.SaveAsync();
        }
    }
}
