using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RentACar.Application.IRepositories.IBrandRepository;
using RentACar.Domain.Entities;
using RentACar.Persistence.Contexts;

namespace RentACar.Persistence.Repositories.BrandRepository
{
    public class BrandReadRepository : ReadRepository<Brand>, IBrandReadRespoitory
    {
        public BrandReadRepository(RentACarContext context) : base(context)
        {
        }

        public async Task<int> BrandCountAsync()
        {
            return await Table.CountAsync();
        }


    }
}
