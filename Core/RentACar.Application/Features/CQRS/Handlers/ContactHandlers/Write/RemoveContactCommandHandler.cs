using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Application.Features.CQRS.Commands.ContactCommands;
using RentACar.Application.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.CQRS.Handlers.ContactHandlers.Write
{
    public class RemoveContactCommandHandler
    {
        private readonly IReadRepository<Contact> _readRepository;
        private readonly IWriteRepository<Contact> _writeRepository;

        public RemoveContactCommandHandler(IReadRepository<Contact> readRepository, IWriteRepository<Contact> writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task Handle(RemoveContactCommand command)
        {
            var values = await _readRepository.GetByIdAsync(command.Id, false);
            _writeRepository.Remove(values);
            await _writeRepository.SaveAsync();
        }
    }
}
