using System.Text;
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
            // For faster test purposes names are hardcoded

            string gen1Name = "Jarek";
            string gen2Name = "Remik";

            General gen1 = new General(gen1Name);
            General gen2 = new General(gen2Name);

            StartBattle(gen1, gen2);
        }

        private void StartBattle(General general1, General general2)
        {
            int roundCounter = 0;

            do
            {
                GeneralsTurn(general1, general2);
                if (general2.FullHealth < 0)
                    break;
                GeneralsTurn(general2, general1);

                roundCounter++;
            } while (general1.FullHealth <= 1 || general2.FullHealth <= 1);

            if (general1.FullHealth < 1)
                Logger.Log($"{general2} has won");
            else
                Logger.Log($"{general1} has won");
        }

        private void PrintActionOptions(General general)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Choose you action General {general.Name}");
            sb.AppendLine(" [1] Attack");
            sb.AppendLine(" [2] Do a Maneuvres");
            sb.AppendLine(" [3] Buy a Soldier");
            sb.AppendLine(" [4] Check my power");

            Console.WriteLine(sb.ToString());
        }

        private void GeneralsTurn(General general, General opponent)
        {
            bool roundCheck = false;
            do
            {
                PrintActionOptions(general);
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1": 
                        general.Attack();
                        opponent.TakeDamage(opponent, general.FullPower());
                        roundCheck = true;
                        break;
                    case "2":
                        general.Maneuveres();
                        roundCheck = true;
                        break;
                    case "3":
                        general.BuySoldier();
                        roundCheck = true;
                        break;
                    case "4":
                        Console.WriteLine(general.FullPower());
                        break;
                    default:
                        Console.WriteLine("Choose an option");
                        break;
                }

            } while (roundCheck == false);
        }
    }
}
