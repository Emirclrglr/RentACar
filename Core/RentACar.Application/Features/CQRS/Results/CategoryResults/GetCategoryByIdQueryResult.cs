using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Domain.Entities.Common;

namespace RentACar.Application.Features.CQRS.Results.CategoryResults
{
    public class GetCategoryByIdQueryResult:BaseEntity
    {
        public string Name { get; set; }
    }
}
