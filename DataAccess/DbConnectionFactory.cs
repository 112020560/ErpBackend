﻿using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class DbConnectionFactory
    {
        public static IDbConnection GetDbConnection(EDbConnectionTypes dbType, string connectionString)
        {
            IDbConnection connection = null;

            switch (dbType)
            {
                case EDbConnectionTypes.SQL:
                    connection = new SqlConnection(connectionString);
                    break;
                case EDbConnectionTypes.XML:
                    // TODO: Implement XML Connection (path name)
                    break;
                case EDbConnectionTypes.DOCUMENT:
                    // TODO: Implement Document DB connection
                    break;
                default:
                    connection = null;
                    break;
            }

            connection.Open();
            return connection;
        }

        public enum EDbConnectionTypes
        {
            SQL,
            DOCUMENT,
            XML
        }
    }
}
