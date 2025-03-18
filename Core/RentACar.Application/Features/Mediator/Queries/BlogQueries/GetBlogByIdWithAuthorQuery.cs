using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Results.BlogResults;
using RentACar.Domain.Entities.Common;

namespace RentACar.Application.Features.Mediator.Queries.BlogQueries
{
    public class GetBlogByIdWithAuthorQuery :BaseEntity, IRequest<GetBlogByIdWithAuthorQueryResult>
    {
        public GetBlogByIdWithAuthorQuery(int id)
        {
            Id = id;
        }
    }
}
