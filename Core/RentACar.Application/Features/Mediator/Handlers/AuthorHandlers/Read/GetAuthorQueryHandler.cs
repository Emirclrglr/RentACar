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
    public class GetAuthorQueryHandler : IRequestHandler<GetAuthorQuery, IQueryable<GetAuthorQueryResult>>
    {
        private readonly IReadRepository<Author> _readRepository;

        public GetAuthorQueryHandler(IReadRepository<Author> readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<IQueryable<GetAuthorQueryResult>> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
        {
            var values = _readRepository.GetAll(false).Select(x=>new GetAuthorQueryResult
            {
                Id = x.Id,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                Name = x.Name
            });
            return await Task.FromResult(values);
        }
    }
}
