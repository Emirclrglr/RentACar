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
    public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand>
    {
        private readonly IWriteRepository<Location> _writeRepository;

        public CreateLocationCommandHandler(IWriteRepository<Location> writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            await _writeRepository.AddAsync(new()
            {
                LocationName = request.LocationName
            });
            await _writeRepository.SaveAsync();
        }
    }
}
