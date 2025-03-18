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
    public class GetTagCloudQueryHandler : IRequestHandler<GetTagCloudQuery, IQueryable<GetTagCloudQueryResult>>
    {
        private readonly IReadRepository<TagCloud> _readRepository;

        public GetTagCloudQueryHandler(IReadRepository<TagCloud> readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<IQueryable<GetTagCloudQueryResult>> Handle(GetTagCloudQuery request, CancellationToken cancellationToken)
        {
            var tagClouds = _readRepository.GetAll(false).Select(x => new GetTagCloudQueryResult
            {
                Id = x.Id,
                BlogId = x.BlogId,
                Title = x.Title
            });
            return await Task.FromResult(tagClouds);
        }
    }
}
