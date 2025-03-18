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
    public class GetVehicleCountWithLessThan1000KmQueryHandler : IRequestHandler<GetVehicleCountWithLessThan1000KmQuery, int>
    {
        private readonly ICarReadRepository _carReadRepository;

        public GetVehicleCountWithLessThan1000KmQueryHandler(ICarReadRepository carReadRepository)
        {
            _carReadRepository = carReadRepository;
        }

        public async Task<int> Handle(GetVehicleCountWithLessThan1000KmQuery request, CancellationToken cancellationToken)
        {
            var count = await _carReadRepository.VehicleCountWithLessThan1000KmAsync();
            return count;
        }
    }
}
