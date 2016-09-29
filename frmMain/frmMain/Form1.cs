using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frmMain
{
    public partial class Form1 : Form
    {
        PlayerShip Player1 = new PlayerShip();
        PlayerShip Player2 = new PlayerShip();
        private bool TwoPlayer;

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            DialogResult TwoPlayerResult = MessageBox.Show("Would you like to play two player?",
    "How many players?",
    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (TwoPlayerResult == System.Windows.Forms.DialogResult.Yes)
            {
                TwoPlayer = true;
            }
            else
            {
                TwoPlayer = false;
            }

            if (TwoPlayer)
            {
                Player1.LoadPlayerShip(this, 1);
                Player2.LoadPlayerShip(this, 2);
            }
            else
            {

                Player1.LoadPlayerShip(this, 3);
                Player2 = null;
            }
            this.GameTick.Enabled = true;
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (TwoPlayer)
            {
                Player1.KeyDown(e, 1);
                Player2.KeyDown(e, 2);
            }
            else
            {
                Player1.KeyDown(e, 3);
            }

            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        } 

        private void frmMain_KeyUp(object sender, KeyEventArgs e)
        {
            if (TwoPlayer)
            {
                Player1.KeyUp(e, 1);
                Player2.KeyUp(e, 2);
            }
            else
            {
                Player1.KeyUp(e, 3);
            }
        } 

        private void GameTick_Tick(object sender, EventArgs e)
        {
            /* Used for:
             * Collision checks
             * Enemy Movement / Firing
             */
            
            //There has to be a better way to do this!
            if (TwoPlayer)
            {
                Player1.ActionCheck(this);
                Player2.ActionCheck(this);
            }
            else
            {
                Player1.ActionCheck(this);
            }
        }
    }
}
