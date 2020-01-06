using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using DataAccess;
using Entities;

namespace Business.Articulos
{
    public class BusquedaAvanzada : SqlRepository<ArticuloBusquedaAvanzada>, IBusquedaAvanzada
    {
        public BusquedaAvanzada(string connectionString) : base(connectionString) { }
        public override Task DeleteAsync<T>(T model)
        {
            throw new System.NotImplementedException();
        }

        public override Task<ArticuloBusquedaAvanzada> FindAsync<T>(T model)
        {
            throw new System.NotImplementedException();
        }

        public override async Task<IEnumerable<ArticuloBusquedaAvanzada>> GetAllAsync<T>(T model)
        {
            using (var conn = GetOpenConnection())
            {
                return await conn.QueryAsync<ArticuloBusquedaAvanzada>(sql: "USP_ARTICULOS_BUSCAR", model, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
            }
        }

        public override Task InsertAsync(ArticuloBusquedaAvanzada entity)
        {
            throw new System.NotImplementedException();
        }

        public override Task UpdateAsync(ArticuloBusquedaAvanzada entityToUpdate)
        {
            throw new System.NotImplementedException();
        }
    }
}