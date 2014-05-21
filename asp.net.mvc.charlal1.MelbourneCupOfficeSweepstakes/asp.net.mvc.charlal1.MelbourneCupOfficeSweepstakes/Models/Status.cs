using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace asp.net.mvc.charlal1.MelbourneCupOfficeSweepstakes.Models
{
    public class Status
    {
        public int StatusID                         { get; set; }
        public virtual List<Player> BettingPlayers  { get; set; }
        public virtual List<Horse> AvailableHorses  { get; set; }

    }
}