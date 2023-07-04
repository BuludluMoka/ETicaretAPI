using OnionArchitecture.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Application.Repositories
{
    public interface IWriteRepository<TEntity,Tkey> : IRepositoy<TEntity,Tkey> where TEntity : BaseEntity<Tkey>
    {
        Task<bool> AddAsync(TEntity model);
        Task<bool> AddRangeAsync(List<TEntity> datas);
        bool Remove(TEntity model);
        bool RemoveRange(List<TEntity> datas);
        Task<bool> RemoveAsync(Tkey id);
        bool Update(TEntity model);
        Task<int> SaveAsync();

    }
}
