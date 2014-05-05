using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using asp.net.mvc.charlal1.IN712.MVC.Intro.Models;

namespace asp.net.mvc.charlal1.IN712.MVC.Intro.Controllers
{
    public class DogShowController : Controller
    {
        //
        // GET: /DowShow/

        public ActionResult Index()
        {
            Dog DemoDog = new Dog();
            DemoDog.Name = "Baldr";
            DemoDog.Breed = "Seta";
            DemoDog.Owner = "Adam";
            DemoDog.Age = 60;

            return View(DemoDog);
        }

        public ActionResult ChooseDog(string dogSize) 
        {
            Dog smallDog = new Dog { Name="Test1", Breed="Test1" };
            Dog largeDog = new Dog { Name="Baldr", Breed="Seta" };

            if(dogSize == "small")
            {
                return View(smallDog);
            }
            else if(dogSize == "large")
            {
                return View(largeDog);
            }
            else
            {
                return View("ErrorView");
            }
        }

    }
}
