using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Persistence.Configuration
{
    public interface IConnectionConfig
    {
        public string ConnectionString { get; }
    }
}
