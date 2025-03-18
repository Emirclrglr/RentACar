using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Application.Features.CQRS.Queries.AboutQueries;
using RentACar.Application.Features.CQRS.Results.AboutResults;
using RentACar.Application.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class GetAboutByIdQueryHandler
    {
        private readonly IReadRepository<About> _readRepository;

        public GetAboutByIdQueryHandler(IReadRepository<About> readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<GetAboutByIdQueryResult> Handle(GetAboutByIdQuery query)
        {
            var values = await _readRepository.GetByIdAsync(query.Id, false);
            return new GetAboutByIdQueryResult
            {
                Id = values.Id,
                Description = values.Description,
                ImageURL = values.ImageURL,
                Title = values.Title
            };
        }
    }
}
