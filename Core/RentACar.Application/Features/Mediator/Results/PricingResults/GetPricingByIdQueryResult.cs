﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Domain.Entities.Common;

namespace RentACar.Application.Features.Mediator.Results.PricingResults
{
    public class GetPricingByIdQueryResult:BaseEntity
    {
        public string Name { get; set; }
    }
}
