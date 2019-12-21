using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IGenericRepository<TEntity>
    {
        IDbConnection GetOpenConnection();
        Task<IEnumerable<TEntity>> GetAllAsync<T>(T model);
        Task<TEntity> FindAsync<T>(T model);
        Task InsertAsync(TEntity entity);
        Task DeleteAsync<T>(T model);
        Task UpdateAsync(TEntity entityToUpdate);
    }
}
