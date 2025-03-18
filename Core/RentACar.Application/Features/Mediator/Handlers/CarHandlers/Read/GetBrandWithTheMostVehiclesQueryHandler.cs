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
    public class GetBrandWithTheMostVehiclesQueryHandler : IRequestHandler<GetBrandWithTheMostVehiclesQuery, string>
    {
        private readonly ICarReadRepository _carReadRepository;

        public GetBrandWithTheMostVehiclesQueryHandler(ICarReadRepository carReadRepository)
        {
            _carReadRepository = carReadRepository;
        }

        public async Task<string> Handle(GetBrandWithTheMostVehiclesQuery request, CancellationToken cancellationToken)
        {
            var car = await _carReadRepository.BrandWithTheMostVehiclesAsync();
            return car;
        }
    }
}
