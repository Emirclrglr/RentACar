using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RentACar.Application.IRepositories.IReviewRepository;
using RentACar.Domain.Entities;
using RentACar.Persistence.Contexts;

namespace RentACar.Persistence.Repositories.ReviewRepository
{
    public class ReviewReadRepository : ReadRepository<Review>, IReviewReadRepository
    {
        public ReviewReadRepository(RentACarContext context) : base(context)
        {
        }

        public IQueryable<Review> GetReviewsByCarId(int id)
        {
            return Table.Where(x => x.CarId == id).AsNoTracking();
        }
    }
}
