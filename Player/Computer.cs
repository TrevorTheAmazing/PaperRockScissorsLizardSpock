using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperRockScissorsLizardSpock
{
    public class Computer : Player
    {
        public Computer()
        {
            //this.Name = Name;
            this.Name = SetPlayerName();
        }

        public override string SetPlayerName()
        {
            List<string> CpuPlayersList = new List<string>() { "Bender", "T-100", "HAL-9000", "OMM-0000", "ED-209" };
            Random random = new Random();

            return CpuPlayersList[random.Next(0, CpuPlayersList.Count)];
        }

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
