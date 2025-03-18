using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Queries.CarQueries;
using RentACar.Application.Features.Mediator.Results.CarResults;
using RentACar.Application.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Mediator.Handlers.CarHandlers.Read
{
    public class GetCarsWithBrandAndPricingQueryHandler : IRequestHandler<GetCarsWithBrandAndPricingQuery, IQueryable<GetCarsWithBrandAndPricingQueryResult>>
    {
        private readonly IReadRepository<Car> _readRepository;

        public GetCarsWithBrandAndPricingQueryHandler(IReadRepository<Car> readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<IQueryable<GetCarsWithBrandAndPricingQueryResult>> Handle(GetCarsWithBrandAndPricingQuery request, CancellationToken cancellationToken)
        {
            var values = _readRepository.GetAll(false).Select(x => new GetCarsWithBrandAndPricingQueryResult
            {
                Id = x.Id,
                BigIMG = x.BigIMG,
                BrandName = x.Brand.BrandName,
                FuelType = x.FuelType,
                CoverIMG = x.CoverIMG,
                Kilometer = x.Kilometer,
                Transmission = x.Transmission,
                Seats = x.Seats,
                Luggage = x.Luggage,
                Model = x.Model,
                Price = x.CarPricings.Select(x => x.Price).First(),
                PricingName = x.CarPricings.Select(x => x.Pricing.Name).First()
            });
            return await Task.FromResult(values);
        }
    }
}
