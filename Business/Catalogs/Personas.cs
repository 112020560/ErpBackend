using Dapper;
using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Business.Catalogs
{
    public class Personas : SqlRepository<Persona>, IPersonas
    {
        public Personas(string connectionString) : base(connectionString) { }

        public override Task DeleteAsync<T>(T model)
        {
            throw new NotImplementedException();
        }

        public async override Task<Persona> FindAsync<T>(T model)
        {
            using (var conn = GetOpenConnection())
            {
                return await conn.QueryFirstOrDefaultAsync<Persona>(sql: "CRM.PA_CON_PERSONA_INFORMACION", model, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
            }
        }

        public async override Task<IEnumerable<Persona>> GetAllAsync<T>(T model)
        {
            using (var conn = GetOpenConnection())
            {
                return await conn.QueryAsync<Persona>(sql: "CRM.PA_CON_PERSONA_INFORMACION", model, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
            }
        }

        public override Task InsertAsync(Persona entity)
        {
            throw new NotImplementedException();
        }

        public override Task UpdateAsync(Persona entityToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
