namespace Culminating
{
    partial class Game
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TimerUpdates = new System.Windows.Forms.Timer(this.components);
            this.picBxPlayer1 = new System.Windows.Forms.PictureBox();
            this.picBxPlayer2 = new System.Windows.Forms.PictureBox();
            this.picBxUO1 = new System.Windows.Forms.PictureBox();
            this.picBxLO1 = new System.Windows.Forms.PictureBox();
            this.picBxLO2 = new System.Windows.Forms.PictureBox();
            this.picBxUO2 = new System.Windows.Forms.PictureBox();
            this.lblCurrentScore = new System.Windows.Forms.Label();
            this.lblHighScore = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.picBxCurrentScore = new System.Windows.Forms.PictureBox();
            this.lblPaused = new System.Windows.Forms.Label();
            this.picBxHighScore = new System.Windows.Forms.PictureBox();
            this.lblGameState = new System.Windows.Forms.Label();
            this.btnPlayAgain = new System.Windows.Forms.Button();
            this.lblHelp = new System.Windows.Forms.Label();
            this.picBxPowerup = new System.Windows.Forms.PictureBox();
            this.P1ShieldTimer = new System.Windows.Forms.Timer(this.components);
            this.TimeTimer = new System.Windows.Forms.Timer(this.components);
            this.P1PeanutTimer = new System.Windows.Forms.Timer(this.components);
            this.lblP1 = new System.Windows.Forms.Label();
            this.lblP2 = new System.Windows.Forms.Label();
            this.chkBxDebugMode = new System.Windows.Forms.CheckBox();
            this.pnlDebugMode = new System.Windows.Forms.Panel();
            this.chkBxClearEffects = new System.Windows.Forms.CheckBox();
            this.chkBxPeanutItem = new System.Windows.Forms.CheckBox();
            this.chkBxTimeItem = new System.Windows.Forms.CheckBox();
            this.chkBxShieldItem = new System.Windows.Forms.CheckBox();
            this.chkBxInvincibility = new System.Windows.Forms.CheckBox();
            this.P2ShieldTimer = new System.Windows.Forms.Timer(this.components);
            this.P2PeanutTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picBxPlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBxPlayer2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBxUO1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBxLO1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBxLO2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBxUO2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBxCurrentScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBxHighScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBxPowerup)).BeginInit();
            this.pnlDebugMode.SuspendLayout();
            this.SuspendLayout();
            // 
            // TimerUpdates
            // 
            this.TimerUpdates.Enabled = true;
            this.TimerUpdates.Interval = 16;
            this.TimerUpdates.Tick += new System.EventHandler(this.TimerUpdates_Tick);
            // 
            // picBxPlayer1
            // 
            this.picBxPlayer1.BackColor = System.Drawing.Color.Transparent;
            this.picBxPlayer1.Image = global::Culminating.Properties.Resources.Player1_Up;
            this.picBxPlayer1.Location = new System.Drawing.Point(86, 190);
            this.picBxPlayer1.Name = "picBxPlayer1";
            this.picBxPlayer1.Size = new System.Drawing.Size(62, 38);
            this.picBxPlayer1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBxPlayer1.TabIndex = 0;
            this.picBxPlayer1.TabStop = false;
            // 
            // picBxPlayer2
            // 
            this.picBxPlayer2.BackColor = System.Drawing.Color.Transparent;
            this.picBxPlayer2.Image = global::Culminating.Properties.Resources.Player2_Up;
            this.picBxPlayer2.Location = new System.Drawing.Point(86, 234);
            this.picBxPlayer2.Name = "picBxPlayer2";
            this.picBxPlayer2.Size = new System.Drawing.Size(62, 38);
            this.picBxPlayer2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBxPlayer2.TabIndex = 1;
            this.picBxPlayer2.TabStop = false;
            // 
            // picBxUO1
            // 
            this.picBxUO1.BackColor = System.Drawing.Color.White;
            this.picBxUO1.Image = global::Culminating.Properties.Resources.Obstacle;
            this.picBxUO1.Location = new System.Drawing.Point(560, -44);
            this.picBxUO1.Name = "picBxUO1";
            this.picBxUO1.Size = new System.Drawing.Size(100, 244);
            this.picBxUO1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBxUO1.TabIndex = 2;
            this.picBxUO1.TabStop = false;
            // 
            // picBxLO1
            // 
            this.picBxLO1.BackColor = System.Drawing.Color.White;
            this.picBxLO1.Image = global::Culminating.Properties.Resources.Obstacle;
            this.picBxLO1.Location = new System.Drawing.Point(560, 351);
            this.picBxLO1.Name = "picBxLO1";
            this.picBxLO1.Size = new System.Drawing.Size(100, 244);
            this.picBxLO1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBxLO1.TabIndex = 3;
            this.picBxLO1.TabStop = false;
            // 
            // picBxLO2
            // 
            this.picBxLO2.BackColor = System.Drawing.Color.White;
            this.picBxLO2.Image = global::Culminating.Properties.Resources.Obstacle;
            this.picBxLO2.Location = new System.Drawing.Point(560, 351);
            this.picBxLO2.Name = "picBxLO2";
            this.picBxLO2.Size = new System.Drawing.Size(100, 244);
            this.picBxLO2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBxLO2.TabIndex = 5;
            this.picBxLO2.TabStop = false;
            // 
            // picBxUO2
            // 
            this.picBxUO2.BackColor = System.Drawing.Color.White;
            this.picBxUO2.Image = global::Culminating.Properties.Resources.Obstacle;
            this.picBxUO2.Location = new System.Drawing.Point(560, -44);
            this.picBxUO2.Name = "picBxUO2";
            this.picBxUO2.Size = new System.Drawing.Size(100, 244);
            this.picBxUO2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBxUO2.TabIndex = 4;
            this.picBxUO2.TabStop = false;
            // 
            // lblCurrentScore
            // 
            this.lblCurrentScore.AutoSize = true;
            this.lblCurrentScore.BackColor = System.Drawing.SystemColors.Control;
            this.lblCurrentScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentScore.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblCurrentScore.Image = global::Culminating.Properties.Resources.GenericLabel;
            this.lblCurrentScore.Location = new System.Drawing.Point(44, 9);
            this.lblCurrentScore.Name = "lblCurrentScore";
            this.lblCurrentScore.Size = new System.Drawing.Size(32, 32);
            this.lblCurrentScore.TabIndex = 6;
            this.lblCurrentScore.Text = "0";
            this.lblCurrentScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHighScore
            // 
            this.lblHighScore.AutoSize = true;
            this.lblHighScore.BackColor = System.Drawing.SystemColors.Control;
            this.lblHighScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHighScore.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblHighScore.Image = global::Culminating.Properties.Resources.GenericLabel;
            this.lblHighScore.Location = new System.Drawing.Point(153, 9);
            this.lblHighScore.Name = "lblHighScore";
            this.lblHighScore.Size = new System.Drawing.Size(32, 32);
            this.lblHighScore.TabIndex = 7;
            this.lblHighScore.Text = "0";
            this.lblHighScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImage = global::Culminating.Properties.Resources.GenericLabel;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.Enabled = false;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.SystemColors.Control;
            this.btnExit.Location = new System.Drawing.Point(354, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(94, 55);
            this.btnExit.TabIndex = 10;
            this.btnExit.TabStop = false;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Visible = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // picBxCurrentScore
            // 
            this.picBxCurrentScore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(116)))), ((int)(((byte)(27)))));
            this.picBxCurrentScore.Image = global::Culminating.Properties.Resources.Obstacle;
            this.picBxCurrentScore.Location = new System.Drawing.Point(12, 9);
            this.picBxCurrentScore.Name = "picBxCurrentScore";
            this.picBxCurrentScore.Size = new System.Drawing.Size(32, 32);
            this.picBxCurrentScore.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBxCurrentScore.TabIndex = 11;
            this.picBxCurrentScore.TabStop = false;
            // 
            // lblPaused
            // 
            this.lblPaused.AutoSize = true;
            this.lblPaused.BackColor = System.Drawing.SystemColors.Control;
            this.lblPaused.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaused.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblPaused.Image = global::Culminating.Properties.Resources.GenericLabel;
            this.lblPaused.Location = new System.Drawing.Point(254, 216);
            this.lblPaused.Name = "lblPaused";
            this.lblPaused.Size = new System.Drawing.Size(137, 32);
            this.lblPaused.TabIndex = 12;
            this.lblPaused.Text = "PAUSED";
            this.lblPaused.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPaused.Visible = false;
            // 
            // picBxHighScore
            // 
            this.picBxHighScore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(116)))), ((int)(((byte)(27)))));
            this.picBxHighScore.Image = global::Culminating.Properties.Resources.Trophy;
            this.picBxHighScore.Location = new System.Drawing.Point(121, 9);
            this.picBxHighScore.Name = "picBxHighScore";
            this.picBxHighScore.Size = new System.Drawing.Size(32, 32);
            this.picBxHighScore.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBxHighScore.TabIndex = 13;
            this.picBxHighScore.TabStop = false;
            // 
            // lblGameState
            // 
            this.lblGameState.AutoSize = true;
            this.lblGameState.BackColor = System.Drawing.SystemColors.Control;
            this.lblGameState.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameState.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblGameState.Image = global::Culminating.Properties.Resources.GenericLabel;
            this.lblGameState.Location = new System.Drawing.Point(228, 216);
            this.lblGameState.Name = "lblGameState";
            this.lblGameState.Size = new System.Drawing.Size(194, 32);
            this.lblGameState.TabIndex = 14;
            this.lblGameState.Text = "GAME OVER";
            this.lblGameState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblGameState.Visible = false;
            // 
            // btnPlayAgain
            // 
            this.btnPlayAgain.BackgroundImage = global::Culminating.Properties.Resources.GenericLabel;
            this.btnPlayAgain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPlayAgain.Enabled = false;
            this.btnPlayAgain.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlayAgain.ForeColor = System.Drawing.SystemColors.Control;
            this.btnPlayAgain.Location = new System.Drawing.Point(454, 12);
            this.btnPlayAgain.Name = "btnPlayAgain";
            this.btnPlayAgain.Size = new System.Drawing.Size(186, 55);
            this.btnPlayAgain.TabIndex = 15;
            this.btnPlayAgain.TabStop = false;
            this.btnPlayAgain.Text = "Play Again";
            this.btnPlayAgain.UseVisualStyleBackColor = true;
            this.btnPlayAgain.Visible = false;
            this.btnPlayAgain.Click += new System.EventHandler(this.btnPlayAgain_Click);
            // 
            // lblHelp
            // 
            this.lblHelp.AutoSize = true;
            this.lblHelp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(116)))), ((int)(((byte)(27)))));
            this.lblHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHelp.ForeColor = System.Drawing.SystemColors.Control;
            this.lblHelp.Location = new System.Drawing.Point(12, 9);
            this.lblHelp.Name = "lblHelp";
            this.lblHelp.Size = new System.Drawing.Size(385, 32);
            this.lblHelp.TabIndex = 16;
            this.lblHelp.Text = "Press the ascend key to start.";
            // 
            // picBxPowerup
            // 
            this.picBxPowerup.BackColor = System.Drawing.Color.Transparent;
            this.picBxPowerup.Image = global::Culminating.Properties.Resources.Shield_Powerup;
            this.picBxPowerup.Location = new System.Drawing.Point(588, 252);
            this.picBxPowerup.Name = "picBxPowerup";
            this.picBxPowerup.Size = new System.Drawing.Size(38, 38);
            this.picBxPowerup.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBxPowerup.TabIndex = 17;
            this.picBxPowerup.TabStop = false;
            // 
            // P1ShieldTimer
            // 
            this.P1ShieldTimer.Interval = 1000;
            this.P1ShieldTimer.Tick += new System.EventHandler(this.P1ShieldTimer_Tick);
            // 
            // TimeTimer
            // 
            this.TimeTimer.Enabled = true;
            this.TimeTimer.Interval = 1000;
            this.TimeTimer.Tick += new System.EventHandler(this.TimeTimer_Tick);
            // 
            // P1PeanutTimer
            // 
            this.P1PeanutTimer.Enabled = true;
            this.P1PeanutTimer.Interval = 1000;
            this.P1PeanutTimer.Tick += new System.EventHandler(this.P1PeanutTimer_Tick);
            // 
            // lblP1
            // 
            this.lblP1.AutoSize = true;
            this.lblP1.BackColor = System.Drawing.Color.Transparent;
            this.lblP1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblP1.ForeColor = System.Drawing.Color.Blue;
            this.lblP1.Location = new System.Drawing.Point(45, 190);
            this.lblP1.Name = "lblP1";
            this.lblP1.Size = new System.Drawing.Size(38, 25);
            this.lblP1.TabIndex = 18;
            this.lblP1.Text = "P1";
            // 
            // lblP2
            // 
            this.lblP2.AutoSize = true;
            this.lblP2.BackColor = System.Drawing.Color.Transparent;
            this.lblP2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblP2.ForeColor = System.Drawing.Color.Red;
            this.lblP2.Location = new System.Drawing.Point(45, 234);
            this.lblP2.Name = "lblP2";
            this.lblP2.Size = new System.Drawing.Size(38, 25);
            this.lblP2.TabIndex = 19;
            this.lblP2.Text = "P2";
            // 
            // chkBxDebugMode
            // 
            this.chkBxDebugMode.AutoSize = true;
            this.chkBxDebugMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(116)))), ((int)(((byte)(27)))));
            this.chkBxDebugMode.Location = new System.Drawing.Point(12, 417);
            this.chkBxDebugMode.Name = "chkBxDebugMode";
            this.chkBxDebugMode.Size = new System.Drawing.Size(111, 21);
            this.chkBxDebugMode.TabIndex = 20;
            this.chkBxDebugMode.TabStop = false;
            this.chkBxDebugMode.Text = "Debug Mode";
            this.chkBxDebugMode.UseVisualStyleBackColor = false;
            this.chkBxDebugMode.CheckedChanged += new System.EventHandler(this.chkBxDebugMode_CheckedChanged);
            // 
            // pnlDebugMode
            // 
            this.pnlDebugMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(116)))), ((int)(((byte)(27)))));
            this.pnlDebugMode.Controls.Add(this.chkBxClearEffects);
            this.pnlDebugMode.Controls.Add(this.chkBxPeanutItem);
            this.pnlDebugMode.Controls.Add(this.chkBxTimeItem);
            this.pnlDebugMode.Controls.Add(this.chkBxShieldItem);
            this.pnlDebugMode.Controls.Add(this.chkBxInvincibility);
            this.pnlDebugMode.Location = new System.Drawing.Point(121, 417);
            this.pnlDebugMode.Name = "pnlDebugMode";
            this.pnlDebugMode.Size = new System.Drawing.Size(490, 21);
            this.pnlDebugMode.TabIndex = 21;
            this.pnlDebugMode.Visible = false;
            // 
            // chkBxClearEffects
            // 
            this.chkBxClearEffects.AutoSize = true;
            this.chkBxClearEffects.Location = new System.Drawing.Point(378, 0);
            this.chkBxClearEffects.Name = "chkBxClearEffects";
            this.chkBxClearEffects.Size = new System.Drawing.Size(110, 21);
            this.chkBxClearEffects.TabIndex = 4;
            this.chkBxClearEffects.TabStop = false;
            this.chkBxClearEffects.Text = "Clear Effects";
            this.chkBxClearEffects.UseVisualStyleBackColor = true;
            this.chkBxClearEffects.CheckedChanged += new System.EventHandler(this.chkBxClearEffects_CheckedChanged);
            // 
            // chkBxPeanutItem
            // 
            this.chkBxPeanutItem.AutoSize = true;
            this.chkBxPeanutItem.Location = new System.Drawing.Point(276, 0);
            this.chkBxPeanutItem.Name = "chkBxPeanutItem";
            this.chkBxPeanutItem.Size = new System.Drawing.Size(97, 21);
            this.chkBxPeanutItem.TabIndex = 3;
            this.chkBxPeanutItem.TabStop = false;
            this.chkBxPeanutItem.Text = "Invincibility";
            this.chkBxPeanutItem.UseVisualStyleBackColor = true;
            this.chkBxPeanutItem.CheckedChanged += new System.EventHandler(this.chkBxPeanutItem_CheckedChanged);
            // 
            // chkBxTimeItem
            // 
            this.chkBxTimeItem.AutoSize = true;
            this.chkBxTimeItem.Location = new System.Drawing.Point(189, 0);
            this.chkBxTimeItem.Name = "chkBxTimeItem";
            this.chkBxTimeItem.Size = new System.Drawing.Size(92, 21);
            this.chkBxTimeItem.TabIndex = 2;
            this.chkBxTimeItem.TabStop = false;
            this.chkBxTimeItem.Text = "Slowdown";
            this.chkBxTimeItem.UseVisualStyleBackColor = true;
            this.chkBxTimeItem.CheckedChanged += new System.EventHandler(this.chkBxTimeItem_CheckedChanged);
            // 
            // chkBxShieldItem
            // 
            this.chkBxShieldItem.AutoSize = true;
            this.chkBxShieldItem.Location = new System.Drawing.Point(93, 0);
            this.chkBxShieldItem.Name = "chkBxShieldItem";
            this.chkBxShieldItem.Size = new System.Drawing.Size(99, 21);
            this.chkBxShieldItem.TabIndex = 1;
            this.chkBxShieldItem.TabStop = false;
            this.chkBxShieldItem.Text = "Shield Item";
            this.chkBxShieldItem.UseVisualStyleBackColor = true;
            this.chkBxShieldItem.CheckedChanged += new System.EventHandler(this.chkBxShieldItem_CheckedChanged);
            // 
            // chkBxInvincibility
            // 
            this.chkBxInvincibility.AutoSize = true;
            this.chkBxInvincibility.Location = new System.Drawing.Point(0, 0);
            this.chkBxInvincibility.Name = "chkBxInvincibility";
            this.chkBxInvincibility.Size = new System.Drawing.Size(92, 21);
            this.chkBxInvincibility.TabIndex = 0;
            this.chkBxInvincibility.TabStop = false;
            this.chkBxInvincibility.Text = "Godmode";
            this.chkBxInvincibility.UseVisualStyleBackColor = true;
            this.chkBxInvincibility.CheckedChanged += new System.EventHandler(this.chkBxInvincibility_CheckedChanged);
            // 
            // P2ShieldTimer
            // 
            this.P2ShieldTimer.Enabled = true;
            this.P2ShieldTimer.Interval = 1000;
            this.P2ShieldTimer.Tick += new System.EventHandler(this.P2ShieldTimer_Tick);
            // 
            // P2PeanutTimer
            // 
            this.P2PeanutTimer.Enabled = true;
            this.P2PeanutTimer.Interval = 1000;
            this.P2PeanutTimer.Tick += new System.EventHandler(this.P2PeanutTimer_Tick);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Culminating.Properties.Resources.Game_Background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(652, 450);
            this.Controls.Add(this.pnlDebugMode);
            this.Controls.Add(this.chkBxDebugMode);
            this.Controls.Add(this.lblP2);
            this.Controls.Add(this.lblP1);
            this.Controls.Add(this.picBxPowerup);
            this.Controls.Add(this.lblHelp);
            this.Controls.Add(this.btnPlayAgain);
            this.Controls.Add(this.lblGameState);
            this.Controls.Add(this.picBxHighScore);
            this.Controls.Add(this.lblPaused);
            this.Controls.Add(this.picBxCurrentScore);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblHighScore);
            this.Controls.Add(this.lblCurrentScore);
            this.Controls.Add(this.picBxLO2);
            this.Controls.Add(this.picBxUO2);
            this.Controls.Add(this.picBxLO1);
            this.Controls.Add(this.picBxUO1);
            this.Controls.Add(this.picBxPlayer2);
            this.Controls.Add(this.picBxPlayer1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Game";
            this.Text = "Deez Flapz";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Game_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Game_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.picBxPlayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBxPlayer2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBxUO1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBxLO1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBxLO2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBxUO2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBxCurrentScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBxHighScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBxPowerup)).EndInit();
            this.pnlDebugMode.ResumeLayout(false);
            this.pnlDebugMode.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer TimerUpdates;
        private System.Windows.Forms.PictureBox picBxPlayer1;
        private System.Windows.Forms.PictureBox picBxPlayer2;
        private System.Windows.Forms.PictureBox picBxUO1;
        private System.Windows.Forms.PictureBox picBxLO1;
        private System.Windows.Forms.PictureBox picBxLO2;
        private System.Windows.Forms.PictureBox picBxUO2;
        private System.Windows.Forms.Label lblCurrentScore;
        private System.Windows.Forms.Label lblHighScore;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.PictureBox picBxCurrentScore;
        private System.Windows.Forms.Label lblPaused;
        private System.Windows.Forms.PictureBox picBxHighScore;
        private System.Windows.Forms.Label lblGameState;
        private System.Windows.Forms.Button btnPlayAgain;
        private System.Windows.Forms.Label lblHelp;
        private System.Windows.Forms.PictureBox picBxPowerup;
        private System.Windows.Forms.Timer P1ShieldTimer;
        private System.Windows.Forms.Timer TimeTimer;
        private System.Windows.Forms.Timer P1PeanutTimer;
        private System.Windows.Forms.Label lblP1;
        private System.Windows.Forms.Label lblP2;
        private System.Windows.Forms.CheckBox chkBxDebugMode;
        private System.Windows.Forms.Panel pnlDebugMode;
        private System.Windows.Forms.CheckBox chkBxInvincibility;
        private System.Windows.Forms.CheckBox chkBxShieldItem;
        private System.Windows.Forms.CheckBox chkBxClearEffects;
        private System.Windows.Forms.CheckBox chkBxPeanutItem;
        private System.Windows.Forms.CheckBox chkBxTimeItem;
        private System.Windows.Forms.Timer P2ShieldTimer;
        private System.Windows.Forms.Timer P2PeanutTimer;
    }
}