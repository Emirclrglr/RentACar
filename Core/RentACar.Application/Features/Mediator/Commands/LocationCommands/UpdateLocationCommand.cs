using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Domain.Entities.Common;

namespace RentACar.Application.Features.Mediator.Commands.LocationCommands
{
    public class UpdateLocationCommand:BaseEntity, IRequest
    {
        public string LocationName { get; set; }
    }
}
