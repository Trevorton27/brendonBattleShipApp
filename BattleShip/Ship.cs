using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BattleShip
{
    class Ship
    {
        public Ship(List<Coordinate> coordinates)
        {
            Coordinates = coordinates;
        }

        public List<Coordinate> Coordinates { get; set; }

        public void printAll ()
        {
            foreach (var coordinate in Coordinates)
            {
                Console.WriteLine($"Coordinate (Ship): C-{coordinate.Column} R-{coordinate.Row} Ship-{coordinate.IsShip} V-{coordinate.IsVisible} ");
            }
        }

        public void changeIsShip ()
        {
            foreach (var coordinate in Coordinates)
            {
                coordinate.IsShip = true;
            }
        }

        public bool isAllHit()
        {
            foreach (var coordinate in Coordinates)
            {
                if (coordinate.IsVisible == false)
                    return false;
            }
            return true;
        }
    }
}
