using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Domain.Entities.Common;

namespace RentACar.Application.Features.Mediator.Commands.ReservationCommands
{
   public class DeleteReservationCommand:BaseEntity, IRequest
    {
        public DeleteReservationCommand(int id)
        {
            Id = id;
        }
    }
}
