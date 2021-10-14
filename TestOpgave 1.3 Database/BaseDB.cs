using System;
using System.Configuration;
using System.Data.SqlClient;

namespace TestOpgave_1._3_Database
{
    public class BaseDB
    {
             // Get connection string in App.config
            private string _conStr = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

            public void ExecuteCommand(Action<SqlCommand> action)
            {
                // Use the connection string and dispose of it.
                using (SqlConnection con = new SqlConnection(_conStr))
                // Use sql command
                using (SqlCommand command = con.CreateCommand())
                {
                    con.Open();
                    action(command);
                }
            }
        }
    }
