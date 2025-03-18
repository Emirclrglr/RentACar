using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Application.Features.CQRS.Commands.BrandCommands;
using RentACar.Application.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.CQRS.Handlers.BrandHandlers.Write
{
    public class RemoveBrandCommandHandler
    {
        private readonly IReadRepository<Brand> _readRepository;
        private readonly IWriteRepository<Brand> _writeRepository;

        public RemoveBrandCommandHandler(IReadRepository<Brand> readRepository, IWriteRepository<Brand> writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task Handle(RemoveBrandCommand command)
        {
            var values = await _readRepository.GetByIdAsync(command.Id, false);
            _writeRepository.Remove(values);
            await _writeRepository.SaveAsync();
        }
    }
}
