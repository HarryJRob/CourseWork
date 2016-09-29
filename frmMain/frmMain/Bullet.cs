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
        protected int _velocity {get; set;}
        protected int _damage;
        protected PictureBox _bulletPictureBox = new PictureBox();
        //protected byte _specialEffects; //Exclude for now

        public Bullet(int Velocity, int Damage, Point ShipPosition,int ShipWidth , Form1 frm, string ImageLocation) //Velocity, Damage, EnemyFire, Poistion, Form, SpecialProperties, ImageLocationPath
        {
            _velocity = Velocity;
            _damage = Damage;
            //Ship.LoadResizeImage(_bulletPictureBox, ImageLocation, 10, 10);
            _bulletPictureBox.Location = new Point(ShipPosition.X + ShipWidth, ShipPosition.Y);
            _bulletPictureBox.BackColor = Color.Red;
            frm.Controls.Add(_bulletPictureBox);
        }
    }
}
