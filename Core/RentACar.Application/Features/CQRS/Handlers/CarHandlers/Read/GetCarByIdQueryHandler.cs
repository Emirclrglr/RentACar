using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Application.Features.CQRS.Queries.CarQueries;
using RentACar.Application.Features.CQRS.Results.CarResults;
using RentACar.Application.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.CQRS.Handlers.CarHandlers.Read
{
    public class GetCarByIdQueryHandler
    {
        private readonly IReadRepository<Car> _readRepository;

        public GetCarByIdQueryHandler(IReadRepository<Car> readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery query)
        {
            var values = await _readRepository.GetByIdAsync(query.Id, false);
            return new GetCarByIdQueryResult
            {
                Id = values.Id,
                Model = values.Model,
                BrandId = values.BrandId,
                BigIMG = values.BigIMG,
                CoverIMG = values.CoverIMG,
                FuelType = values.FuelType,
                Kilometer = values.Kilometer,
                Luggage = values.Luggage,
                Seats = values.Seats,
                Transmission = values.Transmission
            };
        }
    }
}
