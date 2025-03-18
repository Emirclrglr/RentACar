using MediatR;
using RentACar.Application.Features.Mediator.Queries.ReservationQueries;
using RentACar.Application.Features.Mediator.Results.ReservationResults;
using RentACar.Application.IRepositories.IReservationRepository;

namespace RentACar.Application.Features.Mediator.Handlers.ReservationHandlers.Read
{
    public class GetReservationQueryHandler : IRequestHandler<GetReservationQuery, IQueryable<GetReservationQueryResult>>
    {
        private readonly IReservationReadRepository _reservationReadRepository;

        public GetReservationQueryHandler(IReservationReadRepository reservationReadRepository)
        {
            _reservationReadRepository = reservationReadRepository;
        }

        public async Task<IQueryable<GetReservationQueryResult>> Handle(GetReservationQuery request, CancellationToken cancellationToken)
        {
            var values = _reservationReadRepository.GetAll(false).Select(x => new GetReservationQueryResult
            {
                Id = x.Id,
                Firstname = x.Firstname,
                Lastname = x.Lastname,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                Age = x.Age,
                DriverLicenseDate = x.DriverLicenseDate,
                Description = x.Description,
                Status = x.Status,
                CarId = x.CarId,
                DropOffLocationId = x.DropOffLocationId,
                PickUpLocationId = x.PickUpLocationId
            });
            return await Task.FromResult(values);
        }
    }
}
