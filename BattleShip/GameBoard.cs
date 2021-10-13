using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleShip
{
    class GameBoard
    {
        private List<Coordinate> AllCoordinates { get; set; } = new List<Coordinate>();
        public int ShipHealth { get; set; }

        public void DrawGameBoard (bool isPeek = false)
        {
            List<string> Rows = BuildRows();
            Console.Clear();
            Console.WriteLine("        Battle Ship        ");
            Console.WriteLine("                           ");
            Console.WriteLine("     A B C D E F G H I J   ");
            Console.WriteLine("  |=======================|");
            foreach (var row in Rows)
                Console.WriteLine(row);
            Console.WriteLine("  |=======================|");
            Console.WriteLine();
            UpdateHealth(isPeek);
            Console.WriteLine($"      Ship Health: {ShipHealth}");
            if (ShipHealth == 0)
                Console.WriteLine("   SHIP SUNK!!! YOU WIN!!!");
        }

        private List<string> BuildRows ()
        {
            List<string> Rows = new();
            var line = "";
            for (int i = 0; i < 10; i++)
            {
                line = "";
                if ((i + 1).ToString().Length == 1)
                    line += $" {i + 1}||";
                else
                    line += $"{i + 1}||";
                for (int j = 0; j < 10; j++)
                {
                    var matchingCoordinate = AllCoordinates.Where(c => c.Column == j && c.Row == i).Single();
                    var character = ChooseDisplayCharacter(matchingCoordinate.IsShip, matchingCoordinate.IsVisible);
                    line += $" {character}";
                }
                line += " ||";
                Rows.Add(line);
            }
            return Rows;
        }
      
        public void InitializeShip()
        {
            Random rnd = new();
            var randomColumn = rnd.Next(0, 9);
            var randomRow = rnd.Next(0, 9);
            int randomStart = rnd.Next(1, 4);
            bool isStop = false;
            while (!isStop)
            {
                switch (randomStart)
                {
                    case 1:
                        if (randomColumn + 4 < 10)
                        {
                            foreach (var coordinate in AllCoordinates)
                                if (coordinate.Row == randomRow && (coordinate.Column >= randomColumn && coordinate.Column <= randomColumn + 4))
                                    coordinate.IsShip = true;
                            isStop = true;
                        }
                        break;
                    case 2:
                        if (randomColumn - 4 >= 0)
                        {
                            foreach (var coordinate in AllCoordinates)
                                if (coordinate.Row == randomRow && (coordinate.Column >= randomColumn -4 && coordinate.Column <= randomColumn ))
                                    coordinate.IsShip = true;
                            isStop = true;
                        }
                        break;
                    case 3:
                        if (randomRow + 4 < 10)
                        {
                            foreach (var coordinate in AllCoordinates)
                                if (coordinate.Column == randomColumn && (coordinate.Row >= randomRow && coordinate.Row <= randomRow + 4))
                                    coordinate.IsShip = true;
                            isStop = true;
                        }
                        break;
                    case 4:
                        if (randomRow - 4 >= 0)
                        {
                            foreach (var coordinate in AllCoordinates)
                                if (coordinate.Column == randomColumn && (coordinate.Row >= randomRow - 4 && coordinate.Row <= randomRow ))
                                    coordinate.IsShip = true;
                            isStop = true;
                        }
                        break;
                    default:
                        break;
                }
                if (randomStart == 4)
                    randomStart = 0;
                randomStart++;
            }
        }

        public void InitializeCoordinates()
        {
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    AllCoordinates.Add(new Coordinate(i, j));
        }

        private void UpdateHealth(bool isPeek)
        {
            if (!isPeek)
            {
                int count = 0;
                foreach (var coordinate in AllCoordinates)
                    if (coordinate.IsShip && !coordinate.IsVisible)
                        count++;
                ShipHealth = count;
            }
        }

        private static string ChooseDisplayCharacter (bool isShip, bool isVisible)
        {
            string result;
            if (!isVisible)
                result = "-";
            else
            {
                if(isShip)
                    result = "X";
                else
                    result = "O";
            }
            return result;
        }
        
        public int ChangeLetterToNumber (string input)
        {
            List<string> Columns = new() { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
            try
            {
                return Columns.IndexOf(input);
            }
            catch (Exception)
            {
                return 20;
            }
        }

        public void ToggleIsVisible(int column, int row)
        {
            var matchingCoordinate = AllCoordinates.Where(c => c.Column == column && c.Row == row).Single();
            matchingCoordinate.IsVisible = true;
        }

        public void ShowShipTimer(int time)
        {
            foreach (var coordinate in AllCoordinates)
            {
                if (coordinate.IsShip)
                    coordinate.IsVisible = true;
            }
            DrawGameBoard(true);
            System.Threading.Thread.Sleep(time);
            foreach (var coordinate in AllCoordinates)
            {
                if (coordinate.IsShip && !coordinate.IsGuessed)
                    coordinate.IsVisible = false;
            }
            DrawGameBoard(true);
        }

        public void ShowShipPermanent()
        {
            foreach (var coordinate in AllCoordinates)
                if (coordinate.IsShip == true) 
                    coordinate.IsVisible = true;
            DrawGameBoard(true);
        }

        public void ToggleIsGuessed (int column, int row)
        {
            var matchingCoordinate = AllCoordinates.Where(c => c.Column == column && c.Row == row).Single();
            matchingCoordinate.IsGuessed = true;
        }

        public bool CheckIsGuessed (int column, int row)
        {
            bool result = false;
            foreach (var coordinate in AllCoordinates)
                if (coordinate.Column == column && coordinate.Row == row && coordinate.IsGuessed)
                    result = true;
            return result;
        }
    }
}
