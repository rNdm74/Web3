using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using asp.net.mvc.charlal1.IN712.DogSelector.Models;

namespace asp.net.mvc.charlal1.IN712.DogSelector.Controllers
{
    public class DogController : Controller
    {
        //
        // GET: /Dog/

        public ActionResult Index()
        {
            return View();
        }

        // Deal with the form
        // Two methods
        // Choose dog form returns form view
        // Post version is going to get data and do something with it

        //[HttpPost]
        public ActionResult ChooseDogForm(Dog dreamDog) 
        {
            Dog bestMatchDog = new Dog();

            // Figure out who is the best match from the fake database (list)
            // Assign it to best match dog

            // Prioritize features

            //if (!ModelState.IsValid)
            //{
                
            //}
            //else
            //{
            //    return View("ShowResultDog", bestMatchDog);
            //}

            return View();
        }

        private int CountMatches(Dog d1, Dog d2) 
        {
            int matches = 0;

            if (d1.BreedName.Equals(d2.BreedName))
                matches++;

            if (d1.CoatLength.Equals(d2.CoatLength))
                matches++;

            if (d1.Drools.Equals(d2.Drools))
                matches++;

            if (d1.GoodWithChildren.Equals(d2.GoodWithChildren))
                matches++;

            if (d1.GroomingLevel.Equals(d2.GroomingLevel))
                matches++;

            if (d1.IntelligenceLevel.Equals(d2.IntelligenceLevel))
                matches++;

            if (d1.SheedingLevel.Equals(d2.SheedingLevel))
                matches++;

            if (d1.Size.Equals(d2.Size))
                matches++;

            return matches;
        }
    }
}
