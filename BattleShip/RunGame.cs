using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class RunGame
    {
        public void StartGame()
        {
            var isPlayAgain = true;
            do
            {
                var gameBoard = new GameBoard
                {
                    ShipHealth = 5
                };
                var userFeedBack = new UserFeedBack();
                var attemptsRemaining = 8;
                bool successfulAttempt = true;
                bool IsGuessed = false;
                gameBoard.InitializeCoordinates();
                gameBoard.InitializeShip();
                do
                {
                    string attemptsRemainingText;
                    if (attemptsRemaining == 1)
                        attemptsRemainingText = "Last shot! Aim well!";
                    else
                        attemptsRemainingText = attemptsRemaining.ToString();

                    if (!successfulAttempt)
                        attemptsRemainingText += " --> REDO: Put on your glasses! Where are you aiming?!";

                    if (IsGuessed)
                    {
                        attemptsRemainingText += "--> REDO: Commander, we've already hit that spot!";
                        IsGuessed = false;
                    }
                    gameBoard.DrawGameBoard();
                    userFeedBack.GiveFeedBack(attemptsRemaining);

                    var switchValue = Console.ReadLine();
                    successfulAttempt = true;
                    try
                    {
                        switch (switchValue)
                        {
                            case "1":
                                Console.Write("Column (A-J): ");
                                var column1 = gameBoard.ChangeLetterToNumber((Console.ReadLine().ToUpper()));
                                Console.Write("Row (1-10): ");
                                var row1 = Int32.Parse(Console.ReadLine()) - 1;
                                gameBoard.ToggleIsVisible(column1, row1);
                                IsGuessed = gameBoard.CheckIsGuessed(column1, row1);
                                gameBoard.ToggleIsGuessed(column1, row1);
                                break;
                            case "2":
                                gameBoard.ShowShipTimer(250);
                                break;
                            case "x":
                                return;
                            default:
                                successfulAttempt = false;
                                break;
                        }

                    }
                    catch (Exception)
                    {
                        successfulAttempt = false;
                    }

                    if (successfulAttempt && !IsGuessed)
                        attemptsRemaining--;
                } while (attemptsRemaining > 0);
                gameBoard.DrawGameBoard();
                gameBoard.ShowShipPermanent();
                Console.WriteLine();
                Console.WriteLine("         Good Game!");
                Console.WriteLine();
                Console.WriteLine("Play Again? (y/n)");
                var input = Console.ReadLine().ToUpper();
                if (input != "Y")
                    isPlayAgain = false;
            } while (isPlayAgain);
        }
    }
}
