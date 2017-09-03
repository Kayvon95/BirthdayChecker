using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayChecker.Models
{
  
    public class PersonLogic
    {
        public int CalculateDaysLeft(Person person)
        {
            int year = person.BirthYear;
            int month = person.BirthMonth;
            int day = person.BirthDay;

            DateTime Date = DateTime.Now.Date;
            DateTime Birthdate = new DateTime(year, month, day, 7, 47, 0);
            DateTime nextBirthday = Birthdate.AddYears(DateTime.Today.Year - Birthdate.Year);

            if (nextBirthday < DateTime.Today)
            {
                nextBirthday = nextBirthday.AddYears(1);
            }
            int daysLeft = (nextBirthday - DateTime.Today).Days;

            return daysLeft;
        }

        public int CurrentAge(Person person)
        {
            int year = person.BirthYear;
            int currentYear = DateTime.Now.Year;

            int CurrentAge = (currentYear - year);

            return CurrentAge;
        }

        public int AgeAtNextBirthday(Person person)
        {
            int year = person.BirthYear;
            int month = person.BirthMonth;
            int day = person.BirthDay;

            DateTime Date = DateTime.Now.Date;
            DateTime Birthdate = new DateTime(year, month, day, 7, 47, 0);
            DateTime nextBirthday = Birthdate.AddYears(DateTime.Today.Year - Birthdate.Year);

            int currentYear = DateTime.Now.Year;
            int AgeNextBirthday = (currentYear - year) + 1;

            return AgeNextBirthday;
        }

    }
}
