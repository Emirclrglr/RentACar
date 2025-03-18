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
    public class GetFeatureQueryHandler : IRequestHandler<GetFeatureQuery, IQueryable<GetFeatureQueryResult>>
    {
        private readonly IReadRepository<Feature> _readRepository;

        public GetFeatureQueryHandler(IReadRepository<Feature> readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<IQueryable<GetFeatureQueryResult>> Handle(GetFeatureQuery request, CancellationToken cancellationToken)
        {
            var values = _readRepository.GetAll(false);
            var result = values.Select(x => new GetFeatureQueryResult
            {
                Id = x.Id,
                FeatureName = x.FeatureName
            });
            return await Task.FromResult(result);
        }
    }
}
