using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BricksBreaker
{
    class BricksBreaker
    {
        //Symbols
        public static char ballSymbol = '@';
        public static char platformSymbol = '#';
        public static char bricksSymbol = '$';

        //Ball
        public static int ballPointX;
        public static int ballPointY;

        //Movement
        public static int[] directionHorizontal;
        public static int[] directionVertical;
        public static int currentDirectionX;
        public static int currentDirectionY;

        //Platform      
        public static int platformX; //Platform move left and right on X 
        public static readonly int platformY = 33; //Platform don't move on Y. Platform stay only on bottom line.
        public static int platformLenght = 9; //Set platform lenght.

        //Bricks
        public static int[,] bricks;
        public static int bricksOnField;

        //Score
        public static int highScore;

        //lives
        public static int lives;
        public static void Settings()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Title = "Bricks Breaker";
            Console.SetWindowSize(65, 35); //windows width, height.
            Console.SetBufferSize(65, 35); //limit sliders.
            Console.CursorVisible = false; //Hide cursor from console.
            ballPointX = Console.WindowWidth / 2; //Initials ball X position.
            ballPointY = 30; //Initials ball Y position.

            currentDirectionX = 0;
            currentDirectionY = 0;

            directionHorizontal = new int[2] { -1, 1 }; //Left and right direction.
            directionVertical = new int[2] { -1, 1 }; //Up and down direction.

            platformX = Console.WindowWidth / 2 - 4; //Platform position on X.

            bricks = new int[Console.WindowWidth + 1, Console.WindowHeight + 1]; //Set matrix for bricks
            bricksOnField = 0; //Count bricks.
            highScore = 0; //Count score.
            lives = 3; //Count lives in game.
        }


        public static void Menu()
        {
            Console.ForegroundColor = ConsoleColor.Green; //Set color.
            Console.SetCursorPosition(Console.WindowWidth / 2 - 10, 5);
            Console.WriteLine("<< BRICKS BREAKER >>");
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.SetCursorPosition(Console.WindowWidth / 2 - 7, 8);
            Console.WriteLine("Commands:");

            Console.SetCursorPosition(Console.WindowWidth / 2 - 9, 9);
            Console.WriteLine("NEW GAME - start");

            Console.SetCursorPosition(Console.WindowWidth / 2 - 9, 10);
            Console.WriteLine("EXIT - exit");

            Console.SetCursorPosition(Console.WindowWidth / 2 - 10, 15);
            Console.WriteLine("Enter command:");

            var isCorect = false;
            while (!isCorect)
            {
                var command = Console.ReadLine();
                Console.CursorVisible = false;
                if (command == "start")
                {
                    Console.Clear();

                    isCorect = true;
                    break;
                }
                else if (command == "exit")
                {
                    Environment.Exit(1);
                    isCorect = true;
                    break;
                }
            }


        }
        public static void PrintHighScore()
        {
            Console.SetCursorPosition(Console.WindowWidth-9, 0); //Set lokation on HighScore.
            Console.Write("Score: {0}", highScore);
        }

        public static void PrintLives()
        {
            Console.SetCursorPosition(Console.WindowWidth- 25, 0); //Set lokation on lives.
            Console.Write("Lives left: {0}", lives);
        }

        public static void InitialBricks() //Initializing matrix.
        {
            for (int i = 5; i < 15; i++)
            {
                for (int j = 5; j < Console.WindowWidth - 5; j++)
                {
                    bricks[j, i] = 1;
                }
            }
        }

        public static void PrintBricks() //Print bricks on Console.
        {
            for (int i = 0; i < bricks.GetLength(0); i++)
            {
                for (int j = 0; j < bricks.GetLength(1); j++)
                {
                    if (bricks[i, j] != 0)
                    {
                        Console.SetCursorPosition(i, j);
                        Console.Write(bricksSymbol);
                        bricksOnField++;
                    }
                }
            }
        }

        public static void PlatformMovement()
        {
            if (Console.KeyAvailable) //If user is press any button...
            {
                ConsoleKeyInfo key = Console.ReadKey(); //Read pressed button.

                while (Console.KeyAvailable)
                {
                    Console.ReadKey();
                }
                PressKey(key);
            }
        }

        public static void PressKey(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.LeftArrow) //If left arrow is pressed. 
            {
                if (platformX > 0)
                {
                    platformX--; //decrement X
                    Console.SetCursorPosition(platformX + platformLenght, platformY); //Set cursor one symbol less than current
                    Console.Write(' '); //Pring space on last symbol from platform. 
                    PrintPlatform(); //Start printing from current X - 1.
                }
            }
            if (key.Key == ConsoleKey.RightArrow)
            {
                if (platformX + platformLenght < Console.WindowWidth)
                {
                    platformX++; //increment X
                    Console.SetCursorPosition(platformX - 1, platformY); //Set cursor on first symbol.
                    Console.Write(' '); //Print space on first symbol of platform.
                    PrintPlatform(); //Print one symbol on right side of platform.
                }
            }

            if (key.Key == ConsoleKey.Spacebar)
            {
                Console.ReadLine();
            }
        }
        public static void PrintPlatform()
        {
            Console.ForegroundColor = ConsoleColor.Red; //Print every symbol in selected color(red).

            for (int i = platformX; i < platformX + platformLenght; i++)
            {
                Console.SetCursorPosition(i, platformY);
                Console.Write(platformSymbol);
            }

            Console.ResetColor(); //Return original console color.
        }
        public static void BallMovement()
        {
            Console.SetCursorPosition(ballPointX, ballPointY); //Set ball on start coordinates.
            Console.Write(' ');
            ballPointX += directionHorizontal[currentDirectionX]; //Move toward first coordinate X.
            ballPointY += directionVertical[currentDirectionY]; ////Move toward first coordinate Y.
            Console.SetCursorPosition(ballPointX, ballPointY); //Current position.
            Console.Write(ballSymbol); //Ball symbol.          
        }

        public static void CollisionWithBorders() //Checks collisions with borders for X and Y.
        {
            if (ballPointX <= 0)
            {
                ChangeDirectionX();
            }
            if (ballPointX >= Console.WindowWidth - 1)
            {
                ChangeDirectionX();
            }
            if (ballPointY <= 1)
            {
                ChangeDirectionY();
            }
            if (ballPointY >= Console.WindowHeight - 1)
            {
                //ChangeDirectionY();
                throw new IndexOutOfRangeException(); //Game over.
            }
        }

        public static void CollisionWithPlatform()
        {
            if (ballPointX >= platformX - 1 && ballPointX <= platformX + platformLenght + 1 && ballPointY + 1 == platformY) //If ball hit platform change direction and game is on. If ball miss platform  game over.
            {
                ChangeDirectionY();
            }
        }

        public static void CollisionWithBricks()
        {
            if (ballPointY - 1 >= 0 && bricks[ballPointX, ballPointY - 1] != 0) //If ball is not outside borders and if Brick in matrix on position ball X and ball Y-1 
            {
                bricks[ballPointX, ballPointY - 1] = 0; //Clear brick from matrix on this position.
                Console.SetCursorPosition(ballPointX, ballPointY - 1); //Set cursor on this position 
                Console.Write(' '); //Clear brick on console at this position. 
                ChangeDirectionY(); //Redirect ball Y direction.
                highScore += 1; //increment score.
                PrintHighScore(); //Update score.
                bricksOnField--; //Take out brick from all bricks on screen.
            }
            if (ballPointY + 1 < Console.WindowHeight - 2 && bricks[ballPointX, ballPointY + 1] != 0) //If ball is not outside borders and if Brick in matrix on position ball X and ball Y+1 
            {
                bricks[ballPointX, ballPointY + 1] = 0; //Clear brick from matrix on this position.
                Console.SetCursorPosition(ballPointX, ballPointY + 1); //Set cursor on this position 
                Console.Write(' '); //Clear brick on console at this position. 
                ChangeDirectionY(); //Redirect ball Y direction.
                highScore += 1; //increment score.
                PrintHighScore(); //Update score.
                bricksOnField--; //Take out brick from all bricks on screen.
            }
            if (ballPointX + 1 < Console.WindowWidth - 2 && bricks[ballPointX + 1, ballPointY] != 0) //Chech if ballX + 1 is < from right border to avoid exeption and if Brick in matrix on position ball X+1 and ball Y .
            {
                bricks[ballPointX + 1, ballPointY] = 0; //Clear brick from matrix on this position.
                Console.SetCursorPosition(ballPointX + 1, ballPointY); //Set cursor on this position 
                Console.Write(' '); //Clear brick on console at this position. 
                ChangeDirectionX(); //Redirect ball X direction.
                highScore += 1; //increment score.
                PrintHighScore(); //Update score.
                bricksOnField--; //Take out brick from all bricks on screen.
            }
            if (ballPointX - 1 >= 0 && bricks[ballPointX - 1, ballPointY] != 0) //Chech if ball is >= 0 to avoid exeption and if Brick in matrix on position ball X-1 and ball Y. 
            {
                bricks[ballPointX - 1, ballPointY] = 0; //Clear brick from matrix on this position.
                Console.SetCursorPosition(ballPointX - 1, ballPointY); //Set cursor on this position 
                Console.Write(' '); //Clear brick on console at this position. 
                ChangeDirectionX(); //Redirect ball X direction.
                highScore += 1; //increment score.
                PrintHighScore(); //Update score.
                bricksOnField--; //Take out brick from all bricks on screen.
            }

        }

        public static void ChangeDirectionX() //When collision with borders ocure change ball direction for X.
        {
            if (currentDirectionX == 0)
            {
                currentDirectionX = 1;
            }
            else
            {
                currentDirectionX = 0;
            }
        }

        public static void ChangeDirectionY() //When collision with borders ocure change ball direction for Y.
        {
            if (currentDirectionY == 0)
            {
                currentDirectionY = 1;
            }
            else
            {
                currentDirectionY = 0;
            }
        }
        public static void Engine()
        {
            InitialBricks();
            PrintBricks();
            PrintPlatform();
            PrintHighScore();
            PrintLives();
            int speed = 0;

            while (bricksOnField != 0)
            {
                if (speed % 2 == 0)
                {
                    try
                    {
                        CollisionWithBorders(); //Checks borders collisions.
                    }
                    catch (IndexOutOfRangeException)
                    {
                        lives--;
                        if(lives == 0)
                        {
                            GameOver(); break;
                        }

                        PrintLives();

                        //Clear ball left overs. 
                        Console.SetCursorPosition(ballPointX, ballPointY);
                        Console.Write(' ');

                        //If lives are not over game continue. Restart position on ball ind direction.
                        ballPointX = Console.WindowWidth / 2; //Initials ball X position.
                        ballPointY = 30; //Initials ball Y position.

                        currentDirectionX = 0; //Direction for movement on ball.
                        currentDirectionY = 0; //Direction for movement on ball.
                    }

                    CollisionWithPlatform(); //Ball hit platform.
                    CollisionWithBricks(); //Ball hit bricks.                
                    BallMovement(); //Move ball.
                }

                PlatformMovement(); //Move platform;
                Thread.Sleep(40); //Make ball movement slower. 
                speed++;
                if (speed > 100)
                {
                    speed = 0;
                }
            }

            GameOver();
        }

        public static void GameOver()
        {
            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth / 2 - 5, Console.WindowHeight / 2);
            Console.Beep();
            Console.WriteLine("Game over!");
            Console.ReadLine();
        }

        public static void Main(string[] args)
        {           
            Settings();
            Menu();
            Engine();
        }
    }
}
