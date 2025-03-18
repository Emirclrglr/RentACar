using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Domain.Entities.Common;

namespace RentACar.Application.Features.Mediator.Results.AppUserResults
{
    public class GetCheckAppUserQueryResult:BaseEntity
    {
        public string Username { get; set; }
        public string Role { get; set; }
        public bool IsExists { get; set; }
    }
}
