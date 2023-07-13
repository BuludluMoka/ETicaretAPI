using OnionArchitecture.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Application.Abstractions.Repositories
{
    public interface IRepositoy<TEntity, Tkey> where TEntity : BaseEntity<Tkey>
    {
        DbSet<TEntity> Table { get; }
    }
}
