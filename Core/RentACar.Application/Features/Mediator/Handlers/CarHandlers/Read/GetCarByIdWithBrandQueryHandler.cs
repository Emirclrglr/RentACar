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
    public class GetCarByIdWithBrandQueryHandler : IRequestHandler<GetCarByIdWithBrandQuery, GetCarByIdWithBrandQueryResult>
    {
        private readonly ICarReadRepository _carReadRepository;

        public GetCarByIdWithBrandQueryHandler(ICarReadRepository carReadRepository)
        {
            _carReadRepository = carReadRepository;
        }

        public async Task<GetCarByIdWithBrandQueryResult> Handle(GetCarByIdWithBrandQuery request, CancellationToken cancellationToken)
        {
            var values = await _carReadRepository.GetCarByIdWithBrand(request.Id);
            return new GetCarByIdWithBrandQueryResult
            {
                Model = values.Model,
                BigIMG = values.BigIMG,
                BrandName = values.Brand.BrandName,
                CoverIMG = values.CoverIMG,
                FuelType = values.FuelType,
                Id = values.Id,
                Kilometer = values.Kilometer,
                Luggage = values.Luggage,
                Seats = values.Seats,
                Transmission = values.Transmission
            };
        }
    }
}
