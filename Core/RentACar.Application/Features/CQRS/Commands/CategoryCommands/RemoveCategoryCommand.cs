using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Domain.Entities.Common;

namespace RentACar.Application.Features.CQRS.Commands.CategoryCommands
{
    public class RemoveCategoryCommand:BaseEntity
    {
        public RemoveCategoryCommand(int id)
        {
            Id = id;
        }
    }
}
