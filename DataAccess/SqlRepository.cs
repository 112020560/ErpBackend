using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using static DataAccess.DbConnectionFactory;

namespace DataAccess
{
    public abstract class SqlRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class
    {
        private string _connectionString;
        private EDbConnectionType _dbType;

        public SqlRepository(string connectionString)
        {
            _dbType = EDbConnectionType.SQL;
            _connectionString = connectionString;
        }

        public IDbConnection GetOpenConnection()
        {
            return DbConnectionFactory.GetDbConnection(_dbType, _connectionString);
        }

        public abstract Task DeleteAsync<T>(T model);
        public abstract Task<TEntity> FindAsync<T>(T model);
        public abstract Task<IEnumerable<TEntity>> GetAllAsync<T>(T model);
        public abstract Task InsertAsync(TEntity entity);
        public abstract Task UpdateAsync(TEntity entityToUpdate);
    }
}
