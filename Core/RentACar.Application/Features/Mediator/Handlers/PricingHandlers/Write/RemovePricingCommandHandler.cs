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
    public class RemovePricingCommandHandler : IRequestHandler<RemovePricingCommand>
    {
        private readonly IWriteRepository<Pricing> _writeRepository;
        private readonly IReadRepository<Pricing> _readRepository;

        public RemovePricingCommandHandler(IReadRepository<Pricing> readRepository, IWriteRepository<Pricing> writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task Handle(RemovePricingCommand request, CancellationToken cancellationToken)
        {
            var values = await _readRepository.GetByIdAsync(request.Id, false);
            _writeRepository.Remove(values);
            await _writeRepository.SaveAsync();
        }
    }
}
