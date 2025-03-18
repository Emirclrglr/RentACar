﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Results.AuthorResults;

namespace RentACar.Application.Features.Mediator.Queries.AuthorQueries
{
    public class GetAuthorQuery:IRequest<IQueryable<GetAuthorQueryResult>>
    {
    }
}
