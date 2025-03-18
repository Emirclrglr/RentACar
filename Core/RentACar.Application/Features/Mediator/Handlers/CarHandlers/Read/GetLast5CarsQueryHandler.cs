using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Queries.CarQueries;
using RentACar.Application.Features.Mediator.Results.CarResults;
using RentACar.Application.IRepositories.ICarRepository;

namespace RentACar.Application.Features.Mediator.Handlers.CarHandlers.Read
{
    public class GetLast5CarsQueryHandler : IRequestHandler<GetLast5CarsQuery, IQueryable<GetLast5CarQueryResult>>
    {
        private readonly ICarReadRepository _carReadRepository;

        public GetLast5CarsQueryHandler(ICarReadRepository carReadRepository)
        {
            _carReadRepository = carReadRepository;
        }

        public async Task<IQueryable<GetLast5CarQueryResult>> Handle(GetLast5CarsQuery request, CancellationToken cancellationToken)
        {
            var values = _carReadRepository.GetLast5Cars(false).Select(x => new GetLast5CarQueryResult
            {
                Id = x.Id,
                BigIMG = x.BigIMG,
                CoverIMG = x.CoverIMG,
                FuelType = x.FuelType,
                Kilometer = x.Kilometer,
                Luggage = x.Luggage,
                Model = x.Model,
                Seats = x.Seats,
                Transmission = x.Transmission,
                BrandName = x.Brand.BrandName,
                Price = x.CarPricings.Select(x => x.Price).First(),
                PricingName = x.CarPricings.Select(x=>x.Pricing.Name).First()
            });
            return await Task.FromResult(values);
        }
    }
}
