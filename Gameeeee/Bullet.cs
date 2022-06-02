using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;

namespace Gameeeee
{
    class Bullet
    {
        public string direction; // creating a public string called direction
        public int bulletLeft; // create a new public integer
        public int bulletTop; // create a new public integer

        private int speed = 20; // creating a integer called speed and assigning a value of 20
        private PictureBox bullet = new PictureBox(); // create a picture box 
        private System.Windows.Forms.Timer bulletTimer = new System.Windows.Forms.Timer();

        public void MakeBullet(Form form)
        {
            bullet.BackColor = Color.White;
            bullet.Size = new Size(5, 5);
            bullet.Tag = "bullet";
            bullet.Left = bulletLeft;
            bullet.Top = bulletTop;
            bullet.BringToFront();

            form.Controls.Add(bullet);

            bulletTimer.Interval = speed;
            bulletTimer.Tick += new EventHandler(BulletTimerEvent);
            bulletTimer.Start();

        }
        public void BulletTimerEvent(object sender, EventArgs e)
        {
            // if direction equals to left
            if (direction == "left")
            {
                bullet.Left -= speed; // move bullet towards the left of the screen
            }
            // if direction equals right
            if (direction == "right")
            {
                bullet.Left += speed; // move bullet towards the right of the screen
            }
            // if direction is up
            if (direction == "up")
            {
                bullet.Top -= speed; // move the bullet towards top of the screen
            }
            // if direction is down
            if (direction == "down")
            {
                bullet.Top += speed; // move the bullet bottom of the screen
            }

            if (bullet.Left < 10 || bullet.Left > 860 || bullet.Top < 10 || bullet.Top > 600)
            {
                bulletTimer.Stop();
                bulletTimer.Dispose();
                bullet.Dispose();
                bulletTimer = null;
                bullet = null;

            }
        }
    }


}