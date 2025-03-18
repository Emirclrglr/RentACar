using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Domain.Entities.Common;

namespace RentACar.Application.Features.Mediator.Commands.FooterAddressCommands
{
    public class RemoveFooterAddressCommand:BaseEntity, IRequest
    {
        public RemoveFooterAddressCommand(int id)
        {
            Id = id;
        }
    }
}
