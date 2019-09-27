using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperRockScissorsLizardSpock
{

    class Human : Player
    {
        bool nameIsSet;
        string tempStr;

        public Human()
        {
            //this.Name = Name;
            this.Name = SetPlayerName();
        }

        public override string SetPlayerName()
        {            
            //input validation
            bool ValidStr(string Input)
            {
                bool tempResult = true;
                if (!string.IsNullOrEmpty(Input))
                {
                    Input = Input.ToLower();
                    //for (int i = 0; i < Input.Length; i++)
                    //{
                    foreach (char asciiChar in Input.ToCharArray())
                    {
                        if(!(asciiChar > 32 && asciiChar < 127))
                        {
                            tempResult = false;
                            return tempResult;
                        }
                    }
                    
                    if (tempResult)
                    {
                        nameIsSet = true;
                        return nameIsSet;
                    }

                    //}
                }
                return tempResult;
            }//end ValidStr


            //begin Human.SetPlayerName()
            do
            {
                nameIsSet = false;
                Console.WriteLine("What is this human player's name?");
                tempStr = Console.ReadLine();
                ValidStr(tempStr);
                
            } while (!nameIsSet);
            
            return tempStr;
        }//end Human.SetPlayerName()

        public override void SelectGesture()
        {
            //prompt for the player's selected gesture
            //assign selected gesture input to Player.SelectedGesture
            //loop through the players, add their selects to an array
            //pass the array to Gestures.CompareGestures
            SelectedGesture = 3;
        }
    }
}
