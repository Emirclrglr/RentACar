using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Queries.BlogQueries;
using RentACar.Application.Features.Mediator.Results.BlogResults;
using RentACar.Application.IRepositories.IBlogRepository;

namespace RentACar.Application.Features.Mediator.Handlers.BlogHandlers.Read
{
    public class GetBlogByIdWithAuthorQueryHandler : IRequestHandler<GetBlogByIdWithAuthorQuery, GetBlogByIdWithAuthorQueryResult>
    {
        private readonly IBlogReadRepository _blogReadRepository;

        public GetBlogByIdWithAuthorQueryHandler(IBlogReadRepository blogReadRepository)
        {
            _blogReadRepository = blogReadRepository;
        }

        public async Task<GetBlogByIdWithAuthorQueryResult> Handle(GetBlogByIdWithAuthorQuery request, CancellationToken cancellationToken)
        {
            var blogs = _blogReadRepository.BlogDetailsWithAuthorDetails(request.Id);
            var values = new GetBlogByIdWithAuthorQueryResult
            {
                Id = blogs.Id,
                AuthorName = blogs.Author.Name,
                AuthorDescription = blogs.Author.Description,
                AuthorImageUrl = blogs.Author.ImageUrl,
                Title = blogs.Title,
                AuthorId = blogs.AuthorId,
                Description = blogs.Description,
                CategoryId = blogs.CategoryId,
                CoverImgUrl = blogs.CoverImgUrl,
                CreatedDate = blogs.CreatedDate
            };
            return await Task.FromResult(values); 
        }
    }
}
