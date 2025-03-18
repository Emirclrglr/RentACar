using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Queries.ReviewQueries;
using RentACar.Application.Features.Mediator.Results.ReviewResults;
using RentACar.Application.IRepositories.IReviewRepository;

namespace RentACar.Application.Features.Mediator.Handlers.ReviewHandlers.Read
{
    public class GetReviewsByCarIdQueryHandler : IRequestHandler<GetReviewsByCarIdQuery, IQueryable<GetReviewsByCarIdQueryResult>>
    {
        private readonly IReviewReadRepository _reviewReadRepository;

        public GetReviewsByCarIdQueryHandler(IReviewReadRepository reviewReadRepository)
        {
            _reviewReadRepository = reviewReadRepository;
        }

        public async Task<IQueryable<GetReviewsByCarIdQueryResult>> Handle(GetReviewsByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values = _reviewReadRepository.GetReviewsByCarId(request.CarId).Select(x => new GetReviewsByCarIdQueryResult
            {
                Id = x.Id,
                CarId = x.CarId,
                CustomerName = x.CustomerName,
                Comment = x.Comment,
                CustomerImage = x.CustomerImage,
                RatingValue = x.RatingValue,
                ReviewDate = x.ReviewDate
            });

            return await Task.FromResult(values);
        }
    }
}
