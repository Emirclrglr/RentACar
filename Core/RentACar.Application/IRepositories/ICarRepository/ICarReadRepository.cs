using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Application.Features.Mediator.Results.CarResults;
using RentACar.Application.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.IRepositories.ICarRepository
{
    public interface ICarReadRepository:IReadRepository<Car>
    {
        IQueryable<Car> GetLast5Cars(bool tracking = true);
        Task<int> CarCountAsync();
        Task<int> AutomaticCarCountAsync();
        Task<string> BrandWithTheMostVehiclesAsync();
        Task<int> VehicleCountWithLessThan1000KmAsync();
        Task<int> VehicleCountByFuelTypeGasOrDieselAsync();
        Task<int> VehicleCountByFuelTypeElectricAsync();
        IQueryable<GetBrandsByCarCountQueryResult> GetBrandsWithCarCount();
        Task<Car> GetCarByIdWithBrand(int id);

    }
}
