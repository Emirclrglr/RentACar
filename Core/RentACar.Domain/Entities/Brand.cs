using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Domain.Entities.Common;

namespace RentACar.Domain.Entities
{
    public class Brand:BaseEntity
    {
        public string BrandName { get; set; }
        public int CarId { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
