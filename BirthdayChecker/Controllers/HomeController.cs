using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BirthdayChecker.Models;

namespace BirthdayChecker.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;
            int hour = DateTime.Now.Hour;
            int minute = DateTime.Now.Minute;

            String date = day.ToString("D2") + "-" + month.ToString("D2") + "-" + year.ToString();
            String time = hour + ":" + minute.ToString("D2");
            ViewBag.StateDate = date;
            ViewBag.StateTime = time;

            return View("Home");
        }
        
        [HttpGet]
        public ViewResult BirthdateForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult BirthdateForm(Person person)
        {
            //Submitted info via model object
            int year = person.BirthYear;
            int month = person.BirthMonth;
            int day = person.BirthDay;


            DateTime Date = DateTime.Now.Date;
            DateTime Birthdate = new DateTime(year, month, day, 7, 47, 0);
            var nextBirthday = Birthdate.AddYears(DateTime.Today.Year - Birthdate.Year);

            if (nextBirthday < DateTime.Today)
            {
                nextBirthday = nextBirthday.AddYears(1);
            }
            var daysleft = (nextBirthday - DateTime.Today).Days;

            ViewBag.setDaysLeft = daysleft;


            int currentYear = DateTime.Now.Year;
            int AgeNextBirthday = (currentYear - year) + 1;
            ViewBag.setAgeNextBirthday = AgeNextBirthday;

            String CurrentBirthDayAge = (currentYear - year).ToString();
            ViewBag.setCurrentBirthdayAge = CurrentBirthDayAge;
            

            //var dateTilBDay = person.BirthDay - currentdate;

            if (ModelState.IsValid && daysleft > 0 )
            {
                PersonHolder.AddPerson(person);
                return View("BirthdayCheckResult", person);

            } else  if(ModelState.IsValid)
            {
                return View("HappyBirthday", person);
            }
            else {
                return View();
            }
        }
    }
}
