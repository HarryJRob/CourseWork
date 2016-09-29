using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace frmMain
{
    public class Bullet
    {
        protected int _velocity;
        protected int _damage;
        protected PictureBox _bulletPictureBox = new PictureBox();
        //protected byte _specialEffects; //Exclude for now

        public Bullet(int Velocity, int Damage, Point ShipPosition,int ShipWidth , Form1 frm, string ImageLocation) //Velocity, Damage, EnemyFire, Poistion, Form, SpecialProperties, ImageLocationPath
        {
            _velocity = Velocity;
            _damage = Damage;
            Ship.LoadResizeImage(_bulletPictureBox, ImageLocation, 25, 25);
            _bulletPictureBox.Location = new Point(ShipPosition.X + ShipWidth, ShipPosition.Y);
            _bulletPictureBox.BackColor = Color.Transparent;
            frm.Controls.Add(_bulletPictureBox);
        }

        public int Velocity 
        {
            get 
            {
                return _velocity ;
            }
            set 
            {
                _velocity = value;
            }
        }
        public int Damage
        {
            get
            {
                return _damage;
            }
            set 
            {
                _damage = value;
            }
        }
        public void MoveBullet()
        {
            _bulletPictureBox.Location = new Point(_bulletPictureBox.Location.X + _velocity, _bulletPictureBox.Location.Y);
            
        }
    }
}
