using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Application.Features.Mediator.Results.CarPricingResults;
using RentACar.Application.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.IRepositories.ICarPricingRepository
{
   public interface ICarPricingReadRepository : IReadRepository<CarPricing>
    {
        Task<decimal> AverageDailyCarRentalPrice();
        Task<decimal> AverageWeeklyCarRentalPrice();
        Task<decimal> AverageHourlyCarRentalPrice();
        Task<string> MostExpensiveVehicleAsync();
        Task<string> CheapestVehicleAsync();
        IQueryable<GetCarPricingWithTimePeriodQueryResult> GetCarPricingsWithTimePeriod();
    }
}
