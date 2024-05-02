using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Culminating
{
    public partial class Game : Form
    {
        bool GameIsSingleplayer = true; //Boolean variable which indicates whether the game is singleplayer or multiplayer
        bool StartGame = false; //Boolean variable which indicates whether the game has began
        bool Paused = false; //Boolean variable which indicates whether the game is paused

        bool[] PlayerAlive = { true, true }; //Array of booleans to store whether player 1 and player 2 are alive

        int[] PlayerGravity = { 1, 1 }; //Array of integers representing the gravity of each player
        int[] PlayerVelocity = { 0, 0 }; //Array of intengers representing the velocity of each player, how fast it ascends

        byte AnimationCounter = 0; 
        int CurrentScore = 0; //Stores the current score of the form
        bool PointsValid = true;

        int Time = 0;
        byte[] ShieldDuration = { 0, 0 };
        byte TimeDuration = 0;
        byte[] PeanutDuration = { 0, 0 };

        PictureBox[] Obstacles = new PictureBox[4]; //Array of pictureboxes, representing obstacles

        enum PowerupType { Shield, Time, Peanut }; //Enumeration, basically a custom type to which its attributes represent integers starting from 0 and incrementing each time
        PowerupType CurrentPowerupType; //Instance of the custom enum type

        bool[] ShieldEnabled = { false, false };
        bool TimeEnabled = false;
        bool[] PeanutEnabled = { false, false };

        Point UOPrev;
        Point LOPrev;
        Point P1Prev;
        Point P2Prev;

        bool DebugMode = false;
        bool Invincibility = false;

        public Game(bool IsSP) //Added an argument to the Game constructor, indicating whether the game is singleplayer or multiplayer
        {
            GameIsSingleplayer = IsSP; //Assigns the game's member to the parameter
            InitializeComponent();

            //Assigns the obstacles to the obstacle array
            Obstacles[0] = picBxUO1; 
            Obstacles[1] = picBxUO2;
            Obstacles[2] = picBxLO1;
            Obstacles[3] = picBxLO2;

            //Copies the initial locations of obstacles so the PLAY AGAIN button can reset all the values
            UOPrev = picBxUO1.Location;
            LOPrev = picBxLO1.Location;
            P1Prev = picBxPlayer1.Location;
            P2Prev = picBxPlayer2.Location;

            if (IsSP) //If singleplayer, change certain attributes to make logical sense
            {
                lblHelp.Text = "Press SPACE to start";
                picBxPlayer2.Visible = false; //Hides second player
                lblP2.Visible = false;
                PlayerAlive[1] = false;
            }
            else
            {
                lblHelp.Text = "Press W or P to start";
            }

            int RandomYCoord = new Random().Next(-picBxUO1.Height / 2, 1); //Creates an instance of the random class and initialize it to a ycoord

            //Hide the powerup item temporarily by moving it offscreen
            picBxPowerup.Location = new Point(0 - picBxPowerup.Width, picBxPowerup.Location.Y);
            //Creates space between two sets of obstacles
            picBxUO2.Location = new Point(picBxUO1.Location.X + (Width / 2), RandomYCoord);
            picBxLO2.Location = new Point(picBxLO1.Location.X + (Width / 2), picBxUO2.Location.Y + picBxUO2.Height + (picBxPlayer1.Height * 4));

            //Creates a highscore save file if it doesn't exist
            if (!File.Exists("HighScore.txt"))
            {
                FileStream fs = File.Create("HighScore.txt");
                //Closes and disposes to free any resources being used, and allow other objects to access the file
                fs.Close(); 
                fs.Dispose();
            }

            //Read from HighScore.txt
            StreamReader sr = new StreamReader("HighScore.txt");

            int HighScore = 0;
            try
            {
                HighScore = int.Parse(sr.ReadLine()); //Reads the first line and assigns it to the highscore variable
            }
            catch
            {
                HighScore = 0;
            }

            lblHighScore.Text = HighScore.ToString(); //Sets the highscore label to the current highscore
            sr.Close(); //Closes the open file
        }

        private void TimerUpdates_Tick(object sender, EventArgs e) //Event which runs every so often, around every 16 milliseconds
        {
            if (StartGame) //Makes sure the game started
            { 
                //Hides certain parts of the interface
                lblHelp.Visible = false;
                lblP1.Visible = false;
                lblP2.Visible = false;

                //Performs checks to increment the current score once the player is within certain bounds
                if ((picBxPlayer1.Location.X >= picBxUO1.Location.X + picBxUO1.Width &&
                    picBxPlayer1.Location.X <= picBxUO1.Location.X + picBxUO1.Width + 10) ||
                    (picBxPlayer1.Location.X >= picBxUO2.Location.X + picBxUO2.Width &&
                    picBxPlayer1.Location.X <= picBxUO2.Location.X + picBxUO2.Width + 10))
                {
                    if (PointsValid)
                    {
                        CurrentScore++;
                        lblCurrentScore.Text = CurrentScore.ToString();
                        PointsValid = false;
                    }
                }
                else if ((picBxPlayer2.Location.X >= picBxUO1.Location.X + picBxUO1.Width &&
                    picBxPlayer2.Location.X <= picBxUO1.Location.X + picBxUO1.Width + 10) ||
                    (picBxPlayer2.Location.X >= picBxUO2.Location.X + picBxUO2.Width &&
                    picBxPlayer2.Location.X <= picBxUO2.Location.X + picBxUO2.Width + 10))
                {
                    if (PointsValid)
                    {
                        CurrentScore++;
                        lblCurrentScore.Text = CurrentScore.ToString();
                        PointsValid = false;
                    }
                }
                else
                {
                    PointsValid = true;
                }

                //If both players are dead, stop the game from proceeding
                if (!PlayerAlive[0] && !PlayerAlive[1])
                {
                    TimerUpdates.Enabled = false;
                    lblGameState.Visible = true;
                    btnPlayAgain.Visible = true;
                    btnPlayAgain.Enabled = true;
                    btnExit.Visible = true;
                    btnExit.Enabled = true;
                    picBxPlayer1.Visible = false;
                    picBxPlayer2.Visible = false;
                    picBxPowerup.Visible = false;
                    TimeEnabled = false;
                    ScoreCheck(); 

                    //Makes certain buttons visible for the user, such as play again or return to menu
                }
                
                //Iterates through the obstacle array and checks whether the players are hitting them
                for (int i = 0; i < Obstacles.Length; i++)
                {
                    if (DoesCollide(picBxPlayer1, Obstacles[i]))
                    {
                        if (ShieldEnabled[0])
                        {
                            P1ShieldTimer.Enabled = true;
                        }
                        else if (PeanutEnabled[0])
                        {
                            PlayerAlive[0] = true;
                        }
                        else
                        {
                            if (!Invincibility)
                            {
                                PlayerAlive[0] = false;
                            }
                        }
                    }

                    //Checks whether the player has a shield, then handles it
                    if (ShieldDuration[0] >= 2)
                    {
                        chkBxShieldItem.Checked = false;
                        ShieldEnabled[0] = false;
                        P1ShieldTimer.Enabled = false;
                        ShieldDuration[0] = 0;
                        Refresh();
                    }
                    //Checks whether the player has invincibility from the peanut, then handles it
                    else if (PeanutDuration[0] >= 7)
                    {
                        chkBxPeanutItem.Checked = false;
                        PeanutEnabled[0] = false;
                        P1PeanutTimer.Enabled = false;
                        PeanutDuration[0] = 0;
                        Refresh();
                    }

                    if (DoesCollide(picBxPlayer2, Obstacles[i]))
                    {
                        if (ShieldEnabled[1])
                        {
                            P2ShieldTimer.Enabled = true;
                        }
                        else if (PeanutEnabled[1])
                        {
                            PlayerAlive[1] = true;
                        }
                        else
                        {
                            if (!Invincibility)
                            {
                                PlayerAlive[1] = false;
                            }
                        }
                    }

                    if (ShieldDuration[1] >= 2)
                    {
                        chkBxShieldItem.Checked = false;
                        ShieldEnabled[1] = false;
                        P2ShieldTimer.Enabled = false;
                        ShieldDuration[1] = 0;
                        Refresh();
                    }
                    else if (PeanutDuration[1] >= 7)
                    {
                        chkBxPeanutItem.Checked = false;
                        PeanutEnabled[1] = false;
                        P2PeanutTimer.Enabled = false;
                        PeanutDuration[1] = 0;
                        Refresh();
                    }

                    //If the players drop beneath the height of the screen, set their alive attribute to false
                    if (picBxPlayer1.Location.Y + picBxPlayer1.Height >= Height)
                    {
                        if (!Invincibility)
                        {
                            PlayerAlive[0] = false;
                        }

                        picBxPlayer1.Location = new Point(picBxPlayer1.Location.X, Height - picBxPlayer1.Height * 3);
                    }

                    if (picBxPlayer2.Location.Y + picBxPlayer2.Height >= Height)
                    {
                        if (!Invincibility)
                        {
                            PlayerAlive[1] = false;
                        }

                        picBxPlayer2.Location = new Point(picBxPlayer2.Location.X, Height - picBxPlayer2.Height * 3);
                    }
                }

                if (picBxPowerup.Visible) //Checks whether a powerup is on screen
                {
                    //If a player collides with the powerup, an attribute will change which affects the gameplay
                    if (DoesCollide(picBxPlayer1, picBxPowerup))
                    {
                        picBxPowerup.Visible = false;
                        
                        if (CurrentPowerupType == PowerupType.Shield)
                        {
                            ShieldEnabled[0] = true;
                            Refresh();
                        }
                        else if (CurrentPowerupType == PowerupType.Time)
                        {
                            TimeEnabled = true;
                            TimeTimer.Enabled = true;
                            Refresh();
                        }
                        else
                        {
                            PeanutEnabled[0] = true;
                            P1PeanutTimer.Enabled = true;
                            Refresh();
                        }
                    }

                    if (DoesCollide(picBxPlayer2, picBxPowerup))
                    {
                        picBxPowerup.Visible = false;

                        if (CurrentPowerupType == PowerupType.Shield)
                        {
                            ShieldEnabled[1] = true;

                            Refresh();
                        }
                        else if (CurrentPowerupType == PowerupType.Time)
                        {
                            TimeEnabled = true;
                            TimeTimer.Enabled = true;
                            Refresh();
                        }
                        else
                        {
                            PeanutEnabled[1] = true;
                            P2PeanutTimer.Enabled = true;
                            Refresh();
                        }
                    }
                }

                if (PlayerAlive[0] || PlayerAlive[1]) //Checks that at least one of the players are alive
                {
                    //If player try to fly higher than the scope of the application, they are restricted
                    if (picBxPlayer1.Location.Y < 0)
                    {
                        picBxPlayer1.Location = new Point(picBxPlayer1.Location.X, 0);
                    }

                    if (picBxPlayer2.Location.Y < 0)
                    {
                        picBxPlayer2.Location = new Point(picBxPlayer2.Location.X, 0);
                    }

                    //The player which is higher than the other is pushed ontop of them
                    if (picBxPlayer1.Location.Y < picBxPlayer2.Location.Y)
                    {
                        picBxPlayer1.BringToFront();
                    }
                    else
                    {
                        picBxPlayer2.BringToFront();
                    }

                    //An animation which relies on an integer called AnimationCounter to set the player's image to a certain frame
                    if (AnimationCounter >= 0 && AnimationCounter < 2)
                    {
                        //Frame 1
                        if (!GameIsSingleplayer)
                        {
                            picBxPlayer2.Image = Image.FromFile("Player2_Up.png");
                        }
                        picBxPlayer1.Image.Dispose();
                        picBxPlayer1.Image = Image.FromFile("Player1_Up.png");
                    }
                    else if (AnimationCounter >= 2 && AnimationCounter < 4)
                    {
                        //Frame 2
                        if (!GameIsSingleplayer)
                        {
                            picBxPlayer2.Image = Image.FromFile("Player2_Middle.png");
                        }
                        picBxPlayer1.Image.Dispose();
                        picBxPlayer1.Image = Image.FromFile("Player1_Middle.png");
                    }
                    else if (AnimationCounter >= 4 && AnimationCounter < 6)
                    {
                        //Frame 3
                        if (!GameIsSingleplayer)
                        {
                            picBxPlayer2.Image = Image.FromFile("Player2_Down.png");
                        }
                        picBxPlayer1.Image.Dispose();
                        picBxPlayer1.Image = Image.FromFile("Player1_Down.png");
                    }
                    else
                    {
                        AnimationCounter = 0;
                    }

                    //If the time powerup is activated, slow down the rate at which the graphics update
                    if (TimeEnabled && TimeDuration <= 7)
                    {
                        TimerUpdates.Interval = 100;
                    }
                    else //Else just keep the settings the same
                    {
                        chkBxTimeItem.Checked = false;
                        TimeEnabled = false;
                        TimerUpdates.Interval = 16;
                        TimeDuration = 0;
                    }

                    //Playermove functions which move the player. Takes a picturebox, its velocity, gravity, and alive attributes as arguments
                    PlayerMove(picBxPlayer1, ref PlayerVelocity[0], ref PlayerGravity[0], ref PlayerAlive[0]);
                    PlayerMove(picBxPlayer2, ref PlayerVelocity[1], ref PlayerGravity[1], ref PlayerAlive[1]);

                    //If an obstacle goes offscreen, set its value to the right-most of the screen
                    if (picBxUO1.Location.X < 0 - picBxUO1.Width)
                    {
                        //uses the random class to create various positioned gaps between the obstacles
                        Random Rand = new Random();
                        int RandomYCoord = Rand.Next(-picBxUO1.Height / 2, 1);

                        picBxUO1.Location = new Point(Width, RandomYCoord);
                        picBxLO1.Location = new Point(Width, picBxUO1.Location.Y + picBxUO1.Height + (picBxPlayer1.Height * 4));

                        //Every 5 points the player scores, a powerup is randomly generated between two obstacles
                        if (CurrentScore % 5 == 0)
                        {
                            int PowerupRandom = new Random().Next(0, 3);
                            picBxPowerup.Visible = true;

                            if (PowerupRandom == 0)
                            {
                                CurrentPowerupType = PowerupType.Shield;
                                picBxPowerup.Image = Image.FromFile("Shield_Powerup.png");
                            }
                            else if (PowerupRandom == 1)
                            {
                                CurrentPowerupType = PowerupType.Time;
                                picBxPowerup.Image = Image.FromFile("Time_Powerup.png");
                            }
                            else
                            {
                                CurrentPowerupType = PowerupType.Peanut;
                                picBxPowerup.Image = Image.FromFile("Peanut_Powerup.png");
                            }
                            
                            picBxPowerup.Location = new Point(picBxLO1.Location.X, picBxLO1.Location.Y - picBxPowerup.Height - 50); 
                            Time = 0;
                        }
                    }
                    else
                    {
                        picBxUO1.Location = new Point(picBxUO1.Location.X - 5, picBxUO1.Location.Y);
                        picBxLO1.Location = new Point(picBxLO1.Location.X - 5, picBxLO1.Location.Y);
                        picBxPowerup.Location = new Point(picBxPowerup.Location.X - 5, picBxPowerup.Location.Y);
                    }

                    //Same is repeated with the second set of obstacles
                    if (picBxUO2.Location.X < 0 - picBxUO2.Width)
                    {
                        Random Rand = new Random();
                        int RandomYCoord = Rand.Next(-picBxUO1.Height / 2, 1);

                        picBxUO2.Location = new Point(Width, RandomYCoord);
                        picBxLO2.Location = new Point(Width, picBxUO2.Location.Y + picBxUO2.Height + (picBxPlayer1.Height * 4));

                        if (CurrentScore % 5 == 0)
                        {
                            int PowerupRandom = new Random().Next(0, 3);
                            picBxPowerup.Visible = true;

                            if (PowerupRandom == 0)
                            {
                                CurrentPowerupType = PowerupType.Shield;
                                picBxPowerup.Image = Image.FromFile("Shield_Powerup.png");
                            }
                            else if (PowerupRandom == 1)
                            {
                                CurrentPowerupType = PowerupType.Time;
                                picBxPowerup.Image = Image.FromFile("Time_Powerup.png");
                            }
                            else
                            {
                                CurrentPowerupType = PowerupType.Peanut;
                                picBxPowerup.Image = Image.FromFile("Peanut_Powerup.png");
                            }

                            picBxPowerup.Location = new Point(picBxLO2.Location.X, picBxLO2.Location.Y - picBxPowerup.Height - 50);
                            Time = 0;
                        }
                    }
                    else
                    {
                        picBxUO2.Location = new Point(picBxUO2.Location.X - 5, picBxUO2.Location.Y);
                        picBxLO2.Location = new Point(picBxLO2.Location.X - 5, picBxLO2.Location.Y);
                    }

                    AnimationCounter++;
                }
            }
        }

        private void Game_KeyUp(object sender, KeyEventArgs e) //When a key is lifted, execute this function
        {
            if (GameIsSingleplayer) //Checks whether the game is singleplayer
            {
                if (!Paused)
                {
                    if (Keys.Space == e.KeyCode) //On space the velocity is set to 10 and the gravity is set to 1
                    {
                        StartGame = true;
                        PlayerVelocity[0] = 10;
                        PlayerGravity[0] = 1;
                    }
                }

                if (StartGame) //Accepts the escape key as well, allowing the user to pause the menu and halt all graphical updates
                {
                    if (Keys.Escape == e.KeyCode)
                    {
                        if (!Paused && StartGame)
                        {
                            Paused = true;
                            TimerUpdates.Enabled = false;
                            lblPaused.Visible = true;
                        }
                        else
                        {
                            lblPaused.Visible = false;
                            Paused = false;
                            TimerUpdates.Enabled = true;
                        }
                    }
                }
            }
            else //If multiplayer, handles input of the W key for player 1 and P for player 2
            {
                if (!Paused)
                {
                    if (Keys.W == e.KeyCode)
                    {
                        StartGame = true;
                        PlayerVelocity[0] = 10;
                        PlayerGravity[0] = 1;
                    }
                    else if (Keys.P == e.KeyCode)
                    {
                        StartGame = true;
                        PlayerVelocity[1] = 10;
                        PlayerGravity[1] = 1;
                    }
                }

                if (StartGame) //Also handles the escape key
                {
                    if (Keys.Escape == e.KeyCode)
                    {
                        if (!Paused && StartGame)
                        {
                            Paused = true;
                            TimerUpdates.Enabled = false;
                            lblPaused.Visible = true;
                        }
                        else
                        {
                            lblPaused.Visible = false;
                            Paused = false;
                            TimerUpdates.Enabled = true;
                        }
                    }
                }
            }
        }

        private bool DoesCollide(PictureBox PicBx1, PictureBox PicBx2) //A function which takes two pictureboxes as arguments and returns true if they collide, else false
        {
            if (((PicBx1.Location.X >= PicBx2.Location.X && PicBx1.Location.X <= PicBx2.Location.X + PicBx2.Width) &&
                (PicBx1.Location.Y >= PicBx2.Location.Y && PicBx1.Location.Y <= PicBx2.Location.Y + PicBx2.Height)) ||
                ((PicBx1.Location.X + PicBx1.Width >= PicBx2.Location.X && PicBx1.Location.X + PicBx1.Width <= PicBx2.Location.X + PicBx2.Width) &&
                (PicBx1.Location.Y  >= PicBx2.Location.Y && PicBx1.Location.Y <= PicBx2.Location.Y + PicBx2.Height)) ||
                ((PicBx1.Location.X >= PicBx2.Location.X && PicBx1.Location.X <= PicBx2.Location.X + PicBx2.Width) &&
                (PicBx1.Location.Y + PicBx1.Height >= PicBx2.Location.Y && PicBx1.Location.Y + PicBx1.Height <= PicBx2.Location.Y + PicBx2.Height)) ||
                ((PicBx1.Location.X + PicBx1.Width >= PicBx2.Location.X && PicBx1.Location.X + PicBx1.Width <= PicBx2.Location.X + PicBx2.Width) &&
                (PicBx1.Location.Y + PicBx1.Height >= PicBx2.Location.Y && PicBx1.Location.Y + PicBx1.Height <= PicBx2.Location.Y + PicBx2.Height)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ScoreCheck() //A function which open the HighScore file and performs certain actions
        {
            StreamReader sr = new StreamReader("HighScore.txt");

            int FileData = 0, Score = 0;
            int.TryParse(sr.ReadLine(), out FileData);
            int.TryParse(lblCurrentScore.Text, out Score);

            if (sr.ReadLine() == "") //If the file is empty, write to the file the current score
            {
                sr.Close();

                StreamWriter sw = new StreamWriter("HighScore.txt");
                sw.WriteLine(lblCurrentScore.Text.ToString());

                sw.Close();
            }
            else if (Score > FileData) //If the current score is higher than whatever's in the file, overwrite the file
            {
                sr.Close();

                StreamWriter sw = new StreamWriter("HighScore.txt");
                sw.WriteLine(lblCurrentScore.Text);

                sw.Close();
            }
            else //Else just close the file
            {
                sr.Close();
            }
        }

        private void btnPlayAgain_Click(object sender, EventArgs e) //If the button play again is pressed, numerous attributes are assigned pre-determined values
        {
            //This resets the player positions, obstacles, hides buttons, labels, etc.
            picBxPowerup.Location = new Point(0 - picBxPowerup.Width, picBxPowerup.Location.Y);

            StartGame = false;
            Paused = false;

            PlayerAlive[0] = true;
            PlayerAlive[1] = true;

            PlayerGravity[0] = 1;
            PlayerVelocity[0] = 0;
            PlayerGravity[1] = 1;
            PlayerVelocity[1] = 0;

            AnimationCounter = 0;
            CurrentScore = 0;
            PointsValid = true;

            Time = 0;
            TimerUpdates.Enabled = true;
            picBxPlayer1.Location = P1Prev;
            picBxPlayer1.Visible = true;
            picBxPlayer2.Location = P2Prev;
            if (!GameIsSingleplayer)
            {
                picBxPlayer2.Visible = true;
                lblP2.Visible = true;
            }
            picBxUO1.Location = UOPrev;
            picBxLO1.Location = LOPrev;
            picBxLO2.Location = LOPrev;
            picBxUO2.Location = UOPrev;
            lblCurrentScore.Text = "0";
            btnExit.Visible = false;
            btnExit.Enabled = false;
            picBxCurrentScore.ResetText();
            lblGameState.Visible = false;
            btnPlayAgain.Visible = false;
            btnPlayAgain.Enabled = false;
            lblHelp.Visible = true;
            lblP1.Visible = true;
            P1ShieldTimer.Enabled = false;
            ShieldDuration[0] = 0;
            ShieldEnabled[0] = false;
            ShieldDuration[1] = 0;
            ShieldEnabled[1] = false;
            TimeTimer.Enabled = false;
            TimeDuration = 0;
            TimeEnabled = false;
            P1PeanutTimer.Enabled = false;
            PeanutDuration[0] = 0;
            PeanutEnabled[0] = false;
            PeanutDuration[1] = 0;
            PeanutEnabled[1] = false;

            int RandomYCoord = new Random().Next(-picBxUO1.Height / 2, 1);

            picBxUO2.Location = new Point(picBxUO1.Location.X + (Width / 2), RandomYCoord);
            picBxLO2.Location = new Point(picBxLO1.Location.X + (Width / 2), picBxUO2.Location.Y + picBxUO2.Height + (picBxPlayer1.Height * 4));

            if (!File.Exists("HighScore.txt"))
            {
                FileStream fs = File.Create("HighScore.txt");
                fs.Close();
                fs.Dispose();
            }

            StreamReader sr = new StreamReader("HighScore.txt");

            int HighScore = 0;
            try
            {
                HighScore = int.Parse(sr.ReadLine());
            }
            catch
            {
                HighScore = 0;
            }

            lblHighScore.Text = HighScore.ToString();
            sr.Close();
        }

        private void btnExit_Click(object sender, EventArgs e) //Event for the exit button on press
        {
            Close(); //Closes the current form, thus returning to the main menu
        }

        private void TimeTimer_Tick(object sender, EventArgs e)
        {
            TimeDuration++; //Increments the duration of the associated timer by 1
        }

        private void P1ShieldTimer_Tick(object sender, EventArgs e)
        {
            ShieldDuration[0]++; //Increments the duration of the associated timer by 1
        }

        private void P1PeanutTimer_Tick(object sender, EventArgs e)
        {
            PeanutDuration[0]++; //Increments the duration of the associated timer by 1
        }

        private void P2ShieldTimer_Tick(object sender, EventArgs e)
        {
            ShieldDuration[1]++; //Increments the duration of the associated timer by 1
        }

        private void P2PeanutTimer_Tick(object sender, EventArgs e) //Event for the PeanutTimer
        {
            PeanutDuration[1]++; //Increments the duration of the associated timer by 1
        }

        private void PlayerMove(PictureBox Player, ref int Velocity, ref int Gravity, ref bool Alive) //Function which moves a picturebox based on certain variables
        {
            //Takes a picture box, a corresponding velocity, gravity, and alive variables.
            //They are passed on reference so the variables at the top of the page can be changed by the function, rather than making a copy
            //Math utilizing variables such as gravity and velocity to create a parabola-type of movement
            if (Alive)
            {
                if (Velocity != 0)
                {
                    Player.Location = new Point(Player.Location.X, Player.Location.Y - Velocity);
                    Velocity--;
                }
                else
                {
                    Player.Location = new Point(Player.Location.X, Player.Location.Y + Gravity);
                    if (Gravity != 7)
                    {
                        Gravity++;
                    }
                }
            }
            else
            {
                Player.Location = new Point(Player.Location.X - 5, Player.Location.Y);
            }
        }

        private void Game_Paint(object sender, PaintEventArgs e) //Paint event to draw certain images
        {
            if (ShieldEnabled[0]) //Draws blue shield around player 1
            {
                e.Graphics.FillEllipse(new SolidBrush(Color.CornflowerBlue), new Rectangle(picBxPlayer1.Location.X, picBxPlayer1.Location.Y, picBxPlayer1.Width, picBxPlayer1.Height));
            }

            if (PeanutEnabled[0]) //Draws purple shield around player 1
            {
                e.Graphics.FillEllipse(new SolidBrush(Color.Purple), new Rectangle(picBxPlayer1.Location.X, picBxPlayer1.Location.Y, picBxPlayer1.Width, picBxPlayer1.Height));
            }

            if (ShieldEnabled[1]) //Draws blue shield around player 2
            {
                e.Graphics.FillEllipse(new SolidBrush(Color.CornflowerBlue), new Rectangle(picBxPlayer2.Location.X, picBxPlayer2.Location.Y, picBxPlayer2.Width, picBxPlayer2.Height));
            }

            if (PeanutEnabled[1]) //Draws purple shield around player 1
            {
                e.Graphics.FillEllipse(new SolidBrush(Color.Purple), new Rectangle(picBxPlayer2.Location.X, picBxPlayer2.Location.Y, picBxPlayer2.Width, picBxPlayer2.Height));
            }
        }

        private void chkBxDebugMode_CheckedChanged(object sender, EventArgs e) //Event on checkbox change for "Debug Mode"
        {
            DebugMode = chkBxDebugMode.Checked;
            ActiveControl = null;

            if (chkBxDebugMode.Checked)
            {
                pnlDebugMode.Visible = true;
            }
            else
            {
                pnlDebugMode.Visible = false;
            }

            //Opens the debug menu using a panel control
        }

        private void chkBxInvincibility_CheckedChanged(object sender, EventArgs e) //Event on checkbox change for "Invincibility"
        {
            Invincibility = chkBxInvincibility.Checked;

            ActiveControl = null;

            //Makes both players invincible until disabled
        }

        private void chkBxShieldItem_CheckedChanged(object sender, EventArgs e) //Event on checkbox change for "Shield item"
        {
            ShieldEnabled[0] = chkBxShieldItem.Checked;
            ShieldEnabled[1] = chkBxShieldItem.Checked;

            ActiveControl = null;

            //Adds the powerup effect of shield to both players
        }

        private void chkBxTimeItem_CheckedChanged(object sender, EventArgs e) //Event on checkbox change for "Time item"
        {
            TimeEnabled = chkBxTimeItem.Checked;
            TimeTimer.Enabled = true;

            ActiveControl = null;

            //Adds the powerup effect of time to both players
        }

        private void chkBxPeanutItem_CheckedChanged(object sender, EventArgs e) //Event on checkbox change for "Peanut item"
        {
            PeanutEnabled[0] = chkBxPeanutItem.Checked;
            PeanutEnabled[1] = chkBxPeanutItem.Checked;
            P1PeanutTimer.Enabled = true;
            P2PeanutTimer.Enabled = true;

            ActiveControl = null; //Sets the focus of the form to null, so it is not focused on any control

            //Adds the powerup effect of peanut to both players
        }

        private void chkBxClearEffects_CheckedChanged(object sender, EventArgs e) //Event on checkbox change for "Clear effects"
        {
            ShieldEnabled[0] = false;
            ShieldEnabled[1] = false;
            TimeEnabled = false;
            PeanutEnabled[0] = false;
            PeanutEnabled[1] = false;

            chkBxShieldItem.Checked = false;
            chkBxTimeItem.Checked = false;
            chkBxPeanutItem.Checked = false;
            chkBxClearEffects.Checked = false;

            ActiveControl = null; //Sets the focus of the form to null, so it is not focused on any control

            //Clears all powerup effects for both players
        }
    }
}
