using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Application.Features.Mediator.Results.CarBookingResults;
using RentACar.Application.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.IRepositories.ICarBookingRepository
{
    public interface ICarBookingReadRepository : IReadRepository<CarBooking>
    {
        IQueryable<GetCarBookingsLocationWithCarCountQueryResult> LocationWithCarCount();
    }
}
