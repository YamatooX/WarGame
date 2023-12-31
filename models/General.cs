﻿using System.Text;
using WarGame.interfaces;

namespace WarGame.models
{
    public class General : IGeneral
    {
        public string Name { get; set; }
        public IList<Soldier> Army { get; set; }
        public int Gold;
        public int FullHealth;

        public General(string name) 
        {
            Name = name;
            Army = new List<Soldier>();
            Gold = 50;
            FullHealth = GetFullHealth();
        }

        public int Attack()
        {
            if (!Army.Any())
            {
                return 0;
            }

            int damageOutput = FullPower();
            Logger.Log($"General {Name} dealt {damageOutput} damage");

            return damageOutput;
        }

        public void BuySoldier()
        {
            Console.WriteLine("Pick a soldier to buy, General: ");
            PrintBuyingOptions();
            string option = Console.ReadLine();

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

        public void TakeDamage(General general, int amount)
        {
            FullHealth -= amount;
            KillSoldiers(general.Army, FullPower());
        }

        public int GetFullHealth()
        {
            int hp = 0;
            foreach (Soldier soldier in Army)
            {
                hp += soldier.HealthPoints;
            }

            return hp;
        }

        public void Maneuveres()
        {
            PromoteSoldiers();
            Logger.Log($"General {Name} has started maneuvers. All soldiers has their Exp risen");
        }
        public int FullPower()
        {
            if (!Army.Any())
                return 0;

            int power = 0;
            foreach (Soldier soldier in Army)
            {
                power += soldier.Strength;
            }
            return power;
        }

        private void KillSoldiers(IList<Soldier> opponentsArmy, int damageTaken)
        {
            if (!opponentsArmy.Any())
                return;

            int damageToDeal = damageTaken;
            for (int i = opponentsArmy.Count; i <= 0; i--)
            {
                if (damageToDeal >= opponentsArmy[i].HealthPoints)
                {
                    opponentsArmy.RemoveAt(i);
                    damageToDeal -= opponentsArmy[i].HealthPoints;
                }
                else
                {
                    opponentsArmy[i].HealthPoints =- damageToDeal;
                    break;
                }
            }
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
            Gold -= soldier.Cost;
        }

        private bool IsSoldierAffordable(Soldier soldier)
        {
            if (soldier.Cost > Gold)
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
