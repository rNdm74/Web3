using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace asp.net.nvc.charlal1.Introduction_Practical1.Controllers
{
    public class ChristmasController : Controller
    {
        //
        // GET: /ViewBag/

        public ActionResult Index()
        {
            DateTime currentDate = DateTime.Now;
            DateTime holidayDate = new DateTime(currentDate.Year, 12, 25);
            ViewBag.DaysToChristmas = (holidayDate - currentDate).Days + " Days to Christmas";
            return View();
        }

    }
}
