using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Diagnostics;
using System.IO;


namespace SimonSays
{
    public partial class GameScreen : UserControl
    {
        int guessNumber = 0;
        int guessIndex = 0;
        int flashSpeed = 1000;
        Random randNum = new Random();

        //creates sounds for the buttons 
        SoundPlayer blueSound = new SoundPlayer(Properties.Resources.blue);
        SoundPlayer redSound = new SoundPlayer(Properties.Resources.red);
        SoundPlayer yellowSound = new SoundPlayer(Properties.Resources.yellow);
        SoundPlayer greenSound = new SoundPlayer(Properties.Resources.green);

        public GameScreen()
        {
            InitializeComponent();         
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            Form1.patternList.Clear();
            ComputerTurn();
        }

        private void ComputerTurn()
        {
            //slowly speeds up the time between flashes, making it more difficult 
            flashSpeed -= 20;

            //creates a random number from 1-4, to create the pattern 
            Form1.patternList.Add(randNum.Next(1,5));

            //flashes the buttons to show the playable pattern 
            for (guessNumber = 0; guessNumber <  Form1.patternList.Count; guessNumber++)
            {
                Refresh();
                Thread.Sleep(1000);
                if (Form1.patternList[guessNumber] == 1)
                {
                    greenButton.BackColor = Color.GreenYellow;
                    greenSound.Play();
                    Refresh();
                    Thread.Sleep(flashSpeed);
                    greenButton.BackColor = Color.ForestGreen;
                }
                else if (Form1.patternList[guessNumber] == 2)
                {
                    redButton.BackColor = Color.Red;
                    redSound.Play();
                    Refresh();
                    Thread.Sleep(flashSpeed);
                    redButton.BackColor = Color.DarkRed;
                }
                else if (Form1.patternList[guessNumber] == 3)
                {
                    yellowButton.BackColor = Color.Gold;
                    yellowSound.Play();
                    Refresh();
                    Thread.Sleep(flashSpeed);
                    yellowButton.BackColor = Color.Goldenrod;
                }
                else if (Form1.patternList[guessNumber] == 4)
                {
                    blueButton.BackColor = Color.RoyalBlue;
                    blueSound.Play();
                    Refresh();
                    Thread.Sleep(flashSpeed);
                    blueButton.BackColor = Color.DarkBlue;
                }
            }
                Refresh();
        }

        public void GameOver()
        {
            //plays error sound
            SoundPlayer gameOverSound = new SoundPlayer(Properties.Resources.mistake);
            gameOverSound.Play();

            //opens the GameOver screen if the player messes up the pattern 
            Form f = this.FindForm();
            f.Controls.Remove(this);
            GameOverScreen gos = new GameOverScreen();
            f.Controls.Add(gos);
            gos.Location = new Point((f.Width - gos.Width) / 2, (f.Height - gos.Height) / 2);
        }

        #region button presses, in game
        //flashes colour when pushced, and checks if player got the pattern right
        //if not, end game

        private void greenButton_Click(object sender, EventArgs e)
        {
           
            if (Form1.patternList[guessIndex] == 1)
                {
                    greenButton.BackColor = Color.GreenYellow;
                    greenSound.Play();
                    Refresh();
                    Thread.Sleep(800);
                    greenButton.BackColor = Color.ForestGreen;

                    guessIndex++;
                }
            else { GameOver(); }

            if (guessIndex == Form1.patternList.Count())
                {
                    guessIndex = 0;
                    ComputerTurn();
                }   
        }

        private void redButton_Click(object sender, EventArgs e)
        {
            if (Form1.patternList[guessIndex] == 2)
            {
                redButton.BackColor = Color.Red;
                redSound.Play();
                Refresh();
                Thread.Sleep(800);
                redButton.BackColor = Color.DarkRed;

                guessIndex++;
            }
            else { GameOver(); }

            if (guessIndex == Form1.patternList.Count())
            {
                guessIndex = 0;
                ComputerTurn();

            }
        }

        private void yellowButton_Click(object sender, EventArgs e)
        {
            if (Form1.patternList[guessIndex] == 3)
            {
                yellowButton.BackColor = Color.Gold;
                yellowSound.Play();
                Refresh();
                Thread.Sleep(800);
                yellowButton.BackColor = Color.Goldenrod;

                guessIndex++;
            } 
            else { GameOver(); }

            if (guessIndex == Form1.patternList.Count())
            {
                guessIndex = 0;
                ComputerTurn();
            }
        }

        private void blueButton_Click(object sender, EventArgs e)
        {
            if (Form1.patternList[guessIndex] == 4)
            {
                blueButton.BackColor = Color.RoyalBlue;
                blueSound.Play();
                Refresh();
                Thread.Sleep(800);
                blueButton.BackColor = Color.DarkBlue;

                guessIndex++;
            }
            else { GameOver(); }

            if (guessIndex == Form1.patternList.Count())
            {
                guessIndex = 0;
                ComputerTurn();
            }
        }
        #endregion
    }
}
