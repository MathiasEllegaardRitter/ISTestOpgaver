using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestOpgave_1._4_Lib.Models
{
    public class BorrowModel
    {
        [Display(Name = "BookIsbn")]
        [Required(ErrorMessage = "Enter an existing Isbn")]
        public string bookIsbn { get; set; }

        [Display(Name = "Lib user id")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int libUserId { get; set; }
        [DataType(DataType.Date)]
        public DateTime dateStart { get; set; }
        [DataType(DataType.Date)]
        public DateTime dateEnd { get; set; }
        public bool hasReturned { get; set; }


    }
}