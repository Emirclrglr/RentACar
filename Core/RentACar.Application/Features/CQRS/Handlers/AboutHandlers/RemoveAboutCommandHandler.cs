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
    public class RemoveAboutCommandHandler
    {
        private readonly IWriteRepository<About> _writeRepository;
        private readonly IReadRepository<About> _readRepository;

        public RemoveAboutCommandHandler(IWriteRepository<About> writeRepository, IReadRepository<About> readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task Handle(RemoveAboutCommand command)
        {
            var values = await _readRepository.GetByIdAsync(command.Id, false);
            _writeRepository.Remove(values);
            await _writeRepository.SaveAsync();
        }
    }
}
