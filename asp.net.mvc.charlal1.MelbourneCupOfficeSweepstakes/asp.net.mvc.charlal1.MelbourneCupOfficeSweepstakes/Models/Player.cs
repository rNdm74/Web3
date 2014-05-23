using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace asp.net.mvc.charlal1.MelbourneCupOfficeSweepstakes.Models
{
    public class Player
    {
        public int PlayerID                 { get; set; }
        [Required]
        [DisplayName("Player Name")]
        public string Name                  { get; set; }
        [Required]
        [DisplayName("Player E-Mail")]
        public string Email                 { get; set; }
        [Required]
        [DisplayName("Player Horses")]
        public int NoHorses                 { get; set; }
        public int Winnings                 { get; set; }
        public virtual List<Horse> Horses   { get; set; }
    }
}