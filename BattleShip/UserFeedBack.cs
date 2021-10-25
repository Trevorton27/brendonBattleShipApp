using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace BattleShip
{
    class UserFeedBack
    {
        public void GiveFeedBack(int attempts)
        {
            WriteLine("");
            WriteLine($"Turns Remaining: {attempts}");
           WriteLine("");
            WriteLine("1 - Fire shot ##>");
            WriteLine("2 - Use binoculars 0_0");
           WriteLine("Press 'x' to exit the game");
            WriteLine();
           Write("Awaiting your orders, Commander: ");
        }
    }
}
