using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Application.Features.CQRS.Queries.CategoryQueries;
using RentACar.Application.Features.CQRS.Results.CategoryResults;
using RentACar.Application.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.CQRS.Handlers.CategoryHandlers.Read
{
    public class GetCategoryByIdQueryHandler
    {
        private readonly IReadRepository<Category> _readRepository;

        public GetCategoryByIdQueryHandler(IReadRepository<Category> readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery query)
        {
            var values = await _readRepository.GetByIdAsync(query.Id, false);
            return new GetCategoryByIdQueryResult
            {
                Id = values.Id,
                Name = values.Name
            };
        }
    }
}
