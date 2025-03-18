using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Domain.Entities.Common;

namespace RentACar.Application.Features.Mediator.Results.TagCloudResults
{
    public class GetTagCloudQueryResult: BaseEntity
    {
        public string Title { get; set; }
        public int BlogId { get; set; }
    }
}
