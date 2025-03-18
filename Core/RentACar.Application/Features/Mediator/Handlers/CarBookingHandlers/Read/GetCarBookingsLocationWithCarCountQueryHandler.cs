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
    public class GetCarBookingsLocationWithCarCountQueryHandler : IRequestHandler<GetCarBookingsLocationWithCarCountQuery, IQueryable<GetCarBookingsLocationWithCarCountQueryResult>>
    {
        private readonly ICarBookingReadRepository _carBookingReadRepository;

        public GetCarBookingsLocationWithCarCountQueryHandler(ICarBookingReadRepository carBookingReadRepository)
        {
            _carBookingReadRepository = carBookingReadRepository;
        }

        public async Task<IQueryable<GetCarBookingsLocationWithCarCountQueryResult>> Handle(GetCarBookingsLocationWithCarCountQuery request, CancellationToken cancellationToken)
        {
            var values = _carBookingReadRepository.LocationWithCarCount();
            return await Task.FromResult(values);
        }
    }
}
