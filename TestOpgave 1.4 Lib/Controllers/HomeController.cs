using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestOpgave_1._4_Lib.Models;
using TestOpgave_1._4_DataAccess.Logic;

namespace TestOpgave_1._4_Lib.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }





        public ActionResult RegisterBook()
        {
            return View();
        }


        public ActionResult ViewBooks()
        {
            // Get Books.
            var data = BookLogic.LoadBooks();
            // Create List of Book Model.
            List<BookModel> books = new List<BookModel>();

            // For each object in the returned list convert to a new BookModel
            foreach (var row in data)
            {
                books.Add(new BookModel
                {
                    title = row.title,
                    author = row.author,
                    isbnNo = row.isbnNo,
                    isBorrowed = returnBoolResult(row.isBorrowed)
                });
            }
            return View(books);

        }


        [HttpPost]
        public ActionResult RegisterBook(BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                // create book.
                BookLogic.CreateBook(bookModel.title, bookModel.author, bookModel.isbnNo);
                RedirectToAction("Index");
            }
            return View();
        }



        public ActionResult RegisterLibraryUser()
        {

            return View();
        }


        [HttpPost]
        public ActionResult RegisterLibraryUser(LibraryUserModel libraryUserModel)
        {
            if (ModelState.IsValid)
            {
                // create user
                LibUserLogic.CreateLibUser(libraryUserModel.name);
            }

            return View();
        }

        public ActionResult ViewLibUsers()
        {
            // Get users.
            var data = LibUserLogic.LoadLibUsers();
            // Create List of LibraryUser Mode
            List<LibraryUserModel> libraryUsers = new List<LibraryUserModel>();

            // For each object in the returned list convert to a new LibraryUSerModel
            foreach (var row in data)
            {
                libraryUsers.Add(new LibraryUserModel
                {
                    name = row.name,
                    libraryUserNo = row.libraryUserNo
                });
            }

            return View(libraryUsers);

        }



        public ActionResult BorrowBook(BorrowModel borrowModel)
        {
            // Get the current date
            borrowModel.dateStart = DateTime.Today;

            if (ModelState.IsValid)
            {
                // Create loan, but if method returns 1 it displays success text.
                if (BorrowLogic.CreateBorrow(borrowModel.bookIsbn, borrowModel.libUserId, borrowModel.dateStart, borrowModel.dateEnd, 0) == 1)
                {
                    
                    TempData["Message"] = "sucess";
                    
                }
                else
                {
                    // else error text.
                    TempData["Message"] = "Could not find book isbn or user with id";
                }
            }

            return View();

        }

        public ActionResult ViewBorrows()
        {
            // Get not returned loans of books.
            var data = BorrowLogic.LoadUnReturnedBorrowContracts();
            // Create List of Borrow Model
            List<BorrowModel> borrows = new List<BorrowModel>();

            // For each object in the returned list convert to a new borrowmodel
            foreach (var row in data)
            {
                borrows.Add(new BorrowModel
                {
                    bookIsbn = row.bookIsbn,
                    libUserId = row.libUserId,
                    dateStart = row.dateStart,
                    dateEnd = row.dateEnd,
                    hasReturned = returnBoolResult(row.hasReturned)

                    
                }); ;
            }
            // Display unreturned loans.
            return View(borrows);
        }


        public ActionResult DeliverBook(string bookIsbn, int libUserId)
        {
            // Get the current date
            var deliveryDate = DateTime.Today;
            // Pass bookIsbn, libUSerId to know which user that delivered and book.
            BorrowLogic.RegisterDelivery(bookIsbn, libUserId, deliveryDate);
            // Display
            return RedirectToAction("ViewBorrows", "Home");
        }

        // Set Bool from a number
        public bool returnBoolResult(int i)
        {
            if (i == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }




    }
}