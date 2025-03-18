using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Queries.ReservationQueries;
using RentACar.Application.Features.Mediator.Results.ReservationResults;
using RentACar.Application.IRepositories.IReservationRepository;

namespace RentACar.Application.Features.Mediator.Handlers.ReservationHandlers.Read
{
    public class GetReservationWithRelationsQueryHandler : IRequestHandler<GetReservationWithRelationsQuery, IQueryable<GetReservationWithRelationsQueryResult>>
    {
        private readonly IReservationReadRepository _reservationReadRepository;

        public GetReservationWithRelationsQueryHandler(IReservationReadRepository reservationReadRepository)
        {
            _reservationReadRepository = reservationReadRepository;
        }

        public async Task<IQueryable<GetReservationWithRelationsQueryResult>> Handle(GetReservationWithRelationsQuery request, CancellationToken cancellationToken)
        {
            var values = _reservationReadRepository.GetAll(false).Select(x => new GetReservationWithRelationsQueryResult
            {
                Id = x.Id,
                Firstname = x.Firstname,
                Lastname = x.Lastname,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                Age = x.Age,
                Status = x.Status,
                DriverLicenseDate = x.DriverLicenseDate,
                Description = x.Description,
                CarName = $"{x.Car.Brand.BrandName} {x.Car.Model}",
                PickUpLocationName = x.PickUpLocation.LocationName,
                DropOffLocationName = x.DropOffLocation.LocationName
            });
            return await Task.FromResult(values);
        }
    }
}
