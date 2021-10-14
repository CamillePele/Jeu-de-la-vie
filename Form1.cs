using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JeuDeLaVieGraph
{
    public partial class Le_jeu_de_la_vie : Form
    {

        private Game game;
        public int n;


        public Le_jeu_de_la_vie()
        {
            InitializeComponent(50, 5);
            n = 40;
            game = new Game(n, 5);

            Timer MyTimer = new Timer();
            MyTimer.Interval = (100);
            MyTimer.Tick += new EventHandler(MyTimer_Tick);
            MyTimer.Start();

            this.pictureBox1.Paint += new PaintEventHandler(pictureBox1_Paint);
        }

        private void MyTimer_Tick(object sender, EventArgs e) { 
            game.grid.UpdateGrid();
            Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            game.Paint(e.Graphics);
        }

        private void Le_jeu_de_la_vie_Load(object sender, EventArgs e)
        {

        }
    }
}
