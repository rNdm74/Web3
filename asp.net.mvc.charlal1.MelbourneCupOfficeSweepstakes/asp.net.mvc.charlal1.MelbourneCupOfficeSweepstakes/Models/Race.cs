using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace asp.net.mvc.charlal1.MelbourneCupOfficeSweepstakes.Models
{
    public class Race
    {
        public int RaceID { get; set; }
        public int MoneyPool { get; set; }

        public Bet BetInfo { get; set; }

        public List<Player> players { get; set; } 
    }
}