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
    public class GetServiceByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, GetServiceByIdQueryResult>
    {
        private readonly IReadRepository<Service> _readRepository;

        public GetServiceByIdQueryHandler(IReadRepository<Service> readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<GetServiceByIdQueryResult> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _readRepository.GetByIdAsync(request.Id, false);
            return new GetServiceByIdQueryResult
            {
                Id = values.Id,
                Icon = values.Icon,
                Description = values.Description,
                Title = values.Title
            };
        }
    }
}
