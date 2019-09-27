using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperRockScissorsLizardSpock
{
    class Game
    {
        //mem var
        public List<Player> Players = new List<Player>();
        public List<string> GesturesList = new List<string>() { "Paper", "Rock", "Scissors", "Lizard", "Spock" };
        public Random rng;
        public bool GameIsSetUp;
        public Player Player1;
        public Player Player2;

        //constr

        //mem methods
        public bool SetupGame()//START WORKING HERE!
        {
            //display the rules
            DisplayRules();

            for (var i = 0; i <= 1; i++)
            {
                //bool TempIsHuman;
                Console.WriteLine("Setting up player " + (i+1).ToString() + ".");

                if (GetUserInput("Is this player a human?" + Environment.NewLine + "1 = 'Yes'" + Environment.NewLine + "0 = 'No'", "bool"))
                {
                    //TempIsHuman = true;
                    //Player1 = SetupHumanPlayer();
                    Player1 = new Human();
                    Players.Add(Player1);
                }
                else
                {
                //TempIsHuman = false;
                //Player2 = SetupComputerPlayer();
                Player2 = new Computer();
                Players.Add(Player2);
                }                          
            }

            //report "ready to play"
            if (Players.Count == 2)
            {
                GameIsSetUp = true;
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public void RunGame()
        {
            for (int i = 0; i< Players.Count; i++)
            {
                Console.WriteLine("Player " + (i+1).ToString() + " = " + Players[i].Name);
            }
            Console.WriteLine("yay BEGIN GAME NOW");
            Console.ReadLine();
            //one 'game' instance should have at least 3 rounds
            //loop at least 3 rounds

            //tiebreaker round
            //display winner
            AnnounceWinner();
        }
        
        public void DisplayRules()
        {
            Console.WriteLine(
                "Scissors cuts Paper," + Environment.NewLine + "Paper covers Rock," + Environment.NewLine +
                "Rock crushes Lizard," + Environment.NewLine + "Lizard poisons Spock," + Environment.NewLine +
                "Spock smashes Scissors," + Environment.NewLine + "Scissors decapitates Lizard," + Environment.NewLine +
                "Lizard eats Paper," + Environment.NewLine + "Paper disproves Spock," + Environment.NewLine +
                "Spock vaporizes Rock." + Environment.NewLine + "And as it always has ..." + Environment.NewLine +
                Environment.NewLine + "... Rock crushes Scissors.");
            Console.WriteLine("https://www.youtube.com/watch?v=cSLeBKT7-sM");

        }

        public void AnnounceWinner()
        {
            Console.WriteLine("The winner is:");
        }

        public bool GetUserInput(string message, string ValidationType)
        {
            Console.WriteLine(message);
            switch (ValidationType)
            {
                case "int":
                    //return ValidInt(int.Parse(Console.ReadLine()));
                    return ValidInt(Console.ReadLine());
                case "bool":
                    return ValidBool(Console.ReadLine());
                case "str":
                    return ValidStr(Console.ReadLine());
                default:
                    return false;
            }
        }

        public bool ValidStr(string Input)
        {
            string tempString = Input.ToLower();
            bool tempResult = true;
            for (int i = 0; i < Input.Length; i++)
            {
                foreach (char asciiChar in Input.ToCharArray())
                {
                    if (!(asciiChar > 96 && asciiChar < 123))
                    {
                        tempResult = false;
                        break;
                    }
                }
            }
            return tempResult;
        }

        public bool ValidInt(string Input)
        {
            bool tempResult = true;
            for (int i = 0; i < Input.Length; i++)
            {
                foreach (char asciiChar in Input.ToCharArray())
                {
                    if (!(asciiChar > 47 && asciiChar < 58))
                    {
                        tempResult = false;
                        break;
                    }
                }
            }
            return tempResult;
        }

        public bool ValidBool(string Input)
        {
            bool tempResult = true;
            for (int i = 0; i < Input.Length; i++)
            {
                foreach (char asciiChar in Input.ToCharArray())
                {
                    if (!(asciiChar > 47 && asciiChar < 50))
                    {
                        tempResult = false;
                        break;
                    }
                }
            }
            return tempResult;
        }
    }// end Game class
}// end Namespace