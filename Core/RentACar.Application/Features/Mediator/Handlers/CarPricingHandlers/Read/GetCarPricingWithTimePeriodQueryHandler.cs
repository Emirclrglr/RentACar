using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Queries.CarPricingQueries;
using RentACar.Application.Features.Mediator.Results.CarPricingResults;
using RentACar.Application.IRepositories.ICarPricingRepository;

namespace RentACar.Application.Features.Mediator.Handlers.CarPricingHandlers.Read
{
    public class GetCarPricingWithTimePeriodQueryHandler : IRequestHandler<GetCarPricingWithTimePeriodQuery, IQueryable<GetCarPricingWithTimePeriodQueryResult>>
    {
        private readonly ICarPricingReadRepository _carPricingReadRepository;

        public GetCarPricingWithTimePeriodQueryHandler(ICarPricingReadRepository carPricingReadRepository)
        {
            _carPricingReadRepository = carPricingReadRepository;
        }

        public async Task<IQueryable<GetCarPricingWithTimePeriodQueryResult>> Handle(GetCarPricingWithTimePeriodQuery request, CancellationToken cancellationToken)
        {
            var values = _carPricingReadRepository.GetCarPricingsWithTimePeriod();
            return await Task.FromResult(values);
        }
    }
}
