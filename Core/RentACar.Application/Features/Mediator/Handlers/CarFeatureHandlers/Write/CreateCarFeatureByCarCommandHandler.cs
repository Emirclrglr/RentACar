using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Commands.CarFeatureCommands;
using RentACar.Application.IRepositories.ICarFeatureRepository;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Mediator.Handlers.CarFeatureHandlers.Write
{
    public class CreateCarFeatureByCarCommandHandler : IRequestHandler<CreateCarFeatureByCarCommand>
    {
        private readonly ICarFeatureWriteRepository _carFeatureWriteRepository;

        public CreateCarFeatureByCarCommandHandler(ICarFeatureWriteRepository carFeatureWriteRepository)
        {
            _carFeatureWriteRepository = carFeatureWriteRepository;
        }

        public async Task Handle(CreateCarFeatureByCarCommand request, CancellationToken cancellationToken)
        {
            await _carFeatureWriteRepository.AddAsync(new CarFeature()
            {
                CarId = request.CarId,
                FeatureId = request.FeatureId,
                IsAvailable = false
            });
            await _carFeatureWriteRepository.SaveAsync();
        }
    }
}
