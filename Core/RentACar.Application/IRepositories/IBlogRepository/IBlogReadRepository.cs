using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Application.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.IRepositories.IBlogRepository
{
    public interface IBlogReadRepository:IReadRepository<Blog>
    {
        IQueryable<Blog> GetLast3Blogs();
        IQueryable<Blog> BlogListByRecentDateTime(bool tracking = true);
        Blog BlogDetailsWithAuthorDetails(int id);
        Task<int> BlogCountAsync();
    }
}
