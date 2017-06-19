using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PingPong
{
    public class Program
    {
        static int ballPositionX = 5;
        static int ballPositionY = 5;
        static bool ballDirectionUp = true;
        static bool ballDirectionRight = true;
        static int firstPlayerPosition = 0;
        static int secondPlayerPosition = 0;
        static int firstPlayerPadSize = 8;
        static int secondPlayerPadSize = 6;
        static int firstPlayerResult = 0;
        static int secondPlayerResult = 0;
        static Random randomGenerator = new Random();

        static void Main(string[] args)
        {
            RemoveScrollBars();
            SetInitialPositions();

            while (firstPlayerResult != 5 && secondPlayerResult != 5)
            {
                Console.CursorVisible = false;
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        MoveFirstPlayerUp();
                    }
                    if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        MoveFirstPlayerDown();
                    }
                }

                SecondPlayerAIMove();
                MoveBall();
                Console.Clear();
                DrawFirstPlayer();
                DrawSecondPlayer();
                DrawBall();
                PrintResult();
                Thread.Sleep(60);
            }


            if (firstPlayerResult == 5)
            {
                Console.SetCursorPosition(0,0);
                Console.WriteLine("FIRST PLAYER WINS THE GAME!");
                Console.ReadKey();
            }

            if (secondPlayerResult == 5)
            {
                Console.SetCursorPosition(0,0);
                Console.WriteLine("SECOND PLAYER WINS THE GAME!");
                Console.ReadKey();
            }
        }

        private static void MoveBall()
        {
            if (ballPositionY == 0)
            {
                ballDirectionUp = false;
            }

            if (ballPositionY == Console.WindowHeight - 1)
            {
                ballDirectionUp = true;
            }

            if (ballPositionX == Console.WindowWidth - 1)
            {
                SetBallAtMiddle();
                ballDirectionRight = false;
                ballDirectionUp = true;
                firstPlayerResult++;
                Console.SetCursorPosition(0,0);
                Console.WriteLine("First Player Wins The Round!");
                Console.ReadKey();
            }

            if (ballPositionX == 0)
            {
                SetBallAtMiddle();
                ballDirectionRight = true;
                ballDirectionUp = true;
                secondPlayerResult = secondPlayerResult + 1;
                Console.SetCursorPosition(0,0);
                Console.WriteLine("Second Player Wins The Round!");
                Console.ReadKey();
            }

            if (ballPositionX < 3)
            {
                if (ballPositionY >= firstPlayerPosition
                    && ballPositionY < firstPlayerPosition + firstPlayerPadSize)
                {
                    ballDirectionRight = true;
                }
            }

            if (ballPositionX >= Console.WindowWidth - 3 - 1)
            {
                if (ballPositionY >= secondPlayerPosition
                    && ballPositionY < secondPlayerPosition + secondPlayerPadSize)
                {
                    ballDirectionRight = false;
                }
            }

            if (ballDirectionUp)
            {
                ballPositionY--;
            }
            else
            {
                ballPositionY++;
            }

            if (ballDirectionRight)
            {
                ballPositionX++;
            }
            else
            {
                ballPositionX--;
            }
        }

        private static void MoveFirstPlayerDown()
        {
            if (firstPlayerPosition < Console.WindowHeight - firstPlayerPadSize)
            {
                firstPlayerPosition++;
            }
        }

        private static void MoveFirstPlayerUp()
        {
            if (firstPlayerPosition > 0)
            {
                firstPlayerPosition--;
            }
        }


        private static void MoveSecondPlayerDown()
        {
            if (secondPlayerPosition < Console.WindowHeight - secondPlayerPadSize)
            {
                secondPlayerPosition++;
            }
        }

        private static void MoveSecondPlayerUp()
        {
            if (secondPlayerPosition > 0)
            {
                secondPlayerPosition--;
            }
        }

        private static void PrintResult()
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - 1, 0);
            Console.Write("{0}-{1}", firstPlayerResult, secondPlayerResult);
        }

        private static void DrawBall()
        {
            PrintAtPosition(ballPositionX, ballPositionY, '@');
        }

        static void SetBallAtMiddle()
        {
            ballPositionX = Console.WindowWidth / 2;
            ballPositionY = Console.WindowHeight / 2;
        }

        private static void SetInitialPositions()
        {
            firstPlayerPosition = Console.WindowHeight / 2 - firstPlayerPadSize / 2;
            secondPlayerPosition = Console.WindowHeight / 2 - secondPlayerPadSize / 2;
            SetBallAtMiddle();
        }

        static void RemoveScrollBars()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
        }

        static void DrawFirstPlayer()
        {
            for (int y = firstPlayerPosition; y < firstPlayerPosition + firstPlayerPadSize; y++)
            {
                PrintAtPosition(0, y, '*');
            }
        }

        private static void PrintAtPosition(int x, int y, char symbol)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(symbol);
        }

        static void DrawSecondPlayer()
        {
            for (int y = secondPlayerPosition; y < secondPlayerPosition + secondPlayerPadSize; y++)
            {
                PrintAtPosition(Console.WindowWidth - 1, y, '*');
            }
        }

        static void SecondPlayerAIMove()
        {
            int randomNumber = randomGenerator.Next(0, 2);

            if (randomNumber == 0)
            {
                if (ballDirectionUp == true)
                {
                    MoveSecondPlayerUp();
                }
                else
                {
                    MoveSecondPlayerDown();
                }
            }
        }
    }
}
