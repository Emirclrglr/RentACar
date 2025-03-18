using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Application.Features.CQRS.Results.AboutResults;
using RentACar.Application.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class GetAboutQueryHandler
    {
        private readonly IReadRepository<About> _readRepository;

        public GetAboutQueryHandler(IReadRepository<About> readRepository)
        {
            _readRepository = readRepository;
        }

        public IQueryable<GetAboutQueryResult> Handle()
        {
            var values = _readRepository.GetAll(false);
            return values.Select(x => new GetAboutQueryResult
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                ImageURL = x.ImageURL
            });
        }
    }
}
