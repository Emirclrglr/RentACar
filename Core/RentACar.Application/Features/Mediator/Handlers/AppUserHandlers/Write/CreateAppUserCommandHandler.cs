using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Enums;
using RentACar.Application.Features.Mediator.Commands.AppUserCommands;
using RentACar.Application.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Mediator.Handlers.AppUserHandlers.Write
{
    public class CreateAppUserCommandHandler : IRequestHandler<CreateAppUserCommand>
    {
        private readonly IWriteRepository<AppUser> _writeRepository;

        public CreateAppUserCommandHandler(IWriteRepository<AppUser> writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
        {
            await _writeRepository.AddAsync(new()
            {
                Username = request.Username,
                Password = request.Password,
                AppRoleId = (int)RoleEnum.Member
            });
            await _writeRepository.SaveAsync();
        }
    }
}
