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
    public class UpdateCarCommandHandler
    {
        private readonly IWriteRepository<Car> _writeRepository;

        public UpdateCarCommandHandler(IWriteRepository<Car> writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task Handle(UpdateCarCommand command) 
        {
            _writeRepository.Update(new()
            {
                Id = command.Id,
                Model = command.Model,
                BrandId = command.BrandId,
                BigIMG = command.BigIMG,
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
