using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Results.CarResults;

namespace RentACar.Application.Features.Mediator.Queries.CarQueries
{
    public class GetLast5CarsQuery:IRequest<IQueryable<GetLast5CarQueryResult>>
    {
    }
}
