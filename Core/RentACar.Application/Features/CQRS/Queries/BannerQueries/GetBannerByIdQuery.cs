using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Domain.Entities.Common;

namespace RentACar.Application.Features.CQRS.Queries.BannerQueries
{
    public class GetBannerByIdQuery:BaseEntity
    {
        public GetBannerByIdQuery(int id)
        {
            Id = id;
        }
    }
}
