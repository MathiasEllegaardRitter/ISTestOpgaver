using System;
using System.Data.SqlClient;

namespace TestOpgave_1._3_Database
{
    public class DB : BaseDB
    {


        // Create a message in the database, Model used SimpleMessage
        public bool CreateMessage(int number, string message, DateTime dateTime)
        {
            // If databases writes and succeds then it changes to true.
            bool result = false;
            try
            {
                ExecuteCommand((command) => {
                    // Setup Sql query.
                    command.CommandText = "insert into SimpleMessage(Number, SMessage, DateNTIme) values (@inputNumber, @inputMessage, @inputDateTime)";
                    command.Parameters.AddWithValue("@inputNumber", number);
                    command.Parameters.AddWithValue("@inputMessage", message);
                    command.Parameters.AddWithValue("@inputDateTime", dateTime);

                    // Execute sql query
                    int count = command.ExecuteNonQuery();

                    if (count > 0)
                    {
                        result = true; //Changes
                    }

                });  
            }
            catch (SqlException e) // Cstches any Sql error
            {
                Console.Write("Error " + e);
                result = false;
            }
            return result;
        }


        public SimpleMessage GetMessage()
        {
            // If databases reads set to true
            bool found = false;
            // Create object
            SimpleMessage sMessage = new SimpleMessage();
            try
            {
                ExecuteCommand((command) => {
                    // Setup Sql query.
                    command.CommandText = "select * from SimpleMessage where number = 45021";

                    // Execute sql query
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read() && found == false)
                    {
                        // Reads row and set value to object.
                        sMessage.message = reader.GetString(reader.GetOrdinal("SMessage"));
                        sMessage.number = reader.GetInt32(reader.GetOrdinal("Number"));
                        sMessage.date = reader.GetDateTime(reader.GetOrdinal("DateNTime"));

                        // Set to true want to find one object.
                        found = true;
                    }
                });
            }
            catch (SqlException e)
            {
                Console.Write("Error " + e);
            }

            return sMessage;

        }









    }
}
