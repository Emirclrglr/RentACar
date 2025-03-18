using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Application.Features.CQRS.Results.CarResults;
using RentACar.Application.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.CQRS.Handlers.CarHandlers.Read
{
    public class GetCarWithBrandQueryHandler
    {
        private readonly IReadRepository<Car> _readRepository;

        public GetCarWithBrandQueryHandler(IReadRepository<Car> readRepository)
        {
            _readRepository = readRepository;
        }

        public IQueryable<GetCarWithBrandQueryResult> Handle()
        {
            var values = _readRepository.GetAll(false);
            return values.Select(x => new GetCarWithBrandQueryResult
            {
                Id = x.Id,
                Model = x.Model,
                BrandName = x.Brand.BrandName,
                FuelType = x.FuelType,
                BigIMG = x.BigIMG,
                Kilometer = x.Kilometer,
                CoverIMG = x.CoverIMG,
                Luggage = x.Luggage,
                Seats = x.Seats,
                Transmission = x.Transmission
            });
        }
    }
}
