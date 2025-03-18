using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Queries.CarFeatureQueries;
using RentACar.Application.Features.Mediator.Results.CarFeatureResults;
using RentACar.Application.IRepositories.ICarFeatureRepository;

namespace RentACar.Application.Features.Mediator.Handlers.CarFeatureHandlers.Read
{
    public class GetCarFeatureQueryHandler : IRequestHandler<GetCarFeatureQuery, IQueryable<GetCarFeatureQueryResult>>
    {
        private readonly ICarFeatureReadRepository _carFeatureReadRepository;

        public GetCarFeatureQueryHandler(ICarFeatureReadRepository carFeatureReadRepository)
        {
            _carFeatureReadRepository = carFeatureReadRepository;
        }

        public async Task<IQueryable<GetCarFeatureQueryResult>> Handle(GetCarFeatureQuery request, CancellationToken cancellationToken)
        {
            var values = _carFeatureReadRepository.GetAll(false).Select(x => new GetCarFeatureQueryResult
            {
                Id = x.Id,
                CarId = x.CarId,
                FeatureId = x.FeatureId,
                IsAvailable = x.IsAvailable
            });
            return await Task.FromResult(values);
        }
    }
}
