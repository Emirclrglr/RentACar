using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Queries.SocialMediaQueries;
using RentACar.Application.Features.Mediator.Results.SocialMediaResults;
using RentACar.Application.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Mediator.Handlers.SocialMediaHandlers.Read
{
    public class GetSocialMediaQueryHandler : IRequestHandler<GetSocialMediaQuery, IQueryable<GetSocialMediaQueryResult>>
    {
        private readonly IReadRepository<SocialMedia> _readRepository;

        public GetSocialMediaQueryHandler(IReadRepository<SocialMedia> readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<IQueryable<GetSocialMediaQueryResult>> Handle(GetSocialMediaQuery request, CancellationToken cancellationToken)
        {
            var values = _readRepository.GetAll(false).Select(x => new GetSocialMediaQueryResult
            {
                Id = x.Id,
                Icon = x.Icon,
                Name = x.Name,
                Url = x.Url
            });
            return await Task.FromResult(values);
        }
    }
}
