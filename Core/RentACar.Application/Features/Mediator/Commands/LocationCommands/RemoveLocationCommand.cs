using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Domain.Entities.Common;

namespace RentACar.Application.Features.Mediator.Commands.LocationCommands
{
    public class RemoveLocationCommand:BaseEntity, IRequest
    {
        public RemoveLocationCommand(int id)
        {
            Id = id;
        }
    }
}
