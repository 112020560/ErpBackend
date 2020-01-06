using Dapper;
using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Business.Articulos
{
    public class ArticulosVenta : SqlRepository<Articulo>, IArtuclos
    {
        public ArticulosVenta(string connectionString) : base(connectionString) { }

        public override Task DeleteAsync<T>(T model)
        {
            throw new NotImplementedException();
        }

        public async override Task<Articulo> FindAsync<T>(T model)
        {
            using (var conn = GetOpenConnection())
            {
                return await conn.QueryFirstOrDefaultAsync<Articulo>(sql: "usp_ArticulosFacturar_Listar", model, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
            }
        }

        public override Task<IEnumerable<Articulo>> GetAllAsync<T>(T model)
        {
            throw new NotImplementedException();
        }

        public override Task InsertAsync(Articulo entity)
        {
            throw new NotImplementedException();
        }

        public override Task UpdateAsync(Articulo entityToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
