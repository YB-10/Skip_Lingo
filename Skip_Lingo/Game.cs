using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Net.Http.Headers;
using System.Windows.Forms;

namespace Skip_Lingo
{
    public partial class Game : Form
    {
        int rightEdgeLimit;
        int leftEdgeLimit;
        short playerSpeed = 10;
        short enemySpeed = 7;
        short enemyAmmoSpeed = 15;
        bool edgeReached = true;
        public static int score = 0;
        PictureBox enemyAmmo;
        PictureBox enemy;
        Label lblScore;
        System.Media.SoundPlayer gameSoundTrack;

        public void SpeedSettings(ref short playerspeed, ref short enemyspeed, ref short enemyammospeed)
        {
            playerspeed = 10;
            enemyspeed = 7;
            enemyammospeed = 15;
        }

        public Game()
        {
            InitializeComponent();
        }

        private void Game_Load(object sender, EventArgs e)
        {
            rightEdgeLimit = this.Width - 25;
            leftEdgeLimit = 10;
       
            //**************** CREATION DE L'ENNEMI ***********************
            // choix aléatoire de l'ennemi avec la classe Random à partir d'un tableau
            // une autre solution avec switch case

            Image teachMath = Skip_Lingo.Properties.Resources.profmathh;
            Image teachCpp = Skip_Lingo.Properties.Resources.profcpp;
            Image teachSql = Skip_Lingo.Properties.Resources.profsql;
            Image teachJava = Skip_Lingo.Properties.Resources.profjava; //c'est toi Emile haha
                        

            Image[] arr_teacherImgs = { teachMath, teachCpp, teachSql, teachJava };

            enemy = new PictureBox();
            enemy.BringToFront();
            enemy.Size = new Size(50, 90);
            enemy.Location = new Point(239, 24);
            enemy.SizeMode = PictureBoxSizeMode.Zoom;
            enemy.BackColor = Color.Transparent;

            Random rand = new Random();
            int indexOfTeacherImg = rand.Next(arr_teacherImgs.Length);

            //enemy.Image = arr_teacherImgs[indexOfTeacherImg]; 
            // ça fonctionne bien avec la ligne au-dessus mais
            // pour satisfaire les exigences du projet, je le fais avec le switch case

            switch (indexOfTeacherImg)
            {
                case 0: enemy.Image = arr_teacherImgs[0]; break;
                case 1: enemy.Image = arr_teacherImgs[1]; break;
                case 2: enemy.Image = arr_teacherImgs[2]; break;
                case 3: enemy.Image = arr_teacherImgs[3]; break;
            }

            this.Controls.Add(enemy); // pour l'afficher sur La form


            //************************************* CREATION DU PROJECTILE ********************

            Image ammoPic = Skip_Lingo.Properties.Resources.docpic2;

            enemyAmmo = new PictureBox();
            enemyAmmo.Size = new Size(50, 80);
            enemyAmmo.SizeMode = PictureBoxSizeMode.Zoom;
            enemyAmmo.BackColor = Color.Transparent;
            enemyAmmo.Image = ammoPic;
            enemyAmmo.Location = new Point(enemy.Location.X, enemy.Location.Y + 40);
            this.Controls.Add(enemyAmmo);


            //************ CREATION MANUELLE DU LABEL D'AFFICHAGE DU SCORE *******************
            // Pour pouvoir le setter en arrière-plan, j'ai été obligé de le créer manuellement après
            // la création de l'ennemi sinon c'était impossible.

            lblScore = new Label();
            lblScore.Text = "Skipped Homeworks: ";
            lblScore.Location = new Point(115, 20);
            lblScore.Font = new Font("Comic Sans MS", 10, FontStyle.Bold);
            lblScore.Size = new Size(271, 25);
            lblScore.BackColor = Color.Transparent;
            lblScore.ForeColor = Color.Cyan;
            lblScore.ImageAlign = ContentAlignment.MiddleCenter;
            lblScore.SendToBack();
            this.Controls.Add(lblScore);


            //************ CREATION DE LA BANDE SON *******************
            gameSoundTrack = new System.Media.SoundPlayer(Skip_Lingo.Properties.Resources.Ballblazer_soundtrack);
            gameSoundTrack.Play();
        }

