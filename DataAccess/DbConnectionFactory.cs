using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public static class DbConnectionFactory
    {
        public static IDbConnection GetDbConnection(EDbConnectionType dbType, string connectionString)
        {
            IDbConnection connection = null;

            switch (dbType)
            {
                case EDbConnectionType.SQL:
                    connection = new SqlConnection(connectionString);
                    break;
                case EDbConnectionType.XML:
                    // TODO: Implement XML Connection (path name)
                    break;
                case EDbConnectionType.DOCUMENT:
                    // TODO: Implement Document DB connection
                    break;
                default:
                    connection = null;
                    break;
            }

            connection.Open();
            return connection;
        }

        public enum EDbConnectionType
        {
            SQL,
            DOCUMENT,
            XML
        }
    }
}
