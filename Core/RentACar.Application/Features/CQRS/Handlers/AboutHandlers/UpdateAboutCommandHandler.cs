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
    public class UpdateAboutCommandHandler
    {
        private readonly IWriteRepository<About> _writeRepository;

        public UpdateAboutCommandHandler(IWriteRepository<About> writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task Handle(UpdateAboutCommand command)
        {
            _writeRepository.Update(new()
            {
                Id = command.Id,
                ImageURL = command.ImageURL,
                Description = command.Description,
                Title = command.Title
            });
            await _writeRepository.SaveAsync();
        }
    }
}
