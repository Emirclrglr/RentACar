using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Results.ServiceResults;

namespace RentACar.Application.Features.Mediator.Queries.ServiceQueries
{
    public class GetServiceQuery:IRequest<IQueryable<GetServiceQueryResult>>
    {
    }
}
