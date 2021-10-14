using System;
using System.Collections.Generic;
using System.Text;

namespace TestOpgave_1._3_Database
{
    class Program
    {
        public static void Main(String[] args)
        {
            DB db = new DB();

            // Writes to database, the id, string, that was required in test 1.3.
            db.CreateMessage(45021, "Hello Database!", new DateTime(2013, 12, 31, 23, 59, 0));

            // Get message
            var simpleMessage = db.GetMessage();

            // Console write.
            Console.Write("Number : " + simpleMessage.number + Environment.NewLine);
            Console.Write("Date : " + simpleMessage.date + Environment.NewLine);
            Console.Write("Message : " + simpleMessage.message);


            Console.ReadLine();

        }


    }
}