        //***************** MOUVEMENT GAUCHE ET DROIT DU JOUEUR *************
        private void rightMoveTimer_Tick(object sender, EventArgs e)
        {
            if(player.Right < rightEdgeLimit)
            {
                player.Left = player.Left + playerSpeed;
            }
        }

        private void leftMoveTimer_Tick(object sender, EventArgs e)
        {
            if (player.Left > leftEdgeLimit)
            {
                player.Left = player.Left - playerSpeed;
            }
        }

        //***************** DECLENCHEURS DES MOUVEMENTS GAUCHE ET DROIT DU JOUEUR *************
        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Right)
            {
                //rightMoveTimer.Interval = 25;
                rightMoveTimer.Start();
            }

            if(e.KeyCode == Keys.Left)
            {
                //leftMoveTimer.Interval = 25;
                leftMoveTimer.Start();
            }
        }

        private void Game_KeyUp(object sender, KeyEventArgs e)
        {

            rightMoveTimer.Stop();
            leftMoveTimer.Stop();
        }

        //**************************** TO PREVENT FLICKERING ***************
        //Pas de références mais y a beaucoup plus de flickering si je retire la
        // fonction (je ne trouve pas d'explications à cela :o)
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                return handleParam;
            }
        }
        private void teacherMoveTimer_Tick(object sender, EventArgs e)
        {
            //***************** MOUVEMENT GAUCHE ET DROIT DE L'ENNEMI *************
            if (enemy.Left > leftEdgeLimit && edgeReached == true)
            {
                enemy.Left -= enemySpeed;

                if (enemy.Left < leftEdgeLimit)
                {
                    edgeReached = false;
                }
            }
            else
            {
                if (enemy.Right < rightEdgeLimit && edgeReached == false)
                {
                    enemy.Left += enemySpeed;

                    if (enemy.Right > 370)
                    {
                        edgeReached = true;
                    }
                }
            }                    
        }

        private void enemyAmmoTimer_Tick(object sender, EventArgs e)
        {
            //***************** LANCEMENT AUTOMATIQUE D'UN PROJECTILE*************

            if(enemyAmmo.Top < this.Height)
            {
                enemyAmmo.Visible = true;
                enemyAmmo.Top += enemyAmmoSpeed;

                if (enemyAmmo.Bounds.IntersectsWith(player.Bounds) && enemyAmmo.Top < 380)
                {
                    gameSoundTrack.Stop();
                    enemyAmmoTimer.Stop();
                    enemyMoveTimer.Stop();
                    rightMoveTimer.Stop();
                    leftMoveTimer.Stop();
                    playerSpeed = 0;
                    
                    DialogResult youLostMessage = MessageBox.Show($"\tYour Score : {score}\n\n" +
                        $"You lost ! Now, go do your homework !\n\n" +
                        "\tOui: Quit game.\n\tNon: Replay.", "Game Over", MessageBoxButtons.YesNo);                    

                    if (youLostMessage == DialogResult.Yes)
                    {
                        //foreach loop: juste pour satisfaire les exigences du projet
                        foreach (Image img in this.Controls.OfType<Image>())
                        {
                            img.Dispose();
                        }

                        Application.Exit();
                    }
                    else
                    {
                        gameSoundTrack.Play();
                        enemyMoveTimer.Start();
                        SpeedSettings(ref playerSpeed, ref enemySpeed, ref enemyAmmoSpeed);
                        score = -1;                                          
                        enemyAmmoTimer.Start();                        
                    }
                }
            }
            else
            {
                //***************** RELANCE AUTOMATIQUE D'UN PROJECTILE*************
                enemyAmmo.Location = new Point(enemy.Location.X, enemy.Location.Y +40);
                score++ ;
                lblScore.Text = $"Homeworks skipped : {score}";

                if(score % 10 == 0 && score != 0)
                {
                    enemySpeed += 2;
                    enemyAmmoSpeed += 2;
                }
            }
        }
    }
}

// *********************************** REFERENCES ************************************
// https://www.youtube.com/watch?v=sCmybR1e_Vo
// https://www.youtube.com/watch?v=XOJErrCyt5A&list=PL-K0viiuJ2ReKWkb2-zWT2Fb3QXALsed3&index=1
// https://stackoverflow.com/questions/2407534/c-accessing-image-added-to-project-folder
// https://stackoverflow.com/questions/4125698/how-to-play-wav-audio-file-from-resources