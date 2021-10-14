using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestOpgave_1._4_Lib.Models
{
    public class BookModel
    {

        [Display(Name = "Title")]
        [Required(ErrorMessage = "Enter a title for the book")]
        public string title { get; set; }


        [Display(Name = "Authors Name")]
        [Required(ErrorMessage = "Enter the authors name")]
        public string author { get; set; }

        [Display(Name = "ISBN")]
        [Required(ErrorMessage = "Enter the isbn number")]
        public string isbnNo { get; set; }

        public bool isBorrowed { get; set; }



       



    }
}