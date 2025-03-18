using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Domain.Entities.Common;

namespace RentACar.Application.Features.CQRS.Queries.CategoryQueries
{
    public class GetCategoryByIdQuery:BaseEntity
    {
        public GetCategoryByIdQuery(int id)
        {
            Id = id;
        }
    }
}
