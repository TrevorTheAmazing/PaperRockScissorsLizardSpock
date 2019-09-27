using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperRockScissorsLizardSpock
{
    public abstract class Player
    {
        //memb var
        public string Name;
        public int SelectedGesture;
        public int Score;

        //constr
        public Player()
        {
            this.SelectedGesture = 0;
            this.Score = 0;
        }

        //memb methods
        //select gesture
        public abstract string SetPlayerName();
        public abstract void SelectGesture();

    }
}
