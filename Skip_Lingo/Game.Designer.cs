namespace Skip_Lingo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game));
            this.player = new System.Windows.Forms.PictureBox();
            this.leftMoveTimer = new System.Windows.Forms.Timer(this.components);
            this.rightMoveTimer = new System.Windows.Forms.Timer(this.components);
            this.enemyMoveTimer = new System.Windows.Forms.Timer(this.components);
            this.enemyAmmoTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            this.SuspendLayout();
            // 
            // player
            // 
            this.player.BackColor = System.Drawing.Color.Transparent;
            this.player.Image = ((System.Drawing.Image)(resources.GetObject("player.Image")));
            this.player.InitialImage = null;
            this.player.Location = new System.Drawing.Point(228, 691);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(76, 76);
            this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.player.TabIndex = 0;
            this.player.TabStop = false;
            // 
            // leftMoveTimer
            // 
            this.leftMoveTimer.Interval = 5;
            this.leftMoveTimer.Tick += new System.EventHandler(this.leftMoveTimer_Tick);
            // 
            // rightMoveTimer
            // 
            this.rightMoveTimer.Interval = 5;
            this.rightMoveTimer.Tick += new System.EventHandler(this.rightMoveTimer_Tick);
            // 
            // enemyMoveTimer
            // 
            this.enemyMoveTimer.Enabled = true;
            this.enemyMoveTimer.Interval = 20;
            this.enemyMoveTimer.Tick += new System.EventHandler(this.teacherMoveTimer_Tick);
            // 
            // enemyAmmoTimer
            // 
            this.enemyAmmoTimer.Enabled = true;
            this.enemyAmmoTimer.Interval = 20;
            this.enemyAmmoTimer.Tick += new System.EventHandler(this.enemyAmmoTimer_Tick);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(568, 779);
            this.Controls.Add(this.player);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(590, 835);
            this.MinimumSize = new System.Drawing.Size(590, 835);
            this.Name = "Game";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Skip Work";
            this.Load += new System.EventHandler(this.Game_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Game_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Game_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.Timer leftMoveTimer;
        private System.Windows.Forms.Timer rightMoveTimer;
        private System.Windows.Forms.Timer enemyMoveTimer;
        private System.Windows.Forms.Timer enemyAmmoTimer;
    }
}

