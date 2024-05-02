using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Culminating
{
    public partial class MainMenu : Form
    {
        public MainMenu() 
        {
            InitializeComponent(); 
        }

        private void btnQuit_Click(object sender, EventArgs e) //Event called whenever the quit button is pressed
        {
            Close(); //Closes the program
        }

        private void btnSP_Click(object sender, EventArgs e) //Event called whenever the singleplayer button is pressed
        {
            Hide(); //Hides this current menu form
            Game NewGame = new Game(true); //Creates a new instance of the form "Game" (Takes the parameter true, indicating the game is singleplayer)
            NewGame.ShowDialog(); //Method which renders the new form, aka the actual playable game
            Show(); //Once the game form is closed, the menu form can be reshown using this method
        }

        private void btnMP_Click(object sender, EventArgs e) //Event called whenever the multiplayer button is pressed
        {
            Hide(); //Hides this current menu form
            Game NewGame = new Game(false); //Creates a new instance of the form "Game" (Takes the parameter false, indicating the game is multiplayer)
            NewGame.ShowDialog(); //Method which renders the new form, aka the actual playable game
            Show(); //Once the game form is closed, the menu form can be reshown using this method
        }
    }
}
