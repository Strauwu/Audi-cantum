using new_ga_e.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using new_ga_e.Entities;
using new_ga_e.Models;
using System.IO;
using new_ga_e.Controlles;

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
        public void  OnKeyUp(object sender, KeyEventArgs e)
        {
            player.dirX = 0;
            player.dirY = 0;
            player.IsMoving = false;
            player.SetAnimationConfiguration(0);

        }
        public void OnPress(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    player.dirY = -3;
                    player.IsMoving = true;
                    player.SetAnimationConfiguration(2);
                    break;
                case Keys.S:
                    player.dirY = 3;
                    player.IsMoving = true;
                    player.SetAnimationConfiguration(3);
                    break;
                case Keys.A:
                    player.dirX = -3;
                    player.IsMoving = true;
                    //player.flip = 1;
                    player.SetAnimationConfiguration(4);
                    break;
                case Keys.D:
                    player.dirX = 3;
                    player.IsMoving = true;
                    //player.flip = 1;
                    player.SetAnimationConfiguration(5);
                    break;
                case Keys.F:
                    player.dirX = 3;
                    player.IsMoving = false;
                    //player.flip = 1;
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
            player = new Entity(100, 100, Hero.idleFrame, Hero.healFrame,Hero.upFrame,Hero.downFrame,Hero.leftFrame,Hero.rightFrame,playerSheet);
            timer1.Start();
        }

        public void Update(object sender, EventArgs e)
        {
            if (player.IsMoving)
                player.Move();

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
