using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Queries.CarPricingQueries;
using RentACar.Application.IRepositories.ICarPricingRepository;

namespace RentACar.Application.Features.Mediator.Handlers.CarPricingHandlers.Read
{
    public class GetAvgHourlyCarRentalPriceQueryHandler : IRequestHandler<GetAvgHourlyCarRentalPriceQuery, decimal>
    {
        private readonly ICarPricingReadRepository _carPricingReadRepository;

        public GetAvgHourlyCarRentalPriceQueryHandler(ICarPricingReadRepository carPricingReadRepository)
        {
            _carPricingReadRepository = carPricingReadRepository;
        }

        public async Task<decimal> Handle(GetAvgHourlyCarRentalPriceQuery request, CancellationToken cancellationToken)
        {
            var avgPrice = await _carPricingReadRepository.AverageHourlyCarRentalPrice();
            return avgPrice;
        }
    }
}
