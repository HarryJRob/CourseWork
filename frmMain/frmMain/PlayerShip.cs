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
        private bool _moveUp, _moveDown, _moveLeft, _moveRight,_fireBullet,_boost = false;
        private const int _DefaultVelocity = 5;
        private const int _DefaultBoostSpeed = 10;
        private int _velocity = _DefaultVelocity;
        PictureBox PlayerPictureBox = new PictureBox(); //Can be put in parent class but for simplicity leaving it here

        public void LoadPlayerShip(Form1 frm,byte PlayerNumber)
        {
            _Health = 5;
            _BulletImageAddress = @"\PlayerAssets";

            string _rootPath = AppDomain.CurrentDomain.BaseDirectory;
            String[] _pathSeparators = { "\\" };
            string[] _rootPathSplit = _rootPath.Split(_pathSeparators, StringSplitOptions.RemoveEmptyEntries);
            _rootPathSplit[_rootPathSplit.Length - 3] = null;
            _rootPathSplit[_rootPathSplit.Length - 2] = null;
            _rootPathSplit[_rootPathSplit.Length - 1] = null;
            _rootPath = string.Join(@"\", _rootPathSplit.Where(s => !String.IsNullOrEmpty(s)));

            _ShipImageAddress = _rootPath  + @"\PlayerAssets\Player.png";

            Bitmap TempImage = new Bitmap(Image.FromFile(_ShipImageAddress));

            PlayerPictureBox.Name = "PlayerPictureBox";
            PlayerPictureBox.Image = new Bitmap(TempImage, new Size(TempImage.Width/5,TempImage.Height/5));
            PlayerPictureBox.Size = new Size(PlayerPictureBox.Image.Size.Width, PlayerPictureBox.Image.Size.Height);

            if (PlayerNumber == 1)
            {
                PlayerPictureBox.Location = new Point(20, frm.Height / 2 - PlayerPictureBox.Size.Height/2 - 1);
            }
            else if (PlayerNumber == 2)
            {
                PlayerPictureBox.Location = new Point(20, frm.Height / 2 + PlayerPictureBox.Size.Height/2 + 1);
            }
            else if (PlayerNumber == 3)
            {
                PlayerPictureBox.Location = new Point(20, frm.Height / 2 - PlayerPictureBox.Size.Height);
            }

            frm.Controls.Add(PlayerPictureBox);
        }

        public void KeyDown(KeyEventArgs e,byte controlsAllowed) //1 = WASD, 2 = UpDownLeftRight, 3 = Both
        {
            if (controlsAllowed == 1)
            {
                if (e.KeyCode == Keys.W)
                {
                    _moveUp = true;
                }

                if (e.KeyCode == Keys.A)
                {
                    _moveLeft = true;
                }

                if (e.KeyCode == Keys.D)
                {
                    _moveRight = true;
                }

                if (e.KeyCode == Keys.S)
                {
                    _moveDown = true;
                }
                if (e.KeyCode == Keys.ShiftKey)
                {
                    _boost = true;
                }
                if (e.KeyCode == Keys.Space)
                {
                    _fireBullet = true;
                }
            }
            else if (controlsAllowed == 2)
            {
                if (e.KeyCode == Keys.Up)
                {
                    _moveUp = true;
                }

                if (e.KeyCode == Keys.Left)
                {
                    _moveLeft = true;
                }

                if (e.KeyCode == Keys.Right)
                {
                    _moveRight = true;
                }

                if (e.KeyCode == Keys.Down)
                {
                    _moveDown = true;
                }
                if (e.KeyCode == Keys.ControlKey) //Oddly doesnt worth with RShift and NumPad 0. Will Question
                {
                    _boost = true;
                }
                if (e.KeyCode == Keys.Divide)
                {
                    _fireBullet = true;
                }
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
                if (e.KeyCode == Keys.ShiftKey )
                {
                    _boost = true;
                }
                if (e.KeyCode == Keys.Space)
                {
                    _fireBullet = true;
                }
            }
        }

        public void KeyUp(KeyEventArgs e, int controlsAllowed)
        {
            if (controlsAllowed == 1)
            {
                if (e.KeyCode == Keys.W)
                {
                    _moveUp = false;
                }

                if (e.KeyCode == Keys.A)
                {
                    _moveLeft = false;
                }

                if (e.KeyCode == Keys.D)
                {
                    _moveRight = false;
                }

                if (e.KeyCode == Keys.S)
                {
                    _moveDown = false;
                }
                if (e.KeyCode == Keys.ShiftKey)
                {
                    _boost = false;
                }
                if (e.KeyCode == Keys.Space)
                {
                    _fireBullet = false;
                }
            }
            else if (controlsAllowed == 2)
            {
                if (e.KeyCode == Keys.Up)
                {
                    _moveUp = false;
                }

                if (e.KeyCode == Keys.Left)
                {
                    _moveLeft = false;
                }

                if (e.KeyCode == Keys.Right)
                {
                    _moveRight = false;
                }

                if (e.KeyCode == Keys.Down)
                {
                    _moveDown = false;
                }
                if (e.KeyCode == Keys.ControlKey )
                {
                    _boost = false;
                }
                if (e.KeyCode == Keys.Divide)
                {
                    _fireBullet = false;
                }
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
                    _boost = false;
                }
                if (e.KeyCode == Keys.Space)
                {
                    _fireBullet = false;
                }
            }
        }

        public void ActionCheck(Form1 frm)
        {
            if (_boost)
            {
                if (_velocity <= _DefaultBoostSpeed)
                {
                    _velocity += 1;
                }

            }
            else if (_velocity >= _DefaultVelocity )
            {
                _velocity -= 1 ;
            }

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
            if (_fireBullet)
            {
                Ship.FireBullet(false, frm);
                _fireBullet = false;
            }
        }
    }
}
