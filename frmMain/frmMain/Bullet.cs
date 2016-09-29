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
        protected string _bulletImageLocationPath;
        protected bool _enemyFire; // false = friendly, true = enemy
        protected PictureBox _bulletPictureBox = new PictureBox();
        //protected byte _specialEffects; //Exclude for now

        public Bullet(int Velocity, int Damage, string BulletImagePath,bool EnemyFire, Form1 frm, Point ShipLocation) //Velocity, Damage, ImageLocation, Form
        {
            System.Windows.Forms.MessageBox.Show("Hello, World ");
            _velocity = Velocity;
            _damage = Damage;
            _bulletImageLocationPath = BulletImagePath;
            _enemyFire = EnemyFire;

            _bulletPictureBox.BackColor = System.Drawing.Color.Red;
            _bulletPictureBox.Location = ShipLocation;
            frm.Controls.Add(_bulletPictureBox);
        }
    }
}
