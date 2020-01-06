using Dapper;
using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Business.Documents
{
    public class Document : SqlRepository<object>, IDocument
    {
        public Document(string connectionString) : base(connectionString) { }

        public override Task DeleteAsync<T>(T model)
        {
            throw new NotImplementedException();
        }

        public async override Task<object> FindAsync<T>(T model)
        {
            using (var conn = GetOpenConnection())
            {
                return await conn.QueryAsync<object>(sql: "usp_documento_guardar", model, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
            }
        }

        public override Task<IEnumerable<object>> GetAllAsync<T>(T model)
        {
            throw new NotImplementedException();
        }

        public override Task InsertAsync(object entity)
        {
            throw new NotImplementedException();
        }

        public override Task UpdateAsync(object entityToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
