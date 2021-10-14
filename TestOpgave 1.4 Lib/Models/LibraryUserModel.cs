using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestOpgave_1._4_Lib.Models
{
    public class LibraryUserModel
    {
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Enter a name for the user")]
        public string name { get; set; }
        public int libraryUserNo { get; set; }


    }
}