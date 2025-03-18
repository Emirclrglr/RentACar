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
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand>
    {
        private readonly IReservationWriteRepository _reservationWriteRepository;

        public CreateReservationCommandHandler(IReservationWriteRepository reservationWriteRepository)
        {
            _reservationWriteRepository = reservationWriteRepository;
        }

        public async Task Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            await _reservationWriteRepository.AddAsync(new()
            {
                Firstname = request.Firstname,
                Lastname = request.Lastname,
                Email = request.Email,
                Age = request.Age,
                PhoneNumber = request.PhoneNumber,
                DriverLicenseDate = request.DriverLicenseDate,
                Description = request.Description,
                Status = "Rezervasyon Alındı",
                CarId = request.CarId,
                PickUpLocationId = request.PickUpLocationId,
                DropOffLocationId = request.DropOffLocationId
            });
            await _reservationWriteRepository.SaveAsync();
        }
    }
}
