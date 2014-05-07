using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using asp.net.nvc.charlal1.Introduction_Practical1.Models;

namespace asp.net.nvc.charlal1.Introduction_Practical1.Controllers
{
    public class HolidayController : Controller
    {
        //
        // GET: /StrongTypedView/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddHoliday()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewHolidayForm(Holiday newHoliday) 
        {
            DateTime currentDate = DateTime.Now;
            int daysUntil = (newHoliday.Date - currentDate).Days;
            newHoliday.Days = daysUntil;

            return View("NewHolidayConfirm", newHoliday);
        }

        public ActionResult FavoriteHoliday()
        {
            DateTime currentDate = DateTime.Now;
            DateTime holidayDate = new DateTime(currentDate.Year, 12, 25);

            Holiday favoriteHoliday = new Holiday();
            favoriteHoliday.Name = "Christmas";
            favoriteHoliday.Date = holidayDate;
            favoriteHoliday.Days = (holidayDate-currentDate).Days;
            
            return View(favoriteHoliday);
        }
    }
}
