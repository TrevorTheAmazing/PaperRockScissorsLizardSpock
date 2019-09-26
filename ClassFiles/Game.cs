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
        //public Player[] Players = new Player[2];
        public List<Player> Players = new List<Player>();
        public string[] GesturesArray;
        public Random rng;
        public bool GameIsSetUp;

        //constr

        //mem methods
        public bool SetupGame()
        {
            //players setup

            //get ishUman
            //get name
            //add to Players list

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

        public string promptFor(string question, bool valid)
        {
            string response = "";
            do
            {
                Console.WriteLine(question);
                response = Console.ReadLine();
                //while ((response != "") || (valid(response));
            } while (response != "");
            return response;
        }

        public bool yesNo(string input)
        {
            return (input.ToLower() == "yes") || (input.ToLower() == "no");
        }

        public bool chars(string input)
        {
            bool tempResult = true;
            for (int i = 0; i < input.Length; i++)
            {
                foreach (char asciiChar in input.ToCharArray())
                { 
                    if (!(asciiChar > 96 && asciiChar < 122))
                    {
                        tempResult = false;
                        break;
                    }
                }
            }
            return tempResult;
        }

        public bool nums(string input)
        {
            bool tempResult = true;
            for (int i = 0; i < input.Length; i++)
            {
                foreach (char asciiChar in input.ToCharArray())
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
    }
}
