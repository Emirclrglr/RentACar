﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Results.FooterAddressResults;

namespace RentACar.Application.Features.Mediator.Queries.FooterAddressQueries
{
    public class GetFooterAddressQuery:IRequest<IQueryable<GetFooterAddressQueryResult>>
    {
    }
}
