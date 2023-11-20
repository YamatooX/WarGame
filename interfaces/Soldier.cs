using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame.interfaces
{
    public abstract class Soldier
    {
        public int Strength { get; set; }
        public int HealthPoints { get; set; }
        public int Experience {  get; set; }
        public Rank Rank {  get; set; }
        public int Cost;

        public Soldier() 
        {
            Cost = (int)Rank * Strength;
        }
    }

    public enum Rank
    {
        Private,
        Corporal,
        Captain,
        Mayor
    }
}
