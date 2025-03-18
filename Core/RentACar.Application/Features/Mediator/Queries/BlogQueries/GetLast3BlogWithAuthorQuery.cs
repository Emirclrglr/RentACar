using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Results.BlogResults;

namespace RentACar.Application.Features.Mediator.Queries.BlogQueries
{
    public class GetLast3BlogWithAuthorQuery:IRequest<IQueryable<GetLast3BlogWithAuthorQueryResult>>
    {
    }
}
