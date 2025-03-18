using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Queries.CarDescriptionQueries;
using RentACar.Application.Features.Mediator.Results.CarDescriptionResults;
using RentACar.Application.IRepositories.ICarDescriptionRepository;

namespace RentACar.Application.Features.Mediator.Handlers.CarDescriptionHandlers.Read
{
    public class GetCarDescriptionByIdQueryHandler : IRequestHandler<GetCarDescriptionByCarIdQuery, GetCarDescriptionByIdQueryResult>
    {
        private readonly ICarDescriptionReadRepository _carDescriptionReadRepository;

        public GetCarDescriptionByIdQueryHandler(ICarDescriptionReadRepository carDescriptionReadRepository)
        {
            _carDescriptionReadRepository = carDescriptionReadRepository;
        }

        public async Task<GetCarDescriptionByIdQueryResult> Handle(GetCarDescriptionByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _carDescriptionReadRepository.GetCarDescriptionByCarId(request.CarId);
            return new GetCarDescriptionByIdQueryResult
            {
                Id = values.Id,
                CarId = values.CarId,
                Details = values.Details
            };
        }
    }
}
