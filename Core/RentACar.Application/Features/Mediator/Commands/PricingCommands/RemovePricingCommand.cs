using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Domain.Entities.Common;

namespace RentACar.Application.Features.Mediator.Commands.PricingCommands
{
    public class RemovePricingCommand:BaseEntity, IRequest
    {
        public RemovePricingCommand(int id)
        {
            Id = id;
        }
    }
}
