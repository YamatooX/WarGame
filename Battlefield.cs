using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarGame.interfaces;
using WarGame.models;

namespace WarGame
{
    public class Battlefield
    {
        public Battlefield() 
        {
            CreateBattlefield();
        }

        public void CreateBattlefield() 
        {
            // For test purposes names are hardcoded

            string gen1Name = "Jarek";
            string gen2Name = "Remik";

            General gen1 = new General(gen1Name);
            General gen2 = new General(gen2Name);

            StartBattle(gen1, gen2);
        }

        private void StartBattle(General general1, General general2)
        {
            // machanics for battle
            // 1 action for general per turn
            // terms of battle end
            int roundCounter = 0;

            do
            {
                // General 1 turn
                

                //General 2 turn

            } while (true);
        }

        private void PrintActionOptions(General general)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Choose you action General {general.Name}");
            sb.AppendLine(" [1] Attack");
            sb.AppendLine(" [2] Do a Maneuvres");
            sb.AppendLine(" [3] Buy a Soldier");

            Console.WriteLine(sb.ToString());
        }

        private void GeneralsTurn(General general)
        {
            bool roundCheck = false;
            do
            {                
                PrintActionOptions(general);
                roundCheck = true;

            } while (roundCheck == false);
        }
    }
}
