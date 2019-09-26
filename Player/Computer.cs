using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperRockScissorsLizardSpock
{
    public class Computer : Player
    {
        public Computer(/*string Name*/)//:base(Name)
        {
            //this.Name = Name;
            this.Name = SetPlayerName();
        }
        public override string SetPlayerName()
        {
            return "Computer Player";
        }
        public override void SelectGesture()
        {
            SelectedGesture = 3;
        }
    }
}
