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
    public class GetCheapestVehicleQueryHandler : IRequestHandler<GetCheapestVehicleQuery, string>
    {
        private readonly ICarPricingReadRepository _carPricingReadRepository;

        public GetCheapestVehicleQueryHandler(ICarPricingReadRepository carPricingReadRepository)
        {
            _carPricingReadRepository = carPricingReadRepository;
        }

        public async Task<string> Handle(GetCheapestVehicleQuery request, CancellationToken cancellationToken)
        {
            var car = await _carPricingReadRepository.CheapestVehicleAsync();
            return car;
        }
    }
}
