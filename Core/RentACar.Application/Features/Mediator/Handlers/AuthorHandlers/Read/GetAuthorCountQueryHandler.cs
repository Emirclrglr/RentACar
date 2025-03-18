using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Queries.AuthorQueries;
using RentACar.Application.IRepositories.IAuthorRepository;

namespace RentACar.Application.Features.Mediator.Handlers.AuthorHandlers.Read
{
    public class GetAuthorCountQueryHandler : IRequestHandler<GetAuthorCountQuery, int>
    {
        private readonly IAuthorReadRepository _authorReadRepository;

        public GetAuthorCountQueryHandler(IAuthorReadRepository authorReadRepository)
        {
            _authorReadRepository = authorReadRepository;
        }

        public async Task<int> Handle(GetAuthorCountQuery request, CancellationToken cancellationToken)
        {
            var count = await _authorReadRepository.AuthorCountAsync();
            return count;
        }
    }
}
