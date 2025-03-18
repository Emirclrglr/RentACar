using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Queries.LocationQueries;
using RentACar.Application.Features.Mediator.Results.LocationResults;
using RentACar.Application.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Mediator.Handlers.LocationHandlers.Read
{
    public class GetLocationQueryHandler : IRequestHandler<GetLocationQuery, IQueryable<GetLocationQueryResult>>
    {
        private readonly IReadRepository<Location> _readRepository;

        public GetLocationQueryHandler(IReadRepository<Location> readRepository)
        {
            _readRepository = readRepository;
        }

        public Task<IQueryable<GetLocationQueryResult>> Handle(GetLocationQuery request, CancellationToken cancellationToken)
        {
            var values = _readRepository.GetAll(false).Select(x => new GetLocationQueryResult
            {
                Id = x.Id,
                LocationName = x.LocationName
            });
            return Task.FromResult(values);
        }
    }
}
