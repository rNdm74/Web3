using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace asp.net.mvc.charlal1.MelbourneCupOfficeSweepstakes.Models
{
    public class Player
    {
        public int PlayerID                 { get; set; }
        public string Name                  { get; set; }
        public string Email                 { get; set; }
        public virtual List<Horse> Horses   { get; set; }
    }
}