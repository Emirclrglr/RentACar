using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Queries.CarPricingQueries;
using RentACar.Application.Features.Mediator.Results;
using RentACar.Application.IRepositories.ICarPricingRepository;

namespace RentACar.Application.Features.Mediator.Handlers.CarPricingHandlers.Read
{
    public class GetMostExpensiveVehicleQueryHandler : IRequestHandler<GetMostExpensiveVehicleQuery, string>
    {
        private readonly ICarPricingReadRepository _carPricingReadRepository;

        public GetMostExpensiveVehicleQueryHandler(ICarPricingReadRepository carPricingReadRepository)
        {
            _carPricingReadRepository = carPricingReadRepository;
        }

        public async Task<string> Handle(GetMostExpensiveVehicleQuery request, CancellationToken cancellationToken)
        {
            var values = await _carPricingReadRepository.MostExpensiveVehicleAsync();
            return values;
        }
    }
}
