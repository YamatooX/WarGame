using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarGame.interfaces;

namespace WarGame.models
{
    public class Private : Soldier
    {
        public Private()
        {
            Strength = 1;
            HealthPoints = 5;
            Experience = 0;
            Rank = Rank.Private;
        }
    }
}
