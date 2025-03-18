using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Application.IRepositories.IReservationRepository;
using RentACar.Domain.Entities;
using RentACar.Persistence.Contexts;

namespace RentACar.Persistence.Repositories.ReservationRepository
{
    public class ReservationReadRepository : ReadRepository<Reservation>, IReservationReadRepository
    {
        public ReservationReadRepository(RentACarContext context) : base(context)
        {
        }
    }
}
