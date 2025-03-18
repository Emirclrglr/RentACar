using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Domain.Entities.Common;

namespace RentACar.Domain.Entities
{
    public class AppRole:BaseEntity
    {
        public string AppRoleName { get; set; }
        public ICollection<AppUser> AppUsers { get; set; }
    }
}
