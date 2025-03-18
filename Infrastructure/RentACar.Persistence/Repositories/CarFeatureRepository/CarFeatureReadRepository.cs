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
    public class CarFeatureReadRepository : ReadRepository<CarFeature>, ICarFeatureReadRepository
    {
        public CarFeatureReadRepository(RentACarContext context) : base(context)
        {
        }

        public IQueryable<CarFeature> GetCarFeaturesByCarIdWithRelations(int id)
        {
            return Table.Where(x => x.CarId == id).AsNoTracking();
        }
    }
}
