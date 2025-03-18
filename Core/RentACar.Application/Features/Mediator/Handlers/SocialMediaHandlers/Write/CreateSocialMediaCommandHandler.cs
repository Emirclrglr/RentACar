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
    public class CreateSocialMediaCommandHandler : IRequestHandler<CreateSocialMediaCommand>
    {
        private readonly IWriteRepository<SocialMedia> _writeRepository;

        public CreateSocialMediaCommandHandler(IWriteRepository<SocialMedia> writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task Handle(CreateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            await _writeRepository.AddAsync(new()
            {
                Icon = request.Icon,
                Name = request.Name,
                Url = request.Url
            });
            await _writeRepository.SaveAsync();
        }
    }
}
