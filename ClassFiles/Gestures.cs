﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperRockScissorsLizardSpock.ClassFiles
{
    class Gestures
    {
        //memb var
        //public string[] GesturesArray = { "Paper", "Rock", "Scissors", "Lizard", "Spock" };
        public List<string> GesturesList = new List<string>(){ "Paper", "Rock", "Scissors", "Lizard", "Spock" };

        //constr
        public Gestures()
        {
            this.GesturesList = GesturesList;
        }

        //memb methods
        //display gestures
        public void DisplayGestures()
        {
            Console.WriteLine("now in DisplayGestures");
        }
    }

}