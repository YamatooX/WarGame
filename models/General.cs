using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarGame.interfaces;

namespace WarGame.models
{
    public class General : IGeneral
    {
        public string Name { get; set; }
        public IEnumerable<Soldier> Army;
        public int gold;

        public General(string name) 
        {
            Name = name;
            Army = new List<Soldier>();
            gold = 50;
        }

        public int Attack()
        {
            int damageOutput = FullPower();
            return damageOutput;
        }

        // Think about and attack functionality with choosing which Soldiers attack

        public void BuySoldier()
        {
            Console.Write("Pick a soldier to buy, General: ");
            // Buying mechanics
        }

        public void PromoteSoldiers()
        {
            foreach(Soldier soldier in Army)
            {
                soldier.Experience++;
            }
        }

        private int FullPower()
        {
            int power = 0;
            foreach(Soldier soldier in Army)
            {
                power += soldier.Strength;
            }
            return power;
        }
    }
}
