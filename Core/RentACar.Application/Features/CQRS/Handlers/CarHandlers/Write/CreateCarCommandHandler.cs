using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Application.Features.CQRS.Commands.CarCommands;
using RentACar.Application.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.CQRS.Handlers.CarHandlers.Write
{
    public class CreateCarCommandHandler
    {
        private readonly IWriteRepository<Car> _writeRepository;

        public CreateCarCommandHandler(IWriteRepository<Car> writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task Handle(CreateCarCommand command)
        {
            await _writeRepository.AddAsync(new()
            {
                Model = command.Model,
                BigIMG = command.BigIMG,
                BrandId = command.BrandId,
                CoverIMG = command.CoverIMG,
                FuelType = command.FuelType,
                Kilometer = command.Kilometer,
                Luggage = command.Luggage,
                Seats = command.Seats,
                Transmission = command.Transmission
            });
            await _writeRepository.SaveAsync();
        }
    }
}
