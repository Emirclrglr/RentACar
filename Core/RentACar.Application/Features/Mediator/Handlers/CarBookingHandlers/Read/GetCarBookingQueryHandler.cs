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
    public class GetCarBookingQueryHandler : IRequestHandler<GetCarBookingQuery, IQueryable<GetCarBookingQueryResult>>
    {
        private readonly ICarBookingReadRepository _carBookingReadRepository;

        public GetCarBookingQueryHandler(ICarBookingReadRepository carBookingReadRepository)
        {
            _carBookingReadRepository = carBookingReadRepository;
        }

        public async Task<IQueryable<GetCarBookingQueryResult>> Handle(GetCarBookingQuery request, CancellationToken cancellationToken)
        {
            var values = _carBookingReadRepository.GetWhere(x => x.LocationId == request.LocationId && x.IsAvailable == true, false).Select(x => new GetCarBookingQueryResult
            {
                Id = x.Id,
                CarId = x.CarId
            });
            return await Task.FromResult(values);
        }
    }
}
