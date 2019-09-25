using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperRockScissorsLizardSpock
{
    class Player
    {
        //memb var
        public string Name;
        public bool IsHuman;
        //public int SelectedGesture;
        public string SelectedGesture;


        //constr
        public Player(string Name, bool IsHuman)
        {
            this.Name = Name;
            this.IsHuman = true;
        }


        //memb methods
        //select gesture
        public void SelectGesture()
        {
            //prompt for the player's selected gesture
            //assign selected gesture input to Player.SelectedGesture
        }
    }
}
