using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Domain.Entities.Common;

namespace RentACar.Application.Features.Mediator.Commands.ReviewCommands
{
    public class DeleteReviewCommand:BaseEntity, IRequest
    {
        public DeleteReviewCommand(int id)
        {
            Id = id;
        }
    }
}
