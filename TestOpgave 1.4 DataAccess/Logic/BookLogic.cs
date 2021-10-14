using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestOpgave_1._4_DataAccess.Access;
using TestOpgave_1._4_DataAccess.Models;

namespace TestOpgave_1._4_DataAccess.Logic
{
    public static class BookLogic
    {

        public static void CreateBook(string title, string author, string isbn)
        {
            string sql = "insert into [TestOpgave14].[dbo].[Book] (title, author, isbnNo, isBorrowed) values (@title, @author, @isbnNo, 0)";


            BookModel bookModel = new BookModel {
                title = title,
                author = author,
                isbnNo = isbn
            };

            DataAccess.SaveData(sql, bookModel);
        }

        public static List<BookModel> LoadBooks()
        {
            string sql = "select title, author, isbnNo, isBorrowed from [TestOpgave14].[dbo].[Book]";

            return DataAccess.LoadData<BookModel>(sql);


        }





    }
}
