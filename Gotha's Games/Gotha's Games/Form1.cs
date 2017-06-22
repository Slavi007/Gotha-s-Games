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
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.Sound);
            player.Play();
            Process.Start("Snake.exe");   //Starting Snake.exe from the debug folder.
        }

        private void btTron_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.Sound);
            player.Play();
            Process.Start("TronGame.exe");  //Starting TronGame.exe from the debug folder.
        }

        private void btBrickBreaker_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.Sound);
            player.Play();
            Process.Start("BricksBreaker.exe");  //Starting BricksBreaker.exe from the debug folder.
        }

        private void btPingPong_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.Sound);
            player.Play();
            Process.Start("PingPong.exe");  //Starting PingPong.exe from the debug folder.
        }

        private void btTicTacToe_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.Sound);
            player.Play();
            Process.Start("Tic-Tac-Toe.exe");  //Starting Tic-Tac-Toe.exe from the debug folder.
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
