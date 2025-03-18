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
    public class CreateBrandCommandHandler
    {
        private readonly IWriteRepository<Brand> _writeRepository;

        public CreateBrandCommandHandler(IWriteRepository<Brand> writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task Handle(CreateBrandCommand command)
        {
            await _writeRepository.AddAsync(new()
            {
                BrandName = command.BrandName
            });
            await _writeRepository.SaveAsync();
        }
    }
}
