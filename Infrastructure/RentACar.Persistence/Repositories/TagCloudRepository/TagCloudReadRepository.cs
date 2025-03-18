using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RentACar.Application.IRepositories.ITagCloudRepository;
using RentACar.Domain.Entities;
using RentACar.Persistence.Contexts;

namespace RentACar.Persistence.Repositories.TagCloudRepository
{
    public class TagCloudReadRepository : ReadRepository<TagCloud>, ITagCloudReadRepository
    {
        public TagCloudReadRepository(RentACarContext context) : base(context)
        {
        }

        public IQueryable<TagCloud> GetTagsByBlogId(int id)
        {
            return Table.Where(x => x.BlogId == id).AsNoTracking();
        }
    }
}
