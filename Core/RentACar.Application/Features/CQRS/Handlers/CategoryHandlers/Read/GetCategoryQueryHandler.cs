using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Application.Features.CQRS.Results.CategoryResults;
using RentACar.Application.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.CQRS.Handlers.CategoryHandlers.Read
{
    public class GetCategoryQueryHandler
    {
        private readonly IReadRepository<Category> _readRepository;

        public GetCategoryQueryHandler(IReadRepository<Category> readRepository)
        {
            _readRepository = readRepository;
        }

        public IQueryable<GetCategoryQueryResult> Handle()
        {
            var values = _readRepository.GetAll(false);
            return values.Select(x => new GetCategoryQueryResult
            {
                Id = x.Id,
                Name = x.Name
            });
        }
    }
}
