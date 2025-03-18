using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Domain.Entities.Common;

namespace RentACar.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string Email { get; set; }
        public ICollection<CarBookingProccess> CarBookingProccesses { get; set; }

    }
}
