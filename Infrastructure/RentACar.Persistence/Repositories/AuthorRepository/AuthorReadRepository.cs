using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RentACar.Application.IRepositories.IAuthorRepository;
using RentACar.Domain.Entities;
using RentACar.Persistence.Contexts;

namespace RentACar.Persistence.Repositories.AuthorRepository
{
    public class AuthorReadRepository : ReadRepository<Author>, IAuthorReadRepository
    {
        public AuthorReadRepository(RentACarContext context) : base(context)
        {
        }

        public async Task<int> AuthorCountAsync()
        {
            return await Table.CountAsync();
        }
    }
}
