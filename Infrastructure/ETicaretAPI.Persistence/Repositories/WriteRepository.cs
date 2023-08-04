using OnionArchitecture.Domain.Common;
using OnionArchitecture.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using OnionArchitecture.Application.Abstractions.Repositories;
using Core.Application.Utilities.Results;
using System.Reflection.Metadata.Ecma335;

namespace OnionArchitecture.Persistence.Repositories
{
    public class WriteRepository<TEntity, Tkey, TContext> : IWriteRepository<TEntity, Tkey> where TEntity : BaseEntity<Tkey> where TContext : DbContext
    {

        private readonly TContext _context;
        public WriteRepository(TContext context)
        {
            _context = context;
        }
        public DbSet<TEntity> Table => _context.Set<TEntity>();

        public async Task<bool> AddAsync(TEntity model)
        {
            EntityEntry<TEntity> entityEntry = await Table.AddAsync(model);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<TEntity> datas)
        {
            await Table.AddRangeAsync(datas);
            return true;
        }

        public bool Remove(TEntity model)
        {
            EntityEntry<TEntity> entityEntry = Table.Remove(model);
            return entityEntry.State == EntityState.Deleted;
        }
        public bool RemoveRange(List<TEntity> datas)
        {
            Table.RemoveRange(datas);
            return true;
        }
        public async Task<bool> RemoveAsync(Tkey id)
        {
            TEntity entity = await GetEntityByIdAsync(id);
            if (entity != null)
                return Remove(entity);

            return false; // Entity with given id not found
        }
        public bool Update(TEntity model)
        {
            EntityEntry entityEntry = Table.Update(model);
            return entityEntry.State == EntityState.Modified;
        }

        private async Task<TEntity> GetEntityByIdAsync(Tkey id)
        {
            if (typeof(Tkey) == typeof(Guid))
                return await Table.FirstOrDefaultAsync(e => ((Guid)(object)e.Id).Equals(id));

            return await Table.FindAsync(id);
        }
        public async Task<ResultInfo> SaveAsync()
        {
            var result = new OperationResult();
            return (short)await _context.SaveChangesAsync() > 0 ? 
                ResultInfo.SaveSuccess :
                ResultInfo.SaveFailure;
        }


    }
}
