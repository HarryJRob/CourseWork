using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Text;
using System.IO;

namespace frmMain
{
    class PlayerShip : Ship
    {
        private bool _moveUp, _moveDown, _moveLeft, _moveRight,_spaceBar,_shift = false;
        private int _velocity = 10;
        PictureBox PlayerPictureBox = new PictureBox(); //Can be put in parent class but for simplicity leaving it here

        public void LoadPlayerShip(Form1 frm)
        {
            _Health = 5;
            _BulletImageAddress = @"\PlayerAssets";


            string _rootPath = AppDomain.CurrentDomain.BaseDirectory;
            String[] _pathSeparators = new String[] { "\\" };
            string[] _rootPathSplit = _rootPath.Split(_pathSeparators, StringSplitOptions.RemoveEmptyEntries);
            _rootPathSplit[_rootPathSplit.Length - 2] = null;
            _rootPathSplit[_rootPathSplit.Length - 1] = null;
            _rootPath = string.Join(@" ", _rootPathSplit.Where(s => !String.IsNullOrEmpty(s)));

            _ShipImageAddress = AppDomain.CurrentDomain.BaseDirectory  + @"PlayerAssets\Player.png";

            PlayerPictureBox.Location = new Point(20 , 20);
            PlayerPictureBox.Name = "PlayerPictureBox";
            PlayerPictureBox.Image = new Bitmap(_ShipImageAddress);
            PlayerPictureBox.Size = new Size(PlayerPictureBox.Image.Size.Width, PlayerPictureBox.Image.Size.Height);
            frm.Controls.Add(PlayerPictureBox);
        }

        public bool MoveUp
        {
            get
            {
                return _moveUp;
            }
            set
            {
                _moveUp = value;
            }
        }

        public bool MoveDown
        {
            get
            {
                return _moveDown;
            }
            set
            {
                _moveDown = value;
            }
        }

        public bool MoveRight
        {
            get
            {
                return _moveRight;
            }
            set
            {
                _moveRight = value;
            }
        }

        public bool MoveLeft
        {
            get
            {
                return _moveLeft;
            }
            set
            {
                _moveLeft = value;
            }
        }

        public bool SpaceBar
        {
            get
            {
                return SpaceBar;
            }
            set
            {
                _spaceBar = value;
            }
        }   //Fire

        public bool Shift
        {
            get
            {
                return _shift;
            }
            set
            {
                _shift = value;
            }
        }      //Boost

        public void KeyDown(KeyEventArgs e,int controlsAllowed) //1 = WASD, 2 = UpDownLeftRight, 3 = Both
        {
            if (controlsAllowed == 1)
            {

            }
            else if (controlsAllowed == 2)
            {

            }
            else if (controlsAllowed == 3)
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
                {
                   _moveUp = true;
                }

                if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
                {
                    _moveLeft = true;
                }

                if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
                {
                    _moveRight = true;
                }

                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
                {
                    _moveDown = true;
                }
                if (e.KeyCode == Keys.ShiftKey)
                {
                    _shift = true;
                }
                if (e.KeyCode == Keys.Space)
                {
                    _spaceBar = true;
                }
            }
        }

        public void KeyUp(KeyEventArgs e, int controlsAllowed)
        {
            if (controlsAllowed == 1)
            {

            }
            else if (controlsAllowed == 2)
            {

            }
            else if (controlsAllowed == 3)
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
                {
                    _moveUp = false;
                }

                if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
                {
                    _moveLeft = false;
                }

                if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
                {
                    _moveRight = false;
                }

                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
                {
                    _moveDown = false;
                }
                if (e.KeyCode == Keys.ShiftKey)
                {
                    _shift = false;
                }
                if (e.KeyCode == Keys.Space)
                {
                    _spaceBar = false;
                }
            }
        }

        public void ActionCheck(Form1 frm)
        {
            if (_moveUp)
            {
                PlayerPictureBox.Location = new Point(PlayerPictureBox.Location.X, PlayerPictureBox.Location.Y - _velocity); //Negative is Up
            }
            if (_moveDown)
            {
                PlayerPictureBox.Location = new Point(PlayerPictureBox.Location.X, PlayerPictureBox.Location.Y + _velocity);
            }
            if (_moveLeft)
            {
                PlayerPictureBox.Location = new Point(PlayerPictureBox.Location.X - _velocity, PlayerPictureBox.Location.Y); //Negative is left
            }
            if (_moveRight)
            {
                PlayerPictureBox.Location = new Point(PlayerPictureBox.Location.X + _velocity, PlayerPictureBox.Location.Y);
            }
            if (_spaceBar)
            {
                Ship.FireBullet(false, frm);
                _spaceBar = false;
            }
            if (_shift)
            {
                _velocity = 20;
            }
            else
            {
                _velocity = 5;
            }
        }
    }
}
