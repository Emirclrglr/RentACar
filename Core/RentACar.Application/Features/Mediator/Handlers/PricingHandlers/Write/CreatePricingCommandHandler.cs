using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Commands.PricingCommands;
using RentACar.Application.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Mediator.Handlers.PricingHandlers.Write
{
    public class CreatePricingCommandHandler : IRequestHandler<CreatePricingCommand>
    {
        private readonly IWriteRepository<Pricing> _writeRepository;

        public CreatePricingCommandHandler(IWriteRepository<Pricing> writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task Handle(CreatePricingCommand request, CancellationToken cancellationToken)
        {
            await _writeRepository.AddAsync(new()
            {
                Name = request.Name
            });
            await _writeRepository.SaveAsync();
        }
    }
}
