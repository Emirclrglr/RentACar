using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Results;

namespace RentACar.Application.Features.Mediator.Queries.CarPricingQueries
{
    public class GetMostExpensiveVehicleQuery:IRequest<string>
    {
    }
}
