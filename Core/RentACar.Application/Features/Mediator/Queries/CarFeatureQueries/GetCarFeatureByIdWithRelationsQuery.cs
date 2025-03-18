using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Results.CarFeatureResults;
using RentACar.Domain.Entities.Common;

namespace RentACar.Application.Features.Mediator.Queries.CarFeatureQueries
{
    public class GetCarFeatureByIdWithRelationsQuery : IRequest<IQueryable<GetCarFeatureByCarIdWithRelationsQueryResult>>
    {
        public GetCarFeatureByIdWithRelationsQuery(int id)
        {
            CarId = id;
        }

        public int CarId { get; set; }
    }
}
