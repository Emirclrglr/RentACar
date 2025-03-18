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
    public class GetAvgWeeklyCarRentalPriceQueryHandler : IRequestHandler<GetAvgWeeklyCarRentalPriceQuery, decimal>
    {
        private readonly ICarPricingReadRepository _carPricingReadRepository;

        public GetAvgWeeklyCarRentalPriceQueryHandler(ICarPricingReadRepository carPricingReadRepository)
        {
            _carPricingReadRepository = carPricingReadRepository;
        }

        public async Task<decimal> Handle(GetAvgWeeklyCarRentalPriceQuery request, CancellationToken cancellationToken)
        {
            var avgPrice = await _carPricingReadRepository.AverageWeeklyCarRentalPrice();
            return avgPrice;
        }
    }
}

