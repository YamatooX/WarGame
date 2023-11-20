using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarGame.interfaces;

namespace WarGame.models
{
    public class Captain : Soldier
    {
        public Captain()
        {
            Strength = 3;
            HealthPoints = 10;
            Experience = 0;
            Rank = Rank.Captain;
        }
    }
}
