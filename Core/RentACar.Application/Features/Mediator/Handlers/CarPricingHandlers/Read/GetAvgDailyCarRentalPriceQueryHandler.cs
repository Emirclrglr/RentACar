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
    public class GetAvgDailyCarRentalPriceQueryHandler : IRequestHandler<GetAvgDailyCarRentalPriceQuery, decimal>
    {
        private readonly ICarPricingReadRepository _carPricingReadRepository;

        public GetAvgDailyCarRentalPriceQueryHandler(ICarPricingReadRepository carPricingReadRepository)
        {
            _carPricingReadRepository = carPricingReadRepository;
        }

        public async Task<decimal> Handle(GetAvgDailyCarRentalPriceQuery request, CancellationToken cancellationToken)
        {
            var avgPrice = await _carPricingReadRepository.AverageDailyCarRentalPrice();
            return avgPrice;
        }
    }
}
