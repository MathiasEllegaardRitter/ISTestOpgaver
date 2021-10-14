using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestOpgave_1._4_DataAccess.Models
{
    public class BorrowModel
    {
        public string bookIsbn { get; set; }
        public int libUserId { get; set; }
        public DateTime dateStart { get; set; }
        public DateTime dateEnd { get; set; }
        public int hasReturned { get; set; }
        public DateTime deliveryDate { get; set; }
    }
}
