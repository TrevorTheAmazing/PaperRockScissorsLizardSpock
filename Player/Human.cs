using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperRockScissorsLizardSpock
{

    class Human : Player
    {
        public Human(/*string Name*/)// : base(Name)
        {
            //this.Name = Name;
            this.Name = SetPlayerName();
        }

        public override string SetPlayerName()
        {
            Console.WriteLine("What is this human player's name?");
            return Console.ReadLine();
        }
        public override void SelectGesture()
        {
            SelectedGesture = 3;
        }
    }
}
