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


        public override void SelectGesture()
        {
            SelectedGesture = 3;
        }

        public override string SetPlayerName()
        {
            List<string> CpuPlayersList = new List<string>() {"Bender", "T-100", "HAL-9000", "OMM-0000", "ED-209" };
            Random random = new Random();

            return CpuPlayersList[random.Next(0, CpuPlayersList.Count)];
        }
    }
}
