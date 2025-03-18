using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Commands.LocationCommands;
using RentACar.Application.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Mediator.Handlers.LocationHandlers.Write
{
    public class UpdateLocationComandHandler : IRequestHandler<UpdateLocationCommand>
    {
        private readonly IWriteRepository<Location> _writeRepository;

        public UpdateLocationComandHandler(IWriteRepository<Location> writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
        {
            _writeRepository.Update(new()
            {
                Id = request.Id,
                LocationName = request.LocationName
            });
            await _writeRepository.SaveAsync();
        }
    }
}
