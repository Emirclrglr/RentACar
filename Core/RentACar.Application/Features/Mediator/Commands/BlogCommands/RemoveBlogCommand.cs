using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Domain.Entities.Common;

namespace RentACar.Application.Features.Mediator.Commands.BlogCommands
{
    public class RemoveBlogCommand:BaseEntity, IRequest
    {
        public RemoveBlogCommand(int id)
        {
            Id = id;
        }
    }
}
