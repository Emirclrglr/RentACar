using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Domain.Entities.Common;

namespace RentACar.Application.Features.Mediator.Commands.CarFeatureCommands
{
    public class UpdateCarFeatureCommand : BaseEntity, IRequest<List<UpdateCarFeatureCommand>>
    {
        public int CarId { get; set; }
        public int FeatureId { get; set; }
        public bool IsAvailable { get; set; }
    }
}
