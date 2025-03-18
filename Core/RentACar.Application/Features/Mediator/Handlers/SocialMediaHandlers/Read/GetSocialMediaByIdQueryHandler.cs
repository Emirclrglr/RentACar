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
    public class GetSocialMediaByIdQueryHandler : IRequestHandler<GetSocialMediaByIdQuery, GetSocialMediaByIdQueryResult>
    {
        private readonly IReadRepository<SocialMedia> _readRepository;

        public GetSocialMediaByIdQueryHandler(IReadRepository<SocialMedia> readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<GetSocialMediaByIdQueryResult> Handle(GetSocialMediaByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _readRepository.GetByIdAsync(request.Id, false);
            return new GetSocialMediaByIdQueryResult
            {
                Id = values.Id,
                Icon = values.Icon,
                Name = values.Name,
                Url = values.Url
            };
        }
    }
}
