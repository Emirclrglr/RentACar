﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Results.SocialMediaResults;

namespace RentACar.Application.Features.Mediator.Queries.SocialMediaQueries
{
    public class GetSocialMediaQuery:IRequest<IQueryable<GetSocialMediaQueryResult>>
    {
    }
}
