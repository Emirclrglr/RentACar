using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RentACar.Application.IRepositories.ICarDescriptionRepository;
using RentACar.Domain.Entities;
using RentACar.Persistence.Contexts;

namespace RentACar.Persistence.Repositories.CarDescriptionRepository
{
    public class CarDescriptionReadRepository : ReadRepository<CarDescription>, ICarDescriptionReadRepository
    {
        public CarDescriptionReadRepository(RentACarContext context) : base(context)
        {
        }

        public async Task<CarDescription> GetCarDescriptionByCarId(int carId)
        {
            var values = await Table.AsNoTracking().FirstOrDefaultAsync(x => x.CarId == carId);
            return values;
        }
    }
}
