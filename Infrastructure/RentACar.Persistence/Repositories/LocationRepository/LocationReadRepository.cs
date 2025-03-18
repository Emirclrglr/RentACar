using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RentACar.Application.IRepositories.ILocationRepository;
using RentACar.Domain.Entities;
using RentACar.Persistence.Contexts;

namespace RentACar.Persistence.Repositories.LocationRepository
{
    public class LocationReadRepository : ReadRepository<Location>, ILocationReadRespository
    {
        public LocationReadRepository(RentACarContext context) : base(context)
        {
        }

        public async Task<int> LocationCountAsync()
        {
            return await Table.CountAsync();
        }
    }
}
