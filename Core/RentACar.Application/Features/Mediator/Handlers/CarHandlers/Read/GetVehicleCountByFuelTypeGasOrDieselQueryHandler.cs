using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Queries.CarQueries;
using RentACar.Application.IRepositories.ICarRepository;

namespace RentACar.Application.Features.Mediator.Handlers.CarHandlers.Read
{
    public class GetVehicleCountByFuelTypeGasOrDieselQueryHandler : IRequestHandler<GetVehicleCountByFuelTypeGasOrDieselQuery, int>
    {
        private readonly ICarReadRepository _carReadRepository;

        public GetVehicleCountByFuelTypeGasOrDieselQueryHandler(ICarReadRepository carReadRepository)
        {
            _carReadRepository = carReadRepository;
        }

        public async Task<int> Handle(GetVehicleCountByFuelTypeGasOrDieselQuery request, CancellationToken cancellationToken)
        {
            var count = await _carReadRepository.VehicleCountByFuelTypeGasOrDieselAsync();
            return count;
        }
    }
}
