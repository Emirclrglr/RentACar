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
    public class CreateContactCommandHandler
    {
        private readonly IWriteRepository<Contact> _writeRepository;

        public CreateContactCommandHandler(IWriteRepository<Contact> writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task Handle(CreateContactCommand command)
        {
            await _writeRepository.AddAsync(new()
            {
                Email = command.Email,
                MessageContent = command.MessageContent,
                Name = command.Name,
                Subject = command.Subject,
                SendDate = DateTime.Parse(DateTime.Now.ToString())
            });
            await _writeRepository.SaveAsync();
        }
    }
}
