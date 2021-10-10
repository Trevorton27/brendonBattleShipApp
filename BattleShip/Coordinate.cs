using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class Coordinate
    {

        public Coordinate(string column, int row, bool isShip, bool isVisible)
        {
            Column = column;
            Row = row;
            IsShip = isShip;
            IsVisible = isVisible;
        }

        public static bool getBoolInputValue (string inputString)
        {
            bool value;
            if (inputString.ToLower() == "y")
            {
                value = true;
            }
            else
            {
                value = false;
            }
            return value;
        }

        public string Column { get; set; }
        public int Row { get; set; }
        public bool IsShip { get; set; }
        public bool IsVisible { get; set; }
    }
}
