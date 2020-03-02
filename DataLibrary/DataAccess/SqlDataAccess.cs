using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Configuration;
using Oracle.ManagedDataAccess;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace DataLibrary.DataAccess
{
    public class SqlDataAccess
    {
        public static string GetConnectionString(string connectionName = "MVCDemoDB")
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }

        public static List<T> LoadData<T>(string sql)
        {
            using (IDbConnection connection = new OracleConnection(GetConnectionString()))
            {
                return connection.Query<T>(sql).ToList();
            }
        }

        public static int SaveData<T>(string sql, T data)
        {
            using (IDbConnection connection = new OracleConnection(GetConnectionString()))
            {
                return connection.Execute(sql, data);
            }
        }
    }
}
