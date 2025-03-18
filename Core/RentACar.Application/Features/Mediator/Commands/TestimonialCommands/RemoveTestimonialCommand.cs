using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Domain.Entities.Common;

namespace RentACar.Application.Features.Mediator.Commands.TestimonialCommands
{
    public class RemoveTestimonialCommand:BaseEntity, IRequest
    {
        public RemoveTestimonialCommand(int id)
        {
            Id = id;
        }
    }
}
