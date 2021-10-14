using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestOpgave_1._4_DataAccess.Models
{
    public class BookModel
    {
        public int bookId { get; set; }
        public string title { get; set; }

        public string author { get; set; }

        public string isbnNo { get; set; }

        public int isBorrowed { get; set; }

    }
}
