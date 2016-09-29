using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace frmMain
{
     public class Ship 
    {
       protected byte _health;
       protected string _shipImageAddress = "";
       protected string _bulletImageAddress = "";
       protected PictureBox _ShipPictureBox = new PictureBox();
       protected List<Bullet> Bullets = new List<Bullet> { };

       public virtual void FireBullet(Form1 frm)
       {

       }

       public static void LoadResizeImage(PictureBox _passedImage, string _localPath,int _width,int _height) //picturebox object, local path (within project folder), desired width, desired height
       {
           try
           {
               string _rootPath = AppDomain.CurrentDomain.BaseDirectory;
               string _fullAddress;
               String[] _pathSeparators = { "\\" };
               string[] _rootPathSplit = _rootPath.Split(_pathSeparators, StringSplitOptions.RemoveEmptyEntries);
               _rootPathSplit[_rootPathSplit.Length - 3] = null;
               _rootPathSplit[_rootPathSplit.Length - 2] = null;
               _rootPathSplit[_rootPathSplit.Length - 1] = null;
               _rootPath = string.Join(@"\", _rootPathSplit.Where(s => !String.IsNullOrEmpty(s)));

               _fullAddress = _rootPath + @_localPath;

               Bitmap TempImage = new Bitmap(Image.FromFile(_fullAddress));

               _passedImage.Image = new Bitmap(TempImage, new Size(_width, _height));
               _passedImage.Size = new Size(_passedImage.Image.Size.Width, _passedImage.Image.Size.Height);
           }
           catch (Exception)
           {
               MessageBox.Show("Error loading file - Please check you have all required resources");
               Application.Exit();
           } 
       }
    }

}
