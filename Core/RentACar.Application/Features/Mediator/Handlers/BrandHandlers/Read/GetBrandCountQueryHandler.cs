using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Queries.BrandQueries;
using RentACar.Application.IRepositories.IBrandRepository;

namespace RentACar.Application.Features.Mediator.Handlers.BrandHandlers.Read
{
    public class GetBrandCountQueryHandler : IRequestHandler<GetBrandCountQuery, int>
    {
        private readonly IBrandReadRespoitory _brandReadRespoitory;

        public GetBrandCountQueryHandler(IBrandReadRespoitory brandReadRespoitory)
        {
            _brandReadRespoitory = brandReadRespoitory;
        }

        public async Task<int> Handle(GetBrandCountQuery request, CancellationToken cancellationToken)
        {
            var count = await _brandReadRespoitory.BrandCountAsync();
            return count;
        }
    }
}
