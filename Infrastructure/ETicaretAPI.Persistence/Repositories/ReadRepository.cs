using OnionArchitecture.Application.Repositories;
using OnionArchitecture.Domain.Common;
using OnionArchitecture.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Persistence.Repositories
{
    public class ReadRepository<TEntity, Tkey,TContext> : IReadRepository<TEntity, Tkey> where TEntity : BaseEntity<Tkey> where TContext : DbContext
    {
        private readonly TContext _context;
        public ReadRepository(TContext context)
        {
            _context = context;
        }
        public DbSet<TEntity> Table => _context.Set<TEntity>();
        public IQueryable<TEntity> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }
        public IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> method, bool tracking = true)
        {
            var query = Table.Where(method);
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }
        public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = Table.AsNoTracking();
           return await query.FirstOrDefaultAsync(method);
        }
        public async Task<TEntity> GetByIdAsync(Tkey id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = Table.AsNoTracking();

            if (id is Guid)
                return await query.FirstOrDefaultAsync(data => ((Guid)(object)data.Id).Equals(id));
            else
                return  await query.FirstOrDefaultAsync(data => data.Id.Equals(id));
        }

    }
}
