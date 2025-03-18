using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RentACar.Application.IRepositories.ICommentRepository;
using RentACar.Domain.Entities;
using RentACar.Persistence.Contexts;

namespace RentACar.Persistence.Repositories.CommentRepository
{
    public class CommentReadRepository : ReadRepository<Comment>, ICommentReadRepository
    {
        public CommentReadRepository(RentACarContext context) : base(context)
        {
        }

        public async Task<int> GetCommentCountByBlogId(int id)
        {
            return await Table.Where(x => x.BlogId == id).AsNoTracking().CountAsync();
        }

        public IQueryable<Comment> GetCommentsByBlogId(int id)
        {
            return Table.Where(x => x.BlogId == id).AsNoTracking();
        }
    }
}
