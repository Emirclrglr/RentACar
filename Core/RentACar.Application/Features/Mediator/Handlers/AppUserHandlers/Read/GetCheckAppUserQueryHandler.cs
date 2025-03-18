using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RentACar.Application.Features.Mediator.Queries.AppUserQueries;
using RentACar.Application.Features.Mediator.Results.AppUserResults;
using RentACar.Application.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Mediator.Handlers.AppUserHandlers.Read
{
    public class GetCheckAppUserQueryHandler : IRequestHandler<GetCheckAppUserQuery, GetCheckAppUserQueryResult>
    {
        private readonly IReadRepository<AppUser> _readAppUserRepository;
        private readonly IReadRepository<AppRole> _readAppRoleRepository;

        public GetCheckAppUserQueryHandler(IReadRepository<AppUser> readAppUserRepository, IReadRepository<AppRole> readAppRoleRepository)
        {
            _readAppUserRepository = readAppUserRepository;
            _readAppRoleRepository = readAppRoleRepository;
        }

        public async Task<GetCheckAppUserQueryResult> Handle(GetCheckAppUserQuery request, CancellationToken cancellationToken)
        {
            var values = new GetCheckAppUserQueryResult();
            var user = _readAppUserRepository.GetWhere(x => x.Username == request.Username && x.Password == request.Password);
            if (user == null)
            {
                values.IsExists = false;
            }
            else
            {
                values.IsExists = true;
                values.Username = user.Select(x => x.Username).FirstOrDefault();
                values.Role = user.Select(x => x.AppRole.AppRoleName).FirstOrDefault();
                values.Id = user.Select(x => x.Id).FirstOrDefault();
            }
            return values;
        }
    }
}
