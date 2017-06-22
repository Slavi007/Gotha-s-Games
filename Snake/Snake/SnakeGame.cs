using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    public class SnakeGame
    {
        public static void Game()
        {
           //declaring the default paramaters
            Console.CursorVisible = false;
            byte right = 0;
            byte left = 1;
            byte down = 2;
            byte up = 3;
            int lastFoodTime = 0;
            int foodDissapearTime = 9000;
            double sleepTime = 100;
            int direction = right;
            Random randomNumbersGenerator = new Random();
            Console.BufferHeight = Console.WindowHeight;
            lastFoodTime = Environment.TickCount;

            Position[] directions = new Position[]    // declaring the directions
            {
                new Position(0, 1), // right
                new Position(0, -1), // left
                new Position(1, 0), // down
                new Position(-1, 0), // up
            };

            List<Position> obstacles =     // declaring the the default positions of the obstacles
                new List<Position>()
            {
                new Position((randomNumbersGenerator.Next(1,Console.WindowHeight)),randomNumbersGenerator.Next(1,Console.WindowWidth)),
                new Position((randomNumbersGenerator.Next(1,Console.WindowHeight)),randomNumbersGenerator.Next(1,Console.WindowWidth)),
                new Position((randomNumbersGenerator.Next(1,Console.WindowHeight)),randomNumbersGenerator.Next(1,Console.WindowWidth)),
                new Position((randomNumbersGenerator.Next(1,Console.WindowHeight)),randomNumbersGenerator.Next(1,Console.WindowWidth)),
                new Position((randomNumbersGenerator.Next(1,Console.WindowHeight)),randomNumbersGenerator.Next(1,Console.WindowWidth)),
            };
            foreach (Position obstacle in obstacles)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(
                    obstacle.col,
                    obstacle.row);
                Console.Write("X");
            }

            Queue<Position> snakeElements =             // declaring the snake
                new Queue<Position>();
            for (int i = 0; i <= 5; i++)
            {
                snakeElements.Enqueue(new Position(0, i));
            }

            Position food;          //declaring the apple
            do
            {
                food = new Position(
                    randomNumbersGenerator.Next(0,
                        Console.WindowHeight),
                    randomNumbersGenerator.Next(0,
                        Console.WindowWidth));
            }
            while (snakeElements.Contains(food) ||
                   obstacles.Contains(food));
            Console.SetCursorPosition(food.col, food.row);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("@");

            foreach (Position position in snakeElements)
            {
                Console.SetCursorPosition(
                    position.col,
                    position.row);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write((char)149);
            }

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo userInput = Console.ReadKey();
                    if (userInput.Key == ConsoleKey.LeftArrow)
                    {
                        if (direction != right) direction = left;
                    }
                    if (userInput.Key == ConsoleKey.RightArrow)
                    {
                        if (direction != left) direction = right;
                    }
                    if (userInput.Key == ConsoleKey.UpArrow)
                    {
                        if (direction != down) direction = up;
                    }
                    if (userInput.Key == ConsoleKey.DownArrow)
                    {
                        if (direction != up) direction = down;
                    }
                }

                Position snakeHead = snakeElements.Last();
                Position nextDirection = directions[direction];

                Position snakeNewHead = new Position(
                    snakeHead.row + nextDirection.row,
                    snakeHead.col + nextDirection.col);

                if (snakeNewHead.col < 0)
                    snakeNewHead.col = Console.WindowWidth - 1;
                if (snakeNewHead.row < 0)
                    snakeNewHead.row = Console.WindowHeight - 1;
                if (snakeNewHead.row >= Console.WindowHeight)
                    snakeNewHead.row = 0;
                if (snakeNewHead.col >= Console.WindowWidth)
                    snakeNewHead.col = 0;

                if (snakeElements.Contains(snakeNewHead)
                    || obstacles.Contains(snakeNewHead))
                {
                    Console.Clear();
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 13, Console.WindowHeight / 2 - 1);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    int userPoints = (snakeElements.Count - 6) * 100;
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.Error);
                    player.Play();
                    Console.WriteLine(@"Game over! Your points are: {0}", userPoints);
                    Thread.Sleep(3000);
                    Console.Clear();
                    SnakeReset.Reset();                   // Asking for a replay?
                    return;
                }

                Console.SetCursorPosition(
                    snakeHead.col,
                    snakeHead.row);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write((char)149);

                snakeElements.Enqueue(snakeNewHead);
                Console.SetCursorPosition(
                    snakeNewHead.col,
                    snakeNewHead.row);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                if (direction == right) Console.Write(">");
                if (direction == left) Console.Write("<");
                if (direction == up) Console.Write("^");
                if (direction == down) Console.Write("v");


                if (snakeNewHead.col == food.col &&
                    snakeNewHead.row == food.row)
                {
                                                              // feeding the snake
                    do
                    {
                        food = new Position(
                            randomNumbersGenerator.Next(0,
                                Console.WindowHeight),
                            randomNumbersGenerator.Next(0,
                                Console.WindowWidth));
                    }
                    while (snakeElements.Contains(food) ||
                        obstacles.Contains(food));
                    lastFoodTime = Environment.TickCount;
                    Console.SetCursorPosition(
                        food.col,
                        food.row);
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.Apple);
                    player.Play();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("@");                
                    sleepTime -= 0.02;

                    Position obstacle = new Position();
                    do
                    {
                        obstacle = new Position(
                            randomNumbersGenerator.Next(0,
                                Console.WindowHeight),
                            randomNumbersGenerator.Next(0,
                                Console.WindowWidth));
                    }
                    while (snakeElements.Contains(obstacle) ||
                        obstacles.Contains(obstacle) ||
                        (food.row != obstacle.row &&
                        food.col != obstacle.row));
                    obstacles.Add(obstacle);
                    Console.SetCursorPosition(
                        obstacle.col,
                        obstacle.row);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("X");
                }
                else
                {
                    // moving...
                    Position last = snakeElements.Dequeue();
                    Console.SetCursorPosition(last.col, last.row);
                    Console.Write(" ");
                }

                if (Environment.TickCount - lastFoodTime >=
                    foodDissapearTime)
                {
                    Console.SetCursorPosition(food.col, food.row);
                    Console.Write(" ");
                    do
                    {
                        food = new Position(
                            randomNumbersGenerator.Next(0,
                            Console.WindowHeight),
                            randomNumbersGenerator.Next(0,
                            Console.WindowWidth));
                    }
                    while (snakeElements.Contains(food) ||
                        obstacles.Contains(food));
                    lastFoodTime = Environment.TickCount;
                }

                Console.SetCursorPosition(food.col, food.row);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("@");

                sleepTime -= 0.02;

                Thread.Sleep((int)sleepTime);
            }
        }
    }
}
