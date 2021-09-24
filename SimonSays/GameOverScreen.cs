using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimonSays
{
    public partial class GameOverScreen : UserControl
    {
        System.Windows.Media.MediaPlayer gameoverMusic = new System.Windows.Media.MediaPlayer(); 

        public GameOverScreen()
        {
            InitializeComponent();
            gameoverMusic.Open(new Uri(Application.StartupPath + "/Resources/gameoverMusic.wav"));
            gameoverMusic.MediaEnded += new EventHandler(gameoverMusic_MediaEnded); 
             
        }

        private void GameOverScreen_Load(object sender, EventArgs e) 
        {
            //plays background music
            gameoverMusic.Play();

            //reads how long the pattern lasted
            lengthLabel.Text = $"{Form1.patternList.Count()}";
        }

        private void gameoverMusic_MediaEnded(object sender, EventArgs e)

        {
            gameoverMusic.Stop();
            gameoverMusic.Play();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            gameoverMusic.Stop();

            //opens the menu screen to play new game
            Form f = this.FindForm();
            f.Controls.Remove(this);

            MenuScreen menuScreen = new MenuScreen();
            f.Controls.Add(menuScreen);
            menuScreen.Location = new Point((this.Width - menuScreen.Width) / 2, (this.Height - menuScreen.Height) / 2);
        }
    }
}
