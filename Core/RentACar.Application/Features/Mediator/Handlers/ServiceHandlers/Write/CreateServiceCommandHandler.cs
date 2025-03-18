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
    public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand>
    {
        private readonly IWriteRepository<Service> _writeRepository;

        public CreateServiceCommandHandler(IWriteRepository<Service> writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            await _writeRepository.AddAsync(new()
            {
                Title = request.Title,
                Description = request.Description,
                Icon = request.Icon
            });
            await _writeRepository.SaveAsync();
        }
    }
}
