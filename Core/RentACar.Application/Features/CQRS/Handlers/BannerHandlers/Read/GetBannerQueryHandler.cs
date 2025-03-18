using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Application.Features.CQRS.Results.BannerResults;
using RentACar.Application.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.CQRS.Handlers.BannerHandlers.Read
{
    public class GetBannerQueryHandler
    {
        private readonly IReadRepository<Banner> _readRepository;

        public GetBannerQueryHandler(IReadRepository<Banner> readRepository)
        {
            _readRepository = readRepository;
        }

        public IQueryable<GetBannerQueryResult> Handle()
        {
            var values = _readRepository.GetAll(false);
            return values.Select(x => new GetBannerQueryResult
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                VideoDescription = x.VideoDescription,
                VideoURL = x.VideoURL,
            });
        }
    }
}
