using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Domain.Entities.Common;

namespace RentACar.Application.Features.CQRS.Commands.AboutCommands
{
    public class RemoveAboutCommand:BaseEntity
    {
        public RemoveAboutCommand(int id)
        {
            Id = id;
        }
    }
}
