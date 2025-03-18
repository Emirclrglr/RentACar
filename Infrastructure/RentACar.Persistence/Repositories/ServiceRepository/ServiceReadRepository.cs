using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RentACar.Application.IRepositories.IServiceRepository;
using RentACar.Domain.Entities;
using RentACar.Persistence.Contexts;

namespace RentACar.Persistence.Repositories.ServiceRepository
{
    public class ServiceReadRepository : ReadRepository<Service>, IServiceReadRepository
    {
        public ServiceReadRepository(RentACarContext context) : base(context)
        {
        }

        public async Task<int> ServiceCount()
        {
            return await Table.CountAsync();
        }
    }
}
