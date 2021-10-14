using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestOpgave_1._4_DataAccess.Models;
using TestOpgave_1._4_DataAccess.Access;
using Moq;

namespace TestOpgave_1._4_DataAccess.Logic
{
    public static class BorrowLogic
    {

        public static int CreateBorrow(string bookIsbn, int libUserId, DateTime dateStart, DateTime dateEnd, int hasReturned)
        {

            string sqlUpdateBook = "update[TestOpgave14].[dbo].[Book] set isBorrowed = 1 where isbnNo = @bookIsbn";

            string sqlCreateBorrow = @"If Exists (Select * from [TestOpgave14].[dbo].[Book] as Book, [TestOpgave14].[dbo].[LibUser] as LibUser where Book.isbnNo = @bookIsbn and LibUser.libraryUserNo = @libUserId)
                                    begin
                                    insert into [TestOpgave14].[dbo].[Borrow] (bookIsbn, libUserId, dateStart, dateEnd, hasReturned) values(@bookIsbn, @libUserId, @dateStart, @dateEnd, @hasReturned)
                                    end
                                    else
                                    begin
                                    print ('The book or the user does not exist')
                                    end";


            BorrowModel borrowModel = new BorrowModel
            {
                bookIsbn = bookIsbn,
                libUserId = libUserId,
                dateStart = dateStart,
                dateEnd = dateEnd,
                hasReturned = hasReturned
            };

            DataAccess.SaveData(sqlUpdateBook, borrowModel);
            return DataAccess.SaveBorrowData(sqlCreateBorrow, borrowModel);
        }

        public static List<BorrowModel> LoadUnReturnedBorrowContracts()
        {
            string sql = "select bookIsbn, libUserId, dateStart, dateEnd, hasReturned from [TestOpgave14].[dbo].[Borrow] where hasReturned = 0";

            return DataAccess.LoadData<BorrowModel>(sql);
        }


        public static void RegisterDelivery(string bookIsbn, int libUserId, DateTime deliveryDate)
        {
            string sql = "update [TestOpgave14].[dbo].[Borrow] set deliveryDate = @deliveryDate, hasReturned = 1 where bookIsbn = @bookIsbn and libUserId = @libUserId; UPDATE [TestOpgave14].[dbo].[Book] set isBorrowed = 0 where isbnNo = @bookIsbn";
            string sqlUpdateBook = "update [TestOpgave14].[dbo].[Book] set isBorrowed = 1 where isbnNo = @bookIsbn";


            BorrowModel borrowModel = new BorrowModel
            {
                bookIsbn = bookIsbn,
                libUserId = libUserId,
                deliveryDate = deliveryDate
            };

            DataAccess.SaveData(sqlUpdateBook, borrowModel);
            DataAccess.SaveData(sql, borrowModel);
        }





    }
}
