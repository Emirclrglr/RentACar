using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RentACar.Application.Features.Mediator.Results.CarBookingResults;
using RentACar.Application.IRepositories.ICarBookingRepository;
using RentACar.Domain.Entities;
using RentACar.Persistence.Contexts;

namespace RentACar.Persistence.Repositories.CarBookingRepository
{
    public class CarBookingReadRepository : ReadRepository<CarBooking>, ICarBookingReadRepository
    {
        public CarBookingReadRepository(RentACarContext context) : base(context)
        {
        }

        public IQueryable<GetCarBookingsLocationWithCarCountQueryResult> LocationWithCarCount()
        {
            var locationVehicleCounts = Table.GroupBy(x => x.Location.LocationName).Select(g => new GetCarBookingsLocationWithCarCountQueryResult
            {
                LocationName = g.Key,
                VehicleCount = g.Count()
            }).OrderByDescending(g => g.LocationName);
            return locationVehicleCounts.AsNoTracking();
        }
    }
}
