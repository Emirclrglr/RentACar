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
    public class DeleteReservationCommandHandler : IRequestHandler<DeleteReservationCommand>
    {
        private readonly IReservationReadRepository _reservationReadRepository;
        private readonly IReservationWriteRepository _reservationWriteRepository;

        public DeleteReservationCommandHandler(IReservationReadRepository reservationReadRepository, IReservationWriteRepository reservationWriteRepository)
        {
            _reservationReadRepository = reservationReadRepository;
            _reservationWriteRepository = reservationWriteRepository;
        }

        public async Task Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
        {
            var value = await _reservationReadRepository.GetByIdAsync(request.Id);
            _reservationWriteRepository.Remove(value);
            await _reservationWriteRepository.SaveAsync();
        }
    }
}
