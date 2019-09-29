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
        public List<string> GesturesList = new List<string>() { "Rock", "Paper", "Scissors", "Spock", "Lizard" };
        public bool GameIsSetUp;
        int requiredNumberOfPlayers = 2;
        Player tempPlayer;
        int tieCounter = 0;

        //constr

        //mem methods
        public bool SetupGame()
        {

            //display the rules
            Console.Clear();
            DisplayRules();
            if (GetUserInput("Would you like to play?", "bool")=="1")
                {
                do
                {
                    if (GetUserInput("Is this player a human?", "bool") == "1")
                    {
                        tempPlayer = new Human();
                    }
                    else
                    {
                        tempPlayer = new Computer();
                        Console.WriteLine("Your opponent is: " + tempPlayer.Name);
                        Console.ReadLine();
                    }

                    if (tempPlayer != null)
                    {
                        Players.Add(tempPlayer);
                    }
                } while (Players.Count < requiredNumberOfPlayers);
            }
            else
            {
                SetupGame();
            }

            //indicate game is "ready to play"
            if (Players.Count == requiredNumberOfPlayers)
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

            if (GameIsSetUp)
                {
                BeginGame();
                AnnounceWinner();
                }
            else
            {
                Players.Clear();
            }

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
                    Console.WriteLine(Players[i].Name + " is the champ!!!");
                    Console.ReadLine();
                    break;
                }
            }
        }

        public string GetUserInput(string message, string ValidationType)
        {
            bool inputIsValid = false;
            do
            {
                Console.WriteLine(message);

                switch (ValidationType)
                {
                    case "int":
                        string tempInt = Console.ReadLine();
                        if (ValidInt(tempInt))
                        {
                            inputIsValid = true;
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
                            inputIsValid = true;
                            return tempBool;
                        }
                        else
                        {
                            GetUserInput(message, "bool");
                            return "";
                        }
                    case "str":
                        try
                        {
                            string tempStr = Console.ReadLine();
                            if (ValidStr(tempStr))
                            {
                                inputIsValid = true;
                                return tempStr;
                            }
                            else
                            {
                                GetUserInput(message, "str");
                                return "";
                            }
                        }
                        catch (NullReferenceException)
                        {
                            GetUserInput(message, "str");
                            return "";
                        }
                    //return ValidStr(Console.ReadLine());
                    default:
                        return "";
                }
            } while (!inputIsValid);
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
            tieCounter = 0;
            //one 'game' instance should have at least 3 rounds            
            do
            {
                Console.Clear();
                DisplayRules();

                //display the gesture options
                for (int j = 0; j < GesturesList.Count; j++)
                {
                    Console.WriteLine(j + " - " + GesturesList[j]);
                }

                Console.WriteLine("");
                Console.WriteLine("It is time to throw down!");
                Console.WriteLine("");

                //prompt each player for their throw
                for (int i = 0; i < Players.Count; i++)
                {
                    Console.WriteLine("");
                    //prompt the player for their selection                        
                    Players[i].SelectGesture(GesturesList);
                }

                //compare their selections, determine the round winner, increment their score
                CompareSelectedGestures(Players, GesturesList);

            } while (!WinningScoreExists());

        }

        public void CompareSelectedGestures(List<Player> Players, List<string> GesturesList)
        {
            Player Player1 = Players[0];
            Player Player2 = Players[1];

            int tempDescision = (((GesturesList.Count + Player1.SelectedGesture) - Player2.SelectedGesture) % GesturesList.Count);

            Console.WriteLine();
            Console.WriteLine(Player1.Name + " selected " + GesturesList[Player1.SelectedGesture] + ".");
            Console.WriteLine(Player2.Name + " selected " + GesturesList[Player2.SelectedGesture] + ".");
            Console.WriteLine();

            if (tempDescision == 0)
            {
                tieCounter++;
                Console.WriteLine("Tie! (" + tieCounter + ")");
            }
            else if ((tempDescision % 2) == 1)
            {
                Player1.Score++;
                Console.WriteLine(Player1.Name + " wins the round!");
                Console.ReadLine();
            }
            else if ((tempDescision % 2) == 0)
            {
                Player2.Score++;
                Console.WriteLine(Player2.Name + " wins the round!");
                Console.ReadLine();
            }

            else
            {
                Console.Clear();
                Console.WriteLine("3rr0r");
            }


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