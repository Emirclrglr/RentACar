using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Queries.CarQueries;
using RentACar.Application.Features.Mediator.Results.CarResults;
using RentACar.Application.IRepositories.ICarRepository;

namespace RentACar.Application.Features.Mediator.Handlers.CarHandlers.Read
{
    public class GetBrandsByCarCountQueryHandler : IRequestHandler<GetBrandsByCarCountQuery, IQueryable<GetBrandsByCarCountQueryResult>>
    {
        private readonly ICarReadRepository _carReadRepository;

        public GetBrandsByCarCountQueryHandler(ICarReadRepository carReadRepository)
        {
            _carReadRepository = carReadRepository;
        }

        public async Task<IQueryable<GetBrandsByCarCountQueryResult>> Handle(GetBrandsByCarCountQuery request, CancellationToken cancellationToken)
        {
            var values = _carReadRepository.GetBrandsWithCarCount();
            return await Task.FromResult(values);
        }
    }
}
