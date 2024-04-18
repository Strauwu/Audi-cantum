using new_ga_e.Controlles;
using new_ga_e.Entities;
using new_ga_e.Models;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace new_ga_e
{
    public partial class Form1 : Form
    {

        public Image playerSheet;
        public Entity player;
        public Form1()
        {
            InitializeComponent();

            timer1.Interval = 20;
            timer1.Tick += new EventHandler(Update);

            KeyDown += new KeyEventHandler(OnPress);
            KeyUp += new KeyEventHandler(OnKeyUp);

            Init();
        }
        public void OnKeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    player.dirY = 0;
                    break;
                case Keys.S:
                    player.dirY = 0;
                    break;
                case Keys.A:
                    player.dirX = 0;
                    break;
                case Keys.D:
                    player.dirX = 0;
                    break;
                case Keys.F:
                    player.dirY = 0;
                    player.dirX = 0;
                    break;
            }
            if (player.dirX == 0 && player.dirY == 0)
            {
                player.IsMoving = false;
                player.SetAnimationConfiguration(0);
            }
        }
        public void OnPress(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    player.dirY = -1;
                    player.IsMoving = true;
                    player.SetAnimationConfiguration(2);
                    break;
                case Keys.S:
                    player.dirY = 1;
                    player.IsMoving = true;
                    player.SetAnimationConfiguration(3);
                    break;
                case Keys.A:
                    player.dirX = -1;
                    player.IsMoving = true;
                    player.SetAnimationConfiguration(4);
                    break;
                case Keys.D:
                    player.dirX = 1;
                    player.IsMoving = true;
                    player.SetAnimationConfiguration(5);
                    break;
                case Keys.F:
                    player.dirX = 1;
                    player.IsMoving = false;
                    player.SetAnimationConfiguration(1);
                    break;
            }

        }

        public void Init()
        {
            MapController.Init();
            this.Width = MapController.GetWidth();
            this.Height = MapController.GetHeight();
            playerSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "sprites\\gero.png"));
            player = new Entity(100, 100, Hero.idleFrame, Hero.healFrame, Hero.upFrame, Hero.downFrame, Hero.leftFrame, Hero.rightFrame, playerSheet);
            timer1.Start();
        }

        public void Update(object sender, EventArgs e)
        {
            //PhysicsController.IsCollide(player);
            if (!PhysicsController.IsCollide(player, new Point(player.dirX, player.dirY)))
            {
                if (player.IsMoving)
                    player.Move();
            }
            Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            MapController.DrawMap(g);
            player.PlayAnimation(g);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }
    }
}
