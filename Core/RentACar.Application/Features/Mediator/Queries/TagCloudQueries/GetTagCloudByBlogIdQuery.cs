﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.Mediator.Results.TagCloudResults;
using RentACar.Domain.Entities.Common;

namespace RentACar.Application.Features.Mediator.Queries.TagCloudQueries
{
    public class GetTagCloudByBlogIdQuery : IRequest<IQueryable<GetTagCloudByBlogIdQueryResult>>
    {
        public int BlogId { get; set; }
        public GetTagCloudByBlogIdQuery(int id)
        {
            BlogId = id;
        }
    }
}
