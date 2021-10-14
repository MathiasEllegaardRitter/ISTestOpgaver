using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace TestOpgave_1._4_DataAccess.Access
{
    public  static class DataAccess
    {
        public static string GetConnectionString(string dbName = "TestOpgave14")
        {
            return ConfigurationManager.ConnectionStrings[dbName].ConnectionString;
        }

        // Get List of Data returns object.
        public static List<T> LoadData<T>(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Query<T>(sql).ToList();
            }
        }
        // Writes object data to database
        public static void SaveData<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
             cnn.Execute(sql, data);
            }
        }

        // Executes an sql query.
        public static void ExecuteSql(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
               cnn.Execute(sql);
            }
        }

        // Writes object data to database but returns result.
        public static int SaveBorrowData<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Execute(sql, data);
                
            }
        }



    }
}
