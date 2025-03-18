using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Application.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.IRepositories.ITagCloudRepository
{
    public interface ITagCloudReadRepository : IReadRepository<TagCloud>
    {
        IQueryable<TagCloud> GetTagsByBlogId(int id);
    }
}
