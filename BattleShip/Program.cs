using System;

namespace BattleShip
{
    class Program
    {
        static void Main(string[] args)
        {
            var gameBoard = new GameBoard();
            //var ship = new Ship();
            var attemptsRemaining = 8;
            var attemptsRemainingText = "";
            bool successfulAttempt = true;
            gameBoard.initializeCoordinates();
            gameBoard.assignShipCoordinates();
            //ship.assignShipCoordinates();
            do
            {
                if(attemptsRemaining == 1)
                {
                    attemptsRemainingText = "Last Attempt";
                }
                else
                {
                    attemptsRemainingText = attemptsRemaining.ToString();
                }

                if (!successfulAttempt)
                {
                    attemptsRemainingText = attemptsRemainingText + " --> REDO: Be careful with what you type ;)";
                }

                gameBoard.drawBoard();
                Console.WriteLine("");
                Console.WriteLine($"Attempts Remaining: {attemptsRemainingText}");
                Console.WriteLine("");
                Console.WriteLine("1 Make Guess");
                Console.WriteLine("2 Display all coordinates");
                Console.WriteLine("3 Display Ship Coordinates");
                Console.WriteLine("Press 'x' to quit");

                var switchValue = Console.ReadLine();

                successfulAttempt = true;
                try
                {
                    switch (switchValue)
                    {
                        case "1":
                            Console.WriteLine("Column:");
                            var column1 = Console.ReadLine().ToUpper();
                            Console.WriteLine("Row:");
                            var row1 = Int32.Parse(Console.ReadLine());
                            gameBoard.ChangeIsVisible(column1, row1);
                            break;
                        case "2":
                            break;
                        case "3":
                            break;
                        case "4":
                            break;
                        case "5":
                            break;
                        case "x":
                            return;
                        default:
                            break;
                    }

                }
                catch (Exception)
                {
                    successfulAttempt = false;
                }

                if (successfulAttempt)
                {
                    attemptsRemaining--;
                }

            } while (attemptsRemaining > 0);
        }
    }
}
