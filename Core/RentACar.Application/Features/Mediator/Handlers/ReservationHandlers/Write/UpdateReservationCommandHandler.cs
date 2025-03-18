using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Commands.ReservationCommands;
using RentACar.Application.IRepositories.IReservationRepository;

namespace RentACar.Application.Features.Mediator.Handlers.ReservationHandlers.Write
{
    public class UpdateReservationCommandHandler : IRequestHandler<UpdateReservationCommand>
    {
        private readonly IReservationReadRepository _reservationReadRepository;
        private readonly IReservationWriteRepository _reservationWriteRepository;

        public UpdateReservationCommandHandler(IReservationReadRepository reservationReadRepository, IReservationWriteRepository reservationWriteRepository)
        {
            _reservationReadRepository = reservationReadRepository;
            _reservationWriteRepository = reservationWriteRepository;
        }

        public async Task Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
        {
            var values = await _reservationReadRepository.GetByIdAsync(request.Id);
            values.Firstname = request.Firstname;
            values.Lastname = request.Lastname;
            values.Email = request.Email;
            values.PhoneNumber = request.PhoneNumber;
            values.Age = request.Age;
            values.DriverLicenseDate = request.DriverLicenseDate;
            values.Description = request.Description;
            values.Status = request.Status;
            values.CarId = request.CarId;
            values.PickUpLocationId = request.PickUpLocationId;
            values.DropOffLocationId = request.DropOffLocationId;
            await _reservationWriteRepository.SaveAsync();
        }
    }
}
