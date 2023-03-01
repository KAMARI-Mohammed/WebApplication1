using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace WebApplication1.Models
{
    public class Student
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter First Name")]
        public string FistName { get; set; }

        [Required(ErrorMessage = "Please Enter Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please Enter Adresse")]
        public string Adresse { get; set; }

        [Required(ErrorMessage = "Please Enter Code Postal")]
        public string CodePostal { get; set; }

        [Required(ErrorMessage = "Please Enter Mobile No")]
        [Display(Name = "Phone")]
        [StringLength(10, ErrorMessage = "The Mobile must contains 10 characters", MinimumLength = 10)]
        public string Phone { get; set; }


        [Required(ErrorMessage = "Please Enter Email Address")]
        [Display(Name = "Email")]
        [RegularExpression(".+@.+\\..+", ErrorMessage = "Please Enter Correct Email Address")]
        public string Email { get; set; }


        public ICollection<Note> Notes { get; set; }

     

    }
}