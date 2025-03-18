using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Commands.FooterAddressCommands;
using RentACar.Application.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Mediator.Handlers.FooterAddressHandlers.Write
{
    internal class CreateFooterAddressCommandHandler : IRequestHandler<CreateFooterAddressCommand>
    {
        private readonly IWriteRepository<FooterAddress> _writeRepository;

        public CreateFooterAddressCommandHandler(IWriteRepository<FooterAddress> writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task Handle(CreateFooterAddressCommand request, CancellationToken cancellationToken)
        {
            await _writeRepository.AddAsync(new()
            {
                Address = request.Address,
                FooterDescription = request.FooterDescription,
                Mail = request.Mail,
                Phone = request.Phone
            });
            await _writeRepository.SaveAsync();
        }
    }
}
