using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Domain.Entities.Common;

namespace RentACar.Application.Features.CQRS.Commands.BannerCommands
{
    public class RemoveBannerCommand:BaseEntity
    {
        public RemoveBannerCommand(int id)
        {
            Id = id;
        }
    }
}
