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
            // For test purposes names are hardcoded

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
                GeneralsTurn(general1);
                GeneralsTurn(general2);

                roundCounter++;
            } while (true);
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

        private void GeneralsTurn(General general)
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
