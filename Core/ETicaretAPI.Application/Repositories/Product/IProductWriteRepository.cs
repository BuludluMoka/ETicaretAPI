﻿using OnionArchitecture.Application.Abstractions.Repositories;
using OnionArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Application.Repositories
{
    public interface IProductWriteRepository : IWriteRepository<Product, int>
    {
    }
}
