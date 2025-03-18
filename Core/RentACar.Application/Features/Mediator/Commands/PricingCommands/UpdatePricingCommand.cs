using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Domain.Entities.Common;

namespace RentACar.Application.Features.Mediator.Commands.PricingCommands
{
    public class UpdatePricingCommand:BaseEntity, IRequest
    {
        public string Name { get; set; }
    }
}
