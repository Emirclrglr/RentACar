using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Domain.Entities.Common;

namespace RentACar.Application.Features.Mediator.Commands.SocialMediaCommands
{
    public class RemoveSocialMediaCommand:BaseEntity, IRequest
    {
        public RemoveSocialMediaCommand(int id)
        {
            Id = id;
        }
    }
}
