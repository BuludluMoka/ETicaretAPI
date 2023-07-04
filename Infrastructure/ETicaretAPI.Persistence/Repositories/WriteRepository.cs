using OnionArchitecture.Application.Repositories;
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

namespace OnionArchitecture.Persistence.Repositories
{
    public class WriteRepository<TEntity,Tkey ,TContext> : IWriteRepository<TEntity, Tkey> where TEntity : BaseEntity<Tkey>  where TContext : DbContext
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
            TEntity model;
            if (id is Guid)
                model = await Table.FirstOrDefaultAsync(data => ((Guid)(object)data.Id).Equals(id));
            else
                model = await Table.FirstOrDefaultAsync(data => data.Id.Equals(id));
           
            return Remove(model);
        }
        public bool Update(TEntity model)
        {
            EntityEntry entityEntry = Table.Update(model);
            return entityEntry.State == EntityState.Modified;
        }
        public async Task<int> SaveAsync()
        => await _context.SaveChangesAsync();

       
    }
}
