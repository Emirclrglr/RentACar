using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace RentACar.Application.Features.Mediator.Queries.CarQueries
{
    public class GetVehicleCountByFuelTypeGasOrDieselQuery : IRequest<int>
    {
    }
}
