using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gotha_s_Games
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("Snake.exe");   //Starting Snake.exe from the debug folder.
        }

        private void btTron_Click(object sender, EventArgs e)
        {
            Process.Start("TronGame.exe");  //Starting TronGame.exe from the debug folder.
        }

        private void btBrickBreaker_Click(object sender, EventArgs e)
        {
            Process.Start("BricksBreaker.exe");  //Starting BricksBreaker.exe from the debug folder.
        }
    }
}
