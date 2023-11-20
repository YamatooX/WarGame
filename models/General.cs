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
        public IList<Soldier> Army { get; set; }
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

        public void BuySoldier()
        {
            Console.Write("Pick a soldier to buy, General: ");
            string option = Console.ReadLine();
            PrintBuyingOptions();

            switch (option)
            {
                case "1":
                    BuySoldier(new Private());
                    break;
                case "2":
                    BuySoldier(new Corporal());
                    break;
                case "3":
                    BuySoldier(new Captain());
                    break;
                case "4":
                    BuySoldier(new Mayor());
                    break;
                default:
                    Logger.Log("Chosen wrong option");
                    break;
            }
        }        

        public void Maneuveres()
        {
            PromoteSoldiers();
        }

        private void PromoteSoldiers()
        {
            for (int i = 0; i < Army.Count; i++)
            {
                Army[i].Experience++;
                if (CheckPromotions(Army[i]))
                {
                    PromoteSoldier(Army[i]);
                    Army.RemoveAt(i);
                }
            }
        }

        private Soldier? PromoteSoldier(Soldier soldier)
        {
            Rank rank = soldier.Rank;
            switch (rank)
            {
                case Rank.Private:
                    return new Corporal();
                case Rank.Corporal:
                    return new Captain();
                case Rank.Captain:
                    return new Mayor();
            }
            return null;
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

        private bool CheckPromotions(Soldier soldier)
        {
            if (soldier.Experience < 5 && soldier.Rank != Rank.Mayor )
                return false;
            return true;
        }

        private void AddSoldier(Soldier soldier)
        {
            Logger.Log($"{soldier.Rank} bought");
            Army.Add(soldier);
        }

        private void BuySoldier(Soldier soldier)
        {
            if(!IsSoldierAffordable(soldier)) 
            {
                Logger.Log($"Cannot buy {soldier.Rank}");
            }
            AddSoldier(soldier);             
        }

        private bool IsSoldierAffordable(Soldier soldier)
        {
            if (soldier.Cost > gold)
            {
                Logger.Log($"Cannot buy {soldier.Rank}");
                return false;
            }
            return true;
        }

        private void PrintBuyingOptions()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(" [1] Buy Private");
            sb.AppendLine(" [2] Buy Corporal");
            sb.AppendLine(" [3] Buy Captain");
            sb.AppendLine(" [4] Buy Mayor");
            sb.AppendLine(" Press any key to get back");

            Console.WriteLine(sb.ToString());
        }
    }
}
