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
    public class GetCommentByBlogIdQueryHandler : IRequestHandler<GetCommentByBlogIdQuery, IQueryable<GetCommentByBlogIdQueryResult>>
    {
        private readonly ICommentReadRepository _commentReadRepository;

        public GetCommentByBlogIdQueryHandler(ICommentReadRepository commentReadRepository)
        {
            _commentReadRepository = commentReadRepository;
        }

        public async Task<IQueryable<GetCommentByBlogIdQueryResult>> Handle(GetCommentByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var values = _commentReadRepository.GetCommentsByBlogId(request.BlogId).Select(x => new GetCommentByBlogIdQueryResult
            {
                Id = x.Id,
                Name = x.Name,
                BlogId = x.BlogId,
                MessageContent = x.MessageContent,
                CreatedDate = x.CreatedDate
            });

            return await Task.FromResult(values);
        }
    }
}
