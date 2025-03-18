using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Application.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.IRepositories.ICommentRepository
{
    public interface ICommentReadRepository : IReadRepository<Comment>
    {
        IQueryable<Comment> GetCommentsByBlogId(int id);
        Task<int> GetCommentCountByBlogId(int id);
    }
}
