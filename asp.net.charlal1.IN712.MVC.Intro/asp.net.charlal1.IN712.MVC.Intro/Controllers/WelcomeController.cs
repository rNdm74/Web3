using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace asp.net.charlal1.IN712.MVC.Intro.Controllers
{
    public class WelcomeController : Controller
    {
        //
        // GET: /Welcome/

        public ActionResult Index() //must be the same
        {
            return View();
        }

    }
}
