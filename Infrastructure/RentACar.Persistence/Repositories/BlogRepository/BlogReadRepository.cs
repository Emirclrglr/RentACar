using Microsoft.EntityFrameworkCore;
using RentACar.Application.IRepositories.IBlogRepository;
using RentACar.Domain.Entities;
using RentACar.Persistence.Contexts;

namespace RentACar.Persistence.Repositories.BlogRepository
{
    public class BlogReadRepository : ReadRepository<Blog>, IBlogReadRepository
    {
        private readonly RentACarContext _context;
        public BlogReadRepository(RentACarContext context) : base(context)
        {
            _context = context;
        }

        public async Task<int> BlogCountAsync()
        {
            return await Table.CountAsync();
        }

        public Blog BlogDetailsWithAuthorDetails(int id)
        {
            return Table.Include(x => x.Author).AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Blog> BlogListByRecentDateTime(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = Table.AsNoTracking();
            return query.OrderByDescending(blog => blog.CreatedDate);
        }

        public IQueryable<Blog> GetLast3Blogs()
        {
            return Table.Take(3).OrderByDescending(x => x.Id).AsNoTracking();
        }
    }
}
