using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Application.IRepositories.ICarBookingRepository;
using RentACar.Domain.Entities;
using RentACar.Persistence.Contexts;

namespace RentACar.Persistence.Repositories.CarBookingRepository
{
    public class CarBookingWriteRepository : WriteRepository<CarBooking>, ICarBookingWriteRepository
    {
        public CarBookingWriteRepository(RentACarContext context) : base(context)
        {
        }
    }
}
