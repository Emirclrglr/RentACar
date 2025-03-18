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
    public class CreateBannerCommandHandler
    {
        private readonly IWriteRepository<Banner> _writeRepository;

        public CreateBannerCommandHandler(IWriteRepository<Banner> writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task Handle(CreateBannerCommand command)
        {
            await _writeRepository.AddAsync(new()
            {
                Title = command.Title,
                Description = command.Description,
                VideoDescription = command.VideoDescription,
                VideoURL = command.VideoURL,
            });
            await _writeRepository.SaveAsync();
        }
    }
}
