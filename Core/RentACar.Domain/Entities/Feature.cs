using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Domain.Entities.Common;

namespace RentACar.Domain.Entities
{
    public class Feature:BaseEntity
    {
        public string FeatureName { get; set; }
        public ICollection<CarFeature> CarFeatures { get; set; }
    }
}
