using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
   public class SnakeMenu
    {
        public static void Menu()
        { 
                Console.CursorVisible = false; //Removes the bliking line
                drawMenu(new string[] {
                "-New game",
                "-Exit",
            });
            }
        public static int drawMenu(string[] menuItems)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(Console.WindowWidth / 2 - 11, Console.WindowHeight / 2 - 1);
            Console.WriteLine("WELCOME TO SNAKE!");
            Console.SetCursorPosition(0, 0);
            int selectedItem = 0;
            while (true)
            {
                for (int i = 0; i < menuItems.Length; i++)
                {
                    if (selectedItem == i)
                    {
                        Console.SetCursorPosition(Console.WindowWidth / 2 - 11, Console.WindowHeight / 2 - 1);
                        Console.WriteLine("WELCOME TO SNAKE!");
                        Console.SetCursorPosition(0, 0);
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition((Console.WindowWidth) / 2 - 7, Console.WindowHeight / 2 + (i));
                        Console.WriteLine(menuItems[i]);
                        Console.SetCursorPosition((Console.WindowWidth) / 2- 7, Console.WindowHeight / 2 + (i + 1));
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.SetCursorPosition(Console.WindowWidth / 2 - 11, Console.WindowHeight / 2 - 1);
                        Console.WriteLine("WELCOME TO SNAKE!");
                        Console.SetCursorPosition(0, 0);
                        Console.SetCursorPosition((Console.WindowWidth) / 2 - 7, Console.WindowHeight / 2 + (i));
                        Console.WriteLine(menuItems[i]);
                        Console.SetCursorPosition((Console.WindowWidth) / 2 - 7, Console.WindowHeight / 2 + (i + 1));
                    }
                }

                ConsoleKeyInfo cki = Console.ReadKey();

                switch (cki.Key)
                {
                    case ConsoleKey.UpArrow:
                        if ((selectedItem - 1) < 0)
                        {
                            selectedItem = menuItems.Length - 1;
                        }
                        else
                        {
                            selectedItem--;
                        }

                        break;
                    case ConsoleKey.DownArrow:
                        if ((selectedItem + 1) > menuItems.Length - 1)
                        {
                            selectedItem = 0;
                        }
                        else
                        {
                            selectedItem++;
                        }
                        break;


                    case ConsoleKey.Enter:

                        if (menuItems[selectedItem] == "-Exit")
                        {
                            System.Media.SoundPlayer player = new System.Media.SoundPlayer("Sound.wav");
                            player.Play();
                            Thread.Sleep(1000);
                            Environment.Exit(0);
                        }
                        else
                        {
                            Console.Clear();
                            System.Media.SoundPlayer player = new System.Media.SoundPlayer("Sound.wav");
                            player.Play();              // play the game
                            SnakeGame.Game();       
                        }
                        break;
                }
                Console.SetCursorPosition(Console.WindowWidth / 2 - 11, Console.WindowHeight / 2 - 1);
                Console.WriteLine("WELCOME TO SNAKE!");
                Console.SetCursorPosition(0, 0);
                Console.Clear();
            }
        }
    }
  }