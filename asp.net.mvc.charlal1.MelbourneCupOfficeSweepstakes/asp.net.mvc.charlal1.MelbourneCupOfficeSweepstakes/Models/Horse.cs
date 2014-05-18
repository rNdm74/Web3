using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace asp.net.mvc.charlal1.MelbourneCupOfficeSweepstakes.Models
{
    public class Horse
    {
        public int HorseID          { get; set; }
        public string Form          { get; set; }
        public string Name          { get; set; }
        public int FinishingPlace   { get; set; }
        public Player player        { get; set; }
    }
}