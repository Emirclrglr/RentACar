using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Domain.Entities.Common;

namespace RentACar.Application.Features.CQRS.Queries.ContactQueries
{
    public class GetContactByIdQuery:BaseEntity
    {
        public GetContactByIdQuery(int id)
        {
            Id = id;
        }
    }
}
