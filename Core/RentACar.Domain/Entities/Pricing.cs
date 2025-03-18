using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Domain.Entities.Common;

namespace RentACar.Domain.Entities
{
    public class Pricing:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<CarPricing> CarPricings { get; set; }

    }
}
