using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BirthdayChecker.Models
{
    public class Person
    {
        [Required(ErrorMessage = "Please enter your name.")]
        //[RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter a valid name without numbers")]
        public String Name { get; set; }
        
        [Required(ErrorMessage = "Please enter your day of birth.")]
        [RegularExpression("^0[0-3]|1[0-9]?", ErrorMessage = "Please enter a valid day with the format DD(DD-MM-YYYY)")]
        public int BirthDay { get; set; }

        [Required(ErrorMessage = "Please enter your month of birth.")]
        [RegularExpression("^(0?[1-9]|1[012])$", ErrorMessage = "Please enter a valid month wth the format MM(DD-MM-YYYY)")]
        public int BirthMonth { get; set; }

        [RegularExpression("^[0-9]{4}$", ErrorMessage = "Please enter your year of birth with the format YYYY(DD-MM-YYYY)")]
        [Required(ErrorMessage = "Please enter your year of birth.")]
        public int BirthYear { get; set; }

    }
}
