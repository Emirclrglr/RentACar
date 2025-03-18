using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Commands.SocialMediaCommands;
using RentACar.Application.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Mediator.Handlers.SocialMediaHandlers.Write
{
    public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommand>
    {
        private readonly IWriteRepository<SocialMedia> _writeRepository;

        public UpdateSocialMediaCommandHandler(IWriteRepository<SocialMedia> writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            _writeRepository.Update(new()
            {
                Id = request.Id,
                Name = request.Name,
                Icon = request.Icon,
                Url = request.Url
            });
            await _writeRepository.SaveAsync();
        }
    }
}
