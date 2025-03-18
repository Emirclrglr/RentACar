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
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand>
    {
        private readonly IWriteRepository<Service> _writeRepository;

        public UpdateServiceCommandHandler(IWriteRepository<Service> writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            _writeRepository.Update(new()
            {
                Id = request.Id,
                Description = request.Description,
                Icon = request.Icon,
                Title = request.Title
            });
            await _writeRepository.SaveAsync();
        }
    }
}
