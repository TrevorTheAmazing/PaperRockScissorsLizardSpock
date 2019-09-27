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
        public bool GameIsSetUp;
        int requiredNumberOfPlayers = 2;
        Player tempPlayer;
        int tieCounter = 0;

        //constr

        //mem methods
        public bool SetupGame()
        {
            
            //display the rules
            DisplayRules();
            if (GetUserInput("Would you like to play?", "bool")=="1")
                {
                while (Players.Count < requiredNumberOfPlayers)
                {
                    //string tempPlayer = "";
                    if (GetUserInput("Is this player a human?", "bool")=="1")
                    {
                        tempPlayer = new Human();                        
                    }
                    else
                    {
                        tempPlayer = new Computer();
                    }
                    Players.Add(tempPlayer);
                }
            }
            else
            {
                RunGame();
            }

            //indicate game is "ready to play"
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

            BeginGame();


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
                Environment.NewLine + "... Rock crushes Scissors." + Environment.NewLine + Environment.NewLine);

        }

        public void AnnounceWinner()
        {
            Console.WriteLine("The champ is:");
            Console.WriteLine("");
            Console.ReadLine();
            for (int i = 0; i < Players.Count; i++)
            {
                if (Players[i].Score == 2)
                {
                    Console.WriteLine(Players[i].Name + "!");
                    Console.WriteLine("");
                    Console.WriteLine(Players[i].Name + " is the dang champ!!!!!!!!");
                    //Console.ReadLine();
                    break;
                }
            }
        }

        public string GetUserInput(string message, string ValidationType)
        {
            Console.WriteLine(message);

            switch (ValidationType)
            {
                case "int":
                    //return ValidInt(int.Parse(Console.ReadLine()));  
                    string tempInt = Console.ReadLine();
                    if (ValidInt(tempInt))
                    {
                        return tempInt;
                    }
                    else
                    {
                        GetUserInput(message, "int");
                        return "";
                    }
                case "bool":
                    Console.WriteLine(Environment.NewLine + "1 = 'Yes'" + Environment.NewLine + "0 = 'No'");
                    string tempBool = Console.ReadLine();
                    if (ValidBool(tempBool))
                    {
                        return tempBool;
                    }
                    else
                    {
                        return "";
                    }
                case "str":
                    try
                    {
                        string tempStr = Console.ReadLine();
                        if (ValidStr(tempStr))
                        {
                            return tempStr;
                        }
                        else
                        {
                            return "";
                        }
                    }
                    catch (NullReferenceException)
                    {
                        return "";
                    }
                    //return ValidStr(Console.ReadLine());
                default:
                    return "";
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

        public void BeginGame()
        {
            //one 'game' instance should have at least 3 rounds            
            do
            {
                //Console.Clear();
                //display the gesture options
                for (int j = 0; j < GesturesList.Count; j++)
                {
                    Console.WriteLine(j + " - " + GesturesList[j]);
                }

                //prompt each player for their throw
                for (int i = 0; i < Players.Count; i++)
                {
                    Console.WriteLine(Players[i].Name + ", it is your turn to throw down!");
                    //prompt the player for their selection                        
                    Players[i].SelectGesture(GesturesList);
                }

                //compare their selections, determine the round winner, increment their score
                CompareSelectedGestures(Players, GesturesList);
                
                //Player roundWinner = 
                //increment the winner's score

            } while (!WinningScoreExists());

        }

        public void CompareSelectedGestures(List<Player> Players, List<string> GesturesList)
        {
            Player Player1 = Players[0];
            Player Player2 = Players[1];

            int tempDescision = ((GesturesList.Count + (Player1.SelectedGesture - Player2.SelectedGesture)) % GesturesList.Count);

            if (tempDescision==0)
            {
                tieCounter++;
            }
            else if ((tempDescision % 2) == 1)
            {
                Console.WriteLine(Player1.Name + " wins the round!");
                Player1.Score++;
                Console.WriteLine(Player1.Name + " chose " + GesturesList[Player1.SelectedGesture]);
                Console.WriteLine(Player2.Name + " chose " + GesturesList[Player2.SelectedGesture]);
                Console.WriteLine(tieCounter);
                Console.ReadLine();
            }
            else if ((tempDescision % 2) == 0)
            {
                Console.WriteLine(Player2.Name + " wins the round!");
                Player2.Score++;
                Console.WriteLine(Player1.Name + " chose " + GesturesList[Player1.SelectedGesture]);
                Console.WriteLine(Player2.Name + " chose " + GesturesList[Player2.SelectedGesture]);
                Console.WriteLine(tieCounter);
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("3rr0r");
            }

            //Console.WriteLine(Player1.Name + " chose " + GesturesList[Player1.SelectedGesture]);
            //Console.WriteLine(Player2.Name + " chose " + GesturesList[Player2.SelectedGesture]);
            //Console.WriteLine(tieCounter);
            //Console.ReadLine();
        }

        public bool WinningScoreExists()
        {
            bool tempResult = false;
            for (int i = 0; i < Players.Count; i++)
            {
                if (Players[i].Score == 2)
                {
                    tempResult = true;
                    break;
                }
                else
                {
                    tempResult = false;
                }
            }
            return tempResult;
        }
    }// end Game class
}// end Namespace