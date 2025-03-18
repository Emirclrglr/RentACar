using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Queries.TagCloudQueries;
using RentACar.Application.Features.Mediator.Results.TagCloudResults;
using RentACar.Application.IRepositories.ITagCloudRepository;

namespace RentACar.Application.Features.Mediator.Handlers.TagCloudHandlers.Read
{
    public class GetTagCloudByBlogIdQueryHandler : IRequestHandler<GetTagCloudByBlogIdQuery, IQueryable<GetTagCloudByBlogIdQueryResult>>
    {
        private readonly ITagCloudReadRepository _tagCloudReadRepository;

        public GetTagCloudByBlogIdQueryHandler(ITagCloudReadRepository tagCloudReadRepository)
        {
            _tagCloudReadRepository = tagCloudReadRepository;
        }

        public async Task<IQueryable<GetTagCloudByBlogIdQueryResult>> Handle(GetTagCloudByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var values = _tagCloudReadRepository.GetTagsByBlogId(request.BlogId).Select(x => new GetTagCloudByBlogIdQueryResult
            {
                Id = x.Id,
                Title = x.Title,
                BlogId = x.BlogId
            });
            return await Task.FromResult(values);
        }
    }
}
