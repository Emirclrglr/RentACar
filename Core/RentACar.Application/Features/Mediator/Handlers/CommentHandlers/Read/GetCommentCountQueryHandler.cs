using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Queries.CommentQueries;
using RentACar.Application.Features.Mediator.Results.CommentResults;
using RentACar.Application.IRepositories.ICommentRepository;

namespace RentACar.Application.Features.Mediator.Handlers.CommentHandlers.Read
{
    public class GetCommentCountQueryHandler : IRequestHandler<GetCommentCountQuery, int>
    {
        private readonly ICommentReadRepository _commentReadRepository;

        public GetCommentCountQueryHandler(ICommentReadRepository commentReadRepository)
        {
            _commentReadRepository = commentReadRepository;
        }

        public async Task<int> Handle(GetCommentCountQuery request, CancellationToken cancellationToken)
        {
            var count = await _commentReadRepository.GetCommentCountByBlogId(request.BlogId);
            return count;
        }
    }
}
