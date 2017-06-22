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
            Process.Start(Properties.Resources.Snake1);   //Starting Snake.exe from the debug folder.
        }

        private void btTron_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.Sound);
            player.Play();
            Process.Start(Properties.Resources.TronGame);  //Starting TronGame.exe from the debug folder.
        }

        private void btBrickBreaker_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.Sound);
            player.Play();
            Process.Start(Properties.Resources.BricksBreaker);  //Starting BricksBreaker.exe from the debug folder.
        }

        private void btPingPong_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.Sound);
            player.Play();
            Process.Start(Properties.Resources.PingPong);  //Starting PingPong.exe from the debug folder.
        }

        private void btTicTacToe_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.Sound);
            player.Play();
            Process.Start(Properties.Resources.Tic_Tac_Toe);  //Starting Tic-Tac-Toe.exe from the debug folder.
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
