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
    public class GetPricingByIdQueryHandler : IRequestHandler<GetPricingByIdQuery, GetPricingByIdQueryResult>
    {
        private readonly IReadRepository<Pricing> _readRepository;

        public GetPricingByIdQueryHandler(IReadRepository<Pricing> readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<GetPricingByIdQueryResult> Handle(GetPricingByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _readRepository.GetByIdAsync(request.Id, false);
            return new GetPricingByIdQueryResult
            {
                Id = values.Id,
                Name = values.Name
            };
        }
    }
}
