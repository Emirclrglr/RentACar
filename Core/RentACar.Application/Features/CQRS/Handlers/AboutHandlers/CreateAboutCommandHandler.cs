using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Application.Features.CQRS.Commands.AboutCommands;
using RentACar.Application.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class CreateAboutCommandHandler
    {
        private readonly IWriteRepository<About> _writeRepository;

        public CreateAboutCommandHandler(IWriteRepository<About> writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task Handle(CreateAboutCommand command)
        {
            await _writeRepository.AddAsync(new()
            {
                Title = command.Title,
                ImageURL = command.ImageURL,
                Description = command.Description
            });
            await _writeRepository.SaveAsync();
        }
    }
}
