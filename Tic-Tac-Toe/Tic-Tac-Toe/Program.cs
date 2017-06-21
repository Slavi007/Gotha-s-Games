namespace Tic_Tac_Toe
{
    using System;
    using System.Text;
    using System.Threading;

    public class Program
    {
        static string[] boardPosition = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        static int player = 1;
        static string choice; // The position where the player wants to mark
        static int hasWinner = 0;

        public static void Main()
        {
            string playAgain = string.Empty;
            do
            {
                // Play the game as long as you lant
                Game();
                Console.Write("Play again? (Y / N)");
                playAgain = Console.ReadLine().ToUpper();

                // Clear the board
                Reset();
            } while (playAgain == "Y");
        }

        // Play the game
        private static void Game()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Player 1: X      Player 2: O\n");

                // Ckeck whose turn it is
                if (player % 2 == 0)
                {
                    Console.WriteLine("Player 2\n");
                }
                else
                {
                    Console.WriteLine("Player 1\n");
                }

                // Call the board function
                Board();

                Console.Write("Press 1-9 to place your marker: ");
                choice = Console.ReadLine();

                // Check if the position is free
                FreePosition(choice);

                // Check if there is a winner
                hasWinner = CheckWin();
            } while (hasWinner == 0);

            Console.Clear();
            Board();

            // Show who is the winner
            if (hasWinner == 1)
            {
                Console.WriteLine($"Player {(player % 2) + 1} has won!");
            }
            else if (hasWinner == -1)
            {
                Console.WriteLine("Draw!");
            }
        }

        // Creates the board
        private static void Board()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", boardPosition[1], boardPosition[2], boardPosition[3]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", boardPosition[4], boardPosition[5], boardPosition[6]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", boardPosition[7], boardPosition[8], boardPosition[9]);
            Console.WriteLine("     |     |      ");
        }

        private static void FreePosition(string position)
        {
            int intPosition = 0;
            try
            {
                intPosition = Convert.ToInt32(position);
                if (boardPosition[intPosition] != "X" && boardPosition[intPosition] != "O")
                {
                    if (player % 2 == 0)
                    {
                        boardPosition[intPosition] = "O";
                        player++;
                    }
                    else
                    {
                        boardPosition[intPosition] = "X";
                        player++;
                    }
                }
                else
                {
                    Console.Write($"The position is already marked with {boardPosition[intPosition]}!");
                    Thread.Sleep(1500);
                }
            }
            catch (Exception ex)
            {
                if (ex is FormatException)
                {
                    Console.Write("Not a number!");
                    Thread.Sleep(1500);
                }
                else if (ex is IndexOutOfRangeException)
                {
                    Console.Write("Choise is out of range!");
                    Thread.Sleep(1500);
                }
            }
        }

        // Check if there is a winner
        private static int CheckWin()
        {
            // Winning conditions for rows
            if (boardPosition[1] == boardPosition[2] && boardPosition[2] == boardPosition[3])
            {
                return 1;
            }
            else if (boardPosition[4] == boardPosition[5] && boardPosition[5] == boardPosition[6])
            {
                return 1;
            }
            else if (boardPosition[7] == boardPosition[8] && boardPosition[8] == boardPosition[9])
            {
                return 1;
            }
            // Winning conditions for columns
            else if (boardPosition[1] == boardPosition[4] && boardPosition[4] == boardPosition[7])
            {
                return 1;
            }
            else if (boardPosition[2] == boardPosition[5] && boardPosition[5] == boardPosition[8])
            {
                return 1;
            }
            else if (boardPosition[3] == boardPosition[6] && boardPosition[6] == boardPosition[9])
            {
                return 1;
            }
            // Winning conditions for diagonals
            else if (boardPosition[1] == boardPosition[5] && boardPosition[5] == boardPosition[9])
            {
                return 1;
            }
            else if (boardPosition[3] == boardPosition[5] && boardPosition[5] == boardPosition[7])
            {
                return 1;
            }
            // Checking for a draw
            else if (boardPosition[1] != "1" && boardPosition[2] != "2" && boardPosition[3] != "3" &&
                boardPosition[4] != "4" && boardPosition[5] != "5" && boardPosition[6] != "6" &&
                boardPosition[1] != "7" && boardPosition[8] != "8" && boardPosition[9] != "9")
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        // Reset the board
        private static void Reset()
        {
            for (int i = 0; i < 10; i++)
            {
                boardPosition[i] = Convert.ToString(i);
            }
        }
    }
}
