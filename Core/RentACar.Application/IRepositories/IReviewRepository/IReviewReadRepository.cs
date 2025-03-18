using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Application.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.IRepositories.IReviewRepository
{
    public interface IReviewReadRepository : IReadRepository<Review>
    {
        IQueryable<Review> GetReviewsByCarId(int id);
    }
}
