using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Queries.FeatureQueries;
using RentACar.Application.Features.Mediator.Results.FeatureResults;
using RentACar.Application.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Mediator.Handlers.FeatureHandlers.Read
{
    public class GetFeatureByIdQueryHandler : IRequestHandler<GetFeatureByIdQuery, GetFeatureByIdQueryResult>
    {
        private readonly IReadRepository<Feature> _readRepository;

        public GetFeatureByIdQueryHandler(IReadRepository<Feature> readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<GetFeatureByIdQueryResult> Handle(GetFeatureByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _readRepository.GetByIdAsync(request.Id, false);
            return new GetFeatureByIdQueryResult
            {
                Id = values.Id,
                FeatureName = values.FeatureName
            };
        }
    }
}
