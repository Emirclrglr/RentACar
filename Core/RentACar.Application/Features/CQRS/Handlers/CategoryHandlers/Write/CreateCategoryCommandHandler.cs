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
    public class CreateCategoryCommandHandler
    {
        private readonly IWriteRepository<Category> _writeRepository;

        public CreateCategoryCommandHandler(IWriteRepository<Category> writeRepository)
        {
            _writeRepository = writeRepository;
        }
        
        public async Task Handle(CreateCategoryCommand command)
        {
            await _writeRepository.AddAsync(new()
            {
                Name = command.Name
            });
            await _writeRepository.SaveAsync();
        }
    }
}
