﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Application.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.IRepositories.IBrandRepository
{
    public interface IBrandReadRespoitory : IReadRepository<Brand>
    {
        Task<int> BrandCountAsync();
    }
}
