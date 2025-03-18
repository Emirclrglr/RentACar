using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Queries.BlogQueries;
using RentACar.Application.Features.Mediator.Results.BlogResults;
using RentACar.Application.IRepositories.IBlogRepository;
using RentACar.Application.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Mediator.Handlers.BlogHandlers.Read
{
    public class GetLast3BlogWithAuthorQueryHandler : IRequestHandler<GetLast3BlogWithAuthorQuery, IQueryable<GetLast3BlogWithAuthorQueryResult>>
    {
        private readonly IBlogReadRepository _blogReadRepository;

        public GetLast3BlogWithAuthorQueryHandler(IBlogReadRepository blogReadRepository)
        {
            _blogReadRepository = blogReadRepository;
        }

        public async Task<IQueryable<GetLast3BlogWithAuthorQueryResult>> Handle(GetLast3BlogWithAuthorQuery request, CancellationToken cancellationToken)
        {
            var values = _blogReadRepository.GetLast3Blogs().Select(x=>new GetLast3BlogWithAuthorQueryResult
            {
                Id = x.Id,
                Title = x.Title,
                CoverImgUrl = x.CoverImgUrl,
                AuthorName = x.Author.Name,
                CategoryId = x.CategoryId,
                CreatedDate = x.CreatedDate
            });
            return await Task.FromResult(values);
        }
    }
}
