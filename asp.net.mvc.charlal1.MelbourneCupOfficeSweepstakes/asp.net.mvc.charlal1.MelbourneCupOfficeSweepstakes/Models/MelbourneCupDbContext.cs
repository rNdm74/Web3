using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace asp.net.mvc.charlal1.MelbourneCupOfficeSweepstakes.Models
{
    public class MelbourneCupDbContext : DbContext
    {
        public DbSet<Player> Players    { get; set; }
        public DbSet<Horse> Horses      { get; set; }

        public DbSet<Bet> Bets { get; set; }
    }
}