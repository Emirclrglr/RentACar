using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Queries.CarQueries;
using RentACar.Application.IRepositories.ICarRepository;

namespace RentACar.Application.Features.Mediator.Handlers.CarHandlers.Read
{
    public class GetCarCountQueryHandler : IRequestHandler<GetCarCountQuery, int>
    {
        private readonly ICarReadRepository _carReadRepository;

        public GetCarCountQueryHandler(ICarReadRepository carReadRepository)
        {
            _carReadRepository = carReadRepository;
        }

        public async Task<int> Handle(GetCarCountQuery request, CancellationToken cancellationToken)
        {
            var count = await _carReadRepository.CarCountAsync();
            return count;
        }
    }
}
