using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace asp.net.mvc.charlal1.MelbourneCupOfficeSweepstakes.Models
{
    public class Bet
    {
        public int BetID        { get; set; }
        public string Name      { get; set; }
        public int BetAmount    { get; set; }
        public int NoHorses     { get; set; }
        public virtual List<Horse> Horses { get; set; }
    }
}