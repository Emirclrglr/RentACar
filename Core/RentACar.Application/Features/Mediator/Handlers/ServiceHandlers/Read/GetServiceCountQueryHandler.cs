using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Queries.ServiceQueries;
using RentACar.Application.IRepositories.IServiceRepository;

namespace RentACar.Application.Features.Mediator.Handlers.ServiceHandlers.Read
{
    public class GetServiceCountQueryHandler : IRequestHandler<GetServiceCountQuery, int>
    {
        private readonly IServiceReadRepository _serviceReadRepository;

        public GetServiceCountQueryHandler(IServiceReadRepository serviceReadRepository)
        {
            _serviceReadRepository = serviceReadRepository;
        }

        public async Task<int> Handle(GetServiceCountQuery request, CancellationToken cancellationToken)
        {
            var count = await _serviceReadRepository.ServiceCount();
            return count;
        }
    }
}
