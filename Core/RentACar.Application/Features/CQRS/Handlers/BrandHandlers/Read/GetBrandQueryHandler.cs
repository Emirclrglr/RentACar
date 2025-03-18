using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Application.Features.CQRS.Results.BrandResults;
using RentACar.Application.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.CQRS.Handlers.BrandHandlers.Read
{
    public class GetBrandQueryHandler
    {
        private readonly IReadRepository<Brand> _readRepository;

        public GetBrandQueryHandler(IReadRepository<Brand> readRepository)
        {
            _readRepository = readRepository;
        }

        public IQueryable<GetBrandQueryResult> Handle()
        {
            var values = _readRepository.GetAll(false);
            return values.Select(x => new GetBrandQueryResult
            {
                Id = x.Id,
                BrandName = x.BrandName,
            });
        }
    }
}
