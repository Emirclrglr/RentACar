﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace RentACar.Application.Features.Mediator.Commands.FeatureCommands
{
    public class CreateFeatureCommand:IRequest
    {
        public string FeatureName { get; set; }
    }
}
