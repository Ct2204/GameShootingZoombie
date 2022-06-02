using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gameeeee
{
    public partial class Form2 : Form
    {
        bool goup; // this boolean will be used for the player to go up the screen
        bool godown; // this boolean will be used for the player to go down the screen
        bool goleft; // this boolean will be used for the player to go left to the screen
        bool goright; // this boolean will be used for the player to right to the screen
        string facing = "up"; // this string is called facing and it will be used to guide the bullets
        double playerHealth = 100; // this double variable is called player health
        int speed = 10; // this integer is for the speed of the player
        int ammo = 50; // this integer will hold the number of ammo the player has start of the game
        int zombieSpeed = 3; // this integer will hold the speed which the zombies move in the game
        int score = 0; // this integer will hold the score the player achieved through the game
        int highScore = 0;
        bool gameOver = false; // this boolean is false in the beginning and it will be used when the game is finished
        Random randNum = new Random();

        List<PictureBox> zoombieslist = new List<PictureBox>();
        public Form2()
        {
            InitializeComponent();
            RestartGame();
        }

        private void MainTimerEvent(object sender, EventArgs e)
        {

            if (playerHealth > 1) // if player health is greater than 1
            {
                healthBar.Value = Convert.ToInt32(playerHealth); // assign the progress bar to the player health integer
            }
            else
            {
                gameOver = true;
                player.Image = Properties.Resources.dead;
                GameTimer.Stop();

            }


            txtAmmo.Text = "   Ammo:  " + ammo; // show the ammo amount on label 1
            txtScore.Text = "Kills: " + score; // show the total kills on the score



            if (goleft && player.Left > 0)
            {
                player.Left -= speed;
                // if moving left is true AND pacman is 1 pixel more from the left 
                // then move the player to the LEFT
            }
            if (goright && player.Left + player.Width < 900)
            {
                player.Left += speed;
                // if moving RIGHT is true AND player left + player width is less than 930 pixels
                // then move the player to the RIGHT
            }
            if (goup && player.Top > 60)
            {
                player.Top -= speed;
                // if moving TOP is true AND player is 60 pixel more from the top 
                // then move the player to the UP
            }

            if (godown && player.Top + player.Height < 650)
            {
                player.Top += speed;
                // if moving DOWN is true AND player top + player height is less than 700 pixels
                // then move the player to the DOWN
            }
            foreach (Control x in this.Controls)
            {
                // if the X is a picture box and X has a tag AMMO

                if (x is PictureBox && x.Tag == "ammo")
                {
                    // check is X in hitting the player picture box

                    if (((PictureBox)x).Bounds.IntersectsWith(player.Bounds))
                    {
                        // once the player picks up the ammo

                        this.Controls.Remove(((PictureBox)x)); // remove the ammo picture box

                        ((PictureBox)x).Dispose(); // dispose the picture box completely from the program
                        ammo += 10; // add 10 ammo to the integer
                    }
                }
                // heart
                if (x is PictureBox && x.Tag == "heart")
                {


                    if (((PictureBox)x).Bounds.IntersectsWith(player.Bounds))
                    {
                        this.Controls.Remove(((PictureBox)x));

                        ((PictureBox)x).Dispose();
                        playerHealth += 10;
                    }
                }
                if (x is PictureBox && x.Tag == "zombie")
                {

                    // below is the if statament thats checking the bounds of the player and the zombie

                    if (((PictureBox)x).Bounds.IntersectsWith(player.Bounds))
                    {
                        playerHealth -= 1; // if the zombie hits the player then we decrease the health by 1
                    }

                    //move zombie towards the player picture box

                    if (((PictureBox)x).Left > player.Left)
                    {
                        ((PictureBox)x).Left -= zombieSpeed; // move zombie towards the left of the player
                        ((PictureBox)x).Image = Properties.Resources.zleft; // change the zombie image to the left
                    }

                    if (((PictureBox)x).Top > player.Top)
                    {
                        ((PictureBox)x).Top -= zombieSpeed; // move zombie upwards towards the players top
                        ((PictureBox)x).Image = Properties.Resources.zup; // change the zombie picture to the top pointing image
                    }
                    if (((PictureBox)x).Left < player.Left)
                    {
                        ((PictureBox)x).Left += zombieSpeed; // move zombie towards the right of the player
                        ((PictureBox)x).Image = Properties.Resources.zright; // change the image to the right image
                    }
                    if (((PictureBox)x).Top < player.Top)
                    {
                        ((PictureBox)x).Top += zombieSpeed; // move the zombie towards the bottom of the player
                        ((PictureBox)x).Image = Properties.Resources.zdown; // change the image to the down zombie
                    }
                }
                foreach (Control j in this.Controls)
                {
                    // below is the selection thats identifying the bullet and zombie

                    if (j is PictureBox && (string)j.Tag == "bullet" && x is PictureBox && (string)x.Tag == "zombie")
                    {
                        // below is the if statement thats checking if bullet hits the zombie
                        if (x.Bounds.IntersectsWith(j.Bounds))
                        {
                            score++; // increase the kill score by 1 
                            if (score % 10 == 0)
                            {
                                DropHeart();
                            }

                            this.Controls.Remove(j); // this will remove the bullet from the screen
                            j.Dispose(); // this will dispose the bullet all together from the program
                            this.Controls.Remove(x); // this will remove the zombie from the screen
                            x.Dispose(); // this will dispose the zombie from the program
                            MakeZoombies(); // this function will invoke the make zombies function to add another zombie to the game
                            if(score == 20)
                            {
                                nextLevle();
                            }
                        }
                    }
                }
            }

        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (gameOver == true)
            {
                return;
            }


            // if the left key is pressed then do the following
            if (e.KeyCode == Keys.Left)
            {
                goleft = true; // change go left to true
                facing = "left"; //change facing to left
                player.Image = Properties.Resources.left; // change the player image to LEFT image
            }

            // end of left key selection

            // if the right key is pressed then do the following
            if (e.KeyCode == Keys.Right)
            {
                goright = true; // change go right to true
                facing = "right"; // change facing to right
                player.Image = Properties.Resources.right; // change the player image to right
            }
            // end of right key selection

            // if the up key is pressed then do the following
            if (e.KeyCode == Keys.Up)
            {
                facing = "up"; // change facing to up
                goup = true; // change go up to true
                player.Image = Properties.Resources.up; // change the player image to up
            }

            // end of up key selection

            // if the down key is pressed then do the following
            if (e.KeyCode == Keys.Down)
            {
                facing = "down"; // change facing to down
                godown = true; // change go down to true
                player.Image = Properties.Resources.down; //change the player image to down
            }
            // end of the down key selection

            //below is the key up selection for the space key
            if (e.KeyCode == Keys.Space && ammo > 0) // in this if statement we are checking if the space bar is up and ammo is more than 0

            {
                ammo--; // reduce ammo by 1 from the total number
                ShootBullet(facing); // invoke the shoot function with the facing string inside it
                                     //facing will transfer up, down, left or right to the function and that will shoot the bullet that way. 

                if (ammo < 1) // if ammo is less than 1
                {
                    DropAmmo(); // invoke the drop ammo function
                }


            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            // below is the key up selection for the left key
            if (e.KeyCode == Keys.Left)
            {
                goleft = false; // change the go left boolean to false
            }

            // below is the key up selection for the right key
            if (e.KeyCode == Keys.Right)
            {
                goright = false; // change the go right boolean to false
            }
            // below is the key up selection for the up key
            if (e.KeyCode == Keys.Up)
            {
                goup = false; // change the go up boolean to false
            }
            // below is the key up selection for the down key
            if (e.KeyCode == Keys.Down)
            {
                godown = false; // change the go down boolean to false
            }
            if (e.KeyCode == Keys.Space && ammo > 0 && gameOver == false)
            {

                ShootBullet(facing);
            }
            if (e.KeyCode == Keys.Enter && gameOver == true)
            {
                RestartGame();
            }
        }


        private void ShootBullet(string direction)
        {

            Bullet shootBullet = new Bullet();
            shootBullet.direction = direction;
            shootBullet.bulletLeft = player.Left + (player.Width / 2);
            shootBullet.bulletTop = player.Top + (player.Height / 2);
            shootBullet.MakeBullet(this);
        }

        private void MakeZoombies()
        {
            PictureBox zombie = new PictureBox(); // create a new picture box called zombie
            zombie.Tag = "zombie"; // add a tag to it called zombie
            zombie.Image = Properties.Resources.zdown; // the default picture for the zombie is zdown
            zombie.Left = randNum.Next(0, 940); // generate a number between 0 and 900 and assignment that to the new zombies left randNum
            zombie.Top = randNum.Next(0, 700); // generate a number between 0 and 800 and assignment that to the new zombies top
            zombie.SizeMode = PictureBoxSizeMode.AutoSize; // set auto size for the new picture box
            zoombieslist.Add(zombie);
            this.Controls.Add(zombie); // add the picture box to the screen
            player.BringToFront(); // bring the player to the front
        }
        private void DropHeart()
        {
            PictureBox heart = new PictureBox();
            heart.Image = Properties.Resources.heart;
            heart.SizeMode = PictureBoxSizeMode.AutoSize;
            heart.Left = randNum.Next(10, 890); // set the location to a random left
            heart.Top = randNum.Next(50, 650); // set the location to a random top
            heart.Tag = "heart"; // set the tag to ammo
            this.Controls.Add(heart); // add the ammo picture box to the screen
            heart.BringToFront(); // bring it to front
            player.BringToFront(); // bring the player to front
        }

        private void DropAmmo()
        {
            // this function will make a ammo image for this game

            PictureBox ammo = new PictureBox(); // create a new instance of the picture box
            ammo.Image = Properties.Resources.ammo_Image; // assignment the ammo image to the picture box
            ammo.SizeMode = PictureBoxSizeMode.AutoSize; // set the size to auto size
            ammo.Left = randNum.Next(10, 890); // set the location to a random left
            ammo.Top = randNum.Next(50, 650); // set the location to a random top
            ammo.Tag = "ammo"; // set the tag to ammo
            this.Controls.Add(ammo); // add the ammo picture box to the screen
            ammo.BringToFront(); // bring it to front
            player.BringToFront(); // bring the player to front
        }
        private void RestartGame()
        {
            player.Image = Properties.Resources.up;
            if (score > highScore)
            {
                highScore = score;
                txtHighScore.Text = " High Score : " + highScore;
            }

            foreach (PictureBox i in zoombieslist)
            {
                this.Controls.Remove(i);
            }

            zoombieslist.Clear();

            for (int i = 0; i < 3; i++)
            {
                MakeZoombies();
            }

            godown = false;
            goup = false;
            goleft = false;
            goright = false;
            gameOver = false;

            playerHealth = 100;
            score = 0;
            ammo = 50;

            GameTimer.Start();
        }
        private void nextLevle()
        {
            this.Hide();
            Form3 level3 = new Form3();
            level3.ShowDialog();

        }
    }
}
