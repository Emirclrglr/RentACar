using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Queries.CarBookingQueries;
using RentACar.Application.Features.Mediator.Results.CarBookingResults;
using RentACar.Application.IRepositories.ICarBookingRepository;

namespace RentACar.Application.Features.Mediator.Handlers.CarBookingHandlers.Read
{
    public class GetCarBookingWithCarNameAndBrandNameQueryHandler : IRequestHandler<GetCarBookingWithCarNameAndBrandNameQuery, IQueryable<GetCarBookingWithCarNameAndBrandNameQueryResult>>
    {
        private readonly ICarBookingReadRepository _carBookingReadRepository;

        public GetCarBookingWithCarNameAndBrandNameQueryHandler(ICarBookingReadRepository carBookingReadRepository)
        {
            _carBookingReadRepository = carBookingReadRepository;
        }

        public async Task<IQueryable<GetCarBookingWithCarNameAndBrandNameQueryResult>> Handle(GetCarBookingWithCarNameAndBrandNameQuery request, CancellationToken cancellationToken)
        {
            var values = _carBookingReadRepository.GetWhere(x => x.LocationId == request.LocationId && x.IsAvailable == true, false).Select(x => new GetCarBookingWithCarNameAndBrandNameQueryResult
            {
                Id = x.Id,
                CarName = x.Car.Model,
                BrandName = x.Car.Brand.BrandName,
                Price = x.Car.CarPricings.Select(x=>x.Price).FirstOrDefault(),
                PricingName = x.Car.CarPricings.Select(x=>x.Pricing.Name).FirstOrDefault(),
                CarId = x.Car.Id,
                CarImage = x.Car.CoverIMG
            });
            return await Task.FromResult(values);
        }
    }
}
