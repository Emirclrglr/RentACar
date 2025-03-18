using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace RentACar.Application.Features.Mediator.Commands.CarFeatureCommands
{
    public class UpdateCarFeatureIsAvailableToTrueCommand:IRequest
    {
        public int FeatureId { get; set; }

        public UpdateCarFeatureIsAvailableToTrueCommand(int featureId)
        {
            FeatureId = featureId;
        }
    }
}
