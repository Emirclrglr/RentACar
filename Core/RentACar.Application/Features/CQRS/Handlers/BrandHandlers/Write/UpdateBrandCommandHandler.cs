using RentACar.Application.Features.CQRS.Commands.BrandCommands;
using RentACar.Application.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.CQRS.Handlers.BrandHandlers.Write
{
    public class UpdateBrandCommandHandler
    {
        private readonly IWriteRepository<Brand> _writeRepository;

        public UpdateBrandCommandHandler(IWriteRepository<Brand> writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task Handle(UpdateBrandCommand command)
        {
            _writeRepository.Update(new()
            {
                Id = command.Id,
                BrandName = command.BrandName
            });
            await _writeRepository.SaveAsync();
        }
    }
}
