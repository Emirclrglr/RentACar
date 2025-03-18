using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Queries.BlogQueries;
using RentACar.Application.Features.Mediator.Results.BlogResults;
using RentACar.Application.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Mediator.Handlers.BlogHandlers.Read
{
    public class GetBlogQueryHandler : IRequestHandler<GetBlogQuery, IQueryable<GetBlogQueryResult>>
    {
        private readonly IReadRepository<Blog> _readRepository;

        public GetBlogQueryHandler(IReadRepository<Blog> readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<IQueryable<GetBlogQueryResult>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {
            var values = _readRepository.GetAll(false).Select(x=> new GetBlogQueryResult
            {
                AuthorId = x.AuthorId,
                CategoryId = x.CategoryId,
                CoverImgUrl = x.CoverImgUrl,
                CreatedDate = x.CreatedDate,
                Id = x.Id,
                Title = x.Title
            });
            return await Task.FromResult(values);
        }
    }
}
