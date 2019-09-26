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
        public bool SetupGame()
        {
            //display the rules
            DisplayRules();

            for (var i = 0; i <= 1; i++)
            {
                bool TempIsHuman;
                Console.WriteLine("Setting up player " + (i+1).ToString() + ".");
                if (i==0)
                {
                    TempIsHuman = true;//GetUserInput("Is this player a human? /n 1 = 'Yes' /n 0 = 'No'", "bool");
                    //Player1 = SetupHumanPlayer();
                    Player1 = new Human();
                    Players.Add(Player1);
                }
                else if (i==1)
                {
                    TempIsHuman = false;
                    //Player2 = SetupComputerPlayer();
                    Player2 = new Computer();
                    Players.Add(Player2);
                }
                
               //Players.Add(new Player());//!//
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
            Console.WriteLine("now in DisplayRules()");
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
                default:
                    return false;
            }
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

    }// end Game class
}// end Namespace