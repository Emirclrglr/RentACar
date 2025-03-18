using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RentACar.Application.Features.Mediator.Results.CarResults;
using RentACar.Application.IRepositories.ICarRepository;
using RentACar.Domain.Entities;
using RentACar.Persistence.Contexts;

namespace RentACar.Persistence.Repositories.CarRepository
{
    public class CarReadRepository : ReadRepository<Car>, ICarReadRepository
    {
        public CarReadRepository(RentACarContext context) : base(context)
        {
        }

        public async Task<int> AutomaticCarCountAsync()
        {
            return await Table.Where(x => x.Transmission.Contains("Auto")).CountAsync();
        }

        public async Task<string> BrandWithTheMostVehiclesAsync()
        {
            return await Table.GroupBy(c => c.Brand.BrandName).OrderByDescending(g => g.Count()).Select(g => g.Key).FirstOrDefaultAsync();
        }

        public async Task<int> CarCountAsync()
        {
            return await Table.CountAsync();
        }

        public IQueryable<GetBrandsByCarCountQueryResult> GetBrandsWithCarCount()
        {
            var brandVehicleCounts = Table.GroupBy(x => x.Brand.BrandName).Select(g => new GetBrandsByCarCountQueryResult
            {
                BrandName = g.Key,
                VehicleCount = g.Count()
            }).OrderByDescending(g => g.BrandName);
            return brandVehicleCounts.AsNoTracking();
        }

        public async Task<Car> GetCarByIdWithBrand(int id)
        {
            return await Table.Include(x => x.Brand).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        }

        public IQueryable<Car> GetLast5Cars(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = Table.AsNoTracking();
            return query.OrderByDescending(x => x.Id).Take(5);
        }

        public async Task<int> VehicleCountByFuelTypeElectricAsync()
        {
            return await Table.Where(x => x.FuelType.Contains("Electric")).CountAsync();
        }

        public async Task<int> VehicleCountByFuelTypeGasOrDieselAsync()
        {
            return await Table.Where(x => x.FuelType.Contains("Gas") || x.FuelType.Contains("Diesel")).CountAsync();
        }

        public async Task<int> VehicleCountWithLessThan1000KmAsync()
        {
            return await Table.Where(x => x.Kilometer < 1000).CountAsync();
        }
    }
}
