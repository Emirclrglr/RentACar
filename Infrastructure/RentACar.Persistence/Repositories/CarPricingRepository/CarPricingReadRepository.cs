using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RentACar.Application.Enums;
using RentACar.Application.Features.Mediator.Results.CarPricingResults;
using RentACar.Application.IRepositories.ICarPricingRepository;
using RentACar.Domain.Entities;
using RentACar.Persistence.Contexts;

namespace RentACar.Persistence.Repositories.CarPricingRepository
{
    public class CarPricingReadRepository : ReadRepository<CarPricing>, ICarPricingReadRepository
    {
        private readonly RentACarContext _context;
        public CarPricingReadRepository(RentACarContext context) : base(context)
        {
            _context = context;
        }

        public async Task<decimal> AverageDailyCarRentalPrice()
        {
            return await Table.Where(x => x.PricingId == (int)PricingEnum.Daily).AverageAsync(y => y.Price);
        }

        public async Task<decimal> AverageHourlyCarRentalPrice()
        {
            return await Table.Where(x => x.PricingId == (int)PricingEnum.Hourly).AverageAsync(y => y.Price);

        }

        public async Task<decimal> AverageWeeklyCarRentalPrice()
        {
            return await Table.Where(x => x.PricingId == (int)PricingEnum.Weekly).AverageAsync(y => y.Price);
        }

        public async Task<string> CheapestVehicleAsync()
        {
            var modelName = await Table.OrderBy(x => x.Price).Select(x => x.Car.Model).FirstOrDefaultAsync();
            var brandName = await Table.OrderBy(x => x.Price).Select(x => x.Car.Brand.BrandName).FirstOrDefaultAsync();
            return $"{brandName} {modelName}";
        }

        public IQueryable<GetCarPricingWithTimePeriodQueryResult> GetCarPricingsWithTimePeriod()
        {
            var pivotQuery = Table
                             .Include(cp => cp.Car)
                             .ThenInclude(c => c.Brand)
                             .GroupBy(cp => new
                             {
                                 Car = cp.Car.Brand.BrandName + " " + cp.Car.Model,
                                 CoverIMG = cp.Car.CoverIMG,
                                 CarId = cp.CarId
                             })
                             .Select(g => new GetCarPricingWithTimePeriodQueryResult
                             {
                                 CarId = g.Key.CarId,
                                 Model = g.Key.Car,
                                 CoverIMG = g.Key.CoverIMG,
                                 DailyPrice = g.Where(cp => cp.PricingId == (int)PricingEnum.Daily).Sum(cp => (decimal?)cp.Price) ?? 0,
                                 HourlyPrice = g.Where(cp => cp.PricingId == (int)PricingEnum.Hourly).Sum(cp => (decimal?)cp.Price) ?? 0,
                                 WeeklyPrice = g.Where(cp => cp.PricingId == (int)PricingEnum.Weekly).Sum(cp => (decimal?)cp.Price) ?? 0
                             })
                             .ToList();

            return pivotQuery.AsQueryable();
        }

        public async Task<string> MostExpensiveVehicleAsync()
        {
            var modelName = await Table.OrderByDescending(x => x.Price).Select(x => x.Car.Model).FirstOrDefaultAsync();
            var brandName = await Table.OrderByDescending(x => x.Price).Select(x => x.Car.Brand.BrandName).FirstOrDefaultAsync();
            return $"{brandName} {modelName}";

        }
    }
}


