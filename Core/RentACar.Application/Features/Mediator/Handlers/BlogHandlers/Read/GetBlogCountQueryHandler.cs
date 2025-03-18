using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Queries.BlogQueries;
using RentACar.Application.IRepositories.IBlogRepository;

namespace RentACar.Application.Features.Mediator.Handlers.BlogHandlers.Read
{
    public class GetBlogCountQueryHandler : IRequestHandler<GetBlogCountQuery, int>
    {
        private readonly IBlogReadRepository _blogReadRepository;

        public GetBlogCountQueryHandler(IBlogReadRepository blogReadRepository)
        {
            _blogReadRepository = blogReadRepository;
        }

        public async Task<int> Handle(GetBlogCountQuery request, CancellationToken cancellationToken)
        {
            var count = await _blogReadRepository.BlogCountAsync();
            return count;
        }
    }
}
