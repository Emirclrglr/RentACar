using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Results.CommentResults;

namespace RentACar.Application.Features.Mediator.Queries.CommentQueries
{
    public class GetCommentByBlogIdQuery:IRequest<IQueryable<GetCommentByBlogIdQueryResult>>
    {
        public GetCommentByBlogIdQuery(int id)
        {
            BlogId = id;
        }

        public int BlogId { get; set; }
      
    }
}
