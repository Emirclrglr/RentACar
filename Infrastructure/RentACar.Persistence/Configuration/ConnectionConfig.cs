using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace RentACar.Persistence.Configuration
{
    public class ConnectionConfig : IConnectionConfig
    {
        private readonly IConfiguration _configuration;

        public ConnectionConfig(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ConnectionString => _configuration.GetConnectionString("MSSQLConnection");
    }
}
