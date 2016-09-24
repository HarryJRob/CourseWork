using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public struct Bullet
{
    private int ID;
    enum BulletType {Friendly, Enemy}
}

namespace frmMain
{
    public partial class Form1 : Form
    {
        PlayerShip Player1 = new PlayerShip();
        PlayerShip Player2 = new PlayerShip();
        private bool TwoPlayer;

        public Form1()
        {
            TwoPlayer = false;
            InitializeComponent();
            List<Bullet> Bullets = new List<Bullet>();
            if (TwoPlayer)
            {
                Player1.LoadPlayerShip(this);
                Player2.LoadPlayerShip(this);
            }
            else
            {
               
                Player1.LoadPlayerShip(this);
                Player2 = null;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        /*I should be able to encapsulate this!
        * If i do i can have another player with their own controls e.g. If instantiated with 1 as parameter then responds to WASD if 2 then Up,Down,Left,Right otherwise allow both
         * Done!
        */

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
        } //Same again

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
