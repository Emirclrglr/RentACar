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
    public class GetReservationByIdQueryHandler : IRequestHandler<GetReservationByIdQuery, GetReservationByIdQueryResult>
    {
        private readonly IReservationReadRepository _reservationReadRepository;

        public GetReservationByIdQueryHandler(IReservationReadRepository reservationReadRepository)
        {
            _reservationReadRepository = reservationReadRepository;
        }

        public async Task<GetReservationByIdQueryResult> Handle(GetReservationByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _reservationReadRepository.GetByIdAsync(request.Id);
            return new GetReservationByIdQueryResult
            {
                Id = values.Id,
                Firstname = values.Firstname,
                Lastname = values.Lastname,
                Email = values.Email,
                PhoneNumber = values.PhoneNumber,
                Age = values.Age,
                DriverLicenseDate = values.DriverLicenseDate,
                Description = values.Description,
                Status = values.Status,
                CarId = values.CarId,
                PickUpLocationId = values.PickUpLocationId,
                DropOffLocationId = values.DropOffLocationId
            };
        }
    }
}
