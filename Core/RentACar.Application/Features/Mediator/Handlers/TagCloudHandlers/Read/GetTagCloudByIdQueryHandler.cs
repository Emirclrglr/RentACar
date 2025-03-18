using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Queries.TagCloudQueries;
using RentACar.Application.Features.Mediator.Results.TagCloudResults;
using RentACar.Application.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Mediator.Handlers.TagCloudHandlers.Read
{
    public class GetTagCloudByIdQueryHandler : IRequestHandler<GetTagCloudByIdQuery, GetTagCloudByIdQueryResult>
    {
        private readonly IReadRepository<TagCloud> _readRepository;

        public GetTagCloudByIdQueryHandler(IReadRepository<TagCloud> readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<GetTagCloudByIdQueryResult> Handle(GetTagCloudByIdQuery request, CancellationToken cancellationToken)
        {
            var tagCloud = await _readRepository.GetByIdAsync(request.Id, false);
            return new GetTagCloudByIdQueryResult
            {
                Id = tagCloud.Id,
                BlogId = tagCloud.BlogId,
                Title = tagCloud.Title
            };
        }
    }
}
