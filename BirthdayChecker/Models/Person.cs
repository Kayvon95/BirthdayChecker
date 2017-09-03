using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BirthdayChecker.Models
{
    public class Person
    {
        [MaxLength(32, ErrorMessage ="There is a limit of 32 characters for a name entry.")]
        [Required(ErrorMessage = "Please enter your name.")]
        public String Name { get; set; }
        
        [Required(ErrorMessage = "Please enter your day of birth.")]
        [Range(1, 31, ErrorMessage = "Enter a value from 1 to 31.")]
        public int BirthDay { get; set; }

        [Range(1, 12, ErrorMessage = "Please enter a a value from 1 to 12.")]
        [Display(Name = "1-12")]
        [Required(ErrorMessage = "Please enter your month of birth.")]
        public int BirthMonth { get; set; }

        [Range(1890, 2017, ErrorMessage="Please enter a year between 1890 and 2017.")]
        [Required(ErrorMessage = "Please enter your year of birth.")]
        public int BirthYear { get; set; }

    }
}
