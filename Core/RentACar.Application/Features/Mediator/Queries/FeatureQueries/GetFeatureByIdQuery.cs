using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Results.FeatureResults;
using RentACar.Domain.Entities.Common;

namespace RentACar.Application.Features.Mediator.Queries.FeatureQueries
{
    public class GetFeatureByIdQuery : BaseEntity, IRequest<GetFeatureByIdQueryResult>
    {
        public GetFeatureByIdQuery(int id)
        {
            Id = id;
        }
    }
}
