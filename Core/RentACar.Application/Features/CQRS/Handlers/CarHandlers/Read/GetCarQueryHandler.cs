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
    public class GetCarQueryHandler
    {
        private readonly IReadRepository<Car> _readRepository;

        public GetCarQueryHandler(IReadRepository<Car> readRepository)
        {
            _readRepository = readRepository;
        }

        public IQueryable<GetCarQueryResult> Handle()
        {
            var values = _readRepository.GetAll(false);
            return values.Select(x => new GetCarQueryResult
            {
                Id = x.Id,
                Model = x.Model,
                Kilometer = x.Kilometer,
                FuelType = x.FuelType,
                Luggage = x.Luggage,
                Seats = x.Seats,
                Transmission = x.Transmission,
                BigIMG = x.BigIMG,
                CoverIMG = x.CoverIMG,
                BrandId = x.BrandId,
            }); 
        }
    }
}
