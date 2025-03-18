using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Application.Features.CQRS.Commands.CarCommands;
using RentACar.Application.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.CQRS.Handlers.CarHandlers.Write
{
    public class RemoveCarCommandHandler
    {
        private readonly IWriteRepository<Car> _writeRepository;
        private readonly IReadRepository<Car> _readRepository;

        public RemoveCarCommandHandler(IWriteRepository<Car> writeRepository, IReadRepository<Car> readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task Handle(RemoveCarCommand command)
        {
            var values = await _readRepository.GetByIdAsync(command.Id, false);
            _writeRepository.Remove(values);
            await _writeRepository.SaveAsync();
        }
    }
}
