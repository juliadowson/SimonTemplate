using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.IO;

namespace SimonSays
{
    public partial class MenuScreen : UserControl
    {
        System.Windows.Media.MediaPlayer backMusic = new System.Windows.Media.MediaPlayer();

        public MenuScreen()
        {
            InitializeComponent();
            backMusic.Open(new Uri(Application.StartupPath + "/Resources/backMusic.wav"));
            backMusic.MediaEnded += new EventHandler(backMusic_MediaEnded);      
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            backMusic.Stop();

            //opens the GameScreen to begin playing 
            Form f = this.FindForm();
            f.Controls.Remove(this);
            GameScreen gs = new GameScreen();
            f.Controls.Add(gs);
            gs.Location = new Point((f.Width - gs.Width) / 2, (f.Height - gs.Height) / 2);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            //closes the program 
            Application.Exit();
        }

        private void backMusic_MediaEnded(object sender, EventArgs e)
        {
            backMusic.Stop();
            backMusic.Play();
        }

        private void MenuScreen_Load(object sender, EventArgs e)
        {
            //plays background music 
            backMusic.Play();
        }
    }
}
