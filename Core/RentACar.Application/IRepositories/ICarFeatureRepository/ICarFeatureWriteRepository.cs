using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Application.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.IRepositories.ICarFeatureRepository
{
    public interface ICarFeatureWriteRepository : IWriteRepository<CarFeature>
    {
        Task ChangeCarFeatureIsAvailableToTrue(int id);
        Task ChangeCarFeatureIsAvailableToFalse(int id);
    }
}
