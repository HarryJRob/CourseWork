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
    public class PlayerShip : Ship
    {
        private bool _moveUp, _moveDown, _moveLeft, _moveRight,_fireBullet,_boost = false;
        private const int _DefaultVelocity = 5;
        private const int _DefaultBoostSpeed = 10;
        private int _vVelocity = _DefaultVelocity; //Velocity handled seperately
        private int _hVelocity = _DefaultVelocity;

        public void LoadPlayerShip(Form1 frm,byte _playerNumber)
        {
            _health = 5;
            _bulletImageAddress = @"\PlayerAssets\Bullet.png";
            LoadResizeImage(_ShipPictureBox, @"\PlayerAssets\Player.png", 90, 90);
            LoadUserInterface(frm, _playerNumber);

            if (_playerNumber == 1)
            {
                _ShipPictureBox.Location = new Point(20, frm.Height / 2 - _ShipPictureBox.Size.Height/2 - 1);
            }
            else if (_playerNumber == 2)
            {
                _ShipPictureBox.Location = new Point(20, frm.Height / 2 + _ShipPictureBox.Size.Height/2 + 1);
            }
            else if (_playerNumber == 3)
            {
                _ShipPictureBox.Location = new Point(20, frm.Height / 2 - _ShipPictureBox.Size.Height);
            }

            frm.Controls.Add(_ShipPictureBox);
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
                if (e.KeyCode == Keys.Enter)
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
                if (e.KeyCode == Keys.ControlKey)
                {
                    _boost = false;
                }
                if (e.KeyCode == Keys.Enter )
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
                if (_vVelocity < _DefaultBoostSpeed)
                {
                    _vVelocity += 1;
                }
                if (_hVelocity < _DefaultBoostSpeed)
                {
                    _hVelocity += 1;
                }

            }
            else 
            {
                if (_vVelocity > _DefaultVelocity)
                {
                    _vVelocity -= 1;
                }
                if (_hVelocity > _DefaultVelocity)
                {
                    _hVelocity -= 1;
                }
            }

            if (_moveUp)
            {
                _ShipPictureBox.Location = new Point(_ShipPictureBox.Location.X, _ShipPictureBox.Location.Y - _hVelocity); //Negative is Up
            }
            if (_moveDown)
            {
                _ShipPictureBox.Location = new Point(_ShipPictureBox.Location.X, _ShipPictureBox.Location.Y + _hVelocity);
            }
            if (_moveLeft)
            {
                _ShipPictureBox.Location = new Point(_ShipPictureBox.Location.X - _vVelocity, _ShipPictureBox.Location.Y); //Negative is left
            }
            if (_moveRight)
            {
                _ShipPictureBox.Location = new Point(_ShipPictureBox.Location.X + _vVelocity, _ShipPictureBox.Location.Y);
            }
            if (_fireBullet)
            {
                _fireBullet = false;
                FireBullet(frm);
            }
            BulletTick(frm);
        }

        public void LoadUserInterface(Form1 frm, byte _playerNumber)
        {
            if (_playerNumber == 1)
            {
                //UI for player 1
            }
            else if (_playerNumber == 2)
            {
                //UI for player 2
            }
            else if (_playerNumber == 3)
            {
                //UI if only 1 player
            }
        }

        public override void FireBullet(Form1 frm)
        {
            base.FireBullet(frm);
            Bullets.Add(new Bullet(20,1,_ShipPictureBox.Location,_ShipPictureBox.Size.Width, frm, _bulletImageAddress)); //Velocity, Damage, EnemyFire, Poistion,Width of PictureBox , Form, SpecialProperties
        }

        public void BulletTick(Form1 frm)
        {
            Bullets.RemoveAll(item => item == null);
            if (Bullets.Count != 0)
            {
                for (int i = 1; i <= Bullets.Count; i++)
                {
                    Bullets[i - 1].MoveBullet();
                    if (!(frm.ClientRectangle.IntersectsWith(Bullets[i-1].BulletPicturebox.Bounds))) 
                    {
                        Bullets[i - 1].BulletPicturebox.Dispose();
                         Bullets [i-1] = null;
                    }
                }
            }
        }
    }
}
