using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DataAccess;
using Entities;

namespace Business.Catalogs
{
    public class CatalogsServices : SqlRepository<Catalog>, ICatalogs
    {
        public CatalogsServices(string connectionString) : base(connectionString) { }
        public override Task DeleteAsync<T>(T model)
        {
            throw new NotImplementedException();
        }

        public override Task<Catalog> FindAsync<T>(T model)
        {
            throw new NotImplementedException();
        }

        public override async Task<IEnumerable<Catalog>> GetAllAsync<T>(T model)
        {
            using (var conn = GetOpenConnection())
            {
                return await conn.QueryAsync<Catalog>(sql: "RETAIL.PA_CON_CATALOG", model, commandType:CommandType.StoredProcedure).ConfigureAwait(false);
            }
        }

        public override Task InsertAsync(Catalog entity)
        {
            throw new NotImplementedException();
        }

        public override Task UpdateAsync(Catalog entityToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
