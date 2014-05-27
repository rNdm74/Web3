using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace asp.net.mvc.charlal1.MelbourneCupOfficeSweepstakes.Models
{
    public class DbView
    {
        public List<Player> AllPlayers { get; set; }
        public List<Horse> AllHorses { get; set; }
        public Player SignUpPlayer { get; set; }
        public bool[] PlayerExists { get; set; }
        public Status SweepstakeStatus { get; set; }
        public List<Horse> WinningHorses { get; set; }
    }
}