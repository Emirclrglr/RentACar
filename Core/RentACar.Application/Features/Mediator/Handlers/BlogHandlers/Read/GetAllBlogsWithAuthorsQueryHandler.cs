using MediatR;
using RentACar.Application.Features.Mediator.Queries.BlogQueries;
using RentACar.Application.Features.Mediator.Results.BlogResults;
using RentACar.Application.IRepositories.IBlogRepository;

namespace RentACar.Application.Features.Mediator.Handlers.BlogHandlers.Read
{
    public class GetAllBlogsWithAuthorsQueryHandler : IRequestHandler<GetAllBlogsWithAuthorsQuery, IQueryable<GetAllBlogsWithAuthorsQueryResult>>
    {
        private readonly IBlogReadRepository _blogReadRepository;

        public GetAllBlogsWithAuthorsQueryHandler(IBlogReadRepository blogReadRepository)
        {
            _blogReadRepository = blogReadRepository;
        }

        public async Task<IQueryable<GetAllBlogsWithAuthorsQueryResult>> Handle(GetAllBlogsWithAuthorsQuery request, CancellationToken cancellationToken)
        {
            var blogs = _blogReadRepository.BlogListByRecentDateTime(false).Select(x => new GetAllBlogsWithAuthorsQueryResult
            {
                Id = x.Id,
                AuthorName = x.Author.Name,
                Title = x.Title,
                CoverImgUrl = x.CoverImgUrl,
                CreatedDate = x.CreatedDate,
                CategoryId = x.CategoryId
            });

            return await Task.FromResult(blogs);
        }
    }
}
