using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Results.FooterAddressResults;
using RentACar.Domain.Entities.Common;

namespace RentACar.Application.Features.Mediator.Queries.FooterAddressQueries
{
    public class GetFooterAddressByIdQuery:BaseEntity, IRequest<GetFooterAddressByIdQueryResult>
    {
        public GetFooterAddressByIdQuery(int id)
        {
            Id = id;
        }
    }
}
