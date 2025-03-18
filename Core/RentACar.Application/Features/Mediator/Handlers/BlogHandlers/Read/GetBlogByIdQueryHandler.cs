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
    public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, GetBlogByIdQueryResult>
    {
        private readonly IReadRepository<Blog> _readRepository;

        public GetBlogByIdQueryHandler(IReadRepository<Blog> readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<GetBlogByIdQueryResult> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _readRepository.GetByIdAsync(request.Id, false);
            return new()
            {
                Id = values.Id,
                AuthorId = values.AuthorId,
                Title = values.Title,
                Description = values.Description,
                CategoryId = values.CategoryId,
                CoverImgUrl = values.CoverImgUrl,
                CreatedDate = values.CreatedDate
            };
        }
    }
}
