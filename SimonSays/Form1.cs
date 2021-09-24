﻿
/*Julia Dowson
 * ICS4U Mr. T
 * Sept. 22, 2021
 * This is a basic, one player game, based off the original Simon game."
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Media;
using System.Drawing.Drawing2D;


namespace SimonSays
{
    public partial class Form1 : Form
    {
        //creates a list for the colour pattern
        public static List<int> patternList = new List<int>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //opens the menu screen and centres it
            MenuScreen menuScreen = new MenuScreen();
            this.Controls.Add(menuScreen);
            menuScreen.Location = new Point((this.Width - menuScreen.Width) / 2, (this.Height - menuScreen.Height) / 2);
        }
    }
}
