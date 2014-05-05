using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace asp.net.mvc.charlal1.IN712.MVC.Intro.Controllers
{
    public class WelcomeController : Controller
    {
        //
        // GET: /Welcome/

        public ActionResult Index()
        {
            

            return View();
        }

        public ActionResult ViewBagDemo() 
        {
            ViewBag.Message = "This is the Controller's message.";
            ViewBag.CurrentTime = DateTime.Now;

            return View();
        }
    }
}
