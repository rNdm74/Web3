using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace asp.net.mvc.charlal1.MelbourneCupOfficeSweepstakes.Models
{
    public class DatabaseInit : DropCreateDatabaseAlways<MelbourneCupDbContext>
    {
        protected override void Seed(MelbourneCupDbContext context)
        {
            initHorsesDb(context);
            //initPlayersDb(context);
        }

        private void initHorsesDb(MelbourneCupDbContext context) 
        {
            List<Horse> horses = new List<Horse> 
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

            foreach (Horse h in horses)
            {
                context.Horses.Add(h);
            }

            context.SaveChanges();
        }

        private void initPlayersDb(MelbourneCupDbContext context)
        {
            Random rGen = new Random();

            List<Horse> horses = context.Horses.ToList();

            List<Player> players = new List<Player>
            {
                new Player
                {
                    PlayerID = 0, 
                    Name = "Joe Bloggs", 
                    Email = "joe.bloggs@gmail.com", 
                    NoHorses = 2, 
                    Horses = new List<Horse> 
                    {
                        horses[0],
                        horses[1]
                    }
                },
                new Player
                {
                    PlayerID = 1, 
                    Name = "Jane Doe", 
                    Email = "jane.doe@gmail.com", 
                    NoHorses = 1, 
                    Horses = new List<Horse> 
                    {
                        horses[2]
                    }
                }
            };

            foreach (Player p in players)
            {
                context.Players.Add(p);  
            }


            
            context.SaveChanges();
        }
    }
}