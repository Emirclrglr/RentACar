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
    public class GetVehicleCountByFuelTypeElectricQueryHandler : IRequestHandler<GetVehicleCountByFuelTypeElectricQuery, int>
    {
        private readonly ICarReadRepository _carReadRepository;

        public GetVehicleCountByFuelTypeElectricQueryHandler(ICarReadRepository carReadRepository)
        {
            _carReadRepository = carReadRepository;
        }

        public async Task<int> Handle(GetVehicleCountByFuelTypeElectricQuery request, CancellationToken cancellationToken)
        {
            var count = await _carReadRepository.VehicleCountByFuelTypeElectricAsync();
            return count;
        }
    }
}
