using System;
using System.Windows.Forms;

namespace Skip_Lingo
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Game gameWindow = new Game();
            gameWindow.ShowDialog();
            this.Close();
        }
    }
}
