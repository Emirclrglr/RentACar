using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Results.CarDescriptionResults;
using RentACar.Domain.Entities.Common;

namespace RentACar.Application.Features.Mediator.Queries.CarDescriptionQueries
{
    public class GetCarDescriptionByCarIdQuery: IRequest<GetCarDescriptionByIdQueryResult>
    {
        public int CarId { get; set; }
        public GetCarDescriptionByCarIdQuery(int id)
        {
            CarId = id;
        }
    }
}
