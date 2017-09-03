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
            ViewBag.setDate = date;
            ViewBag.setTime = time;

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
            if (ModelState.IsValid)
            {
                PersonLogic plogic = new PersonLogic();
               
                int daysleft = plogic.CalculateDaysLeft(person);

                if (daysleft == 0)
                {
                    int currentAge= plogic.CurrentAge(person);

                    ViewBag.setCurrentBirthDayAge = currentAge;

                    return View("HappyBirthday", person);
                }
                else
                {
                    int AgeNextBirthday = plogic.AgeAtNextBirthday(person);

                    ViewBag.setAgeNextBirthday = AgeNextBirthday;
                    ViewBag.setDaysLeft = daysleft;

                    return View("BirthdayCheckResult", person);
                }
            }
            else
            {
                return View();
            }
        }
    }
}
