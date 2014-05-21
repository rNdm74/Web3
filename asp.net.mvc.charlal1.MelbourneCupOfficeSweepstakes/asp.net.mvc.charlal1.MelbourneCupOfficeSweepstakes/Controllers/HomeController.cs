using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using asp.net.mvc.charlal1.MelbourneCupOfficeSweepstakes.Models;

namespace asp.net.mvc.charlal1.MelbourneCupOfficeSweepstakes.Controllers
{
    public class HomeController : Controller
    {
        private MelbourneCupDbContext db = new MelbourneCupDbContext();

        //
        // GET: /Home/

        public ActionResult Index()
        {
            //SeedDatabase();
            return View();
        }

        //
        // POST: /Player/Create
        public ActionResult Result(Bet bet, Player player)
        {

            ViewBag.Bet = createBet(bet);

            return View(createBet(bet));
        }

        private Bet createBet(Bet bet) 
        {
            Bet newBet = new Bet { BetID = bet.BetID, Name = bet.Name, NoHorses = bet.NoHorses, BetAmount = bet.BetAmount };

            Random rGen = new Random();

            List<Horse> pickedHorses = new List<Horse>();

            List<Horse> horseList = db.Horses.ToList();

            for (int i = 0; i < newBet.NoHorses; i++)
            {
                int randomNumber = rGen.Next(horseList.Count);

                Horse pickedHorse = horseList[randomNumber];

                pickedHorses.Add(pickedHorse);
            }

            newBet.Horses = pickedHorses;

            return newBet;
        }

        private void SeedDatabase() 
        {
            var Horses = new List<Horse> 
            {
                new Horse{Form="13X66X10X1", Name="GLASS HARMONIUM",    FinishingPlace=4},
                new Horse{Form="12X3X12X91", Name="DUNADEN",            FinishingPlace=1},
                new Horse{Form="X446X13137", Name="DRUNKEN SAILOR",     FinishingPlace=12},
                new Horse{Form="2573X34844", Name="MANIGHAR",           FinishingPlace=5},
                new Horse{Form="3621X5X406", Name="UNUSUAL SUSPECT",    FinishingPlace=9},
                new Horse{Form="2164112461", Name="FOX HUNT",           FinishingPlace=7},
                new Horse{Form="111X4215X5", Name="LUCAS CRANACH",      FinishingPlace=3},
                new Horse{Form="X025X67009", Name="PRECEDENCE",         FinishingPlace=11},
                new Horse{Form="9X20141053", Name="RED CADEAUX",        FinishingPlace=2},
                new Horse{Form="189X223274", Name="LOST IN THE MOMENT", FinishingPlace=6},
                new Horse{Form="23245X0622", Name="AT FIRST SIGHT",     FinishingPlace=10},
                new Horse{Form="0121X07201", Name="NIWOT",              FinishingPlace=8},
            };

            foreach (Horse h in Horses)
            {
                db.Horses.Add(h);
            }

            db.SaveChanges();
        }
    }
}
