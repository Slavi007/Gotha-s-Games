namespace TronGame
{
    using System;
    using System.Runtime.InteropServices;
    using System.Threading;
    public class Startup
    {
        private static int left = 0;
        private static int right = 1;
        private static int up = 2;
        private static int down = 3;

        static int firstPlayerScore = 0;
        static int firstPlayerDirection = right;
        static int firstPlayerColumn = 0;
        static int firstPlayerRow = 15;

        static int secondPlayerScore = 0;
        static int secondPlayerDirection = left;
        static int secondPlayerColumn = 99;
        static int secondPlayerRow = 15;

        static bool[,] isUsed;

        public static void Main(string[] args)
        {
            SetGameField();
            isUsed = new bool[Console.WindowWidth, Console.WindowHeight];

            while (true)
            {
               if(Console.KeyAvailable)
               { 
                    var key = Console.ReadKey(true);
                    ChangePlayerDirection(key);
               }

                MovePlayer();

                var firstPlayerLoses = DoesPlayersLose(firstPlayerRow, firstPlayerColumn);
                var secondPlayerLoses = DoesPlayersLose(secondPlayerRow, secondPlayerColumn);

                if (firstPlayerLoses && secondPlayerLoses)
                {
                    firstPlayerScore++;
                    secondPlayerScore++;
                    Console.WriteLine();
                    Console.WriteLine("Come over");
                    Console.WriteLine("Draw game!!!");
                    Console.WriteLine($"Current score: {firstPlayerScore} - {secondPlayerScore}");
                    ResetGame();
                }
                else if (firstPlayerLoses)
                {
                    secondPlayerScore++;
                    Console.WriteLine();
                    Console.WriteLine("Game over");
                    Console.WriteLine("Second player wins!");
                    Console.WriteLine($"Current score: {firstPlayerScore} - {secondPlayerScore}");
                    ResetGame(); ;
                }
                else if (secondPlayerLoses)
                {
                    firstPlayerScore++;
                    Console.WriteLine();
                    Console.WriteLine("Game over");
                    Console.WriteLine("First player wins!");
                    Console.WriteLine($"Current score: {firstPlayerScore} - {secondPlayerScore}");
                    ResetGame();
                }

                isUsed[firstPlayerColumn, firstPlayerRow] = true;
                isUsed[secondPlayerColumn, secondPlayerRow] = true;

                WriteOnPosition(firstPlayerColumn, firstPlayerRow, '*', ConsoleColor.Blue);
                WriteOnPosition(secondPlayerColumn, secondPlayerRow, '*', ConsoleColor.DarkYellow);

              Thread.Sleep(100);
            }
        }

        private static void ResetGame()
        {
            isUsed = new bool[Console.WindowWidth, Console.WindowHeight];
            firstPlayerDirection = right;
            secondPlayerDirection = left;
            Console.WriteLine("Press any key to start again");
            Console.ReadKey();
            Console.Clear();;
            MovePlayer();
        }


        private static bool DoesPlayersLose(int row, int col)
        {
            if (row < 0)
            {
                return true;
            }
            else if (col < 0)
            {
                return true;
            }
            else if (row >= Console.WindowHeight)
            {
                return true;
            }
            else if (col >= Console.WindowWidth)
            {
                return true;
            }
            else if (isUsed[col, row])
            {
                return true;
            }
            return false;
        }

        private static void SetGameField()
        {
            Console.WindowHeight = 30;
            Console.BufferHeight = 30;

            Console.WindowWidth = 100;
            Console.BufferWidth = 100;

            
        }

        private static void MovePlayer()
        {
            if (firstPlayerDirection == right)
            {
                firstPlayerColumn++;
            }
            if (firstPlayerDirection == left)
            {
                firstPlayerColumn--;
            }
            if (firstPlayerDirection == up)
            {
                firstPlayerRow--;
            }
            if (firstPlayerDirection == down)
            {
                firstPlayerRow++;
            }

            if (secondPlayerDirection == right)
            {
                secondPlayerColumn++;
            }
            if (secondPlayerDirection == left)
            {
                secondPlayerColumn--;
            }
            if (secondPlayerDirection == up)
            {
                secondPlayerRow--;
            }
            if (secondPlayerDirection == down)
            {
                secondPlayerRow++;
            }
        }

        static void WriteOnPosition(int x, int y, char c, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(x, y);
            Console.Write(c);
        }

        private static void ChangePlayerDirection(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.W)
            {
                firstPlayerDirection = up;
            }
            else if (key.Key == ConsoleKey.A)
            {
                firstPlayerDirection = left;
            }
            else if (key.Key == ConsoleKey.D)
            {
                firstPlayerDirection = right;
            }
            else if (key.Key == ConsoleKey.S)
            {
                firstPlayerDirection = down;
            }
            else if (key.Key == ConsoleKey.UpArrow)
            {
                secondPlayerDirection = up;
            }
            else if (key.Key == ConsoleKey.LeftArrow)
            {
                secondPlayerDirection = left;
            }
            else if (key.Key == ConsoleKey.RightArrow)
            {
                secondPlayerDirection = right;
            }
            else if (key.Key == ConsoleKey.DownArrow)
            {
                secondPlayerDirection = down;
            }
        }
    }
}
