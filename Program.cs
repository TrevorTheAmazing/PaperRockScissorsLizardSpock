using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperRockScissorsLizardSpock
{
    class Program
    {
        static void Main(string[] args)
        {
            Game PaperRockScissorsLizardSpock = new Game();
            do
            {
                PaperRockScissorsLizardSpock.SetupGame();
            } while (!PaperRockScissorsLizardSpock.GameIsSetUp);
            if (PaperRockScissorsLizardSpock.GameIsSetUp)
            {
                PaperRockScissorsLizardSpock.RunGame();
            }            
            Console.ReadLine();
        }
    }
}
