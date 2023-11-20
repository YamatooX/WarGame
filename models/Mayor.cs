using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarGame.interfaces;

namespace WarGame.models
{
    public class Mayor : Soldier
    {
        public Mayor()
        {
            Strength = 5;
            HealthPoints = 12;
            Experience = 0;
            Rank = Rank.Mayor;
        }
    }
}
