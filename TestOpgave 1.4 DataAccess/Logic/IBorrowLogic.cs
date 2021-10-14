using System;
using System.Collections.Generic;
using TestOpgave_1._4_DataAccess.Models;

namespace TestOpgave_1._4_DataAccess.Logic
{
    public interface IBorrowLogic
    {
        int CreateBorrow(string bookIsbn, int libUserId, DateTime dateStart, DateTime dateEnd, int hasReturned);
        List<BorrowModel> LoadUnReturnedBorrowContracts();

        void RegisterDelivery(string bookIsbn, int libUserId, DateTime deliveryDate);

    }
}