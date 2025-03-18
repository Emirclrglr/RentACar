using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RentACar.Application.IRepositories.ICarFeatureRepository;
using RentACar.Domain.Entities;
using RentACar.Persistence.Contexts;

namespace RentACar.Persistence.Repositories.CarFeatureRepository
{
    public class CarFeatureWriteRepository : WriteRepository<CarFeature>, ICarFeatureWriteRepository
    {
        public CarFeatureWriteRepository(RentACarContext context) : base(context)
        {
        }

        public async Task ChangeCarFeatureIsAvailableToFalse(int id)
        {
            var value = await Table.Where(x => x.Id == id).FirstOrDefaultAsync();
            value.IsAvailable = false;
        }

        public async Task ChangeCarFeatureIsAvailableToTrue(int id)
        {
            var value = await Table.Where(x => x.Id == id).FirstOrDefaultAsync();
            value.IsAvailable = true;
        }


    }
}
