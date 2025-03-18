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
    public class GetCommentQueryHandler : IRequestHandler<GetCommentQuery, IQueryable<GetCommentQueryResult>>
    {
        private readonly ICommentReadRepository _commentReadRepository;

        public GetCommentQueryHandler(ICommentReadRepository commentReadRepository)
        {
            _commentReadRepository = commentReadRepository;
        }

        public async Task<IQueryable<GetCommentQueryResult>> Handle(GetCommentQuery request, CancellationToken cancellationToken)
        {
            var values = _commentReadRepository.GetAll(false).Select(x => new GetCommentQueryResult
            {
                Id = x.Id,
                Name = x.Name,
                MessageContent = x.MessageContent,
                CreatedDate = x.CreatedDate,
                BlogId = x.BlogId
            });

            return await Task.FromResult(values);
        }
    }
}
