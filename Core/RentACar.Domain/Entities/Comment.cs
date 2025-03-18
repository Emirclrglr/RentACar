using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Domain.Entities.Common;

namespace RentACar.Domain.Entities
{
    public class Comment : BaseEntity
    {
        public string Name { get; set; }
        public string MessageContent { get; set; }
        public DateTime CreatedDate { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
