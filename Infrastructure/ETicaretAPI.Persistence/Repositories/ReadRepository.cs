﻿using Microsoft.EntityFrameworkCore;
using OnionArchitecture.Application.Abstractions.Repositories;
using OnionArchitecture.Domain.Common;
using System.Linq.Expressions;

namespace OnionArchitecture.Persistence.Repositories
{
    public class ReadRepository<TEntity, Tkey, TContext> : IReadRepository<TEntity, Tkey> where TEntity : BaseEntity<Tkey> where TContext : DbContext
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
            if (typeof(Tkey) == typeof(Guid))
            {
                return await query.FirstOrDefaultAsync(e => ((Guid)(object)e.Id).Equals(id));
            }
            else
            {
                return await query.FirstOrDefaultAsync(x => x.Id.Equals(id));
            }
        }

    }
}
