using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Commands.ServiceCommands;
using RentACar.Application.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Mediator.Handlers.ServiceHandlers.Write
{
    public class RemoveServiceCommandHandler : IRequestHandler<RemoveServiceCommand>
    {
        private readonly IWriteRepository<Service> _writeRepository;
        private readonly IReadRepository<Service> _readRepository;

        public RemoveServiceCommandHandler(IReadRepository<Service> readRepository, IWriteRepository<Service> writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task Handle(RemoveServiceCommand request, CancellationToken cancellationToken)
        {
            var values = await _readRepository.GetByIdAsync(request.Id, false);
            _writeRepository.Remove(values);
            await _writeRepository.SaveAsync();
        }
    }
}
