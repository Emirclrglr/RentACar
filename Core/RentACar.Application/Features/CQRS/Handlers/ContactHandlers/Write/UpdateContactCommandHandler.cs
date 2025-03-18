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
    public class UpdateContactCommandHandler
    {
        private readonly IWriteRepository<Contact> _writeRepository;

        public UpdateContactCommandHandler(IWriteRepository<Contact> writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task Handle(UpdateContactCommand command)
        {
            _writeRepository.Update(new()
            {
                Id = command.Id,
                Email = command.Email,
                MessageContent = command.MessageContent,
                Name = command.Name,
                SendDate = command.SendDate,
                Subject = command.Subject
            });
            await _writeRepository.SaveAsync();
        }
    }
}
