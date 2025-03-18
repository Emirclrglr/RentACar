using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Application.Features.CQRS.Commands.BannerCommands;
using RentACar.Application.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.CQRS.Handlers.BannerHandlers.Write
{
    public class RemoveBannerCommandHandler
    {
        private readonly IWriteRepository<Banner> _writeRepository;
        private readonly IReadRepository<Banner> _readRepository;

        public RemoveBannerCommandHandler(IReadRepository<Banner> readRepository, IWriteRepository<Banner> writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task Handle(RemoveBannerCommand command)
        {
            var values = await _readRepository.GetByIdAsync(command.Id, false);
            _writeRepository.Remove(values);
            await _writeRepository.SaveAsync();
        }
    }
}
