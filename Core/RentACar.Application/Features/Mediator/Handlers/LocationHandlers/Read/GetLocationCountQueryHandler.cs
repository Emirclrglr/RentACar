using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Queries.LocationQueries;
using RentACar.Application.IRepositories.ILocationRepository;

namespace RentACar.Application.Features.Mediator.Handlers.LocationHandlers.Read
{
    public class GetLocationCountQueryHandler : IRequestHandler<GetLocationCountQuery, int>
    {
        private readonly ILocationReadRespository _locationReadRespository;

        public GetLocationCountQueryHandler(ILocationReadRespository locationReadRespository)
        {
            _locationReadRespository = locationReadRespository;
        }

        public async Task<int> Handle(GetLocationCountQuery request, CancellationToken cancellationToken)
        {
            var count = await _locationReadRespository.LocationCountAsync();
            return count;
        }
    }
}
