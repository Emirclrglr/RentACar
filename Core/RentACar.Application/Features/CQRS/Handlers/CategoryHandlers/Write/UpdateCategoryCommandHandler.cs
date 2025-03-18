using RentACar.Application.Features.CQRS.Commands.CategoryCommands;
using RentACar.Application.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.CQRS.Handlers.CategoryHandlers.Write
{
    public class UpdateCategoryCommandHandler
    {
        private readonly IWriteRepository<Category> _writeRepository;

        public UpdateCategoryCommandHandler(IWriteRepository<Category> writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task Handle(UpdateCategoryCommand command)
        {
            _writeRepository.Update(new()
            {
                Id = command.Id,
                Name = command.Name
            });
            await _writeRepository.SaveAsync();
        }
    }
}
