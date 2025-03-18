using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace RentACar.Application.Features.Mediator.Commands.CarFeatureCommands
{
    public class UpdateCarFeatureIsAvailableToFalseCommand:IRequest
    {
        public int FeatureId { get; set; }

        public UpdateCarFeatureIsAvailableToFalseCommand(int featureId)
        {
            FeatureId = featureId;
        }
    }
}
