using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Domain.Entities.Common;

namespace RentACar.Application.Features.Mediator.Commands.ServiceCommands
{
    public class RemoveServiceCommand:BaseEntity, IRequest
    {
        public RemoveServiceCommand(int id)
        {
            Id = id;
        }
    }
}
