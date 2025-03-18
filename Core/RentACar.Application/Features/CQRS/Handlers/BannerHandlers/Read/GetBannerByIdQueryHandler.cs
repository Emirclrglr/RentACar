using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Application.Features.CQRS.Queries.BannerQueries;
using RentACar.Application.Features.CQRS.Results.BannerResults;
using RentACar.Application.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.CQRS.Handlers.BannerHandlers.Read
{
    public class GetBannerByIdQueryHandler
    {
        private readonly IReadRepository<Banner> _readRepository;

        public GetBannerByIdQueryHandler(IReadRepository<Banner> readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<GetBannerByIdQueryResult> Handle(GetBannerByIdQuery query)
        {
            var values = await _readRepository.GetByIdAsync(query.Id, false);
            return new GetBannerByIdQueryResult
            {
                Id = values.Id,
                Description = values.Description,
                Title = values.Title,
                VideoDescription = values.VideoDescription,
                VideoURL = values.VideoURL
            };
        }
    }
}
