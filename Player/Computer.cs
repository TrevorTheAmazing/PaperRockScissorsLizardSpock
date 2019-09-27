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

        public override void SelectGesture(List<string> GesturesList)
        {
            Random random = new Random();
            //prompt for the player's selected gesture
            //assign selected gesture input to Player.SelectedGesture
            this.SelectedGesture = (random.Next(0, GesturesList.Count));           
        }
    }
}
