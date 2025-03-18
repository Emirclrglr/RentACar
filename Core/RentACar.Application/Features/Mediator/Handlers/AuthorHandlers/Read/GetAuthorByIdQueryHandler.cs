using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Queries.AuthorQueries;
using RentACar.Application.Features.Mediator.Results.AuthorResults;
using RentACar.Application.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Mediator.Handlers.AuthorHandlers.Read
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, GetAuthorByIdQueryResult>
    {
        private readonly IReadRepository<Author> _readRepository;

        public GetAuthorByIdQueryHandler(IReadRepository<Author> readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<GetAuthorByIdQueryResult> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _readRepository.GetByIdAsync(request.Id, false);
            return new()
            {
                Id = values.Id,
                Name = values.Name,
                ImageUrl = values.ImageUrl,
                Description = values.Description
            };
        }
    }
}
