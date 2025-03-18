using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Queries.ServiceQueries;
using RentACar.Application.Features.Mediator.Results.ServiceResults;
using RentACar.Application.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Mediator.Handlers.ServiceHandlers.Read
{
    public class GetServiceQueryHandler : IRequestHandler<GetServiceQuery, IQueryable<GetServiceQueryResult>>
    {
        private readonly IReadRepository<Service> _readRepository;

        public GetServiceQueryHandler(IReadRepository<Service> readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<IQueryable<GetServiceQueryResult>> Handle(GetServiceQuery request, CancellationToken cancellationToken)
        {
            var values = _readRepository.GetAll(false).Select(x => new GetServiceQueryResult
            {
                Id = x.Id,
                Description = x.Description,
                Icon = x.Icon,
                Title = x.Title
            });
            return await Task.FromResult(values);
        }
    }
}
