using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Application.Features.CQRS.Commands.AboutCommands;
using RentACar.Application.Features.CQRS.Commands.BannerCommands;
using RentACar.Application.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.CQRS.Handlers.BannerHandlers.Write
{
    public class UpdateBannerCommandHandler
    {
        private readonly IWriteRepository<Banner> _writeRepository;

        public UpdateBannerCommandHandler(IWriteRepository<Banner> writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task Handle(UpdateBannerCommand command)
        {
            _writeRepository.Update(new()
            {
                Id = command.Id,
                Description = command.Description,
                Title = command.Title,
                VideoDescription = command.VideoDescription,
                VideoURL = command.VideoURL
            });
            await _writeRepository.SaveAsync();
        }
    }
}
