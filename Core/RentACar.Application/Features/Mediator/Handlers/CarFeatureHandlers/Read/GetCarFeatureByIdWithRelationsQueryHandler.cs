using MediatR;
using RentACar.Application.Features.Mediator.Queries.CarFeatureQueries;
using RentACar.Application.Features.Mediator.Results.CarFeatureResults;
using RentACar.Application.IRepositories.ICarFeatureRepository;

namespace RentACar.Application.Features.Mediator.Handlers.CarFeatureHandlers.Read
{
    public class GetCarFeatureByIdWithRelationsQueryHandler : IRequestHandler<GetCarFeatureByIdWithRelationsQuery, IQueryable<GetCarFeatureByCarIdWithRelationsQueryResult>>
    {
        private readonly ICarFeatureReadRepository _carFeatureReadRepository;

        public GetCarFeatureByIdWithRelationsQueryHandler(ICarFeatureReadRepository carFeatureReadRepository)
        {
            _carFeatureReadRepository = carFeatureReadRepository;
        }

        public async Task<IQueryable<GetCarFeatureByCarIdWithRelationsQueryResult>> Handle(GetCarFeatureByIdWithRelationsQuery request, CancellationToken cancellationToken)
        {
            var values = _carFeatureReadRepository.GetCarFeaturesByCarIdWithRelations(request.CarId).Select(x => new GetCarFeatureByCarIdWithRelationsQueryResult
            {
                Id = x.Id,
                CarModel = x.Car.Model,
                CarBrand = x.Car.Brand.BrandName,
                CarFeatureName = x.Feature.FeatureName,
                IsAvailable = x.IsAvailable,
                CarId = x.CarId,
                FeatureId = x.FeatureId
            });
            return await Task.FromResult(values);
        }
    }
}
