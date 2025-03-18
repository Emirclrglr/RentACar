using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Queries.PricingQueries;
using RentACar.Application.Features.Mediator.Results.PricingResults;
using RentACar.Application.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Mediator.Handlers.PricingHandlers.Read
{
    public class GetPricingQueryHandler : IRequestHandler<GetPricingQuery, IQueryable<GetPricingQueryResult>>
    {
        private readonly IReadRepository<Pricing> _readRepository;

        public GetPricingQueryHandler(IReadRepository<Pricing> readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<IQueryable<GetPricingQueryResult>> Handle(GetPricingQuery request, CancellationToken cancellationToken)
        {
            var values = _readRepository.GetAll(false).Select(x => new GetPricingQueryResult
            {
                Id = x.Id,
                Name = x.Name
            });
            return await Task.FromResult(values);
        }
    }
}
