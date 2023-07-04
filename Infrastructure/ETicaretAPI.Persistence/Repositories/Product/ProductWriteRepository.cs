﻿using OnionArchitecture.Application.Repositories;
using OnionArchitecture.Domain.Entities;
using OnionArchitecture.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Persistence.Repositories
{
    public class ProductWriteRepository : WriteRepository<Product, int ,ETicaretAPIDbContext>, IProductWriteRepository
    {
        public ProductWriteRepository(ETicaretAPIDbContext context) : base(context)
        {
        }
    }
}
