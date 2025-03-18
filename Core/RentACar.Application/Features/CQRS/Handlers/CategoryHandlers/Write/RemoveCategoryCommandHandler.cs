using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Application.Features.CQRS.Commands.CategoryCommands;
using RentACar.Application.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.CQRS.Handlers.CategoryHandlers.Write
{
    public class RemoveCategoryCommandHandler
    {
        private readonly IWriteRepository<Category> _writeRepository;
        private readonly IReadRepository<Category> _readRepository;

        public RemoveCategoryCommandHandler(IWriteRepository<Category> writeRepository, IReadRepository<Category> readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task Handle(RemoveCategoryCommand command)
        {
            var values = await _readRepository.GetByIdAsync(command.Id, false);
            _writeRepository.Remove(values);
            await _writeRepository.SaveAsync();
        }
    }
}
