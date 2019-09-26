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

        //constr

        //mem methods
        public bool SetupGame()
        {
            //players setup
            //get ishUman
            bool TempIsHuman = GetUserInput("Is this player a human? /n 1 = 'Yes' /n 0 = 'No'", "bool");
            
            //get name
            if (TempIsHuman)
            {
                Console.WriteLine("What is this human player's name?");
                string TempName = Console.ReadLine();
            }
            //instantiate Player
            //add to Players list
            Player Player1 = new Human(TempName/*, IsHuman*/);
            //Players.add();

            //display the rules
            DisplayRules();

            //report "ready to play"
            return true;
        }

        public void RunGame()
        {
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
            //int input = int.Parse(Console.ReadLine());
            //if (input == 0)
            //{
            //    return false;
            //}
            //else if (input == 1)
            //{
            //    return true;
            //} 
            //else
            //{
            //    return false;
            //}
        }

        //public bool ValidInt(int Input)
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

        public class Human : Player
        {
            public Human(string Name):base(Name)
            {
                this.Name = Name;
            }
            public override void SelectGesture()
            {
                SelectedGesture = 3;
            }
        }

        public class Computer : Player
        {
            public Computer(string Name):base(Name)
            {
                this.Name = Name;
            }
            public override void SelectGesture()
            {
                SelectedGesture = 3;
            }
        }
    }// end Game class
}// end Namespace