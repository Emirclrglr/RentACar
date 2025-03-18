using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace RentACar.Application.Features.Mediator.Commands.CarFeatureCommands
{
    public class CreateCarFeatureByCarCommand:IRequest
    {
        public int CarId { get; set; }
        public int FeatureId { get; set; }
        public bool IsAvailable { get; set; }
    }
}
