using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace RentACar.Application
{
    public static class MediatorRegistrationService
    {
        public static void MediatorRegistration(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(MediatorRegistrationService).Assembly));
        }
    }
}
