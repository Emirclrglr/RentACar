using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Application.Features.CQRS.Queries.BrandQueries;
using RentACar.Application.Features.CQRS.Results.BrandResults;
using RentACar.Application.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.CQRS.Handlers.BrandHandlers.Read
{
    public class GetBrandByIdQueryHandler
    {
        private readonly IReadRepository<Brand> _readRepository;

        public GetBrandByIdQueryHandler(IReadRepository<Brand> readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<GetBrandByIdQueryResult> Handle(GetBrandByIdQuery query)
        {
            var values = await _readRepository.GetByIdAsync(query.Id, false);
            return new GetBrandByIdQueryResult
            {
                Id = values.Id,
                BrandName = values.BrandName
            };
        }
    }
}
