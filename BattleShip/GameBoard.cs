using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class GameBoard
    {
        private List<Coordinate> _coordinates { get; set; } = new List<Coordinate>();
        
        public void drawBoard ()
        {
            List<string> Columns = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J"};
            List<string> Rows = new List<string>();
            var line = "";
            for (int i = 0; i < 10; i++)
            {
                line = "";
                if ((i + 1).ToString().Length == 1)
                {
                    line = line + $" {i + 1}||";
                }
                else
                {
                    line = line + $"{i + 1}||";
                }
                for (int j = 0; j < 10; j++)
                {
                    var matchingCoordinate = _coordinates.Where(c => c.Column.Contains(Columns[j]) && c.Row == i + 1).Single();
                    var character = chooseDisplayCharacter(matchingCoordinate.IsShip, matchingCoordinate.IsVisible);
                    line = line + $" {character}";
                }
                line = line + " ||";
                Rows.Add(line);
            }

            //Console.Clear();

            Console.WriteLine("        Battle Ship        ");
            Console.WriteLine("                           ");
            Console.WriteLine("     A B C D E F G H I J   ");
            Console.WriteLine("  |=======================|");
            foreach (var row in Rows)
            {
                Console.WriteLine(row);
            }
            Console.WriteLine("  |=======================|");
        }


        public void assignShipCoordinates()
        {
            List<string> Columns = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
            var randomColumn = "A";
            var randomRow = 1;

            List<Coordinate> shipCoordinates = tryShipCoordinates(randomColumn, randomRow);

            var ship = new Ship(shipCoordinates);
            ship.changeIsShip();
        }

        private List<Coordinate> tryShipCoordinates(string randomColumn, int randomRow)
        {
            List<Coordinate> ship = new List<Coordinate>();
            foreach (var coordinate in _coordinates)
            {
                if (coordinate.Row == 3)
                {
                    ship.Add(coordinate);
                }
            }
            return ship;
        }

        private static string chooseDisplayCharacter (bool isShip, bool isVisible)
        {
            var result = "";
            if (!isVisible)
            {
                result = "-";
            }
            else
            {
                if(isShip)
                {
                    result = "X";
                }
                else
                {
                    result = "O";
                }
            }
            return result;
        }
        
        
        public void initializeCoordinates ()
        {
            List<string> Columns = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
            foreach (var column in Columns)
            {
                for (int i = 0; i < 10; i++)
                {
                    _coordinates.Add(new Coordinate(column, i + 1, false, false));
                }
            }
        }
        
        public void ChangeIsVisible (string column, int row)
        {
            var matchingCoordinate = _coordinates.Where(c => c.Column.Contains(column) && c.Row == row).Single();
            matchingCoordinate.IsVisible = true;
        }

    

        //public void DisplayShipCoordinates() 
        //{
            
        //}
    }
}
