using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarGame.interfaces;

namespace WarGame.models
{
    public class Corporal : Soldier
    {
        public Corporal()
        {
            Strength = 2;
            HealthPoints = 8;
            Experience = 0;
            Rank = Rank.Corporal;
        }
    }
}
