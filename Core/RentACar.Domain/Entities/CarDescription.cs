using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Domain.Entities.Common;

namespace RentACar.Domain.Entities
{
    public class CarDescription : BaseEntity
    {
        public string Details { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
