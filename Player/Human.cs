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
        bool gestureIsSet;
        string tempStr;
        string tempGesture;

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

        public override void SelectGesture(List<string> GesturesList)
        {
            
            bool ValidInt(string Input)
            {
                bool tempResult = true;
                for (int i = 0; i < Input.Length; i++)
                {
                    foreach (char asciiChar in Input.ToCharArray())
                    {
                        if (!(asciiChar > 47 && asciiChar < 58))
                        {
                            tempResult = false;
                            return tempResult;
                        }
                    }
                }
                if (tempResult)
                {
                    try
                    {
                        if ((Int32.Parse(Input)) < (GesturesList.Count))
                        {
                            gestureIsSet = true;
                            return gestureIsSet;
                        }
                    }
                    catch
                    {
                        SelectGesture(GesturesList);
                    }

                }
                return tempResult;
            }

            do
            {
                gestureIsSet = false;
                Console.WriteLine(this.Name + ", select a gesture:");
                tempGesture = Console.ReadLine();
                ValidInt(tempGesture);
            } while (!gestureIsSet);

            //assign selected gesture input to Player.SelectedGesture
            if (gestureIsSet)
            {
                try
                {
                    this.SelectedGesture = (Int32.Parse(tempGesture));
                }
                catch
                {
                    SelectGesture(GesturesList);
                }
                
            }
            else
            {
                SelectGesture(GesturesList);
            }
        }
    }
}
 