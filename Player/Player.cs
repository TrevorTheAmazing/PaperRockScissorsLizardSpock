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
        //"can't abstract fields"
        public string Name;
        public bool IsHuman;
        public int SelectedGesture;
        public int Score;

        //constr
        //public Player(string Name, bool IsHuman = false)
        public Player()
        {
            /*this.Name = Name;
            this.IsHuman = IsHuman;*/
            this.SelectedGesture = 0;
            this.Score = 0;
        }

        //memb methods
        //select gesture
        public abstract string SetPlayerName();
        public abstract void SelectGesture();
        //{
            //prompt for the player's selected gesture
            //assign selected gesture input to Player.SelectedGesture
        //}
    }
}
