using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Text;

namespace Snake
{
    public struct Position  //declaring the structure for the cordinates
    {
        public int row;
        public int col;
        public Position(int row, int col)
        {
            this.row = row;
            this.col = col;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SnakeMenu.Menu();
        }      
    }
  }